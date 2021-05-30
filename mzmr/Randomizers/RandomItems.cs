using Common.Key;
using Common.SaveData;
using mzmr.Data;
using mzmr.Items;
using mzmr.Utility;
using Newtonsoft.Json;
using Randomizer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Verifier;
using Verifier.Key;

namespace mzmr.Randomizers
{
    public class RandomItems : RandomAspect
    {
        // data for making assignments
        private int numItemsRemoved;
        private Location[] locations;
        private HashSet<int> pbRestrictions;
        private List<int> remainingLocations;
        private List<ItemType> remainingItems;
        private Conditions conditions;
        private NodeTraverser traverser;

        // data for writing assignments
        private Dictionary<ItemType, int> abilityOffsets;
        private Dictionary<int, byte> roomTilesets;
        private byte nextTilesetNum;

        private const int maxAttempts = 50000;

        public RandomItems(Rom rom, Settings settings, Random rng) : base(rom, settings, rng)
        {
            int noneCount = 0;
            foreach (ItemType item in settings.customAssignments.Values)
            {
                if (item == ItemType.None) { noneCount++; }
            }
            numItemsRemoved = Math.Max(settings.numItemsRemoved, noneCount);
        }

        public override RandomizeResult Randomize(CancellationToken cancellationToken)
        {
            if (!settings.randomAbilities &&
                !settings.randomTanks &&
                numItemsRemoved == 0)
            {
                return new RandomizeResult { Success = true };
            }

            if(settings.logicType == LogicType.Old)
            {
                return OldRandomize();
            }

            return NewRandomize(cancellationToken);
        }

