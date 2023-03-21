using System;
using mzmr.Utility;
using System.Collections.Generic;
using System.IO;
using System.Text;
using mzmr.Items;
using System.Threading;

namespace mzmr.Randomizers
{
    class RandomText : RandomAspect
    {
        public RandomText(Rom rom, Settings settings, Random rng) : base(rom, settings, rng)
        {

            string workPath = AppDomain.CurrentDomain.BaseDirectory;
            if (!File.Exists(workPath + @"/Text/story.txt"))
                throw new FileNotFoundException("Story text file not found.");
            storyText = File.ReadAllLines(workPath + @"/Text/story.txt");
            if (!File.Exists(workPath + @"/Text/area.txt"))
                throw new FileNotFoundException("Area Name text file not found.");
            areaText = File.ReadAllLines(workPath + @"/Text/area.txt");
            if (!File.Exists(workPath + @"/Text/description.txt"))
                throw new FileNotFoundException("Item Description text file not found.");
            descriptionText = File.ReadAllLines(workPath + @"/Text/description.txt");
            if (!File.Exists(workPath + @"/Text/prefix.txt"))
                throw new FileNotFoundException("Item Prefix text file not found.");
            prefixText = File.ReadAllLines(workPath + @"/Text/prefix.txt");
            if (!File.Exists(workPath + @"/Text/weaponSuffix.txt"))
                throw new FileNotFoundException("Weapon Suffix text file not found.");
            weapSuffixText = File.ReadAllLines(workPath + @"/Text/weaponSuffix.txt");
            if (!File.Exists(workPath + @"/Text/equipmentSuffix.txt"))
                throw new FileNotFoundException("Equipment Suffix text file not found.");
            equipSuffixText = File.ReadAllLines(workPath + @"/Text/equipmentSuffix.txt");
            if (!File.Exists(workPath + @"/Text/oneLine.txt"))
                throw new FileNotFoundException("One Line Message text file not found.");
            oneLineText = File.ReadAllLines(workPath + @"/Text/oneLine.txt");
            if (!File.Exists(workPath + @"/Text/twoLine.txt"))
                throw new FileNotFoundException("Two Line Message text file not found.");
            twoLineText = File.ReadAllLines(workPath + @"/Text/twoLine.txt");
            if (!File.Exists(workPath + @"/Text/difficulty.txt"))
                throw new FileNotFoundException("Difficulty text file not found.");
            difficultyText = File.ReadAllLines(workPath + @"/Text/difficulty.txt");
            if (!File.Exists(workPath + @"/Text/aquired.txt"))
                throw new FileNotFoundException("Aquired text file not found.");
            aquiredText = File.ReadAllLines(workPath + @"/Text/aquired.txt");
            if (!File.Exists(workPath + @"/Text/capacity.txt"))
                throw new FileNotFoundException("Capacity text file not found.");
            capacityText = File.ReadAllLines(workPath + @"/Text/capacity.txt");
        }

        private readonly string[] storyText, areaText, descriptionText, prefixText, weapSuffixText, equipSuffixText, oneLineText, twoLineText, difficultyText, aquiredText, capacityText; 

