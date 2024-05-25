using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace mzmr.Utility
{
    public static class Patch
    {
        public static void Apply(Rom rom, byte[] data)
        {
            // check sig
            int patchLen = data.Length;
            if (patchLen < 8 || data[0] != 'P' || data[1] != 'A' ||
                data[2] != 'T' || data[3] != 'C' || data[4] != 'H')
                throw new Exception("Not a valid IPS file.");

            // records
            int offset = 5;
            while (offset + 2 < patchLen)
            {
                int writeOffset = (data[offset] << 16) | (data[offset + 1] << 8) | data[offset + 2];
                if (writeOffset == 0x454F46)
                {
                    // EOF
                    return;
                }
                offset += 3;
                if (offset + 1 >= patchLen)
                    throw new Exception("Abrupt end to IPS file, entry cut off before size.");
                int size = (data[offset] << 8) | data[offset + 1];
                offset += 2;
                if (size == 0)
                {
                    // RLE
                    if (offset + 1 >= patchLen)
                        throw new Exception("Abrupt end to IPS file, entry cut off before RLE size.");
                    int rleSize = (data[offset] << 8) | data[offset + 1];
                    if (writeOffset + rleSize > rom.Size)
                        throw new Exception("Trying to patch data past the end of the ROM file.");
                    offset += 2;
                    if (offset >= patchLen)
                        throw new Exception("Abrupt end to IPS file, entry cut off before RLE byte.");
                    byte rleByte = data[offset++];
                    for (int i = writeOffset; i < writeOffset + rleSize; i++)
                        rom.Write8(i, rleByte);
                }
                else
                {
                    if (offset + size > patchLen)
                        throw new Exception("Abrupt end to IPS file, entry cut off before end of data block.");
                    if (writeOffset + size > rom.Size)
                        throw new Exception("Trying to patch data past the end of the ROM file");
                    rom.WriteBytes(data, offset, writeOffset, size);
                    offset += size;
                }
            }
            throw new Exception("Improperly terminated IPS file.");
        }

        public static void ApplyUPS(Rom rom, byte[] data)
        {
            List<ulong> changedOffsetsList = new List<ulong>();
            List<byte[]> XORbytesList = new List<byte[]>();
            int offset = 4;
            if (data[0] != 'U' || data[1] != 'P' || data[2] != 'S' || data[3] != '1')
                throw new Exception("Not a valid UPS file.");
            ulong oldFileSize = Decrypt(ref offset, data);
            ulong newFileSize = Decrypt(ref offset, data);

            //body
            ulong filePosition = 0;
            while (offset < data.Length - 12)
            {
                filePosition += Decrypt(ref offset, data);
                changedOffsetsList.Add(filePosition);
                List<byte> newXORdata = new List<byte>();

                while (data[offset] != 0)
                {
                    newXORdata.Add(data[offset++]);
                }
                XORbytesList.Add(newXORdata.ToArray());
                filePosition += (ulong)newXORdata.Count + 1;
                offset++;
            }
            ulong[] changedOffsets = changedOffsetsList.ToArray();
            byte[][] XORbytes = XORbytesList.ToArray();

            ulong lenght = (ulong)rom.Data.Length;
            if (lenght < newFileSize)
                lenght = newFileSize;

            byte[] result = new byte[lenght];
            Buffer.BlockCopy(rom.Data, 0, result, 0, Math.Min(rom.Data.Length, result.Length));

            for (int i = 0; i < changedOffsets.LongLength; i++)
                for (ulong u = 0; u < (ulong)XORbytes[i].LongLength; u++)
                    result[changedOffsets[i] + u] ^= XORbytes[i][u];
            rom.Data = result;

        }

        static ulong Decrypt(ref int pointer, byte[] data)
        {
            ulong value = 0;
            int shift = 1;
            byte x = data[pointer++];
            value += (ulong)((x & 0x7F) * shift);
            while ((x & 0x80) == 0)
            {
                shift <<= 7;
                value += (ulong)shift;
                x = data[pointer++];
                value += (ulong)((x & 0x7F) * shift);
            }
            return value;
        }

    }
}
