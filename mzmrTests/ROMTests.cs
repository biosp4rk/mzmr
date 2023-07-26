using Microsoft.VisualStudio.TestTools.UnitTesting;
using mzmr;
using System;

namespace mzmrTests
{
    [TestClass]
    public class RomTests
    {
        private Rom rom = Tests.TestRom;
        private const int TestAddr = 0x780000;

        [TestMethod]
        public void Read8Test()
        {
            Assert.AreEqual(0x42, rom.Read8(0xAC));
            Assert.AreEqual(0x4D, rom.Read8(0xAD));
        }

        [TestMethod]
        public void Read16Test()
        {
            Assert.AreEqual(0x4D42, rom.Read16(0xAC));
            Assert.AreEqual(0x4558, rom.Read16(0xAE));
        }

        [TestMethod]
        public void Read32Test()
        {
            Assert.AreEqual(0x4F52455A, rom.Read32(0xA0));
            Assert.AreEqual(0x45584D42, rom.Read32(0xAC));
        }

        [TestMethod]
        public void ReadPtrTest()
        {
            Assert.AreEqual(0x284, rom.ReadPtr(0x280));
            Assert.AreEqual(0x2C8, rom.ReadPtr(0x284));
        }

        [TestMethod]
        public void Write8Test()
        {
            byte[] data = rom.Data;
            rom.Write8(TestAddr, 1);
            Assert.AreEqual(1, data[TestAddr]);
            rom.Write8(TestAddr, 0xFE);
            Assert.AreEqual(0xFE, data[TestAddr]);
        }

        [TestMethod]
        public void Write16Test()
        {
            byte[] data = rom.Data;
            rom.Write16(TestAddr, 0x1234);
            Assert.AreEqual(0x34, data[TestAddr]);
            Assert.AreEqual(0x12, data[TestAddr + 1]);
            rom.Write16(TestAddr, 0xABCD);
            Assert.AreEqual(0xCD, data[TestAddr]);
            Assert.AreEqual(0xAB, data[TestAddr + 1]);
        }

        [TestMethod]
        public void WritePtrTest()
        {
            byte[] data = rom.Data;
            rom.WritePtr(TestAddr, 0x123456);
            Assert.AreEqual(0x56, data[TestAddr]);
            Assert.AreEqual(0x34, data[TestAddr + 1]);
            Assert.AreEqual(0x12, data[TestAddr + 2]);
            Assert.AreEqual(0x08, data[TestAddr + 3]);
        }

        [TestMethod]
        public void ReadBytesTest()
        {
            byte[] actual = new byte[4];
            rom.ReadBytes(actual, 0xAC, 0, 4);
            byte[] expected = new byte[] { 0x42, 0x4D, 0x58, 0x45 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WriteBytesTest()
        {
            byte[] test = new byte[] { 0x12, 0x34, 0xAB, 0xCD };
            rom.WriteBytes(test, 0, TestAddr, 4);
            byte[] data = rom.Data;
            Assert.AreEqual(0x12, data[TestAddr]);
            Assert.AreEqual(0x34, data[TestAddr + 1]);
            Assert.AreEqual(0xAB, data[TestAddr + 2]);
            Assert.AreEqual(0xCD, data[TestAddr + 3]);
        }

        [TestMethod]
        public void CopyBytesTest()
        {
            rom.CopyBytes(0xAC, TestAddr, 4);
            byte[] data = rom.Data;
            Assert.AreEqual(0x42, data[TestAddr]);
            Assert.AreEqual(0x4D, data[TestAddr + 1]);
            Assert.AreEqual(0x58, data[TestAddr + 2]);
            Assert.AreEqual(0x45, data[TestAddr + 3]);
        }

        [TestMethod]
        public void WriteToEndTest()
        {
            byte[] test = new byte[] { 0x12, 0x34, 0x56, 0xFF };
            rom.WriteToEnd(test);
            byte[] data = rom.Data;
            int end = 0x760D38;
            Assert.AreEqual(0x12, data[end]);
            Assert.AreEqual(0x34, data[end + 1]);
            Assert.AreEqual(0x56, data[end + 2]);
            Assert.AreEqual(0xFF, data[end + 3]);
            Assert.AreEqual(0x00, data[end + 4]);
            Assert.AreEqual(0x00, data[end + 5]);
            Assert.AreEqual(0x00, data[end + 6]);
            Assert.AreEqual(0x00, data[end + 7]);
        }

        [TestMethod]
        public void GetSpriteGfxPtrTest()
        {
            Assert.AreEqual(0x75EC00, Rom.GetSpriteGfxPtr(0x12));
        }

        [TestMethod]
        public void GetSpritePalettePtrTest()
        {
            Assert.AreEqual(0x75EEF8, Rom.GetSpritePalettePtr(0x12));
        }

    }
}