        private enum MessageType { STORY, ITEM_INFO, AREA, MISC, FILESCREEN };
        public override RandomizeResult Randomize(CancellationToken cancellationToken)
        {
            byte i;
            string newText;
            if (settings.ItemText)
            {
                for (i = 0; i < 0x16; i++)
                {
                    if (!((i == 0) | (i == 0x16)))
                    {
                        newText = CenterText(ItemStr(i));
                        WriteNewText(newText, i, MessageType.MISC);
                    }
                }

                for (i = 0; i < 0x13; i++)
                {
                    newText = FormatString(descriptionText[GetRandVal(descriptionText.Length)], 15);
                    WriteNewText(newText, i, MessageType.ITEM_INFO);
                }
            }
            
            if (settings.AreaText)
            {
                for (i = 0; i < 14; i++)
                {
                    newText = CenterText(FormatString(areaText[GetRandVal(areaText.Length)], 1));
                    WriteNewText(newText, i, MessageType.AREA);
                }
            }

            if (settings.MiscText)
            {
                for (i = 0x16; i < 0x26; i++)
                {
                    if (!((i == 0) | (i == 0x16)))
                    {
                        newText = CenterText(MiscStr(i));
                        WriteNewText(newText, i, MessageType.MISC);
                    }
                }

                for (i = 0; i < 0x25; i++)
                {
                    if ((i == 0x11) || (i == 0x12))
                    {
                        newText = FilescreenStr(i);
                        WriteNewText(newText, i, MessageType.FILESCREEN);
                    }
                }
            }

            if (settings.CutsceneText)
            {
                for (i = 0; i < 3; i++)
                {
                    newText = FormatString(storyText[GetRandVal(storyText.Length)], 9);
                    WriteNewText(newText, i, MessageType.STORY);
                }
            }

            return new RandomizeResult(true);
        }

        private void WriteNewText(string str, uint mNum, MessageType type)
        {
            byte[] values = Text.BytesFromText(str);
            int textAddress = rom.WriteToEnd(values);
            uint[] ptrAddress = { 0x7609F4, 0x7609A8, 0x7606FC, 0x760660, 0x760A0C }; //base address for message types
            uint num = ptrAddress[(int)type] + (mNum * 4);  //math to get message pointer address
            rom.WritePtr((int)num, textAddress);
        }

        //formats strings with newlines if the text is too long and special chars/strings. if line max count reached, ignore rest of text
        private string FormatString(string str, byte lines)
        {
            int length = 0;
            StringBuilder sb = new StringBuilder(str);
            for (int i = 0; (i < sb.Length) && (lines > 0); i++)
            {
                if (sb[i] == '\n')
                {
                    length = 0;
                    lines -= 1;
                    continue;
                }
                // bracketed expression
                if (sb[i] == '[')
                {
                    string temp = "[";
                    int j = 0;
                    do
                    {
                        j++;
                        temp += sb[i + j];
                    } while ((sb[i + j] != ']') && ((j + i) < sb.Length));
                    sb.Remove(i, temp.Length);  //remove expression 
                    switch (temp) 
                    {
                        case "[COLOR]":     //random color
                            char ch = (char)(0x8100 | (byte)rng.Next(3, 11));
                            sb.Insert(i, ch);
                            break;
                        case "[NEWLINE]":       //\n
                            sb.Insert(i, '\n');
                            lines -= 1;
                            length = 0;
                            break;
                        case "[WEAPON]":        //random weapon string
                            sb.Insert(i, ItemStr(0xA)); break;
                        case "[EQUIPMENT]":     //random equipment string
                            sb.Insert(i, ItemStr(0xC)); break;
                        case "[AREA]":          //random area name
                            sb.Insert(i, areaText[GetRandVal(areaText.Length)]); break;
                        case "[DIFFICULTY]":    //random difficulty name
                            sb.Insert(i, difficultyText[GetRandVal(difficultyText.Length)]); break;
                        case "[NUMBER]":        //random number from 0-100
                            sb.Insert(i, rng.Next(0, 101).ToString()); break;
                        case  "[WHITE]":          //set text to specific colors
                            sb.Insert(i, (char)(0x8104)); break;
                        case "[GREY]":
                            sb.Insert(i, (char)(0x8103)); break;
                        case "[LIGHTGREY]":
                            sb.Insert(i, (char)(0x8102)); break;
                        case "[YELLOW]":
                            sb.Insert(i, (char)(0x8105)); break;
                        case "[RED]":
                            sb.Insert(i, (char)(0x8106)); break;
                        case "[PINK]":
                            sb.Insert(i, (char)(0x8107)); break;
                        case "[GREEN]":
                            sb.Insert(i, (char)(0x8108)); break;
                        case "[BLUE]":
                            sb.Insert(i, (char)(0x8109)); break;
                        case "[TEAL]":
                            sb.Insert(i, (char)(0x810A)); break;
                        case "[UP]":            //codes for GBA buttons    
                            sb.Insert(i, (char)(0x300)); break;
                        case "[DOWN]":
                            sb.Insert(i, (char)(0x302)); break;
                        case "[LEFT]":
                            sb.Insert(i, (char)(0x304)); break;
                        case "[RIGHT]":
                            sb.Insert(i, (char)(0x306)); break;
                        case "[A]":
                            sb.Insert(i, (char)(0x308)); break;
                        case "[B]":
                            sb.Insert(i, (char)(0x30A)); break;
                        case "[L]":
                            sb.Insert(i, (char)(0x30C)); break; 
                        case "[R]":
                            sb.Insert(i, (char)(0x30E)); break;
                        case "[MECHA]":         //get name of replacement boss
                            sb.Insert(i, RandomBosses.GetBoss(RandomBosses.Bosses.Mecha)); break;
                        case "[RIDLEY]":
                            sb.Insert(i, RandomBosses.GetBoss(RandomBosses.Bosses.Ridley)); break;
                        case "[KRAID]":
                            sb.Insert(i, RandomBosses.GetBoss(RandomBosses.Bosses.Kraid)); break;
                        case "[LONG]":      //area of specificied item
                        case "[ICE]":
                        case "[WAVE]":
                        case "[CHARGE]":
                        case "[PLASMA]":
                        case "[VARIA]":
                        case "[GRAVITY]":
                        case "[HIJUMP]":
                        case "[SPEEDBOOSTER]":
                        case "[SPACEJUMP]":
                        case "[MORPH]":
                        case "[POWERGRIP]":
                        case "[SCREWATTACK]":
                        case "[BOMB]":
                        case "[WEAPONLOC]":
                        case "[EQUIPMENTLOC]":
                        case "[MAJORITEM]":
                            sb.Insert(i, ItemLocStr(temp)); break;
                        default:
                            break;
                    }
                    if (sb[i] == '[') //checks if inserted string has a bracketed expression
                         i--;
                    continue;
                }
                length += Text.GetCharWidth(rom, sb[i]);
                if (length >= 220)
                {
                    int j = 0;
                    while (sb[i - j] != ' ' && j < i)       //ensures newline does not occur mid-word
                        j++;
                    sb[i - j] = '\n'; 
                    lines -= 1;
                    i -= j;
                    length = 0;
                }
            }
            return sb.ToString();
        }

