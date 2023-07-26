using Common.Key;
using Common.Log;
using Common.SaveData;
using mzmr.Data;
using mzmr.Items;
using mzmr.Utility;
using Randomizer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using Verifier;
using Verifier.ItemRules;
using Verifier.Key;

namespace mzmr.Randomizers
{
    public class RandomItems : RandomAspect
    {
        // data for making assignments
        private int numItemsRemoved;
        private Location[] locations;
        private NodeTraverser traverser;

        // data for writing assignments
        private Dictionary<ItemType, int> abilityOffsets;
        private Dictionary<int, byte> roomTilesets;
        private byte nextTilesetNum;

        public RandomItems(Rom rom, Settings settings, Random rng) : base(rom, settings, rng)
        {
            int noneCount = 0;
            foreach (ItemType item in settings.CustomAssignments.Values)
            {
                if (item == ItemType.None)
                    noneCount++;
            }
            numItemsRemoved = Math.Max(settings.NumItemsRemoved, noneCount);
        }

        public override RandomizeResult Randomize(CancellationToken cancellationToken)
        {
            if (!settings.SwapOrRemoveItems)
                return new RandomizeResult { Success = true };

            var result = new RandomizeResult();
            result.DetailedLog = new LogLayer("Item Randomization");

            var placer = new ItemPlacer();
            var options = new FillOptions();
            
            options.gameCompletion = (FillOptions.GameCompletion)settings.Completion;
            options.noEarlyPbs = settings.NoPBsBeforeChozodia;

            SaveData data = settings.logicData;

            if (data == null)
                return new RandomizeResult(false);

            locations = Location.GetLocations();
            KeyManager.Initialize(data);

            traverser = new NodeTraverser();
            var startingInventory = GetStartingInventory(data);

            var inventoryLog = result.DetailedLog.AddChild("Starting Inventory", startingInventory.myKeys.Select(key => key.Name));

            options.itemRules = settings.rules.Select(rule => rule.ToLogicRules()).SelectMany(x => x).ToList();
            options.majorSwap = (FillOptions.ItemSwap)settings.AbilitySwap;
            options.minorSwap = (FillOptions.ItemSwap)settings.TankSwap;

            var itemMap = new Dictionary<string, Guid>();
            foreach (var location in settings.CustomAssignments)
            {
                var logicName = location.Value.LogicName();
                if (logicName == "None")
                    itemMap.Add(locations[location.Key].LogicName, StaticKeys.Nothing);
                else
                {
                    var item = KeyManager.GetKeyFromName(logicName);
                    if (item != null)
                        itemMap.Add(locations[location.Key].LogicName, item.Id);
                }
            }

            if (itemMap.Any())
                result.DetailedLog.AddChild("Predefined locations", itemMap.Select(loc => $"{loc.Key} - {KeyManager.GetKeyName(loc.Value)}"));

            if (!VerifyItemMap(data, itemMap, options, startingInventory, result.DetailedLog.AddChild("Logic Verification"), cancellationToken))
            {
                result.Success = false;
                result.DetailedLog.AddChild("Verification failed");
                return result;
            }

            for (int i = 0; i < 10; i++)
            {
                var attemptLog = result.DetailedLog.AddChild($"Attempt {i + 1}");

                if (cancellationToken.IsCancellationRequested)
                {
                    result.Success = false;
                    attemptLog.AddChild("Cancelled");
                    return result;
                }

                ItemPool pool = GenerateItemPool(data, itemMap, options, startingInventory, attemptLog, cancellationToken);

                if (cancellationToken.IsCancellationRequested)
                {
                    result.Success = false;
                    attemptLog.AddChild("Cancelled");
                    return result;
                }

                if (pool == null)
                {
                    result.Success = false;
                    return result;
                }

                var randomMap = placer.FillLocations(data, options, pool, startingInventory, rng, itemMap);

                attemptLog.AddChild(placer.Log);

                var verified = ItemRuleUtility.VerifyLocationRules(options.itemRules, randomMap, attemptLog);

                if (!verified)
                {
                    attemptLog.AddChild("Item Rule Verification failed");
                    continue;
                }

                if (settings.Completion == GameCompletion.Beatable)
                {
                    verified = traverser.VerifyBeatable(data, randomMap, new Inventory(startingInventory));
                    attemptLog.AddChild(traverser.DetailedLog);
                }
                else if (settings.Completion == GameCompletion.AllItems)
                {
                    verified = traverser.VerifyFullCompletable(data, randomMap, new Inventory(startingInventory));
                    attemptLog.AddChild(traverser.DetailedLog);
                }
                else
                {
                    attemptLog.AddChild("Game Completion set to Unchanged - Verification skipped");
                }
                
                if (!verified)
                {
                    attemptLog.AddChild("Verification failed");
                    continue;
                }

                // apply base changes
                Patch.Apply(rom, Properties.Resources.ZM_U_randoBase);

                foreach (var loc in locations)
                {
                    if (randomMap.ContainsKey(loc.LogicName))
                    {
                        var key = KeyManager.GetKey(randomMap[loc.LogicName]);
                        loc.NewItem = Item.FromLogicName(key?.Name ?? "None");
                    }
                }

                rom.FindEndOfData();
                WriteAssignments();
                FinalChanges();

                result.Success = true;
                return result;
            }

            result.Success = false;
            return result;
        }

