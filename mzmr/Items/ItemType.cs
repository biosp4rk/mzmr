using mzmr.Data;
using mzmr.Properties;
using System;

namespace mzmr.Items
{
    public enum ItemType { Undefined, None, Energy, Missile, Super, Power, Long, Charge, 
        Ice, Wave, Plasma, Bomb, Varia, Gravity, Morph, Speed, Hi, Screw, Space, Grip }

    public static class Item
    {
        public static bool IsTank(this ItemType type)
        {
            return type >= ItemType.Energy && type <= ItemType.Power;
        }

        public static bool IsAbility(this ItemType type)
        {
            return type >= ItemType.Long;
        }

        public static int MaxNumber(this ItemType type)
        {
            if (type.IsAbility())
            {
                return 1;
            }
            switch (type)
            {
                case ItemType.Energy:
                    return 12;
                case ItemType.Missile:
                    return 50;
                case ItemType.Super:
                    return 15;
                case ItemType.Power:
                    return 9;
                case ItemType.None:
                    return 90;
                default:
                    return -1;
            }
        }

        public static byte Clipdata(this ItemType type, bool hidden = false)
        {
            // default to air
            int clip = 0;

            if (type == ItemType.None)
            {
                if (hidden)
                {
                    // shot block (never respawn)
                    return 0x52;
                }
            }
            else
            {
                if (type.IsTank())
                {
                    clip = 0x5C + type - ItemType.Energy;
                }
                else if (type.IsAbility())
                {
                    clip = 0xB0 + type - ItemType.Long;
                }

                if (hidden) { clip += 0x10; }
            }

            return (byte)clip;
        }

        public static byte BehaviorType(this ItemType type)
        {
            if (type.IsTank())
            {
                return (byte)(0x38 + type - ItemType.Energy);
            }
            if (type.IsAbility())
            {
                return (byte)(0x70 + type - ItemType.Long);
            }
            return 0xFF;
        }

        public static byte BG1(this ItemType type)
        {
            switch (type)
            {
                case ItemType.Missile:
                    return 0x48;
                case ItemType.Energy:
                    return 0x49;
                case ItemType.Power:
                    return 0x4A;
                case ItemType.Super:
                    return 0x4B;
                default:
                    return 0;
            }
        }

        public static byte SpriteID(this ItemType type)
        {
            switch (type)
            {
                case ItemType.Long:
                    return 0x23;
                case ItemType.Charge:
                    return 0x44;
                case ItemType.Ice:
                    return 0x25;
                case ItemType.Wave:
                    return 0x27;
                case ItemType.Plasma:
                    return 0x94;
                case ItemType.Bomb:
                    return 0x29;
                case ItemType.Varia:
                    return 0x31;
                case ItemType.Gravity:
                    return 0x58;
                case ItemType.Morph:
                    return 0x21;
                case ItemType.Speed:
                    return 0x2B;
                case ItemType.Hi:
                    return 0x2D;
                case ItemType.Screw:
                    return 0x2F;
                case ItemType.Space:
                    return 0x59;
                case ItemType.Grip:
                    return 0x4C;
                default:
                    return 0;
            }
        }

        public static GFX AbilityGraphics(this ItemType type)
        {
            switch (type)
            {
                case ItemType.None:
                    return new GFX(Resources.gfxNone, 6);
                case ItemType.Energy:
                    return new GFX(Resources.gfxEnergy, 6);
                case ItemType.Missile:
                    return new GFX(Resources.gfxMissile, 6);
                case ItemType.Super:
                    return new GFX(Resources.gfxSuper, 6);
                case ItemType.Power:
                    return new GFX(Resources.gfxPower, 6);
                case ItemType.Long:
                    return new GFX(Resources.gfxLong, 6);
                case ItemType.Charge:
                    return new GFX(Resources.gfxCharge, 6);
                case ItemType.Ice:
                    return new GFX(Resources.gfxIce, 6);
                case ItemType.Wave:
                    return new GFX(Resources.gfxWave, 6);
                case ItemType.Plasma:
                    return new GFX(Resources.gfxPlasma, 6);
                case ItemType.Bomb:
                    return new GFX(Resources.gfxBomb, 6);
                case ItemType.Varia:
                    return new GFX(Resources.gfxVaria, 6);
                case ItemType.Gravity:
                    return new GFX(Resources.gfxGravity, 6);
                case ItemType.Morph:
                    return new GFX(Resources.gfxMorph, 6);
                case ItemType.Speed:
                    return new GFX(Resources.gfxSpeed, 6);
                case ItemType.Hi:
                    return new GFX(Resources.gfxHi, 6);
                case ItemType.Screw:
                    return new GFX(Resources.gfxScrew, 6);
                case ItemType.Space:
                    return new GFX(Resources.gfxSpace, 6);
                case ItemType.Grip:
                    return new GFX(Resources.gfxGrip, 6);
                default:
                    return null;
            }
        }

        public static Palette AbilityPalette(this ItemType type)
        {
            switch (type)
            {
                case ItemType.None:
                case ItemType.Energy:
                case ItemType.Missile:
                case ItemType.Super:
                case ItemType.Power:
                    return new Palette(Resources.palTank);
                case ItemType.Long:
                    return new Palette(Resources.palLong);
                case ItemType.Charge:
                    return new Palette(Resources.palCharge);
                case ItemType.Ice:
                    return new Palette(Resources.palIce);
                case ItemType.Wave:
                    return new Palette(Resources.palWave);
                case ItemType.Plasma:
                    return new Palette(Resources.palPlasma);
                case ItemType.Bomb:
                    return new Palette(Resources.palBomb);
                case ItemType.Varia:
                    return new Palette(Resources.palVaria);
                case ItemType.Gravity:
                    return new Palette(Resources.palGravity);
                case ItemType.Morph:
                    return new Palette(Resources.palMorph);
                case ItemType.Speed:
                    return new Palette(Resources.palSpeed);
                case ItemType.Hi:
                    return new Palette(Resources.palHi);
                case ItemType.Screw:
                    return new Palette(Resources.palScrew);
                case ItemType.Space:
                    return new Palette(Resources.palSpace);
                case ItemType.Grip:
                    return new Palette(Resources.palGrip);
                default:
                    return null;
            }
        }

        public static string Name(this ItemType type)
        {
            switch (type)
            {
                case ItemType.Undefined:
                    return "Random";
                case ItemType.None:
                    return "None";
                case ItemType.Energy:
                    return "Energy Tank";
                case ItemType.Missile:
                    return "Missile Tank";
                case ItemType.Super:
                    return "Super Missile Tank";
                case ItemType.Power:
                    return "Power Bomb Tank";
                case ItemType.Long:
                    return "Long Beam";
                case ItemType.Charge:
                    return "Charge Beam";
                case ItemType.Ice:
                    return "Ice Beam";
                case ItemType.Wave:
                    return "Wave Beam";
                case ItemType.Plasma:
                    return "Plasma Beam";
                case ItemType.Bomb:
                    return "Bomb";
                case ItemType.Varia:
                    return "Varia Suit";
                case ItemType.Gravity:
                    return "Gravity Suit";
                case ItemType.Morph:
                    return "Morph Ball";
                case ItemType.Speed:
                    return "Speed Booster";
                case ItemType.Hi:
                    return "Hi-Jump";
                case ItemType.Screw:
                    return "Screw Attack";
                case ItemType.Space:
                    return "Space Jump";
                case ItemType.Grip:
                    return "Power Grip";
                default:
                    throw new FormatException();
            }
        }

    }
}
