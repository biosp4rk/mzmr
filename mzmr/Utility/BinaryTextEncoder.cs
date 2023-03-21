using System;
using System.Collections.Generic;
using System.Text;

namespace mzmr.Utility
{
    public abstract class BinaryTextEncoder
    {
        protected List<byte> data;
        protected int index;
        protected int bitPosition;

    }

    public class BinaryTextReader : BinaryTextEncoder
    {
        public BinaryTextReader(string settings)
        {
            byte sum1 = CharToData(settings[0]);
            byte sum2 = CharToData(settings[1]);
            settings = settings.Substring(2);

            data = new List<byte>();
            index = -1;
            bitPosition = 0;

            // get data
            foreach (char ch in settings)
                data.Add(CharToData(ch));

            // verify checksum
            int calcSum1 = 1;
            int calcSum2 = 1;
            foreach (byte val in data)
            {
                calcSum1 += val;
                calcSum2 += calcSum1;
            }

            if (sum1 != (calcSum1 % 64) || sum2 != (calcSum2 % 64))
                throw new FormatException();
        }

        public bool ReadBool()
        {
            if (bitPosition == 0)
                index++;

            int bitFlag = 1 << bitPosition;
            bitPosition = (bitPosition + 1) % 6;
            return (data[index] & bitFlag) != 0;
        }

        public int ReadNumber(int numOfBits)
        {
            int val = 0;

            for (int i = numOfBits - 1; i >= 0; i--)
            {
                if (ReadBool())
                    val |= (1 << i);
            }

            return val;
        }

        public string ReadString(int length)
        {
            byte[] ascii = new byte[length];

            for (int i = 0; i < length; i++)
                ascii[i] = (byte)ReadNumber(8);

            return Encoding.ASCII.GetString(ascii);
        }

        private byte CharToData(char ch)
        {
            if (ch >= 'A' && ch <= 'Z')
                return (byte)(ch - 65);
            if (ch >= 'a' && ch <= 'z')
                return (byte)(ch - 71);
            if (ch >= '0' && ch <= '9')
                return (byte)(ch + 4);
            if (ch == '-')
                return 62;
            if (ch == '_')
                return 63;
            
            throw new FormatException($"Character '{ch}' is not valid.");
        }

    }

    public class BinaryTextWriter : BinaryTextEncoder
    {
        public BinaryTextWriter()
        {
            data = new List<byte>();
            index = -1;
            bitPosition = 0;
        }

        public void AddBool(bool val)
        {
            if (bitPosition == 0)
            {
                data.Add(0);
                index++;
            }

            if (val == true)
            {
                byte bitFlag = (byte)(1 << bitPosition);
                data[index] |= bitFlag;
            }

            bitPosition = (bitPosition + 1) % 6;
        }

        public void AddNumber(int val, int numOfBits)
        {
            for (int i = numOfBits - 1; i >= 0; i--)
            {
                bool bitSet = ((val >> i) & 1) == 1;
                AddBool(bitSet);
            }
        }

        public void AddString(string str)
        {
            byte[] ascii = Encoding.ASCII.GetBytes(str);
            foreach (byte b in ascii)
                AddNumber(b, 8);
        }

        public string GetOutputString()
        {
            // insert checksum
            int sum1 = 1;
            int sum2 = 1;
            foreach (byte val in data)
            {
                sum1 += val;
                sum2 += sum1;
            }

            byte[] output = new byte[data.Count + 2];
            int index = 0;
            output[index++] = DataToChar((byte)(sum1 % 64));
            output[index++] = DataToChar((byte)(sum2 % 64));

            foreach (byte val in data)
            {
                byte ascii = DataToChar(val);
                output[index++] = ascii;
            }

            return Encoding.ASCII.GetString(output);
        }

        private byte DataToChar(byte val)
        {
            if (val < 26)
                return (byte)(val + 65);
            if (val < 52)
                return (byte)(val + 71);
            if (val < 62)
                return (byte)(val - 4);
            if (val == 62)
                return 45;
            if (val == 63)
                return 95;

            throw new FormatException();
        }

    }

}