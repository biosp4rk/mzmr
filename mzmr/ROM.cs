using System;
using System.IO;
using System.Text;

namespace mzmr
{
    public class Rom
    {
        public int Size => Data.Length;
        public readonly byte[] Data;

        private int endOfData;

        // constructor
        public Rom(string filename)
        {
            Data = File.ReadAllBytes(filename);

            // check length
            if (Data.Length != 0x800000)
            {
                throw new IOException("File is not the correct size");
            }

            // check title and code
            string title = ReadAscii(0xA0, 0x10);
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
            ushort val = Read16(Rom.IntroTextOffset);
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
                if (Data[endOfData] != 0xFF) { break; }
            }
            endOfData++;
        }

        public void Save(string filename)
        {
            File.WriteAllBytes(filename, Data);
        }

        #region read/write

        public byte Read8(int offset)
        {
            return Data[offset];
        }

        public ushort Read16(int offset)
        {
            return (ushort)(Data[offset] | (Data[offset + 1] << 8));
        }

        public int Read32(int offset)
        {
            return Data[offset] | (Data[offset + 1] << 8) | (Data[offset + 2] << 16) | (Data[offset + 3] << 24);
        }

        public int ReadPtr(int offset)
        {
            return Data[offset] | (Data[offset + 1] << 8) | (Data[offset + 2] << 16) | ((Data[offset + 3] - 8) << 24);
        }

        private string ReadAscii(int offset, int len)
        {
            byte[] text = new byte[len];
            Array.Copy(Data, offset, text, 0, len);
            return Encoding.ASCII.GetString(text);
        }

        public void Write8(int offset, byte val)
        {
            Data[offset] = val;
        }

        public void Write16(int offset, ushort val)
        {
            Data[offset] = (byte)val;
            Data[offset + 1] = (byte)(val >> 8);
        }

        public void WritePtr(int offset, int val)
        {
            Data[offset] = (byte)val;
            Data[offset + 1] = (byte)(val >> 8);
            Data[offset + 2] = (byte)(val >> 16);
            Data[offset + 3] = (byte)((val >> 24) + 8);
        }

        public void RomToArray(byte[] dstData, int srcOffset, int dstOffset, int len)
        {
            Buffer.BlockCopy(Data, srcOffset, dstData, dstOffset, len);
        }

        public void ArrayToRom(byte[] srcData, int srcOffset, int dstOffset, int len)
        {
            Buffer.BlockCopy(srcData, srcOffset, Data, dstOffset, len);
        }

        public void Copy(int srcOffset, int dstOffset, int len)
        {
            Buffer.BlockCopy(Data, srcOffset, Data, dstOffset, len);
        }

        public int WriteToEnd(byte[] src)
        {
            int offset = endOfData;
            int length = src.Length;

            // write to end
            Buffer.BlockCopy(src, 0, Data, offset, length);

            // check if data ends with 0xFF
            endOfData = offset + length;
            if (Data[endOfData - 1] == 0xFF)
            {
                Data[endOfData++] = 0;
            }
            // align
            while (endOfData % 4 != 0)
            {
                Data[endOfData++] = 0;
            }

            return offset;
        }

        #endregion  

        public static int GetSpriteGfxPtr(byte spriteID)
        {
            return SpriteGfxOffset + (spriteID - 0x10) * 4;
        }

        public static int GetSpritePalettePtr(byte spriteID)
        {
            return SpritePaletteOffset + (spriteID - 0x10) * 4;
        }

        // constants
        public const int IntroTextOffset = 0x445CE4;

        public static string[] AreaNames =
        {
            "Brinstar", "Kraid", "Norfair", "Ridley", "Tourian", "Crateria", "Chozodia"
        };
        public static byte[] RoomsPerArea =
        {
            0x2A, 0x2A, 0x39, 0x21, 0x14, 0x16, 0x63
        };
        public const byte NumOfTilesets = 0x4F;
        public const byte NumOfAnimTilesets = 0x8;
        public const byte NumOfAnimGfx = 0x26;
        public const byte NumOfAnimPalettes = 0x12;
        public const byte NumOfSpritesets = 0x72;
        public const byte PiratePBSpriteID = 0xB5;

        public int TilesetOffset => ReadPtr(TilesetPtr);
        public int AnimTilesetOffset => ReadPtr(AnimTilesetPtr);
        public int AnimGfxOffset => ReadPtr(AnimGfxPtr);
        public int TileTable400Offset => ReadPtr(TileTable400Ptr);
        public const int AreaRoomEntryOffset = 0x75FAC4;
        public const int NumTanksPerAreaOffset = 0x3459A0;
        public const int TankCollectionInfoOffset = 0x3459A0;
        public const int SpriteGfxOffset = 0x75EBF8;
        public const int SpritePaletteOffset = 0x75EEF0;
        public const int SpritesetOffset = 0x75F31C;
        public const int AnimPaletteOffset = 0x35FBFC;
        public const int ChozoTargetOffset = 0x40DF78;
        public const int MinimapDataOffset = 0x7601EC;
        public const int CharWidthsOffset = 0x40D7B0;

        private const int TilesetPtr = 0x56250;
        private const int AnimTilesetPtr = 0x5E200;
        private const int AnimGfxPtr = 0x5E1F8;
        private const int TileTable400Ptr = 0x56318;

    }
}