        private bool VerifyItemMap(SaveData data, Dictionary<string, Guid> itemMap, FillOptions options,
            Inventory startingInventory, LogLayer detailedLog, CancellationToken cancellationToken)
        {
            if (settings.Completion == GameCompletion.NoLogic)
                return true;

            ItemPool pool = new ItemPool();

            pool.CreatePool();

            var logicVerificationLog = detailedLog.AddChild("Verifying that logic is beatable in raw form");

            var testInventory = new Inventory(startingInventory);
            testInventory.myKeys.AddRange(pool.AvailableItems()
            .Where(key => key != Guid.Empty && (!options.noEarlyPbs || key != StaticKeys.PowerBombs))
            .Select(id => KeyManager.GetKey(id))
            .Where(item => item != null));

            logicVerificationLog.AddChild("Test pool", testInventory.myKeys
                .Where(key => !KeyManager.IsSetting(key.Id))
                .GroupBy(key => key.Id)
                .Select(group => group.Count() > 1 ? $"{KeyManager.GetKeyName(group.Key)} - {group.Count()}" : KeyManager.GetKeyName(group.Key)));

            var verified = traverser.VerifyBeatable(data, new Dictionary<string, Guid>(), testInventory);
            logicVerificationLog.AddChild(traverser.DetailedLog);

            if (!verified)
            {
                detailedLog.AddChild("Raw logic verification failed");
                return false;
            }

            var itemMapVerificationLog = detailedLog.AddChild("Verifying that logic is beatable with supplied item map");

            foreach (var item in itemMap.Values)
                pool.Pull(item);

            testInventory = new Inventory(startingInventory);
            testInventory.myKeys.AddRange(pool.AvailableItems()
            .Where(key => key != Guid.Empty && (!options.noEarlyPbs || key != StaticKeys.PowerBombs))
            .Select(id => KeyManager.GetKey(id))
            .Where(item => item != null));

            itemMapVerificationLog.AddChild("Test pool", testInventory.myKeys
                .Where(key => !KeyManager.IsSetting(key.Id))
                .GroupBy(key => key.Id)
                .Select(group => group.Count() > 1 ? $"{KeyManager.GetKeyName(group.Key)} - {group.Count()}" : KeyManager.GetKeyName(group.Key)));

            verified = traverser.VerifyBeatable(data, itemMap, testInventory);
            itemMapVerificationLog.AddChild(traverser.DetailedLog);

            if (!verified)
            {
                detailedLog.AddChild("Item map logic verification failed");
                return false;
            }

            return true;
        }

