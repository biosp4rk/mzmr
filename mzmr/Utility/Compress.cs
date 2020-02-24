using System;
using System.Collections.Generic;

namespace mzmr.Utility
{
    public static class Compress
    {
        public static int DecompLZ77(byte[] input, int source, out byte[] output)
        {
            // get length of decompressed data
            int remain = input[source + 1] + (input[source + 2] << 8) + (input[source + 3] << 16);
            output = new byte[remain];

            // check for valid data size
            if (remain == 0)
            {
                return 0;
            }

            int srcStart = source;
            source += 4;
            int dest = 0;

            // decompress
            while (remain > 0)
            {
                byte cflag = input[source++];

                for (int i = 0; i < 8; i++)
                {
                    // uncompressed
                    if ((cflag & 0x80) == 0)
                    {
                        output[dest++] = input[source++];
                        remain--;
                    }
                    // compressed
                    else
                    {
                        int amountToCopy = (input[source] >> 4) + 3;
                        int window = ((input[source] & 0xF) << 8) + input[source + 1] + 1;
                        source += 2;
                        remain -= amountToCopy;

                        for (int j = 0; j < amountToCopy; j++)
                        {
                            output[dest] = output[dest - window];
                            dest++;
                        }
                    }
                    if (remain <= 0)
                    {
                        return source - srcStart;
                    }
                    cflag <<= 1;
                }
            }
            return source - srcStart;
        }

        public static int CompLZ77(byte[] input, int length, out byte[] output)
        {
            // assumes input stream starts at 0
            const int maxLookAheadSize = 18;
            const int maxSearchBufferSize = 0x1000;
            int srcIndex = 0;
            Dictionary<int, List<int>> triplets = new Dictionary<int, List<int>>();

            // write start of data
            List<byte> outList = new List<byte>();
            outList.Add(0x10);
            outList.Add((byte)length);
            outList.Add((byte)(length >> 8));
            outList.Add((byte)(length >> 16));

            while (srcIndex < length)
            {
                // get index of compression flag
                int flag = outList.Count;
                outList.Add(0);

                for (int i = 0; i < 8; i++)
                {
                    // check if near end
                    if (srcIndex + 3 > length)
                    {
                        if (srcIndex >= length) { break; }

                        // uncompressed
                        outList.Add(input[srcIndex++]);
                        continue;
                    }

                    // find the longest match among triplets
                    int lookAheadTriplet = input[srcIndex] | (input[srcIndex + 1] << 8) | (input[srcIndex + 2] << 16);
                    List<int> indexes;
                    if (!triplets.TryGetValue(lookAheadTriplet, out indexes))
                    {
                        // uncompressed
                        triplets[lookAheadTriplet] = new List<int>() { srcIndex };
                        outList.Add(input[srcIndex++]);
                        continue;
                    }

                    // check each index of triplet
                    int searchBufferStart = srcIndex - maxSearchBufferSize;
                    if (searchBufferStart < 0) { searchBufferStart = 0; }
                    int lookAheadSize = length - srcIndex;
                    if (lookAheadSize > maxLookAheadSize) { lookAheadSize = maxLookAheadSize; }
                    int longestMatchLen = 0;
                    int longestMatchIndex = -1;

                    int j = indexes.Count - 1;
                    if (indexes[j] + 1 >= srcIndex) { j--; }
                    while (j >= 0)
                    {
                        int searchBufferIndex = indexes[j];
                            
                        // stop once triplets outside of search buffer are reached
                        if (searchBufferIndex < searchBufferStart) { break; }

                        int matchLen = 3;
                        while (matchLen < lookAheadSize)
                        {
                            if (input[searchBufferIndex + matchLen] != input[srcIndex + matchLen]) { break; }
                            matchLen++;
                        }

                        // update longest match
                        if (matchLen > longestMatchLen)
                        {
                            longestMatchLen = matchLen;
                            longestMatchIndex = searchBufferIndex;

                            // stop looking if match is max size
                            if (longestMatchLen == lookAheadSize) { break; }
                        }

                        j--;
                    }

                    // add current triplet
                    indexes.Add(srcIndex);

                    // check if no match found
                    if (longestMatchIndex == -1)
                    {
                        // uncompressed
                        outList.Add(input[srcIndex++]);
                        continue;
                    }
                    
                    // write compressed bytes
                    int matchOffset = srcIndex - longestMatchIndex - 1;
                    outList.Add((byte)(((longestMatchLen - 3) << 4) | (matchOffset >> 8)));
                    outList.Add((byte)matchOffset);
                    outList[flag] |= (byte)(0x80 >> i);
                    
                    // add remaining triplets
                    int nextIndex = srcIndex + longestMatchLen;
                    int lastTriplet = length - 3;
                    if (nextIndex < lastTriplet) { lastTriplet = nextIndex; }
                    srcIndex++;
                    while (srcIndex < lastTriplet)
                    {
                        lookAheadTriplet = input[srcIndex] | (input[srcIndex + 1] << 8) | (input[srcIndex + 2] << 16);
                        if (triplets.TryGetValue(lookAheadTriplet, out indexes))
                        {
                            indexes.Add(srcIndex);
                        }
                        else
                        {
                            triplets[lookAheadTriplet] = new List<int>() { srcIndex };
                        }

                        srcIndex++;
                    }
                    srcIndex = nextIndex;
                }
            }

            output = outList.ToArray();
            return output.Length;
        }

    }
}
