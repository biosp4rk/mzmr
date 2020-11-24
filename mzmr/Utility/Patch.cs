using System;

namespace mzmr.Utility
{
    public static class Patch
    {
        public static void Apply(ROM rom, byte[] data)
        {
            // check sig
            int patchLen = data.Length;
            if (patchLen < 8 || data[0] != 'P' || data[1] != 'A' ||
                data[2] != 'T' || data[3] != 'C' || data[4] != 'H')
            {
                throw new Exception("Not a valid IPS file.");
            }

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
                {
                    throw new Exception("Abrupt end to IPS file, entry cut off before size.");
                }
                int size = (data[offset] << 8) | data[offset + 1];
                offset += 2;
                if (size == 0)
                {
                    // RLE
                    if (offset + 1 >= patchLen)
                    {
                        throw new Exception("Abrupt end to IPS file, entry cut off before RLE size.");
                    }
                    int rleSize = (data[offset] << 8) | data[offset + 1];
                    if (writeOffset + rleSize > rom.Size)
                    {
                        throw new Exception("Trying to patch data past the end of the ROM file.");
                    }
                    offset += 2;
                    if (offset >= patchLen)
                    {
                        throw new Exception("Abrupt end to IPS file, entry cut off before RLE byte.");
                    }
                    byte rleByte = data[offset++];
                    for (int i = writeOffset; i < writeOffset + rleSize; i++)
                    {
                        rom.Write8(i, rleByte);
                    }
                }
                else
                {
                    if (offset + size > patchLen)
                    {
                        throw new Exception("Abrupt end to IPS file, entry cut off before end of data block.");
                    }
                    if (writeOffset + size > rom.Size)
                    {
                        throw new Exception("Trying to patch data past the end of the ROM file");
                    }
                    rom.ArrayToRom(data, offset, writeOffset, size);
                    offset += size;
                }
            }
            throw new Exception("Improperly terminated IPS file.");
        }

    }
}