        private ItemPool GenerateItemPool(SaveData data, Dictionary<string, Guid> itemMap, FillOptions options, 
            Inventory startingInventory, LogLayer detailedLog, CancellationToken cancellationToken)
        {
            ItemPool pool = new ItemPool();

            if (numItemsRemoved == 0)
            {
                pool.CreatePool();
                foreach (var item in itemMap.Values)
                    pool.Pull(item);

                return pool;
            }

            var poolLog = detailedLog.AddChild("Find viable item pool");

            var restrictedItems = settings.rules.SelectMany(rule => rule.ToRestrictedPoolItems()).Where(x => x != Guid.Empty).ToList();

            if (restrictedItems.Any())
                poolLog.AddChild("Items to remove first", restrictedItems.Select(item => KeyManager.GetKeyName(item)));

            var prioritizedItems = settings.rules.SelectMany(rule => rule.ToPrioritizedPoolItems()).Where(x => x != Guid.Empty).ToList();

            if (prioritizedItems.Any())
                poolLog.AddChild("Items prioritized to stay", prioritizedItems.Select(item => KeyManager.GetKeyName(item)));

            // Try to find a viable item pool for the item restriction
            pool.CreatePool();
            foreach (var item in itemMap.Values)
                pool.Pull(item);

            if (cancellationToken.IsCancellationRequested)
            {
                poolLog.AddChild("Cancelled");
                return null;
            }

            var startCount = pool.AvailableItems().Count;
            poolLog.AddChild($"Pool starting with {startCount} items");
            poolLog.AddChild($"Items to remove {numItemsRemoved}");

            if (startCount < numItemsRemoved)
            {
                poolLog.AddChild("Not enough room to remove items");
                return null;
            }

            var pullingLog = poolLog.AddChild("Pulled Items");
            var removedAbilities = 0;

            var requiredItems = new List<Guid>();
            while (pool.AvailableItems().Count + requiredItems.Count > startCount - numItemsRemoved)
            {
                if (pool.AvailableItems().Count() == 0)
                {
                    poolLog.AddChild("Ran out of items to remove");
                    return null;
                }

                var pullList = restrictedItems.AsEnumerable();
                if (settings.NumAbilitiesRemoved.HasValue)
                {
                    if (removedAbilities < settings.NumAbilitiesRemoved)
                    {
                        var restrictedAbilities = pullList.Where(item => StaticKeys.IsMajorItem(item));
                        if (restrictedAbilities.Any())
                            pullList = restrictedAbilities;
                        else
                            pullList = pool.AvailableItems().Where(item => StaticKeys.IsMajorItem(item));
                    }
                    else
                    {
                        var restrictedTanks = pullList.Where(item => StaticKeys.IsMinorItem(item));
                        if (restrictedTanks.Any())
                            pullList = restrictedTanks;
                        else
                            pullList = pool.AvailableItems().Where(item => StaticKeys.IsMinorItem(item));
                    }
                }

                var pulledItem = pool.PullAmong(pullList, rng);

                var pulledItemLog = pullingLog.AddChild(KeyManager.GetKeyName(pulledItem));

                var combinedPoolItems = pool.AvailableItems().Concat(requiredItems);

                var totalItems = combinedPoolItems.Concat(itemMap.Values);

                if (prioritizedItems.Any(item => !totalItems.Contains(item)))
                {
                    // The pulled item was actually required to beat the game
                    pulledItemLog.Message += " - Prioritized";
                    pulledItemLog.AddChild("Item is prioritized to stay in pool");
                    requiredItems.Add(pulledItem);
                }
                else if (settings.Completion != GameCompletion.NoLogic)
                {
                    var testInventory = new Inventory(startingInventory);
                    testInventory.myKeys.AddRange(combinedPoolItems
                    .Where(key => key != Guid.Empty && (!options.noEarlyPbs || key != StaticKeys.PowerBombs))
                    .Select(id => KeyManager.GetKey(id))
                    .Where(item => item != null));

                    pulledItemLog.AddChild("Test pool", testInventory.myKeys
                        .Where(key => !KeyManager.IsSetting(key.Id))
                        .GroupBy(key => key.Id)
                        .Select(group => group.Count() > 1 ? $"{KeyManager.GetKeyName(group.Key)} - {group.Count()}" : KeyManager.GetKeyName(group.Key)));

                    var verified = false;
                    if (settings.Completion == GameCompletion.Beatable)
                        verified = traverser.VerifyBeatable(data, itemMap, testInventory);
                    else if (settings.Completion == GameCompletion.AllItems)
                        verified = traverser.VerifyFullCompletable(data, itemMap, testInventory);

                    if (verified)
                    {
                        pulledItemLog.Message += " - Expendable";
                        var successLog = pulledItemLog.AddChild("Verification successful");
                        successLog.AddChild(traverser.DetailedLog);

                        if (StaticKeys.IsMajorItem(pulledItem))
                            removedAbilities++;
                    }
                    else
                    {
                        // The pulled item was actually required to beat the game
                        pulledItemLog.Message += " - Required";
                        var failedLog = pulledItemLog.AddChild("Verification failed, item is required");
                        failedLog.AddChild(traverser.DetailedLog);
                        requiredItems.Add(pulledItem);
                    }
                }
            }

            poolLog.AddChild("Remaining items", pool.AvailableItems()
                    .Where(key => !KeyManager.IsSetting(key))
                    .GroupBy(key => key)
                    .Select(group => group.Count() > 1 ? $"{KeyManager.GetKeyName(group.Key)} - {group.Count()}" : KeyManager.GetKeyName(group.Key)));

            poolLog.AddChild("Required items", requiredItems
                    .Where(key => !KeyManager.IsSetting(key))
                    .GroupBy(key => key)
                    .Select(group => group.Count() > 1 ? $"{KeyManager.GetKeyName(group.Key)} - {group.Count()}" : KeyManager.GetKeyName(group.Key)));

            // Add back required items
            pool.AddRange(requiredItems);
            pool.Pad(100 - itemMap.Count);
            return pool;
        }

