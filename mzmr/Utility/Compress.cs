using System;
using System.Collections.Generic;

namespace mzmr.Utility
{
    public static class Compress
    {
        private const int MinMatchSize = 3;
        private const int MaxMatchSize = 18;
        private const int MaxWindowSize = 0x1000;

        public static byte[] CompLZ77(byte[] input)
        {
            // assumes input stream starts at 0
            int length = input.Length;
            int idx = 0;
            var longestMatches = FindLongestMatches(input);

            // write start of data
            List<byte> output = new List<byte>();
            output.Add(0x10);
            output.Add((byte)length);
            output.Add((byte)(length >> 8));
            output.Add((byte)(length >> 16));

            while (idx < length)
            {
                // get index of new compression flag
                int flag = output.Count;
                output.Add(0);

                for (int i = 0; i < 8; i++)
                {
                    // find longest match at current position
                    if (longestMatches.TryGetValue(
                        idx, out (int len, int idx) match))
                    {
                        // compressed
                        int matchOffset = idx - match.idx - 1;
                        output.Add((byte)(((match.len - 3) << 4) | (matchOffset >> 8)));
                        output.Add((byte)matchOffset);
                        output[flag] |= (byte)(0x80 >> i);
                        idx += match.len;
                    }
                    else
                    {
                        // uncompressed
                        output.Add(input[idx++]);
                    }

                    // check if at end
                    if (idx >= length) { return output.ToArray(); }
                }
            }

            throw new Exception("LZ77 compression error");
        }

        public static Dictionary<int, (int, int)> FindLongestMatches(byte[] input)
        {
            int length = input.Length;
            var triplets = new Dictionary<int, List<int>>();
            var longestMatches = new Dictionary<int, (int, int)>();

            for (int i = 0; i < length - 2; i++)
            {
                // get triplet at current position
                int triplet = input[i] | (input[i + 1] << 8) | (input[i + 2] << 16);

                // check if triplet has no match
                if (!triplets.TryGetValue(triplet, out var indexes))
                {
                    triplets[triplet] = new List<int>(){ i };
                    continue;
                }

                int windowStart = Math.Max(i - MaxWindowSize, 0);
                int maxSize = Math.Min(MaxMatchSize, length - i);
                int longestLen = 0;
                int longestIdx = -1;

                // skip first index if one byte behind current position
                int j = indexes.Count - 1;
                if (indexes[j] >= i - 1) { j -= 1; }

                // try each index to find the longest match
                while (j >= 0)
                {
                    int idx = indexes[j];
                    // stop if past window
                    if (idx < windowStart) { break; }

                    // find length of match
                    int matchLen = MinMatchSize;
                    while (matchLen < maxSize)
                    {
                        if (input[idx + matchLen] != input[i + matchLen])
                        {
                            break;
                        }
                        matchLen++;
                    }

                    // update longest match
                    if (matchLen > longestLen)
                    {
                        longestLen = matchLen;
                        longestIdx = idx;

                        // stop looking if max size
                        if (longestLen == maxSize) { break; }
                    }

                    j--;
                }

                indexes.Add(i);
                if (longestLen >= MinMatchSize)
                {
                    longestMatches[i] = (longestLen, longestIdx);
                }
            }

            return longestMatches;
        }

        public static int DecompLZ77(byte[] input, int idx, out byte[] output)
        {
            // get length of decompressed data
            int remain = input[idx + 1] + (input[idx + 2] << 8) + (input[idx + 3] << 16);
            output = new byte[remain];

            // check for valid data size
            if (remain == 0) { return 0; }

            int srcStart = idx;
            idx += 4;
            int dst = 0;

            // decompress
            while (remain > 0)
            {
                byte cflag = input[idx++];

                for (int i = 0; i < 8; i++)
                {
                    // uncompressed
                    if ((cflag & 0x80) == 0)
                    {
                        output[dst++] = input[idx++];
                        remain--;
                    }
                    // compressed
                    else
                    {
                        int amountToCopy = (input[idx] >> 4) + MinMatchSize;
                        int window = ((input[idx] & 0xF) << 8) + input[idx + 1] + 1;
                        idx += 2;
                        remain -= amountToCopy;

                        for (int j = 0; j < amountToCopy; j++)
                        {
                            output[dst] = output[dst - window];
                            dst++;
                        }
                    }
                    if (remain <= 0)
                    {
                        return idx - srcStart;
                    }
                    cflag <<= 1;
                }
            }
            return idx - srcStart;
        }
        
    }
}