        private RandomizeResult NewRandomize(CancellationToken cancellationToken)
        {
            var result = new RandomizeResult();
            result.DetailedLog = new LogLayer("Item Randomization");

            var placer = new ItemPlacer();
            var options = new FillOptions();
            
            options.gameCompletion = (FillOptions.GameCompletion)settings.gameCompletion;
            options.noEarlyPbs = settings.noPBsBeforeChozodia;

            SaveData data = settings.logicData;

            if (data == null)
            {
                return new RandomizeResult(false);
            }

            locations = Location.GetLocations();
            KeyManager.Initialize(data);

            traverser = new NodeTraverser();
            var startingInventory = GetStartingInventory(data);

            var inventoryLog = result.DetailedLog.AddChild("Starting Inventory", startingInventory.myKeys.Select(key => key.Name));

            for (int i = 0; i < 10; i++)
            {
                var attemptLog = result.DetailedLog.AddChild($"Attempt {i + 1}");

                if (cancellationToken.IsCancellationRequested)
                {
                    result.Success = false;
                    attemptLog.AddChild("Cancelled");
                    return result;
                }

                var itemMap = new Dictionary<string, Guid>();
                foreach (var location in settings.customAssignments)
                {
                    var logicName = location.Value.LogicName();
                    if (logicName == "None")
                    {
                        itemMap.Add(locations[location.Key].LogicName, StaticKeys.Nothing);
                    }
                    else
                    {
                        var item = KeyManager.GetKeyFromName(logicName);
                        if (item != null)
                        {
                            itemMap.Add(locations[location.Key].LogicName, item.Id);
                        }
                    }
                }

                options.itemRules = settings.rules.Select(rule => rule.ToLogicRules()).SelectMany(x => x).ToList();

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

                var verified = false;
                if (settings.gameCompletion == GameCompletion.Beatable)
                    verified = traverser.VerifyBeatable(data, randomMap, new Inventory(startingInventory));
                else if (settings.gameCompletion == GameCompletion.AllItems)
                    verified = traverser.VerifyFullCompletable(data, randomMap, new Inventory(startingInventory));

                attemptLog.AddChild(traverser.DetailedLog);

                if (verified)
                {
                    attemptLog.AddChild("Verified");

                    // apply base changes
                    Patch.Apply(rom, Properties.Resources.ZM_U_randomItemBase);

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

                attemptLog.AddChild("Verification failed");
            }

            result.Success = false;
            return result;
        }

        private ItemPool GenerateItemPool(SaveData data, Dictionary<string, Guid> itemMap, FillOptions options, 
            Inventory startingInventory, LogLayer detailedLog, CancellationToken cancellationToken)
        {
            ItemPool pool = new ItemPool();

            if (numItemsRemoved < 1)
            {
                pool.CreatePool();
                foreach (var item in itemMap.Values)
                {
                    pool.Pull(item);
                }

                return pool;
            }

            var poolLog = detailedLog.AddChild("Find viable item pool");

            var restrictedItems = settings.rules.SelectMany(rule => rule.ToRestrictedPoolItems()).Where(x => x != Guid.Empty).ToList();

            if (restrictedItems.Any())
            {
                poolLog.AddChild("Items to remove first", restrictedItems.Select(item => KeyManager.GetKeyName(item)));
            }

            var prioritizedItems = settings.rules.SelectMany(rule => rule.ToPrioritizedPoolItems()).Where(x => x != Guid.Empty).ToList();

            if (prioritizedItems.Any())
            {
                poolLog.AddChild("Items prioritized to stay", prioritizedItems.Select(item => KeyManager.GetKeyName(item)));
            }

            // Try to find a viable item pool for the item restriction
            for (int i = 0; i < 10; i++)
            {
                pool.CreatePool();
                foreach (var item in itemMap.Values)
                {
                    pool.Pull(item);
                }

                var currentPoolLog = poolLog.AddChild($"Attempt {i + 1}");
                if (cancellationToken.IsCancellationRequested)
                {
                    currentPoolLog.AddChild("Cancelled");
                    return null;
                }

                var startCount = pool.AvailableItems().Count;
                currentPoolLog.AddChild($"Pool starting with {startCount} items");
                currentPoolLog.AddChild($"Items to remove {numItemsRemoved}");

                if (startCount < numItemsRemoved)
                {
                    currentPoolLog.AddChild("Not enough room to remove items");
                    return null;
                }

                var pullingLog = currentPoolLog.AddChild("Pulled Items");

                var requiredItems = new List<Guid>();
                while (pool.AvailableItems().Count + requiredItems.Count > startCount - numItemsRemoved)
                {
                    var pulledItem = pool.PullAmong(restrictedItems, rng);

                    var pulledItemLog = pullingLog.AddChild(KeyManager.GetKeyName(pulledItem));

                    var combinedItems = pool.AvailableItems().Concat(requiredItems);

                    var testInventory = new Inventory(startingInventory);
                    testInventory.myKeys.AddRange(combinedItems
                    .Where(key => key != Guid.Empty && (!options.noEarlyPbs || key != StaticKeys.PowerBombs))
                    .Select(id => KeyManager.GetKey(id))
                    .Where(item => item != null));

                    pulledItemLog.AddChild("Test pool", testInventory.myKeys
                        .Where(key => !KeyManager.IsSetting(key.Id))
                        .GroupBy(key => key.Id)
                        .Select(group => group.Count() > 1 ? $"{KeyManager.GetKeyName(group.Key)} - {group.Count()}" : KeyManager.GetKeyName(group.Key)));

                    var verified = false;
                    if (settings.gameCompletion == GameCompletion.Beatable)
                        verified = traverser.VerifyBeatable(data, itemMap, testInventory);
                    else if (settings.gameCompletion == GameCompletion.AllItems)
                        verified = traverser.VerifyFullCompletable(data, itemMap, testInventory);

                    if (verified)
                    {
                        pulledItemLog.Message += " - Expendable";
                        pulledItemLog.AddChild("Verification successful");
                    }
                    else
                    {
                        // The pulled item was actually required to beat the game
                        pulledItemLog.Message += " - Required";
                        pulledItemLog.AddChild("Verification failed, item is required");
                        requiredItems.Add(pulledItem);
                    }
                }

                currentPoolLog.AddChild("Remaining items", pool.AvailableItems()
                        .Where(key => !KeyManager.IsSetting(key))
                        .GroupBy(key => key)
                        .Select(group => group.Count() > 1 ? $"{KeyManager.GetKeyName(group.Key)} - {group.Count()}" : KeyManager.GetKeyName(group.Key)));

                currentPoolLog.AddChild("Required items", requiredItems
                        .Where(key => !KeyManager.IsSetting(key))
                        .GroupBy(key => key)
                        .Select(group => group.Count() > 1 ? $"{KeyManager.GetKeyName(group.Key)} - {group.Count()}" : KeyManager.GetKeyName(group.Key)));

                // Add back required items
                pool.AddRange(requiredItems);
                pool.Pad(100 - itemMap.Count);
                return pool;
            }

            return null;
        }

        private Inventory GetStartingInventory(SaveData data)
        {
            var inventory = new Inventory();

            var orderedSettings = KeyManager.GetSettingKeys().Where(key => !key.Static).OrderBy(setting => setting.Name);

            for (int i = 0; i < settings.logicSettings.Length; i++)
            {
                if(settings.logicSettings[i])
                { 
                    inventory.myKeys.Add(orderedSettings.ElementAt(i));
                }
            }

            if (settings.iceNotRequired)
            {
                inventory.myKeys.Add(KeyManager.GetKeyFromName("Ice Beam Not Required"));
            }

            if (settings.plasmaNotRequired)
            {
                inventory.myKeys.Add(KeyManager.GetKeyFromName("Plasma Beam Not Required"));
            }

            if (settings.wallJumping)
            {
                var wjKey = KeyManager.GetKeyFromName("Can Walljump");
                if (!inventory.myKeys.Contains(wjKey))
                {
                    inventory.myKeys.Add(wjKey);
                }
            }

            if (settings.infiniteBombJump)
            {
                var ibjKey = KeyManager.GetKeyFromName("Can Infinite bomb jump");
                if (!inventory.myKeys.Contains(ibjKey))
                {
                    inventory.myKeys.Add(ibjKey);
                }
            }

            if (settings.randomEnemies)
            {
                inventory.myKeys.Add(KeyManager.GetKeyFromName("Randomize Enemies"));
            }

            if (settings.chozoStatueHints)
            {
                inventory.myKeys.Add(KeyManager.GetKeyFromName("Chozo Statue Hints"));
            }

            if (settings.obtainUnkItems)
            {
                inventory.myKeys.Add(KeyManager.GetKeyFromName("Obtain Unknown Items"));
            }

            return inventory;
        }

        private RandomizeResult OldRandomize()
        {
            Initialize();

            // apply base changes
            Patch.Apply(rom, Properties.Resources.ZM_U_randomItemBase);

            List<int> remainingLocationsBackup = new List<int>(remainingLocations);
            List<ItemType> remainingItemsBackup = new List<ItemType>(remainingItems);
            int attempts = 0;

            while (attempts < maxAttempts)
            {
                bool success = TryRandomize();
                attempts++;

                if (success) { break; }
                else
                {
                    // copy backups
                    remainingLocations = new List<int>(remainingLocationsBackup);
                    remainingItems = new List<ItemType>(remainingItemsBackup);
                }
            }

            Console.WriteLine($"Item randomization attempts: {attempts}");
            if (attempts >= maxAttempts) { return new RandomizeResult(false); }

            rom.FindEndOfData();
            WriteAssignments();
            FinalChanges();

            return new RandomizeResult(true);
        }

        private void Initialize()
        {
            // power bomb restrictions
            if (settings.noPBsBeforeChozodia)
            {
                pbRestrictions = new HashSet<int>();

                // add non-Chozodia locations
                for (int i = 0; i <= 81; i++)
                {
                    pbRestrictions.Add(i);
                }

                // remove Tourian locations
                pbRestrictions.Remove(73);
                pbRestrictions.Remove(74);

                // remove locations that require gravity
                if (!settings.obtainUnkItems)
                {
                    pbRestrictions.Remove(24);  // Kraid lava
                    pbRestrictions.Remove(32);  // Norfair lava
                }
            }

            // get locations
            locations = Location.GetLocations();
            Dictionary<int, ItemType> customAssignments = settings.customAssignments;

            // get list of items/locations to randomize
            remainingLocations = new List<int>();
            remainingItems = new List<ItemType>();
            for (int i = 0; i < 100; i++)
            {
                Location loc = locations[i];

                if (customAssignments.ContainsKey(i))
                {
                    // custom assignment
                    loc.NewItem = customAssignments[i];
                    remainingItems.Add(loc.OrigItem);
                }
                else if (!settings.randomTanks && loc.OrigItem.IsTank() ||
                    !settings.randomAbilities && loc.OrigItem.IsAbility())
                {
                    // abilities/tanks only
                    loc.NewItem = loc.OrigItem;
                }
                else
                {
                    // otherwise, add to remaining
                    remainingLocations.Add(i);
                    remainingItems.Add(loc.OrigItem);
                }
            }

            // remove items that have already been assigned
            foreach (ItemType item in customAssignments.Values)
            {
                remainingItems.Remove(item);
            }

            // handle morph
            if (settings.gameCompletion != GameCompletion.Unchanged)
            {
                // allow space jump first (1/198)
                if (settings.obtainUnkItems && !customAssignments.ContainsKey(0) &&
                    !customAssignments.ContainsKey(3) && rng.Next(198) == 0)
                {
                    locations[0].NewItem = ItemType.Space;
                    locations[3].NewItem = ItemType.Morph;
                    remainingLocations.Remove(0);
                    remainingLocations.Remove(3);
                    remainingItems.Remove(ItemType.Morph);
                    remainingItems.Remove(ItemType.Space);
                }
                else if (!customAssignments.ContainsKey(0))
                {
                    locations[0].NewItem = ItemType.Morph;
                    remainingLocations.Remove(0);
                    remainingItems.Remove(ItemType.Morph);
                }
            }
        }

        private bool TryRandomize()
        {
            // shuffle items and locations
            RandomAll.ShuffleList(rng, remainingLocations);
            RandomAll.ShuffleList(rng, remainingItems);

            // remove items
            for (int i = 0; i < numItemsRemoved; i++)
            {
                int index = rng.Next(remainingItems.Count);
                remainingItems.RemoveAt(index);
            }

            foreach (ItemType item in remainingItems)
            {
                int chosenLocation = -1;

                foreach (int loc in remainingLocations)
                {
                    if (item.IsAbility())
                    {
                        if (settings.gameCompletion == GameCompletion.AllItems &&
                            locations[loc].Requirements.Contains(item))
                        {
                            continue;
                        }
                    }
                    else if (item == ItemType.Power)
                    {
                        if (settings.noPBsBeforeChozodia && pbRestrictions.Contains(loc))
                        {
                            continue;
                        }
                    }

                    chosenLocation = loc;
                    break;
                }

                // check if no location was found
                if (chosenLocation == -1) { return false; }

                // assign and remove location
                locations[chosenLocation].NewItem = item;
                remainingLocations.Remove(chosenLocation);
            }

            // set remaining locations to none
            foreach (int loc in remainingLocations)
            {
                locations[loc].NewItem = ItemType.None;
            }

            // final checks
            bool result = true;

            if (settings.gameCompletion == GameCompletion.AllItems)
            {
                conditions = new Conditions(settings, locations);
                result = conditions.Is100able(numItemsRemoved);
            }
            else if (settings.gameCompletion == GameCompletion.Beatable)
            {
                conditions = new Conditions(settings, locations);
                result = conditions.IsBeatable();
            }

            return result;
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
                if (loc.NewItem == loc.OrigItem) { continue; }

                if (loc.OrigItem.IsTank())
                {
                    if (loc.NewItem.IsAbility())
                    {
                        AbilityToTank(loc);
                    }
                    else
                    {
                        TankToTank(loc);
                    }
                }
                else
                {
                    ItemToAbility(loc);
                }
            }
        }

