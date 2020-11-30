using Microsoft.VisualStudio.TestTools.UnitTesting;
using mzmr.Items;
using System;
using System.Drawing;

namespace mzmrTests.Items
{
    [TestClass]
    public class MapImagesTests
    {
        [TestMethod]
        public void DrawTest()
        {
            var locations = Location.GetLocations();
            for (int i = 0; i < locations.Length; i++)
            {
                locations[i].NewItem = locations[i].OrigItem;
            }
            Bitmap[] images = MapImages.Draw(locations);
            Assert.AreEqual(7, images.Length);
            foreach (Bitmap image in images)
            {
                Assert.IsNotNull(image);
            }
        }

    }
}