using mzmr.Utility;
using System;

namespace mzmr.Data
{
    public class TileTable
    {
        private readonly ushort[] data;

        private readonly ROM rom;
        private readonly int pointer;
        private int origLen;

        public TileTable(ROM rom, int pointer)
        {
            this.rom = rom;
            this.pointer = pointer;

            // assume tile table is compressed
            int offset = rom.ReadPtr(pointer);
            origLen = Compress.DecompLZ77(rom.Bytes, offset, out byte[] decompData);
            data = new ushort[decompData.Length * 2];
            Buffer.BlockCopy(decompData, 0, data, 0, decompData.Length);
        }

        public void SetTileNumber(int tileNum, int x, int y)
        {
            int index = y * 32 + x;
            data[index] = (ushort)((data[index] & 0xFC00) | (tileNum & 0x3FF));
        }

        public void SetPalette(int pal, int x, int y)
        {
            int index = y * 32 + x;
            data[index] = (ushort)((data[index] & 0xFFF) | ((pal & 0xF) << 12));
        }

        public void Write()
        {
            // compress data
            byte[] uncompData = new byte[data.Length * 2];
            Buffer.BlockCopy(data, 0, uncompData, 0, uncompData.Length);
            int newLen = Compress.CompLZ77(uncompData, uncompData.Length, out byte[] compData);

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
