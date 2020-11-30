using Microsoft.VisualStudio.TestTools.UnitTesting;
using mzmr.Items;
using System;

namespace mzmrTests.Items
{
    [TestClass]
    public class LocationTests
    {
        [TestMethod]
        public void GetLocationTest()
        {
            for (int i = 0; i < 100; i++)
            {
                var loc = Location.GetLocation(i);
                Assert.AreEqual(i, loc.Number);
                Assert.IsTrue(loc.Area >= 0 && loc.Area <= 7);
                Assert.IsTrue(loc.MinimapX >= 0 && loc.MinimapX < 32);
                Assert.IsTrue(loc.MinimapY >= 0 && loc.MinimapY < 32);
                Assert.IsTrue(loc.OrigItem >= ItemType.Energy);
                Assert.IsNotNull(loc.Requirements);
            }

            Assert.ThrowsException<IndexOutOfRangeException>(() => Location.GetLocation(100));
        }

        [TestMethod]
        public void GetLocationsTest()
        {
            var locations = Location.GetLocations();
            Assert.AreEqual(100, locations.Length);
        }

    }
}