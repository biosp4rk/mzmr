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
            // 1.4.0
            string config = "vSoAcsQz-S357";
            Settings settings = new Settings(config);
            Assert.AreEqual(70, settings.NumItemsRemoved);
            Assert.AreEqual(70, settings.NumTanksRemoved);
            Assert.AreEqual(75, settings.HueMinimum);
            Assert.AreEqual(115, settings.HueMaximum);

            // skip checksum and version
            string actual = settings.GetString();
            Assert.AreEqual(config.Substring(5), actual.Substring(5));
        }

        public void GetString_1_3_Test()
        {
            // 1.3.0 - 1.3.2
            string config = "3pIjrZP3B";
            Settings settings = new Settings(config);
            Assert.AreEqual(Swap.GlobalPool, settings.AbilitySwap);
            Assert.AreEqual(GameCompletion.AllItems, settings.Completion);
            Assert.AreEqual(0, settings.NumItemsRemoved);
            Assert.IsFalse(settings.PauseScreenInfo);

            // skip checksum and version
            string actual = settings.GetString();
            Assert.AreEqual(config.Substring(5), actual.Substring(5));
        }

    }
}
