using mzmr.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace mzmrTests.Utility
{
    [TestClass]
    public class BinaryTextEncoderTests
    {
        [TestMethod]
        public void BoolTest()
        {
            var btw = new BinaryTextWriter();
            btw.AddBool(true);
            btw.AddBool(false);
            var btr = new BinaryTextReader(btw.GetOutputString());
            Assert.IsTrue(btr.ReadBool());
            Assert.IsFalse(btr.ReadBool());
        }

        [TestMethod]
        public void NumberTest()
        {
            var btw = new BinaryTextWriter();
            btw.AddNumber(7, 4);
            btw.AddNumber(1, 10);
            var btr = new BinaryTextReader(btw.GetOutputString());
            Assert.AreEqual(7, btr.ReadNumber(4));
            Assert.AreEqual(1, btr.ReadNumber(10));
        }

        [TestMethod]
        public void StringTest()
        {
            var btw = new BinaryTextWriter();
            btw.AddString("TEST");
            btw.AddString("1.2.3");
            var btr = new BinaryTextReader(btw.GetOutputString());
            Assert.AreEqual("TEST", btr.ReadString(4));
            Assert.AreEqual("1.2.3", btr.ReadString(5));
        }

    }
}