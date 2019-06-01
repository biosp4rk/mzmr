using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace mzmr
{
    public class ROM
    {
        public int Size { get { return data.Length; } }
        public byte[] Bytes { get { return data; } }

        private byte[] data;
        private int endOfData;

        // constructor
        public ROM(string filename)
        {
            data = File.ReadAllBytes(filename);

            // check length
            if (data.Length != 0x800000)
            {
                throw new IOException("File is not the correct size");
            }

            // check title and code
            string title = ReadASCII(0xA0, 0x10);
            switch (title)
            {
                case "ZEROMISSIONEBMXE":
                    break;
                case "ZEROMISSIONPBMXP":
                    throw new IOException("The European (E) version is not compatible. Please use the North American (U) version.");
                case "ZEROMISSIONJBMXJ":
                    throw new IOException("The Japanese (J) version is not compatible. Please use the North American (U) version.");
                default:
                    throw new IOException("File is not a valid Metroid: Zero Mission ROM.");
            }

            // check if reusing randomized rom
            ushort val = Read16(ROM.InfoOffset);
            if (val == 0x8D)
            {
                throw new IOException("ROM has already been randomized. Please use an unmodified ROM.");
            }

            FindEndOfData();
        }

        public void FindEndOfData()
        {
            endOfData = 0x7D8000;

            while (endOfData > 0)
            {
                endOfData--;
                if (data[endOfData] != 0xFF) { break; }
            }
            endOfData++;
        }

        public void Save(string filename)
        {
            File.WriteAllBytes(filename, data);
        }

        #region read/write

        public byte Read8(int offset)
        {
            return data[offset];
        }

        public ushort Read16(int offset)
        {
            return (ushort)(data[offset] | (data[offset + 1] << 8));
        }

        public int Read32(int offset)
        {
            return data[offset] | (data[offset + 1] << 8) | (data[offset + 2] << 16) | (data[offset + 3] << 24);
        }

        public int ReadPtr(int offset)
        {
            return data[offset] | (data[offset + 1] << 8) | (data[offset + 2] << 16) | ((data[offset + 3] - 8) << 24);
        }

        private string ReadASCII(int offset, int len)
        {
            byte[] text = new byte[len];
            Array.Copy(data, offset, text, 0, len);
            return Encoding.ASCII.GetString(text);
        }

        public void Write8(int offset, byte val)
        {
            data[offset] = val;
        }

        public void Write16(int offset, ushort val)
        {
            data[offset] = (byte)val;
            data[offset + 1] = (byte)(val >> 8);
        }

        public void WritePtr(int offset, int val)
        {
            data[offset] = (byte)val;
            data[offset + 1] = (byte)(val >> 8);
            data[offset + 2] = (byte)(val >> 16);
            data[offset + 3] = (byte)((val >> 24) + 8);
        }

        public void RomToArray(Array dstData, int srcOffset, int dstOffset, int len)
        {
            Buffer.BlockCopy(data, srcOffset, dstData, dstOffset, len);
        }

        public void ArrayToRom(Array srcData, int srcOffset, int dstOffset, int len)
        {
            Buffer.BlockCopy(srcData, srcOffset, data, dstOffset, len);
        }

        public void Copy(int srcOffset, int dstOffset, int len)
        {
            Buffer.BlockCopy(data, srcOffset, data, dstOffset, len);
        }

        public int WriteToEnd(Array src, int length)
        {
            int offset = endOfData;

            // write to end
            Buffer.BlockCopy(src, 0, data, offset, length);

            // check if data ends with 0xFF
            endOfData = offset + length;
            if (data[endOfData - 1] == 0xFF)
            {
                data[endOfData++] = 0;
            }
            // align
            while (endOfData % 4 != 0)
            {
                data[endOfData++] = 0;
            }

            return offset;
        }

        #endregion  


        // constants
        public const int InfoOffset = 0x445CE4;

        public readonly string[] AreaNames =
        {
            "Brinstar", "Kraid", "Norfair", "Ridley", "Tourian", "Crateria", "Chozodia"
        };
        public const byte NumOfTilesets = 0x4F;
        public const byte NumOfAnimTilesets = 0x8;
        public const byte NumOfAnimGfx = 0x26;
        public const byte NumOfAnimPalettes = 0x12;
        public const byte NumOfSpritesets = 0x72;
        public const byte PiratePBSpriteID = 0xB5;

        public int TilesetOffset { get { return ReadPtr(TilesetPtr); } }
        public int AnimTilesetOffset { get { return ReadPtr(AnimTilesetPtr); } }
        public int AnimGfxOffset { get { return ReadPtr(AnimGfxPtr); } }
        public int TileTable400Offset { get { return ReadPtr(TileTable400Ptr); } }
        public const int AreaHeaderOffset = 0x75FAC4;
        public const int NumTanksPerAreaOffset = 0x3459A0;
        public const int TankCollectionInfoOffset = 0x3459A0;
        public const int SpriteGfxOffset = 0x75EBF8;
        public const int SpritePaletteOffset = 0x75EEF0;
        public const int SpritesetOffset = 0x75F31C;
        public const int AnimPaletteOffset = 0x35FBFC;
        public const int ChozoTargetOffset = 0x40DF78;
        public const int MinimapDataOffset = 0x7601EC;

        private const int TilesetPtr = 0x56250;
        private const int AnimTilesetPtr = 0x5E200;
        private const int AnimGfxPtr = 0x5E1F8;
        private const int TileTable400Ptr = 0x56318;

    }
}
