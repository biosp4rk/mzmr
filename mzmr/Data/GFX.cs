using mzmr.Utility;
using System;
using System.Drawing;

namespace mzmr.Data
{
    public class Gfx
    {
        public readonly byte[] Data;
        public readonly int Width;

        private readonly Rom rom;
        private readonly int pointer;
        private int origLen;

        public Gfx(Rom rom, int pointer, int width)
        {
            Width = width;
            this.rom = rom;
            this.pointer = pointer;

            // assume graphics compressed
            int offset = rom.ReadPtr(pointer);
            origLen = Compress.DecompLZ77(rom.Bytes, offset, out Data);
        }

        public Gfx(byte[] data, int width)
        {
            Data = data;
            Width = width;
        }

        public void AddGfx(Gfx srcGfx, int x, int y)
        {
            int dstByteWidth = Width * 0x20;
            int dstIndex = (y * dstByteWidth) + (x * 0x20);
            byte[] srcData = srcGfx.Data;
            int srcByteWidth = srcGfx.Width * 0x20;
            int srcHeight = srcData.Length / srcByteWidth;
            int srcIndex = 0;
            for (int j = 0; j < srcHeight; j++)
            {
                Array.Copy(srcData, srcIndex, Data, dstIndex, srcByteWidth);
                dstIndex += dstByteWidth;
                srcIndex += srcByteWidth;
            }
        }

        public void AddGfx(Gfx srcGfx, Rectangle srcRect, int x, int y)
        {
            int dstByteWidth = Width * 0x20;
            int dstIndex = (y * dstByteWidth) + (x * 0x20);
            byte[] srcData = srcGfx.Data;
            int srcByteWidth = srcGfx.Width * 0x20;
            int srcHeight = srcRect.Height;
            int copyLen = srcRect.Width * 0x20;
            int srcIndex = (srcRect.Y * srcByteWidth) + (srcRect.X * 0x20);
            for (int j = 0; j < srcHeight; j++)
            {
                Array.Copy(srcData, srcIndex, Data, dstIndex, copyLen);
                dstIndex += dstByteWidth;
                srcIndex += srcByteWidth;
            }
        }

        public void Write()
        {
            // compress data
            byte[] compData = Compress.CompLZ77(Data);
            int newLen = compData.Length;

            // write new data
            if (newLen <= origLen)
            {
                int offset = rom.ReadPtr(pointer);
                rom.ArrayToRom(compData, 0, offset, newLen);
            }
            else
            {
                int offset = rom.WriteToEnd(compData);
                rom.WritePtr(pointer, offset);
            }

            origLen = newLen;
        }

        public void WriteToEnd(Rom rom, int pointer)
        {
            // compress data
            byte[] compData = Compress.CompLZ77(Data);

            // write new data
            int offset = rom.WriteToEnd(compData);
            rom.WritePtr(pointer, offset);
        }

    }
}
