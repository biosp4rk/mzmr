using System;
using System.Collections.Generic;

namespace mzmr
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
            // preprocess (find all 3 byte runs)
            Dictionary<int, List<int>> runs = new Dictionary<int, List<int>>();
            for (int i = 0; i < input.Length - 2; i++)
            {
                int triplet = input[i] | (input[i + 1] << 8) | (input[i + 2] << 16);

                List<int> indexes;
                if (runs.TryGetValue(triplet, out indexes))
                {
                    indexes.Add(i);
                }
                else
                {
                    runs.Add(triplet, new List<int>() { i });
                }
            }

            // assumes input stream starts at 0
            int maxRunLen = 18;
            int windowSize = 0x1000;
            int source = 0;
            int dest = 0;

            // get reasonable capacity for output
            int maxLen = length + (length / 8) + 5;
            output = new byte[maxLen];

            // write start of data
            output[dest++] = 0x10;
            output[dest++] = (byte)length;
            output[dest++] = (byte)(length >> 8);
            output[dest++] = (byte)(length >> 16);

            while (source < length)
            {
                int flag = dest++;
                output[flag] = 0;

                for (int i = 0; i < 8; i++)
                {
                    // get next three bytes
                    if (source + 3 > length) { goto Uncompressed; }
                    int triplet = input[source] | (input[source + 1] << 8) | (input[source + 2] << 16);

                    List<int> indexes;
                    if (runs.TryGetValue(triplet, out indexes))
                    {
                        // find start of indexes to check
                        int j = 0;
                        while (indexes[j] < source - windowSize) { j++; }

                        // find longest run
                        int longestRunLen = -1;
                        int longestRunIndex = -1;

                        for (; j < indexes.Count; j++)
                        {
                            int index = indexes[j];
                            if (index >= source - 1) { break; }

                            int run = 3;
                            while ((source + run < length) && (input[index + run] == input[source + run]) && (run < maxRunLen))
                            {
                                run++;
                            }

                            if (run > longestRunLen)
                            {
                                longestRunLen = run;
                                longestRunIndex = index;
                            }
                        }

                        if (longestRunIndex == -1)
                        {
                            goto Uncompressed;
                        }

                        int runOffset = source - longestRunIndex - 1;
                        output[dest++] = (byte)(((longestRunLen - 3) << 4) | (runOffset >> 8));
                        output[dest++] = (byte)runOffset;
                        output[flag] |= (byte)(0x80 >> i);
                        source += longestRunLen;
                        goto End;
                    }

                Uncompressed:
                    output[dest++] = input[source++];

                End:
                    if (source >= length) { break; }
                }
            }

            return dest;
        }


    }
}
