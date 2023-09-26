using mzmr.Utility;
using System;

namespace mzmr.Data
{
    public class Tilemap
    {
        private readonly ushort[] data;

        private readonly Rom rom;
        private readonly int pointer;
        private int origLen;
        private bool compressed;

        public ushort this[int i]
        {
            get { return data[i]; }
            set { data[i] = value; }
        }

        public Tilemap(Rom rom, int pointer, bool compressed = false)
        {
            this.rom = rom;
            this.pointer = pointer;
            this.compressed = compressed;

            if (compressed)
            {
                int offset = rom.ReadPtr(pointer);
                origLen = Compress.DecompLZ77(rom.Data, offset, out byte[] decompData);
                data = Arrays.ByteToUshort(decompData);
            }
            else
            {
                int offset = rom.ReadPtr(pointer);
                byte rows = rom.Read8(offset + 1);
                origLen = rows * 0x40 + 1;

                byte[] bytes = new byte[origLen * 2];
                rom.ReadBytes(bytes, offset, 0, bytes.Length);
                data = Arrays.ByteToUshort(bytes);
            }
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
            if (compressed)
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
            else
            {
                byte[] bytes = Arrays.UshortToByte(data);
                int offset = rom.ReadPtr(pointer);
                rom.WriteBytes(bytes, 0, offset, bytes.Length);
            }
        }

        public void WriteCopy(int newPointer)
        {
            int offset;

            if (compressed)
            {
                byte[] uncompData = Arrays.UshortToByte(data);
                byte[] compData = Compress.CompLZ77(uncompData);
                offset = rom.WriteToEnd(compData);
            }
            else
            {
                byte[] bytes = Arrays.UshortToByte(data);
                offset = rom.WriteToEnd(bytes);
            }

            rom.WritePtr(newPointer, offset);
        }

    }
}
