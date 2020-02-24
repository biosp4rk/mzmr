using System;

namespace mzmr.Data
{
    public class Palette
    {
        private int Rows => palette.Length / 16;

        private readonly ushort[,] palette;

        private readonly ROM rom;
        private readonly int addr;

        public Palette(ROM rom, int offset, int len)
        {
            this.rom = rom;
            this.addr = offset;
            palette = new ushort[len, 16];

            for (int r = 0; r < len; r++)
            {
                for (int c = 0; c < 16; c++)
                {
                    ushort val = rom.Read16(offset);
                    palette[r, c] = val;
                    offset += 2;
                }
            }
        }

        public void Write()
        {
            int offset = addr;
            int rows = this.Rows;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < 16; c++)
                {
                    ushort val = palette[r, c];
                    rom.Write16(offset, val);
                    offset += 2;
                }
            }
        }

        private struct RGB
        {
            public byte R;
            public byte G;
            public byte B;

            public ushort Raw { get { return (ushort)(R | (G << 5) | (B << 10)); } }

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

            public double Luma
            {
                get { return 0.316 * R + 0.460 * G + 0.224 * B; }
            }

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
                    {
                        H = 60 * ((((G - B) / range) + 6) % 6);
                    }
                }
                else if (G >= R && G >= B)
                {
                    min = Math.Min(R, B);
                    range = G - min;
                    L = (G + min) / 2;
                    if (range == 0) { H = 0; }
                    else
                    {
                        H = 60 * (((B - R) / range) + 2);
                    }
                }
                else
                {
                    min = Math.Min(R, G);
                    range = B - min;
                    L = (B + min) / 2;
                    if (range == 0) { H = 0; }
                    else
                    {
                        H = 60 * (((R - G) / range) + 4);
                    }
                }

                if (range == 0) { S = 0; }
                else
                {
                    S = range / (1 - Math.Abs(2 * L - 1));
                }
            }
        }

        public void ShiftHue(int shift)
        {
            int rows = this.Rows;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < 16; c++)
                {
                    // get RGB
                    ushort val = palette[r, c];
                    RGB rgb = new RGB(val);
                    double origLuma = rgb.Luma;

                    // shift hue
                    HSL hsl = new HSL(rgb);
                    hsl.H = (hsl.H + shift) % 360;

                    // get new RGB
                    rgb = new RGB(hsl);
                    double newLuma = rgb.Luma;
                    rgb *= (origLuma / newLuma);
                    palette[r, c] = rgb.Raw;
                }
            }
        }

    }
}
