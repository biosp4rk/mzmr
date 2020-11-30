using mzmr;
using mzmr.Items;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace mzmrTests.Items
{
    [TestClass]
    public class ConditionsTests
    {
        [TestMethod]
        public void VanillaItemsTest()
        {
            // setup
            var settings = new Settings("vBIjjZP3B");
            var locations = Location.GetLocations();
            for (int i = 0; i < locations.Length; i++)
            {
                locations[i].NewItem = locations[i].OrigItem;
            }
            Conditions cond = new Conditions(settings, locations);
            string co = cond.GetCollectionOrder();

            Assert.IsTrue(cond.IsBeatable());
            Assert.IsTrue(cond.Is100able(0));
            Assert.IsFalse(co.Contains("Round 5"));
            Assert.IsTrue(co.Contains("17-Bomb"));
            Assert.IsTrue(co.Contains("76-Grip"));
        }

        [TestMethod]
        public void RemoveItemsTest()
        {
            // setup
            var settings = new Settings("vBIjjZP3B");
            var locations = Location.GetLocations();
            for (int i = 0; i < locations.Length; i++)
            {
                locations[i].NewItem = ItemType.None;
            }
            // obtainable
            locations[0].NewItem = ItemType.Space;
            locations[2].NewItem = ItemType.Bomb;
            locations[3].NewItem = ItemType.Morph;
            locations[11].NewItem = ItemType.Missile;
            locations[12].NewItem = ItemType.Gravity;
            // unobtainable
            locations[5].NewItem = ItemType.Speed;
            Conditions cond = new Conditions(settings, locations);
            string co = cond.GetCollectionOrder();

            Assert.IsTrue(cond.IsBeatable());
            Assert.IsFalse(cond.Is100able(94));
            Assert.IsFalse(co.Contains("Round 4"));
            Assert.IsTrue(co.Contains("2-Bomb"));
            Assert.IsFalse(co.Contains("Grip"));
            Assert.IsFalse(co.Contains("Speed"));
        }

    }
}