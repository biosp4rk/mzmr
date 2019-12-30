using System;
using System.Collections.Generic;

namespace mzmr
{
    public static class Text
    {
        public static ushort[] BytesFromText(string text)
        {
            List<ushort> values = new List<ushort>();
            foreach (char c in text)
            {
                values.Add(GetCharValue(c));
            }
            values.Add(0xFF00);
            return values.ToArray();
        }

        private static ushort GetCharValue(char c)
        {
            byte ascii = Convert.ToByte(c);

            if (ascii >= 48 && ascii <= 57)
            {
                // digit
                return (ushort)(ascii + 0x20);
            }
            if (ascii >= 65 && ascii <= 90)
            {
                // uppercase letters
                return (ushort)(ascii + 0x40);
            }
            if (ascii >= 97 && ascii <= 122)
            {
                // lowercase letters
                return (ushort)(ascii + 0x60);
            }
            switch (ascii)
            {
                case 10:  // newline
                    return 0xFE00;
                case 32:  // space
                    return 0x40;
                case 45:  // dash
                    return 0x4D;
                case 46:  // period
                    return 0x4E;
                case 58:  // colon
                    return 0x5A;
                case 95:  // underscore
                    return 0x9F;
                default:
                    throw new FormatException("Invalid character");
            }
        }


    }
}
