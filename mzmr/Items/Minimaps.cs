using System;
using System.Drawing;

namespace mzmr
{
    public static class Minimaps
    {
        public static Bitmap[] Draw(Location[] locations)
        {
            // get bitmaps
            Bitmap[] minimaps =
            {
                Properties.Resources.brinstarMap,
                Properties.Resources.kraidMap,
                Properties.Resources.norfairMap,
                Properties.Resources.ridleyMap,
                Properties.Resources.tourianMap,
                Properties.Resources.crateriaMap,
                Properties.Resources.chozodiaMap
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
                    return Properties.Resources.energyMap;
                case ItemType.Missile:
                    return Properties.Resources.missileMap;
                case ItemType.Super:
                    return Properties.Resources.superMap;
                case ItemType.Power:
                    return Properties.Resources.powerMap;
                case ItemType.Long:
                    return Properties.Resources.longMap;
                case ItemType.Charge:
                    return Properties.Resources.chargeMap;
                case ItemType.Ice:
                    return Properties.Resources.iceMap;
                case ItemType.Wave:
                    return Properties.Resources.waveMap;
                case ItemType.Plasma:
                    return Properties.Resources.plasmaMap;
                case ItemType.Bomb:
                    return Properties.Resources.bombMap;
                case ItemType.Varia:
                    return Properties.Resources.variaMap;
                case ItemType.Gravity:
                    return Properties.Resources.gravityMap;
                case ItemType.Morph:
                    return Properties.Resources.morphMap;
                case ItemType.Speed:
                    return Properties.Resources.speedMap;
                case ItemType.Hi:
                    return Properties.Resources.hiMap;
                case ItemType.Screw:
                    return Properties.Resources.screwMap;
                case ItemType.Space:
                    return Properties.Resources.spaceMap;
                case ItemType.Grip:
                    return Properties.Resources.gripMap;
                default:
                    throw new ArgumentException();
            }
        }


    }
}
