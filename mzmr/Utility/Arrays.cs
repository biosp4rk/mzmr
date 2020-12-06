using System;
using System.Collections.Generic;

namespace mzmr.Utility
{
    public static class Arrays
    {
        public static ushort[] ByteToUshort(byte[] bytes)
        {
            ushort[] ushorts = new ushort[bytes.Length / 2];
            int j = 0;
            for (int i = 0; i < bytes.Length; i += 2)
            {
                ushort val = (ushort)(bytes[i] | (bytes[i + 1] << 8));
                ushorts[j++] = val;
            }
            return ushorts;
        }

        public static byte[] UshortToByte(ushort[] ushorts)
        {
            byte[] bytes = new byte[ushorts.Length * 2];
            int i = 0;
            foreach (ushort val in ushorts)
            {
                bytes[i++] = (byte)val;
                bytes[i++] = (byte)(val >> 8);
            }
            return bytes;
        }

        public static string[] IntRange(int end)
        {
            string[] strings = new string[end];
            for (int i = 0; i < end; i++)
            {
                strings[i] = i.ToString();
            }
            return strings;
        }

    }
}
