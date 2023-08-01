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

            public RGB(byte r, byte g, byte b)
            {
                R = r;
                G = g;
                B = b;
            }

            public static RGB FromLAB(LAB lab)
            {
                // convert to XYZ
                double Y = (lab.L + 16) / 116;
                double X = lab.A / 500 + Y;
                double Z = Y - lab.B / 200;

                // scale XYZ
                X = ScaleXYZ(X);
                Y = ScaleXYZ(Y);
                Z = ScaleXYZ(Z);

                // reference illuminant
                X *= 0.950489;
                // Y *= 1;
                Z *= 1.088840;

                // convert to RGB linear
                double rf = X * 3.2406 + Y * -1.5372 + Z * -0.4986;
                double gf = X * -0.9689 + Y * 1.8758 + Z * 0.0415;
                double bf = X * 0.0557 + Y * -0.2040 + Z * 1.0570;

                // gamma coorection
                rf = ScaleRGB(rf);
                gf = ScaleRGB(gf);
                bf = ScaleRGB(bf);

                int r = (int)Math.Round(rf * 31);
                int g = (int)Math.Round(gf * 31);
                int b = (int)Math.Round(bf * 31);

                return new RGB(
                    (byte)Math.Min(Math.Max(0, r), 31),
                    (byte)Math.Min(Math.Max(0, g), 31),
                    (byte)Math.Min(Math.Max(0, b), 31));
            }

            private static double ScaleXYZ(double value)
            {
                if (value > 0.206897)
                    return Math.Pow(value, 3);
                return (value - 0.137931) / 7.78704;
            }

            private static double ScaleRGB(double value)
            {
                if (value > 0.0031308)
                    return 1.055 * Math.Pow(value, 1 / 2.4) - 0.055;
                return value * 12.92;
            }

        }

        private struct LAB
        {
            private const double TwoPi = 2 * Math.PI;

            /// <summary>
            /// Gets the hue measured in radians. Ranges from -π to π.
            /// </summary>
            public double Hue => Math.Atan2(B, A);
            /// <summary>
            /// The intensity or purity of a color, i.e. how far it is from a
            /// neutral gray of the same lightness.
            /// </summary>
            public double Chroma => Math.Sqrt(A * A + B * B);

            public double L;
            public double A;
            public double B;

            public LAB(double l, double a, double b)
            {
                L = l;
                A = a;
                B = b;
            }

            public static LAB FromRGB(RGB rgb)
            {
                // conver to linear rgb
                double r = ScaleRGB(rgb.R / 31.0);
                double g = ScaleRGB(rgb.G / 31.0);
                double b = ScaleRGB(rgb.B / 31.0);

                // convert to XYZ
                double X = r * 0.4124 + g * 0.3576 + b * 0.1805;
                double Y = r * 0.2126 + g * 0.7152 + b * 0.0722;
                double Z = r * 0.0193 + g * 0.1192 + b * 0.9505;

                // reference illuminant
                X /= 0.950489;
                // Y /= 1;
                Z /= 1.088840;

                // scale XYZ
                X = ScaleXYZ(X);
                Y = ScaleXYZ(Y);
                Z = ScaleXYZ(Z);

                return new LAB(
                    116 * Y - 16,
                    500 * (X - Y),
                    200 * (Y - Z));
            }

            private static double ScaleRGB(double value)
            {
                if (value > 0.04045)
                    return Math.Pow((value + 0.055) / 1.055, 2.4);
                return value / 12.92;
            }

            private static double ScaleXYZ(double value)
            {
                if (value > 0.008856)
                    return Math.Pow(value, 0.333333);
                return (7.78704 * value) + 0.137931;
            }

            /// <summary>
            /// Shifts hue by the provided amount, measured in radians
            /// </summary>
            public LAB ShiftHue(double shift)
            {
                // get hue in range 0 to 2π
                double hue = Hue + Math.PI;
                hue = (hue + shift) % TwoPi;
                // put hue back in range -π to π
                hue -= Math.PI;

                // get new a* and b* values
                double chroma = Chroma;
                double a = chroma * Math.Cos(hue);
                double b = chroma * Math.Sin(hue);
                return new LAB(L, a, b);
            }

        }

        /// <summary>
        /// Shifts hue by the provided amount, measured in degrees
        /// </summary>
        public void ShiftHue(int shift)
        {
            // convert shift to radians
            double shiftRads = shift * (Math.PI / 180);

            for (int i = 0; i < data.Length; i++)
            {
                // get RGB
                ushort val = data[i];
                RGB rgb = new RGB(val);

                // get LAB and shift hue
                LAB lab = LAB.FromRGB(rgb);
                lab = lab.ShiftHue(shiftRads);

                // get new RGB
                rgb = RGB.FromLAB(lab);
                data[i] = rgb.Raw;
            }
        }

    }
}
