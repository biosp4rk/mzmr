﻿using mzmr.Utility;
using System;

namespace mzmr.Data
{
    public class Minimap
    {
        public readonly byte AreaID;
        private readonly ushort[] data;

        private readonly ROM rom;
        private readonly int pointer;
        private int origLen;

        // constructor
        public Minimap(ROM rom, byte areaID)
        {
            this.rom = rom;
            AreaID = areaID;

            try
            {
                // decompress map data
                pointer = ROM.MinimapDataOffset + AreaID * 4;
                int offset = rom.ReadPtr(pointer);
                origLen = Compress.DecompLZ77(rom.Bytes, offset, out byte[] decompData);
                // copy to ushort array
                data = new ushort[0x400];
                Buffer.BlockCopy(decompData, 0, data, 0, decompData.Length);
            }
            catch (IndexOutOfRangeException)
            {
                throw new Exception("Bad minimap data");
            }
        }

        public void IncrementTile(int x, int y)
        {
            int index = y * 32 + x;
            ushort val = data[index];
            data[index] = (ushort)((0xFC00 & val) | (0x3FF & (val + 1)));
        }

        public void Write()
        {
            // compress data
            byte[] uncompData = new byte[data.Length * 2];
            Buffer.BlockCopy(data, 0, uncompData, 0, uncompData.Length);
            int newLen = Compress.CompLZ77(uncompData, 0x800, out byte[] compData);

            // write new data
            if (newLen <= origLen)
            {
                int offset = rom.ReadPtr(pointer);
                rom.ArrayToRom(compData, 0, offset, newLen);
            }
            else
            {
                int offset = rom.WriteToEnd(compData, newLen);
                rom.WritePtr(pointer, offset);
            }

            origLen = newLen;
        }

    }
}
