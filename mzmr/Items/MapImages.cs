using mzmr.Properties;
using System;
using System.Drawing;

namespace mzmr.Items
{
    public static class MapImages
    {
        public static Bitmap[] Draw(Location[] locations)
        {
            // get bitmaps
            Bitmap[] minimaps =
            {
                Resources.brinstarMap,
                Resources.kraidMap,
                Resources.norfairMap,
                Resources.ridleyMap,
                Resources.tourianMap,
                Resources.crateriaMap,
                Resources.chozodiaMap
            };

            Point[] corners =
            {
                new Point(-2, 0),
                new Point(1, -1),
                new Point(1, -1),
                new Point(0, -2),
                new Point(15, -2),
                new Point(0, -1),
                new Point(-1, -2)
            };

            foreach (Location loc in locations)
            {
                if (loc.NewItem == ItemType.None) { continue; }

                byte area = loc.Area;
                int x = loc.MinimapX - corners[area].X;
                int y = loc.MinimapY - corners[area].Y;

                using (Graphics g = Graphics.FromImage(minimaps[area]))
                {
                    g.DrawImage(ItemImage(loc.NewItem), x * 16, y * 16);
                }
            }

            return minimaps;
        }

        private static Bitmap ItemImage(ItemType item)
        {
            switch (item)
            {
                case ItemType.Energy:
                    return Resources.energyMap;
                case ItemType.Missile:
                    return Resources.missileMap;
                case ItemType.Super:
                    return Resources.superMap;
                case ItemType.Power:
                    return Resources.powerMap;
                case ItemType.Long:
                    return Resources.longMap;
                case ItemType.Charge:
                    return Resources.chargeMap;
                case ItemType.Ice:
                    return Resources.iceMap;
                case ItemType.Wave:
                    return Resources.waveMap;
                case ItemType.Plasma:
                    return Resources.plasmaMap;
                case ItemType.Bomb:
                    return Resources.bombMap;
                case ItemType.Varia:
                    return Resources.variaMap;
                case ItemType.Gravity:
                    return Resources.gravityMap;
                case ItemType.Morph:
                    return Resources.morphMap;
                case ItemType.Speed:
                    return Resources.speedMap;
                case ItemType.Hi:
                    return Resources.hiMap;
                case ItemType.Screw:
                    return Resources.screwMap;
                case ItemType.Space:
                    return Resources.spaceMap;
                case ItemType.Grip:
                    return Resources.gripMap;
                default:
                    throw new ArgumentException();
            }
        }

    }
}