        private string FilescreenStr(byte mNum)
        {
            string str = "Difficulty Setting\n " + difficultyText[GetRandVal(difficultyText.Length)] + "\n " + difficultyText[GetRandVal(difficultyText.Length)];
            if (mNum == 0x12)
                str += "\n " + difficultyText[GetRandVal(difficultyText.Length)];
            return FormatString(str, 4);
        }

        private string ItemStr(byte val)
        {

            string str, str2;
            if (val <= 0xB)         //projectile item messages
            {
                if ((val >= 0x7 && val <= 0xB) | (val == 0x3) | (val == 0x5))   //true if beam message or first tank grab
                    return FormatString(prefixText[GetRandVal(prefixText.Length)] + weapSuffixText[GetRandVal(weapSuffixText.Length)], 1 );
                else if ((val == 2) | (val == 4) | (val == 6))              //true if tank grab
                {
                    str2 = ((prefixText[GetRandVal(prefixText.Length)] + weapSuffixText[GetRandVal(weapSuffixText.Length)]));
                    str = str2 + ' ' + aquiredText[GetRandVal(aquiredText.Length)] + "\n";
                    str += str2 + ' ' + capacityText[GetRandVal(capacityText.Length)];
                }
                else                    //true if message 1
                {
                    str2 = ((prefixText[GetRandVal(prefixText.Length)] + equipSuffixText[GetRandVal(equipSuffixText.Length)]));
                    str = str2 + ' ' + aquiredText[GetRandVal(aquiredText.Length)] + "\n";
                    str += str2 + ' ' + capacityText[GetRandVal(capacityText.Length)];
                }
                //this allows the tank names to be the same for both lines
                return FormatString(str, 2);
            }
            else      //other item messages
                return FormatString(prefixText[GetRandVal(prefixText.Length)] + equipSuffixText[GetRandVal(equipSuffixText.Length)], 1);
        }

