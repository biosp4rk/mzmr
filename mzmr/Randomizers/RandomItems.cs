using mzmr.Data;
using mzmr.Items;
using mzmr.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace mzmr.Randomizers
{
    public class RandomItems : RandomAspect
    {
        // data for making assignments
        private Location[] locations;
        private HashSet<int> pbRestrictions;
        private List<int> remainingLocations;
        private List<ItemType> remainingItems;
        private Conditions conditions;

        // data for writing assignments
        private Dictionary<ItemType, int> abilityOffsets;
        private Dictionary<int, byte> roomTilesets;
        private byte nextTilesetNum;

        private const int maxAttempts = 50000;

        public RandomItems(ROM rom, Settings settings, Random rng) : base(rom, settings, rng)
        {

        }

        public override bool Randomize()
        {
            if (!settings.randomAbilities &&
                !settings.randomTanks &&
                settings.numItemsRemoved == 0) { return true; }

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
            if (attempts >= maxAttempts) { return false; }

            rom.FindEndOfData();
            WriteAssignments();
            FinalChanges();

            return true;
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
            int count = settings.numItemsRemoved;
            // account for custom assignments of None
            foreach (ItemType item in settings.customAssignments.Values)
            {
                if (item == ItemType.None) { count--; }
            }
            count = Math.Min(count, remainingItems.Count);
            for (int i = 0; i < count; i++)
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
                result = conditions.Is100Able(settings.numItemsRemoved);
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
            nextTilesetNum = ROM.NumOfTilesets;

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
                int headerOffset = rom.ReadPtr(ROM.AreaRoomEntryOffset + loc.Area * 4) + (loc.Room * 0x3C);
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
            GFX baseGfx = new GFX(baseData, 32);
            GFX itemGfx = loc.NewItem.AbilityGraphics();
            baseGfx.AddGfx(itemGfx, x, y);

            // write new gfx to rom
            byte spriteID = loc.OrigItem.SpriteID();
            int gfxPtr = ROM.GetSpriteGfxPtr(spriteID);
            baseGfx.WriteToEnd(rom, gfxPtr);

            // write new palette
            Palette newPal = loc.NewItem.AbilityPalette();
            int palPtr = ROM.GetSpritePalettePtr(spriteID);
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
            GFX baseGfx = new GFX(new byte[0x800], 32);
            GFX itemGfx = loc.NewItem.AbilityGraphics();
            baseGfx.AddGfx(itemGfx, 0, 0);
            // draw 4th block
            Rectangle rect = new Rectangle(0, 0, 2, 2);
            baseGfx.AddGfx(itemGfx, rect, 6, 0);

            // write new gfx to rom
            int gfxPtr = ROM.GetSpriteGfxPtr(ROM.PiratePBSpriteID);
            baseGfx.WriteToEnd(rom, gfxPtr);

            // write new palette
            Palette newPal = loc.NewItem.AbilityPalette();
            int palPtr = ROM.GetSpritePalettePtr(ROM.PiratePBSpriteID);
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

            rom.ArrayToRom(numTanks, 0, ROM.NumTanksPerAreaOffset, numTanks.Length);
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
                int offset = ROM.ChozoTargetOffset + index * 0xC;
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
            string[] areaNames = ROM.AreaNames;
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
                sb.AppendLine(conditions.GetCollectionOrder());
            }

            return sb.ToString();
        }

        public Bitmap[] GetMaps()
        {
            return AreaMaps.Draw(locations);
        }

    }
}
