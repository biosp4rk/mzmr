using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace mzmr.Utility
{
    public class ByteStream
    {
        // properties
        public byte[] Data { get { return data; } }
        public int Position { get { return pos; } }
        public int Length { get { return length; } }
        private int Capacity
        {
            get { return data.Length; }
            set { Array.Resize(ref data, value); }
        }

        // fields
        private const int size32mb = 0x2000000;

        private byte[] data;
        private int pos;
        private int length;

        // constructors
        public ByteStream(int capacity = 4)
        {
            data = new byte[capacity];
            pos = 0;
            length = 0;
        }

        public ByteStream(byte[] data)
        {
            this.data = data;
            pos = 0;
            length = data.Length;
        }

        // methods
        private void Resize()
        {
            // double capacity until greater than length
            int newCapacity = Capacity * 2;
            while (length > newCapacity)
            {
                newCapacity *= 2;
            }

            // check if over 32 MB
            if (newCapacity > size32mb)
            {
                if (length <= size32mb)
                {
                    newCapacity = size32mb;
                }
                else
                {
                    // TODO: throw exception
                    return;
                }
            }

            Capacity = newCapacity;
        }

        public void Seek(int offset)
        {
            pos = offset;
        }

        public void Align(int remainder = 4)
        {
            while (pos % remainder != 0)
            {
                pos++;
            }
        }

        #region value read/write

        public byte Read8()
        {
            return data[pos++];
        }

        public ushort Read16()
        {
            if (pos % 2 != 0) { pos++; }

            ushort val = (ushort)(data[pos] | (data[pos + 1] << 8));
            pos += 2;
            return val;
        }

        public int Read32()
        {
            int remainder = pos % 4;
            if (remainder != 0)
            {
                pos += 4 - remainder;
            }

            int val = data[pos] | (data[pos + 1] << 8) | (data[pos + 2] << 16) | (data[pos + 3] << 24);
            pos += 4;
            return val;
        }

        public int ReadPtr()
        {
            int remainder = pos % 4;
            if (remainder != 0)
            {
                pos += 4 - remainder;
            }

            int val = data[pos] | (data[pos + 1] << 8) | (data[pos + 2] << 16) | ((data[pos + 3] - 8) << 24);
            pos += 4;
            return val;
        }

        public string ReadASCII(int len)
        {
            byte[] text = new byte[len];
            Array.Copy(data, pos, text, 0, len);
            string str = Encoding.ASCII.GetString(text);

            pos += len;
            return str;
        }

        public void Write8(byte val)
        {
            if (pos >= length)
            {
                length = pos + 1;
                if (length > Capacity)
                {
                    Resize();
                }
            }

            data[pos++] = val;
        }

        public void Write16(ushort val)
        {
            if (pos % 2 != 0) { Write8(0); }

            if (pos + 2 > length)
            {
                length = pos + 2;
                if (length > Capacity)
                {
                    Resize();
                }
            }

            data[pos] = (byte)val;
            data[pos + 1] = (byte)(val >> 8);
            pos += 2;
        }

        public void Write32(int val, bool align = true)
        {
            if (align)
            {
                while (pos % 4 != 0) { Write8(0); }
            }

            if (pos + 4 > length)
            {
                length = pos + 4;
                if (length > Capacity)
                {
                    Resize();
                }
            }

            data[pos] = (byte)val;
            data[pos + 1] = (byte)(val >> 8);
            data[pos + 2] = (byte)(val >> 16);
            data[pos + 3] = (byte)(val >> 24);
            pos += 4;
        }

        public void WritePtr(int val)
        {
            while (pos % 4 != 0) { Write8(0); }

            if (pos + 4 > length)
            {
                length = pos + 4;
                if (length > Capacity)
                {
                    Resize();
                }
            }

            data[pos] = (byte)val;
            data[pos + 1] = (byte)(val >> 8);
            data[pos + 2] = (byte)(val >> 16);
            data[pos + 3] = (byte)((val >> 24) + 8);
            pos += 4;
        }

        public void WriteASCII(string str)
        {
            byte[] text = Encoding.ASCII.GetBytes(str);
            int textLen = text.Length;

            if (pos + textLen > length)
            {
                length = pos + textLen;
                if (length > Capacity)
                {
                    Resize();
                }
            }

            Array.Copy(text, 0, data, pos, textLen);
            pos += textLen;
        }

        #endregion

        #region value read/write (offset)

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

        public string ReadASCII(int offset, int len)
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

        public void Write32(int offset, int val)
        {
            data[offset] = (byte)val;
            data[offset + 1] = (byte)(val >> 8);
            data[offset + 2] = (byte)(val >> 16);
            data[offset + 3] = (byte)(val >> 24);
        }

        public void WritePtr(int offset, int val)
        {
            data[offset] = (byte)val;
            data[offset + 1] = (byte)(val >> 8);
            data[offset + 2] = (byte)(val >> 16);
            data[offset + 3] = (byte)((val >> 24) + 8);
        }

        public void WriteASCII(int offset, string str)
        {
            byte[] text = Encoding.ASCII.GetBytes(str);
            Array.Copy(text, 0, data, offset, text.Length);
        }

        #endregion

        #region data read/write

        public void CopyToArray(int srcOffset, Array dstData, int dstOffset, int len)
        {
            Buffer.BlockCopy(data, srcOffset, dstData, dstOffset, len);
        }

        public void CopyFromArray(Array srcData, int srcOffset, int dstOffset, int len)
        {
            Buffer.BlockCopy(srcData, srcOffset, data, dstOffset, len);
        }

        public void OverlappingCopy(int amount, int window)
        {
            if (pos + amount > length)
            {
                length = pos + amount;
                if (length > Capacity)
                {
                    Resize();
                }
            }

            for (int i = 0; i < amount; i++)
            {
                data[pos] = data[pos - window];
                pos++;
            }

        }
        #endregion
    }
}
