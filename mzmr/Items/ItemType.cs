using mzmr.Properties;
using System;

namespace mzmr
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
            return 0;
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

        public static byte[] AbilityGraphics(this ItemType type)
        {
            switch (type)
            {
                case ItemType.None:
                    return Resources.gfxNone;
                case ItemType.Energy:
                    return Resources.gfxEnergy;
                case ItemType.Missile:
                    return Resources.gfxMissile;
                case ItemType.Super:
                    return Resources.gfxSuper;
                case ItemType.Power:
                    return Resources.gfxPower;
                case ItemType.Long:
                    return Resources.gfxLong;
                case ItemType.Charge:
                    return Resources.gfxCharge;
                case ItemType.Ice:
                    return Resources.gfxIce;
                case ItemType.Wave:
                    return Resources.gfxWave;
                case ItemType.Plasma:
                    return Resources.gfxPlasma;
                case ItemType.Bomb:
                    return Resources.gfxBomb;
                case ItemType.Varia:
                    return Resources.gfxVaria;
                case ItemType.Gravity:
                    return Resources.gfxGravity;
                case ItemType.Morph:
                    return Resources.gfxMorph;
                case ItemType.Speed:
                    return Resources.gfxSpeed;
                case ItemType.Hi:
                    return Resources.gfxHi;
                case ItemType.Screw:
                    return Resources.gfxScrew;
                case ItemType.Space:
                    return Resources.gfxSpace;
                case ItemType.Grip:
                    return Resources.gfxGrip;
                default:
                    return null;
            }
        }

        public static byte[] AbilityPalette(this ItemType type)
        {
            switch (type)
            {
                case ItemType.None:
                case ItemType.Energy:
                case ItemType.Missile:
                case ItemType.Super:
                case ItemType.Power:
                    return Resources.palTank;
                case ItemType.Long:
                    return Resources.palLong;
                case ItemType.Charge:
                    return Resources.palCharge;
                case ItemType.Ice:
                    return Resources.palIce;
                case ItemType.Wave:
                    return Resources.palWave;
                case ItemType.Plasma:
                    return Resources.palPlasma;
                case ItemType.Bomb:
                    return Resources.palBomb;
                case ItemType.Varia:
                    return Resources.palVaria;
                case ItemType.Gravity:
                    return Resources.palGravity;
                case ItemType.Morph:
                    return Resources.palMorph;
                case ItemType.Speed:
                    return Resources.palSpeed;
                case ItemType.Hi:
                    return Resources.palHi;
                case ItemType.Screw:
                    return Resources.palScrew;
                case ItemType.Space:
                    return Resources.palSpace;
                case ItemType.Grip:
                    return Resources.palGrip;
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
