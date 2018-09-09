using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace mzmr
{
    public class Location
    {
        public bool IsHidden
        {
            get { return Item.IsTank(OrigItem) && BG1Offset == 0; }
        }
        public bool DisableVariaAnim
        {
            get { return VariaX == 0; }
        }

        public const int ChargeBeamst = 9;
        public const int PiratePB = 91;

        public int Number;
        public byte Area;
        public byte Room;
        public byte MinimapX;
        public byte MinimapY;
        public ushort VariaX;
        public ushort VariaY;
        public int ClipdataOffset;
        public int BG1Offset;
        public ItemType OrigItem;
        public ItemType NewItem;
        public List<ItemType> Requirements;

        public Location()
        {
            Requirements = new List<ItemType>();
        }

        public static Location[] InitializeLocations()
        {
            Location[] locations = new Location[100];
            int index = 0;

            StringReader sr = new StringReader(Properties.Resources.locations);
            string line = "";

            while (line != null)
            {
                Location loc = new Location();

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("[")) { break; }
                    string[] items = line.Split('=');
                    if (items.Length != 2) { continue; }

                    string name = items[0];
                    string value = items[1];
                    switch (name)
                    {
                        case "Number":
                            loc.Number = Convert.ToInt32(value, 16);
                            break;
                        case "Area":
                            loc.Area = Convert.ToByte(value, 16);
                            break;
                        case "Room":
                            loc.Room = Convert.ToByte(value, 16);
                            break;
                        case "Minimap":
                            MatchCollection map = Regex.Matches(value, @"[0-9A-F]+");
                            loc.MinimapX = Convert.ToByte(map[0].Value, 16);
                            loc.MinimapY = Convert.ToByte(map[1].Value, 16);
                            break;
                        case "Item":
                            ItemType type = (ItemType)Enum.Parse(typeof(ItemType), value);
                            loc.OrigItem = type;
                            break;
                        case "Clip":
                            loc.ClipdataOffset = Convert.ToInt32(value, 16);
                            break;
                        case "BG1":
                            loc.BG1Offset = Convert.ToInt32(value, 16);
                            break;
                        case "Varia":
                            MatchCollection pos = Regex.Matches(value, @"[0-9A-F]+");
                            loc.VariaX = Convert.ToUInt16(pos[0].Value, 16);
                            loc.VariaY = Convert.ToUInt16(pos[1].Value, 16);
                            break;
                        case "Requirements":
                            MatchCollection req = Regex.Matches(value, @"\w+");
                            foreach (Match m in req)
                            {
                                ItemType temp = (ItemType)Enum.Parse(typeof(ItemType), m.Value);
                                loc.Requirements.Add(temp);
                            }
                            break;
                        default:
                            throw new FormatException();
                    }
                }

                if (loc.OrigItem != ItemType.None)
                {
                    locations[index++] = loc;
                }
            }

            if (index != 100)
            {
                throw new FormatException();
            }

            return locations;
        }


    }
}