        private void TankToTank(Location loc)
        {
            bool hidden = loc.IsHidden;

            rom.Write8(loc.ClipdataOffset, loc.NewItem.Clipdata(hidden));

            if (!hidden)
            {
                rom.Write8(loc.BG1Offset, loc.NewItem.BG1());
            }
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
            bool hidden = loc.IsHidden;
            rom.Write8(loc.ClipdataOffset, loc.NewItem.Clipdata(hidden));

            if (!hidden)
            {
                rom.Write8(loc.BG1Offset, bg1Val);
            }
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
            {
                Patch.Apply(rom, Properties.Resources.ZM_U_fixChargeOAM);
            }

            // set clipdata for imago cocoon right side
            ItemType item = locations[Location.ImagoCocoon].NewItem;
            rom.Write8(0x67A199, item.Clipdata(true));

            // fix number of tanks per area
            WriteNumTanksPerArea();

            // chozo statue hints
            if (settings.chozoStatueHints)
            {
                Patch.Apply(rom, Properties.Resources.ZM_U_fixChozoHints);
                WriteChozoStatueHints();
            }
            else
            {
                Patch.Apply(rom, Properties.Resources.ZM_U_removeChozoHints);
            }

            // remove items from minimap
            if (settings.numItemsRemoved > 0)
            {
                RemoveMinimapItems();
            }

            // set percent for 100% ending
            byte percent = (byte)(99 - settings.numItemsRemoved);
            rom.Write8(0x87BB8, percent);
        }

