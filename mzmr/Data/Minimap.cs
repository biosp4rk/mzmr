﻿using mzmr.Utility;
using System;

namespace mzmr.Data
{
    public class Minimap
    {
        public readonly byte AreaID;
        private readonly ushort[] data;

        private readonly Rom rom;
        private readonly int pointer;
        private int origLen;

        // constructor
        public Minimap(Rom rom, byte areaID)
        {
            this.rom = rom;
            AreaID = areaID;

            try
            {
                // decompress map data
                pointer = Rom.MinimapDataOffset + AreaID * 4;
                int offset = rom.ReadPtr(pointer);
                origLen = Compress.DecompLZ77(rom.Data, offset, out byte[] decompData);
                data = Arrays.ByteToUshort(decompData);
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
            byte[] uncompData = Arrays.UshortToByte(data);
            byte[] compData = Compress.CompLZ77(uncompData);
            int newLen = compData.Length;

            // write new data
            if (newLen <= origLen)
            {
                int offset = rom.ReadPtr(pointer);
                rom.WriteBytes(compData, 0, offset, newLen);
            }
            else
            {
                int offset = rom.WriteToEnd(compData);
                rom.WritePtr(pointer, offset);
            }

            origLen = newLen;
        }

    }
}
