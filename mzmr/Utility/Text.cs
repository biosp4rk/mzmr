using System;
using System.Collections.Generic;

namespace mzmr.Utility
{
    public static class Text
    {
        public static byte[] BytesFromText(string text)
        {
            List<ushort> values = new List<ushort>();
            foreach (char c in text)
            {
                values.Add(GetCharValue(c));
            }
            values.Add(0xFF00);
            return Arrays.UshortToByte(values.ToArray());
        }

        private static ushort GetCharValue(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return (ushort)(c + 0x20);
            }
            if (c >= 'A' && c <= 'Z')
            {
                return (ushort)(c + 0x40);
            }
            if (c >= 'a' && c <= 'z')
            {
                return (ushort)(c + 0x60);
            }
            switch (c)
            {
                case '\n':  // newline
                    return 0xFE00;
                case ' ':  // space
                    return 0x40;
                case '-':  // dash
                    return 0x4D;
                case '.':  // period
                    return 0x4E;
                case ':':  // colon
                    return 0x5A;
                case '_':  // underscore
                    return 0x9F;
                default:
                    throw new FormatException("Invalid character");
            }
        }

        public static int GetCharWidth(ROM rom, char c)
        {
            ushort val = GetCharValue(c);
            return rom.Read8(ROM.CharWidthsOffset + val);
        }

    }
}
