using Microsoft.VisualStudio.TestTools.UnitTesting;
using mzmr.Utility;
using System;

namespace mzmrTests.Utility
{
    [TestClass]
    public class TextTests
    {
        [TestMethod]
        public void BytesFromTextTest()
        {
            string s = "ABxy12-_";
            byte[] expected = new byte[]
            {
                0x81, 0, 0x82, 0, 0xD8, 0, 0xD9, 0,
                0x51, 0, 0x52, 0, 0x4D, 0, 0x9F, 0, 0, 0xFF
            };
            CollectionAssert.AreEqual(expected, Text.BytesFromText(s));
        }

        [TestMethod]
        public void GetCharWidthTest()
        {
            var rom = Tests.TestRom;
            Assert.AreEqual(6, Text.GetCharWidth(rom, ' '));
            Assert.AreEqual(2, Text.GetCharWidth(rom, 'i'));
            Assert.AreEqual(8, Text.GetCharWidth(rom, 'W'));
            Assert.ThrowsException<FormatException>(() => Text.GetCharWidth(rom, '~'));
        }

    }
}