using mzmr.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace mzmrTests.Utility
{
    [TestClass]
    public class PatchTests
    {
        [TestMethod]
        public void ApplyTest()
        {
            var rom = Tests.TestRom;
            byte[] patch = new byte[]
            {
                0x50, 0x41, 0x54, 0x43, 0x48,  // "PATCH"
                0x00, 0x00, 0xAC,  // offset
                0x00, 0x04,  // length
                0x54, 0x45, 0x53, 0x54,  // data
                0x45, 0x4F, 0x46  // "EOF"
            };
            Patch.Apply(rom, patch);
            byte[] actual = rom.Bytes;

            byte[] expected = Tests.TestRom.Bytes;
            expected[0xAC] = 0x54;
            expected[0xAD] = 0x45;
            expected[0xAE] = 0x53;
            expected[0xAF] = 0x54;
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}