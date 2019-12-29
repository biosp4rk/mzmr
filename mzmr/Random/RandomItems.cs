using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace mzmr
{
    public class RandomItems : RandomAspect
    {
        // data for making assignments
        private Location[] locations;
        private List<int> remainingLocations;
        private List<ItemType> remainingItems;

        private HashSet<int> pbRestrictions;

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
            if (!settings.randomAbilities && !settings.randomTanks) { return true; }

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

            Console.WriteLine(attempts);
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
            locations = Location.InitializeLocations();
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
            int count = Math.Min(settings.numItemsRemoved, remainingItems.Count);
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
                Conditions conditions = new Conditions(settings, locations);
                result = conditions.Is100Able(settings.numItemsRemoved);
            }
            else if (settings.gameCompletion == GameCompletion.Beatable)
            {
                Conditions conditions = new Conditions(settings, locations);
                result = conditions.IsBeatable();
            }

            return result;
        }

        private void WriteAssignments()
        {
            // initialize data
            abilityOffsets = new Dictionary<ItemType, int>();
            StringReader sr = new StringReader(Properties.Resources.ZM_U_replaceAbilities);

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] items = line.Split('=');
                if (items.Length != 2) { continue; }

                ItemType type = Item.FromString(items[0]);
                int offset = Convert.ToInt32(items[1], 16);
                abilityOffsets.Add(type, offset);
            }

            sr.Close();

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
            byte tsNum;
            byte bg1Val;

            int key = loc.Room | (loc.Area << 8);
            if (roomTilesets.TryGetValue(key, out tsNum))
            {
                ts = new Tileset(rom, tsNum);
                bg1Val = ts.AddAbility(loc.NewItem);
                ts.Write(tsNum);
            }
            else
            {
                // get room header
                int headerOffset = rom.ReadPtr(ROM.AreaHeaderOffset + loc.Area * 4) + (loc.Room * 0x3C);
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
            byte[] baseGFX;
            int drawOffset;
            switch (loc.OrigItem)
            {
                case ItemType.Morph:
                case ItemType.Charge:
                    baseGFX = new byte[0x800];
                    drawOffset = 0;
                    break;
                case ItemType.Grip:
                    baseGFX = new byte[0x1000];
                    drawOffset = 0;
                    break;
                default:
                    baseGFX = Properties.Resources.chozoStatueGFX;
                    drawOffset = 0x1080;
                    break;
            }

            // copy new gfx onto base gfx
            byte[] newGfx = loc.NewItem.AbilityGFX();
            Array.Copy(newGfx, 0, baseGFX, drawOffset, 0xC0);
            Array.Copy(newGfx, 0xC0, baseGFX, drawOffset + 0x400, 0xC0);

            // compressed combined gfx
            byte[] compGFX;
            int compLen = Compress.CompLZ77(baseGFX, baseGFX.Length, out compGFX);

            // write to end of rom
            int newOffset = rom.WriteToEnd(compGFX, compLen);

            // fix pointer
            byte spriteID = (byte)(loc.OrigItem.SpriteID() - 0x10);
            int gfxPtr = ROM.SpriteGfxOffset + spriteID * 4;
            rom.WritePtr(gfxPtr, newOffset);

            // write new palette
            byte[] newPal = loc.NewItem.AbilityPalette();
            int palPtr = ROM.SpritePaletteOffset + spriteID * 4;
            int palOffset = rom.ReadPtr(palPtr);
            rom.ArrayToRom(newPal, 0, palOffset, newPal.Length);
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

        // TODO: reuse code in ItemToAbility
        private void PiratePB()
        {
            Location loc = locations[Location.PiratePB];
            if (loc.NewItem == ItemType.Power) { return; }

            // get base gfx
            byte[] baseGFX = new byte[0x800];

            // copy new gfx onto base gfx
            byte[] newGFX = loc.NewItem.AbilityGFX();
            Array.Copy(newGFX, 0, baseGFX, 0, 0xC0);
            Array.Copy(newGFX, 0xC0, baseGFX, 0x400, 0xC0);
            // write 4th block
            Array.Copy(newGFX, 0x40, baseGFX, 0xC0, 0x40);
            Array.Copy(newGFX, 0x100, baseGFX, 0x4C0, 0x40);

            // compressed combined gfx
            byte[] compGFX;
            int compLen = Compress.CompLZ77(baseGFX, baseGFX.Length, out compGFX);

            // write to end of rom
            int newOffset = rom.WriteToEnd(compGFX, compLen);

            // fix pointer
            byte spriteID = (byte)(ROM.PiratePBSpriteID - 0x10);
            int gfxPtr = ROM.SpriteGfxOffset + spriteID * 4;
            rom.WritePtr(gfxPtr, newOffset);

            // write new palette
            byte[] newPal = loc.NewItem.AbilityPalette();
            int palPtr = ROM.SpritePaletteOffset + spriteID * 4;
            int palOffset = rom.ReadPtr(palPtr);
            rom.ArrayToRom(newPal, 0, palOffset, newPal.Length);
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
                    mm.Write(rom);
                }
            }
        }

        public override void GetLog(StringBuilder sb)
        {
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
                sb.AppendLine("Items: Unchanged");
                return;
            }

            string[] areaNames = rom.AreaNames;

            foreach (Location loc in locations)
            {
                sb.AppendFormat("{0,-4}", loc.Number);
                sb.AppendFormat("{0,-10}", areaNames[loc.Area]);
                sb.AppendFormat("{0,-10}", "(" + loc.MinimapX + ", " + loc.MinimapY + ")");
                sb.AppendLine(loc.NewItem.Name());
            }
        }

        public Bitmap[] GetMaps()
        {
            return AreaMaps.Draw(locations);
        }


    }
}
