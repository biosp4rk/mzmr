using System;

namespace mzmr
{
    public class Minimap
    {
        // fields
        private ushort[,] map;

        public byte areaID;
        private int pointer;
        private int origLen;

        // constructor
        public Minimap(ROM rom, byte area)
        {
            this.areaID = area;

            try
            {
                // decompress map data
                pointer = ROM.MinimapDataOffset + areaID * 4;
                int mapDataOffset = rom.ReadPtr(pointer);
                byte[] mapData;
                origLen = Compress.DecompLZ77(rom.Bytes, mapDataOffset, out mapData);

                // convert to 2D ushort array
                map = new ushort[32, 32];
                int index = 0;
                for (int y = 0; y < 32; y++)
                {
                    for (int x = 0; x < 32; x++)
                    {
                        map[x, y] = (ushort)(mapData[index] | (mapData[index + 1] << 8));
                        index += 2;
                    }
                }
            }
            catch (IndexOutOfRangeException) { throw new Exception("Bad minimap data"); }
        }

        public void IncrementTile(byte x, byte y)
        {
            ushort val = map[x, y];
            map[x, y] = (ushort)((0xFC00 & val) | (0x3FF & (val + 1)));
        }

        public void Write(ROM rom)
        {
            // convert map squares to ByteStream
            byte[] uncomp = new byte[0x800];
            int index = 0;
            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    ushort val = map[x, y];
                    uncomp[index] = (byte)val;
                    uncomp[index + 1] = (byte)(val >> 8);
                    index += 2;
                }
            }

            // compress by LZ77
            byte[] dataToWrite;
            int newCompLen = Compress.CompLZ77(uncomp, 0x800, out dataToWrite);

            // write new data
            if (newCompLen <= origLen)
            {
                int offset = rom.ReadPtr(pointer);
                rom.ArrayToRom(dataToWrite, 0, offset, newCompLen);
            }
            else
            {
                int offset = rom.WriteToEnd(dataToWrite, newCompLen);
                rom.WritePtr(pointer, offset);
            }
        }


    }
}
