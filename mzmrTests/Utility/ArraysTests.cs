using Microsoft.VisualStudio.TestTools.UnitTesting;
using mzmr.Utility;
using System;

namespace mzmrTests.Utility
{
    [TestClass]
    public class ArraysTests
    {
        [TestMethod]
        public void ByteToUshortTest()
        {
            byte[] bytes = new byte[] { 0x34, 0x12, 0x78, 0x56 };
            ushort[] expected = new ushort[] { 0x1234, 0x5678 };
            CollectionAssert.AreEqual(expected, Arrays.ByteToUshort(bytes));
        }

        [TestMethod]
        public void UshortToByteTest()
        {
            ushort[] ushorts = new ushort[] { 0x1234, 0x5678 };
            byte[] expected = new byte[] { 0x34, 0x12, 0x78, 0x56 };
            
            CollectionAssert.AreEqual(expected, Arrays.UshortToByte(ushorts));
        }

    }
}