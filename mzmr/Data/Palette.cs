using mzmr.Utility;
using System;

namespace mzmr.Data
{
    public class Palette
    {
        private ushort[] data;

        private Rom rom;
        private int address;
        private int? pointer;
        private int origLen;

        public Palette(Rom rom, int offset, int rows, int? pointer = null)
        {
            this.rom = rom;
            address = offset;
            this.pointer = pointer;
            data = new ushort[rows * 16];

            for (int i = 0; i < data.Length; i++)
            {
                ushort val = rom.Read16(offset);
                data[i] = val;
                offset += 2;
            }

            origLen = rows * 32;
        }

        public Palette(byte[] data)
        {
            this.data = Arrays.ByteToUshort(data);
        }

        public void AppendPalette(Palette toAppend)
        {
            int prevLen = data.Length;
            int addedLen = toAppend.data.Length;
            Array.Resize(ref data, prevLen + addedLen);
            Array.Copy(toAppend.data, 0, data, prevLen, addedLen);
        }

        public ushort GetColor(int row, int index)
        {
            return data[row * 16 + index];
        }

        public void CopyRows(Palette src, int srcRow, int dstRow, int numRows)
        {
            Array.Copy(src.data, srcRow * 16, data, dstRow * 16, numRows * 16);
        }

        public void Write()
        {
            int newLen = data.Length * 2;
            byte[] toWrite = Arrays.UshortToByte(data);

            if (newLen <= origLen)
                rom.WriteBytes(toWrite, 0, address, toWrite.Length);
            else
            {
                address = rom.WriteToEnd(toWrite);
                rom.WritePtr(pointer.Value, address);
            }

            origLen = newLen;
        }

        public void Write(Rom rom, int ptr)
        {
            int offset = rom.ReadPtr(ptr);
            foreach (ushort val in data)
            {
                rom.Write16(offset, val);
                offset += 2;
            }
        }

        public void WriteCopy(int newPointer)
        {
            byte[] toWrite = Arrays.UshortToByte(data);
            int offset = rom.WriteToEnd(toWrite);
            rom.WritePtr(newPointer, offset);
        }

        private struct RGB
        {
            public byte R;
            public byte G;
            public byte B;

            public ushort Raw => (ushort)(R | (G << 5) | (B << 10));

            public RGB(ushort val)
            {
                R = (byte)(val & 0x1F);
                G = (byte)((val >> 5) & 0x1F);
                B = (byte)((val >> 10) & 0x1F);
            }

            public RGB(HSL hsl)
            {
                double C = (1 - Math.Abs(2 * hsl.L - 1)) * hsl.S;
                double X = C * (1 - Math.Abs((hsl.H / 60) % 2 - 1));
                double m = hsl.L - (C / 2);

                double r, g, b;
                switch ((int)hsl.H / 60)
                {
                    case 0:
                        r = C; g = X; b = 0;
                        break;
                    case 1:
                        r = X; g = C; b = 0;
                        break;
                    case 2:
                        r = 0; g = C; b = X;
                        break;
                    case 3:
                        r = 0; g = X; b = C;
                        break;
                    case 4:
                        r = X; g = 0; b = C;
                        break;
                    case 5:
                        r = C; g = 0; b = X;
                        break;
                    default:
                        r = 0; g = 0; b = 0;
                        break;
                }

                R = (byte)((r + m) * 31);
                G = (byte)((g + m) * 31);
                B = (byte)((b + m) * 31);
            }

            public double Luma => 0.316 * R + 0.460 * G + 0.224 * B;

            public static RGB operator *(RGB rgb, double factor)
            {
                rgb.R = (byte)Math.Min(rgb.R * factor, 31);
                rgb.G = (byte)Math.Min(rgb.G * factor, 31);
                rgb.B = (byte)Math.Min(rgb.B * factor, 31);
                return rgb;
            }
        }

        private struct HSL
        {
            public double H;
            public double S;
            public double L;

            public HSL(RGB rgb)
            {
                // get HSL
                double R = rgb.R / 31.0;
                double G = rgb.G / 31.0;
                double B = rgb.B / 31.0;

                double min, range;
                if (R >= G && R >= B)
                {
                    min = Math.Min(G, B);
                    range = R - min;
                    L = (R + min) / 2;
                    if (range == 0) { H = 0; }
                    else
                        H = 60 * ((((G - B) / range) + 6) % 6);
                }
                else if (G >= R && G >= B)
                {
                    min = Math.Min(R, B);
                    range = G - min;
                    L = (G + min) / 2;
                    if (range == 0) { H = 0; }
                    else
                        H = 60 * (((B - R) / range) + 2);
                }
                else
                {
                    min = Math.Min(R, G);
                    range = B - min;
                    L = (B + min) / 2;
                    if (range == 0) { H = 0; }
                    else
                        H = 60 * (((R - G) / range) + 4);
                }

                if (range == 0) { S = 0; }
                else
                    S = range / (1 - Math.Abs(2 * L - 1));
            }
        }

        public void ShiftHue(int shift)
        {
            for (int i = 0; i < data.Length; i++)
            {
                // get RGB
                ushort val = data[i];
                RGB rgb = new RGB(val);
                double origLuma = rgb.Luma;

                // shift hue
                HSL hsl = new HSL(rgb);
                hsl.H = (hsl.H + shift) % 360;

                // get new RGB
                rgb = new RGB(hsl);
                double newLuma = rgb.Luma;
                rgb *= (origLuma / newLuma);
                data[i] = rgb.Raw;
            }
        }

    }
}