        private void PiratePB()
        {
            Location loc = locations[Location.PiratePB];
            if (loc.NewItem == ItemType.Power) { return; }

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

            rom.ArrayToRom(numTanks, 0, Rom.NumTanksPerAreaOffset, numTanks.Length);
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
                if (index == -1) { continue; }
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
                if (found.Contains(type)) { continue; }
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
                if (loc.NewItem != ItemType.None || loc.OrigItem.IsAbility()) { continue; }

                if (minimaps[loc.Area] == null)
                {
                    minimaps[loc.Area] = new Minimap(rom, loc.Area);
                }

                minimaps[loc.Area].IncrementTile(loc.MinimapX, loc.MinimapY);
            }
            foreach (Minimap mm in minimaps)
            {
                if (mm != null)
                {
                    mm.Write();
                }
            }
        }

        public override string GetLog()
        {
            StringBuilder sb = new StringBuilder();

            if (settings.randomAbilities && settings.randomTanks)
            {
                sb.AppendLine("Items: All");
            }
            else if (settings.randomAbilities)
            {
                sb.AppendLine("Items: Abilities only");
            }
            else if (settings.randomTanks)
            {
                sb.AppendLine("Items: Tanks only");
            }
            else
            {
                return "Items: Unchanged";
            }

            // write item locations
            string[] areaNames = Rom.AreaNames;
            foreach (Location loc in locations)
            {
                sb.AppendFormat("{0,-4}", loc.Number);
                sb.AppendFormat("{0,-10}", areaNames[loc.Area]);
                sb.AppendFormat("{0,-10}", "(" + loc.MinimapX + ", " + loc.MinimapY + ")");
                sb.AppendLine(loc.NewItem.Name());
            }
            sb.AppendLine();

            // write item collection order
            if (settings.gameCompletion != GameCompletion.Unchanged)
            {
                if (settings.logicType == LogicType.Old)
                {
                    sb.AppendLine(conditions.GetCollectionOrder());
                }
                else
                {
                    sb.AppendLine(traverser.GetWaveLog());
                }
            }

            return sb.ToString();
        }

        public Bitmap[] GetMaps()
        {
            return MapImages.Draw(locations);
        }

    }
}