        private Inventory GetStartingInventory(SaveData data)
        {
            var inventory = new Inventory();

            var orderedSettings = KeyManager.GetSettingKeys().Where(key => !key.Static).OrderBy(setting => setting.Name);

            for (int i = 0; i < settings.logicSettings.Length; i++)
            {
                if (settings.logicSettings[i])
                    inventory.myKeys.Add(orderedSettings.ElementAt(i));
            }

            if (settings.IceNotRequired)
                inventory.myKeys.Add(KeyManager.GetKeyFromName("Ice Beam Not Required"));

            if (settings.PlasmaNotRequired)
                inventory.myKeys.Add(KeyManager.GetKeyFromName("Plasma Beam Not Required"));

            if (settings.RandoEnemies)
                inventory.myKeys.Add(KeyManager.GetKeyFromName("Randomize Enemies"));

            if (settings.ChozoStatueHints)
                inventory.myKeys.Add(KeyManager.GetKeyFromName("Chozo Statue Hints"));

            if (settings.ObtainUnkItems)
                inventory.myKeys.Add(KeyManager.GetKeyFromName("Obtain Unknown Items"));

            if (settings.DisableInfiniteBombJump)
                inventory.myKeys.Add(KeyManager.GetKeyFromName("Disable Infinite Bomb Jump"));

            if (settings.DisableWallJump)
                inventory.myKeys.Add(KeyManager.GetKeyFromName("Disable Wall Jump"));

            return inventory;
        }

        private void WriteAssignments()
        {
            // initialize data
            abilityOffsets = new Dictionary<ItemType, int>()
            {
                { ItemType.Long, 0x13902 },
                { ItemType.Charge, 0x13650 },
                { ItemType.Ice, 0x13906 },
                { ItemType.Wave, 0x1390A },
                { ItemType.Plasma, 0x139E4 },
                { ItemType.Bomb, 0x1390E },
                { ItemType.Varia, 0x1391E },
                { ItemType.Gravity, 0x1396C },
                { ItemType.Morph, 0x1316C },
                { ItemType.Speed, 0x13912 },
                { ItemType.Hi, 0x13916 },
                { ItemType.Screw, 0x1391A },
                { ItemType.Space, 0x1396E },
                { ItemType.Grip, 0x133AA }
            };

            roomTilesets = new Dictionary<int, byte>();
            nextTilesetNum = Rom.NumOfTilesets;

            // write each location
            foreach (Location loc in locations)
            {
                if (loc.NewItem == loc.OrigItem)
                    continue;

                if (loc.OrigItem.IsTank())
                {
                    if (loc.NewItem.IsAbility())
                        AbilityToTank(loc);
                    else
                        TankToTank(loc);
                }
                else
                    ItemToAbility(loc);
            }
        }

        private void TankToTank(Location loc)
        {
            byte clip = loc.NewItem.Clipdata(loc.IsHidden);
            rom.Write8(loc.ClipdataOffset, clip);
            if (!loc.IsHidden)
                rom.Write8(loc.BG1Offset, loc.NewItem.BG1());
        }

