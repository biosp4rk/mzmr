using mzmr.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace mzmrTests.Utility
{
    [TestClass]
    public class CompressTests
    {
        [TestMethod]
        public void CompLZ77Test()
        {
            byte[] input = new byte[]
            {
                1, 2, 3, 4, 5, 0, 1, 2, 0, 1, 2, 3, 4, 5
            };
            byte[] expected = new byte[]
            {
                0x10, 0x0E, 0, 0,
                0x00, 1, 2, 3, 4, 5, 0, 1, 2,
                0xC0, 0x00, 0x02, 0x00, 0x08
            };
            CollectionAssert.AreEqual(expected, Compress.CompLZ77(input));
        }

        [TestMethod]
        public void DecompLZ77Test()
        {
            byte[] input = new byte[]
            {
                0x10, 0x0E, 0, 0,
                0x00, 1, 2, 3, 4, 5, 0, 1, 2,
                0xC0, 0x00, 0x02, 0x00, 0x08
            };
            byte[] actual;
            int compLen = Compress.DecompLZ77(input, 0, out actual);
            Assert.AreEqual(0x12, compLen);

            byte[] expected = new byte[]
            {
                1, 2, 3, 4, 5, 0, 1, 2, 0, 1, 2, 3, 4, 5
            };
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}