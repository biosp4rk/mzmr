using mzmr.Data;
using mzmr.Items;
using mzmr.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace mzmrTests.Items
{
    [TestClass]
    public class ItemTypeTests
    {
        [TestMethod]
        public void IsTankTest()
        {
            Assert.IsFalse(ItemType.Undefined.IsTank());
            Assert.IsFalse(ItemType.None.IsTank());
            Assert.IsTrue(ItemType.Energy.IsTank());
            Assert.IsTrue(ItemType.Missile.IsTank());
            Assert.IsFalse(ItemType.Grip.IsTank());
        }

        [TestMethod]
        public void IsAbilityTest()
        {
            Assert.IsFalse(ItemType.Undefined.IsAbility());
            Assert.IsFalse(ItemType.None.IsAbility());
            Assert.IsFalse(ItemType.Missile.IsAbility());
            Assert.IsTrue(ItemType.Morph.IsAbility());
            Assert.IsTrue(ItemType.Grip.IsAbility());
        }

        [TestMethod]
        public void MaxNumberTest()
        {
            Assert.AreEqual(12, ItemType.Energy.MaxNumber());
            Assert.AreEqual(50, ItemType.Missile.MaxNumber());
            Assert.AreEqual(15, ItemType.Super.MaxNumber());
            Assert.AreEqual(9, ItemType.Power.MaxNumber());
            Assert.AreEqual(1, ItemType.Speed.MaxNumber());
            Assert.AreEqual(1, ItemType.Grip.MaxNumber());
        }

        [TestMethod]
        public void ClipdataTest()
        {
            Assert.AreEqual(0, ItemType.None.Clipdata(false));
            Assert.AreEqual(0x52, ItemType.None.Clipdata(true));
            Assert.AreEqual(0x5C, ItemType.Energy.Clipdata(false));
            Assert.AreEqual(0x6C, ItemType.Energy.Clipdata(true));
            Assert.AreEqual(0xB0, ItemType.Long.Clipdata(false));
            Assert.AreEqual(0xC0, ItemType.Long.Clipdata(true));
        }

        [TestMethod]
        public void BehaviorTypeTest()
        {
            Assert.AreEqual(0xFF, ItemType.None.BehaviorType());
            Assert.AreEqual(0x38, ItemType.Energy.BehaviorType());
            Assert.AreEqual(0x70, ItemType.Long.BehaviorType());
        }

        [TestMethod]
        public void BG1Test()
        {
            Assert.AreEqual(0, ItemType.None.BG1());
            Assert.AreEqual(0x49, ItemType.Energy.BG1());
            Assert.AreEqual(0x48, ItemType.Missile.BG1());
            Assert.AreEqual(0x4B, ItemType.Super.BG1());
            Assert.AreEqual(0x4A, ItemType.Power.BG1());
            Assert.AreEqual(0, ItemType.Morph.BG1());
        }

        [TestMethod]
        public void SpriteIDTest()
        {
            Assert.AreEqual(0, ItemType.None.SpriteID());
            Assert.AreEqual(0, ItemType.Energy.SpriteID());
            Assert.AreEqual(0x2B, ItemType.Speed.SpriteID());
            Assert.AreEqual(0x4C, ItemType.Grip.SpriteID());
        }

        [TestMethod]
        public void AbilityGraphicsTest()
        {
            Assert.IsNotNull(ItemType.None.AbilityGraphics());
            Assert.IsNotNull(ItemType.Missile.AbilityGraphics());
            Assert.IsNotNull(ItemType.Speed.AbilityGraphics());
        }

        [TestMethod]
        public void AbilityPaletteTest()
        {
            Assert.IsNotNull(ItemType.None.AbilityPalette());
            Assert.IsNotNull(ItemType.Missile.AbilityPalette());
            Assert.IsNotNull(ItemType.Speed.AbilityPalette());
        }

        [TestMethod]
        public void NameTest()
        {
            Assert.AreEqual("Random", ItemType.Undefined.Name());
            Assert.AreEqual("None", ItemType.None.Name());
            Assert.AreEqual("Energy Tank", ItemType.Energy.Name());
            Assert.AreEqual("Missile Tank", ItemType.Missile.Name());
            Assert.AreEqual("Speed Booster", ItemType.Speed.Name());
            Assert.AreEqual("Power Grip", ItemType.Grip.Name());
        }

    }
}