        private void AbilityToTank(Location loc)
        {
            // modify tileset
            Tileset ts;
            byte bg1Val;

            int key = loc.Room | (loc.Area << 8);
            if (roomTilesets.TryGetValue(key, out byte tsNum))
            {
                ts = new Tileset(rom, tsNum);
                bg1Val = ts.AddAbility(loc.NewItem);
                ts.Write(tsNum);
            }
            else
            {
                // get room header
                int headerOffset = rom.ReadPtr(Rom.AreaRoomEntryOffset + loc.Area * 4) + (loc.Room * 0x3C);
                tsNum = rom.Read8(headerOffset);

                ts = new Tileset(rom, tsNum);
                bg1Val = ts.AddAbility(loc.NewItem);
                ts.Write(nextTilesetNum);

                rom.Write8(headerOffset, nextTilesetNum);
                nextTilesetNum++;
            }

            // write clipdata and BG1
            byte clip = loc.NewItem.Clipdata(loc.IsHidden);
            rom.Write8(loc.ClipdataOffset, clip);
            if (!loc.IsHidden)
                rom.Write8(loc.BG1Offset, bg1Val);
        }

        private void ItemToAbility(Location loc)
        {
            // replace BehaviorType
            int offset = abilityOffsets[loc.OrigItem];
            rom.Write8(offset, loc.NewItem.BehaviorType());

            // get base gfx
            byte[] baseData;
            int x, y;
            switch (loc.OrigItem)
            {
                case ItemType.Morph:
                case ItemType.Charge:
                    baseData = new byte[0x800];
                    x = 0;
                    y = 0;
                    break;
                case ItemType.Grip:
                    baseData = new byte[0x1000];
                    x = 0;
                    y = 0;
                    break;
                default:
                    baseData = Properties.Resources.gfxChozoStatue;
                    x = 4;
                    y = 4;
                    break;
            }

            // copy new gfx onto base gfx
            Gfx baseGfx = new Gfx(baseData, 32);
            Gfx itemGfx = loc.NewItem.AbilityGraphics();
            baseGfx.AddGfx(itemGfx, x, y);

            // write new gfx to rom
            byte spriteID = loc.OrigItem.SpriteID();
            int gfxPtr = Rom.GetSpriteGfxPtr(spriteID);
            baseGfx.WriteToEnd(rom, gfxPtr);

            // write new palette
            Palette newPal = loc.NewItem.AbilityPalette();
            int palPtr = Rom.GetSpritePalettePtr(spriteID);
            newPal.Write(rom, palPtr);
        }

        private void FinalChanges()
        {
            // modify pirate PB graphics
            PiratePB();

            // fix charge beam OAM
            if (locations[Location.ChargeBeamst].NewItem != ItemType.Charge)
                Patch.Apply(rom, Properties.Resources.ZM_U_fixChargeOAM);

            // set clipdata for imago cocoon right side
            ItemType item = locations[Location.ImagoCocoon].NewItem;
            rom.Write8(0x67A199, item.Clipdata(true));

            // fix number of tanks per area
            WriteNumTanksPerArea();

            // chozo statue hints
            if (settings.ChozoStatueHints)
            {
                Patch.Apply(rom, Properties.Resources.ZM_U_fixChozoHints);
                WriteChozoStatueHints();
            }
            else
                Patch.Apply(rom, Properties.Resources.ZM_U_removeChozoHints);

            // remove items from minimap
            RemoveMinimapItems();

            // set percent for 100% ending
            byte percent = (byte)(99 - settings.NumItemsRemoved);
            rom.Write8(0x87BB8, percent);
        }

        private void PiratePB()
        {
            Location loc = locations[Location.PiratePB];
            if (loc.NewItem == ItemType.Power)
                return;

            // copy new gfx onto base gfx
            Gfx baseGfx = new Gfx(new byte[0x800], 32);
            Gfx itemGfx = loc.NewItem.AbilityGraphics();
            baseGfx.AddGfx(itemGfx, 0, 0);
            // draw 4th block
            Rectangle rect = new Rectangle(0, 0, 2, 2);
            baseGfx.AddGfx(itemGfx, rect, 6, 0);

            // write new gfx to rom
            int gfxPtr = Rom.GetSpriteGfxPtr(Rom.PiratePBSpriteID);
            baseGfx.WriteToEnd(rom, gfxPtr);

            // write new palette
            Palette newPal = loc.NewItem.AbilityPalette();
            int palPtr = Rom.GetSpritePalettePtr(Rom.PiratePBSpriteID);
            newPal.Write(rom, palPtr);
        }