        private string MiscStr(byte val)
        {
            if ((val == 0x17) | ((val <= 0x20) && (val >= 0x1B)))  //single line messages
                return FormatString(oneLineText[GetRandVal(oneLineText.Length)] , 1);
            else
                return FormatString(twoLineText[GetRandVal(twoLineText.Length)], 2);
        }

        private int GetRandVal(int maxVal) => rng.Next(0, maxVal);

        private string CenterText(string str)
        {
            if (str.Contains("\n"))        //splits two line messages and indents each
            {
                string[] splitStr = str.Split('\n');
                return (CenterText(splitStr[0]) + '\n' + CenterText(splitStr[1]));
            }
            int length = 0;
            foreach (char c in str)
                length += Text.GetCharWidth(rom, c);
            if (length >= 220)          //no indent needed if longer than 220
                return str;
            length = (((length + 220) / 2) - length);   //math to see size of indent
            char ch = (char)(0x8000 | (byte)length); //0x80XX, indent code + indent value
            str = str.Insert(0, ch.ToString());
            return str;

        }

        private string ItemLocStr(string str)
        {
            Location location = null;
            var items = Enum.GetValues(typeof(ItemType));
            if (!settings.SwapOrRemoveItems)  //if not randomized
                    return "its usual spot.";
            switch (str)
            {
                case "[LONG]":
                    location = RandomItems.FindItem(ItemType.Long); break;
                case "[ICE]":
                    location = RandomItems.FindItem(ItemType.Ice); break;
                case "[WAVE]":
                    location = RandomItems.FindItem(ItemType.Wave); break;
                case "[CHARGE]":
                    location = RandomItems.FindItem(ItemType.Charge); break;
                case "[PLASMA]":
                    location = RandomItems.FindItem(ItemType.Plasma); break;
                case "[VARIA]":
                    location = RandomItems.FindItem(ItemType.Varia); break;
                case "[GRAVITY]":
                    location = RandomItems.FindItem(ItemType.Gravity); break;
                case "[HIJUMP]":
                    location = RandomItems.FindItem(ItemType.Hi); break;
                case "[SPEEDBOOSTER]":
                    location = RandomItems.FindItem(ItemType.Speed); break;
                case "[SPACEJUMP]":
                    location = RandomItems.FindItem(ItemType.Space); break;
                case "[MORPH]":
                    location = RandomItems.FindItem(ItemType.Morph); break;
                case "[POWERGRIP]":
                    location = RandomItems.FindItem(ItemType.Grip); break;
                case "[SCREWATTACK]":
                    location = RandomItems.FindItem(ItemType.Screw); break;
                case "[BOMB]":
                    location = RandomItems.FindItem(ItemType.Bomb); break;
                case "[MAJORITEM]":
                    location = RandomItems.FindItem((ItemType)items.GetValue(rng.Next(6, items.Length))); break;
                case "[WEAPONLOC]":
                    location = RandomItems.FindItem((ItemType)items.GetValue(rng.Next(3, 12))); break;
                case "[EQUIPMENTLOC]":
                    location = RandomItems.FindItem((ItemType)items.GetValue(rng.Next(12, items.Length))); break;
            }
            if (location != null)
                return location.LogicName;
            else
                return "Another Seed";       //string for if item is removed/not found
        }

        public override string GetLog()
        {
            var changed = new List<string>();
            if (settings.ItemText)
                changed.Add("Items");
            if (settings.AreaText)
                changed.Add("Areas");
            if (settings.MiscText)
                changed.Add("Misc. Messages");
            if (settings.CutsceneText)
                changed.Add("Cutscene Messages");
            if (changed.Count == 0)
                return "Text: Unchanged" + Environment.NewLine;
            return "Text: " + string.Join(", ", changed) + Environment.NewLine;
        }
    }
}
