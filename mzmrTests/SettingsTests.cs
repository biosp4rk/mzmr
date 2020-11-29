using mzmr;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace mzmrTests
{
    [TestClass]
    public class SettingsTests
    {
        [TestMethod]
        public void GetStringTest()
        {
            // 1.3.2
            string expected = "3pIjrZP3B";
            Settings settings = new Settings(expected);
            Assert.AreEqual(true, settings.randomAbilities);
            Assert.AreEqual(GameCompletion.AllItems, settings.gameCompletion);
            Assert.AreEqual(0, settings.numItemsRemoved);
            Assert.AreEqual(false, settings.pauseScreenInfo);

            // skip checksum and version
            string actual = settings.GetString();
            Assert.AreEqual(expected.Substring(5), actual.Substring(5));
        }

    }
}