        private void WriteNumTanksPerArea()
        {
            byte[] numTanks = new byte[0x1C];

            foreach (Location loc in locations)
            {
                int index = loc.Area * 4;

                switch (loc.NewItem)
                {
                    case ItemType.Energy:
                        numTanks[index]++;
                        break;
                    case ItemType.Missile:
                        numTanks[index + 1]++;
                        break;
                    case ItemType.Super:
                        numTanks[index + 2]++;
                        break;
                    case ItemType.Power:
                        numTanks[index + 3]++;
                        break;
                }
            }

            rom.WriteBytes(numTanks, 0, Rom.NumTanksPerAreaOffset, numTanks.Length);
        }

        private void WriteChozoStatueHints()
        {
            ItemType[] itemHints = new ItemType[] { 
                ItemType.Long, ItemType.Bomb, ItemType.Ice, ItemType.Speed,
                ItemType.Hi, ItemType.Varia, ItemType.Wave
            };
            HashSet<ItemType> found = new HashSet<ItemType>();

            foreach (Location loc in locations)
            {
                int index = Array.IndexOf(itemHints, loc.NewItem);
                if (index == -1)
                    continue;

                found.Add(loc.NewItem);
                int offset = Rom.ChozoTargetOffset + index * 0xC;
                rom.Write8(offset + 6, loc.Area);
                rom.Write8(offset + 7, loc.MinimapX);
                rom.Write8(offset + 8, loc.MinimapY);
            }

            // disable statues for removed items
            const int jump = 0x14004;
            foreach (ItemType type in itemHints)
            {
                if (found.Contains(type))
                    continue;

                switch (type)
                {
                    case ItemType.Long:
                        rom.WritePtr(0x13E00, jump);
                        rom.Write8(0x340B4D, 0);
                        rom.WritePtr(0x340B54, 0x364F4C);
                        break;
                    case ItemType.Bomb:
                        rom.WritePtr(0x13E18, jump);
                        break;
                    case ItemType.Ice:
                        rom.WritePtr(0x13E08, jump);
                        break;
                    case ItemType.Speed:
                        rom.WritePtr(0x13E20, jump);
                        break;
                    case ItemType.Hi:
                        rom.WritePtr(0x13E28, jump);
                        break;
                    case ItemType.Varia:
                        rom.WritePtr(0x13E38, jump);
                        break;
                    case ItemType.Wave:
                        rom.WritePtr(0x13E10, jump);
                        break;
                }
            }
        }

        private void RemoveMinimapItems()
        {
            Minimap[] minimaps = new Minimap[7];
            foreach (Location loc in locations)
            {
                if (loc.NewItem != ItemType.None || loc.OrigItem.IsAbility())
                    continue;

                if (minimaps[loc.Area] == null)
                    minimaps[loc.Area] = new Minimap(rom, loc.Area);

                minimaps[loc.Area].IncrementTile(loc.MinimapX, loc.MinimapY);
            }
            foreach (Minimap mm in minimaps)
            {
                if (mm != null)
                    mm.Write();
            }
        }

        public override string GetLog()
        {
            StringBuilder sb = new StringBuilder();

            switch (settings.AbilitySwap)
            {
                case Swap.LocalPool:
                    sb.AppendLine("Abilities: Shuffled in own pool");
                    break;
                case Swap.GlobalPool:
                    sb.AppendLine("Abilities: Shuffled with all items");
                    break;
                default:
                    sb.AppendLine("Abilities: Unchanged");
                    break;
            }

            switch (settings.TankSwap)
            {
                case Swap.LocalPool:
                    sb.AppendLine("Tanks: Shuffled in own pool");
                    break;
                case Swap.GlobalPool:
                    sb.AppendLine("Tanks: Shuffled with all items");
                    break;
                default:
                    sb.AppendLine("Tanks: Unchanged");
                    break;
            }

            if (settings.SwapOrRemoveItems)
            {
                // write item locations
                string[] areaNames = Rom.AreaNames;
                foreach (Location loc in locations)
                {
                    sb.AppendFormat("{0,-4}", loc.Number);
                    sb.AppendFormat("{0,-10}", areaNames[loc.Area]);
                    sb.AppendFormat("{0,-10}", $"({loc.MinimapX}, {loc.MinimapY})");
                    sb.AppendLine(loc.NewItem.Name());
                }
                sb.AppendLine();

                // write item collection order
                sb.AppendLine(traverser.GetWaveLog());
            }

            return sb.ToString();
        }

        public Bitmap[] GetMaps()
        {
            return MapImages.Draw(locations);
        }

    }
}
