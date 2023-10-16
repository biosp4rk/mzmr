﻿using mzmr.Data;
using mzmr.Properties;
using System;
using System.Collections.Generic;

namespace mzmr.Items
{
    public enum ItemType
    {
        Undefined, None,
        Energy, Missile, Super, Power,
        Long, Charge, Ice, Wave, Plasma,
        Bomb,
        Varia, Gravity,
        Morph, Speed, Hi, Screw, Space, Grip
    }

    public static class Item
    {
        public static string[] Names
        {
            get
            {
                var vals = (ItemType[])Enum.GetValues(typeof(ItemType));
                return new List<ItemType>(vals).ConvertAll(v => v.Name()).ToArray();
            }
        }

        public static bool IsTank(this ItemType type)
        {
            return type >= ItemType.Energy && type <= ItemType.Power;
        }

        public static bool IsAbility(this ItemType type)
        {
            return type >= ItemType.Long;
        }

        public static int MaxNumber(this ItemType type, int game)
        {
            if (type.IsAbility())
                return 1;
            switch ((Game)game)
            {
                case Game.Deep_Freeze:
                    switch (type)
                    {
                        case ItemType.Energy:
                            return 8;
                        case ItemType.Missile:
                            return 15;
                        case ItemType.Super:
                            return 10;
                        case ItemType.Power:
                            return 4;
                        case ItemType.None:
                            return 35;
                        default:
                            return -1;
                    }
                case Game.Spooky:
                    switch (type)
                    {
                        case ItemType.Energy:
                            return 6;
                        case ItemType.Missile:
                            return 14;
                        case ItemType.Super:
                            return 9;
                        case ItemType.Power:
                            return 3;
                        case ItemType.None:
                            return 30;
                        default:
                            return -1;
                    }
                default:
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
                    clip = 0x5C + type - ItemType.Energy;
                else if (type.IsAbility())
                    clip = 0xB0 + type - ItemType.Long;

                if (hidden) { clip += 0x10; }
            }

            return (byte)clip;
        }

        public static byte BehaviorType(this ItemType type)
        {
            if (type.IsTank())
                return (byte)(0x38 + type - ItemType.Energy);
            if (type.IsAbility())
                return (byte)(0x70 + type - ItemType.Long);
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

        public static Gfx AbilityGraphics(this ItemType type)
        {
            switch (type)
            {
                case ItemType.None:
                    return new Gfx(Resources.gfxNone, 6);
                case ItemType.Energy:
                    return new Gfx(Resources.gfxEnergy, 6);
                case ItemType.Missile:
                    return new Gfx(Resources.gfxMissile, 6);
                case ItemType.Super:
                    return new Gfx(Resources.gfxSuper, 6);
                case ItemType.Power:
                    return new Gfx(Resources.gfxPower, 6);
                case ItemType.Long:
                    return new Gfx(Resources.gfxLong, 6);
                case ItemType.Charge:
                    return new Gfx(Resources.gfxCharge, 6);
                case ItemType.Ice:
                    return new Gfx(Resources.gfxIce, 6);
                case ItemType.Wave:
                    return new Gfx(Resources.gfxWave, 6);
                case ItemType.Plasma:
                    return new Gfx(Resources.gfxPlasma, 6);
                case ItemType.Bomb:
                    return new Gfx(Resources.gfxBomb, 6);
                case ItemType.Varia:
                    return new Gfx(Resources.gfxVaria, 6);
                case ItemType.Gravity:
                    return new Gfx(Resources.gfxGravity, 6);
                case ItemType.Morph:
                    return new Gfx(Resources.gfxMorph, 6);
                case ItemType.Speed:
                    return new Gfx(Resources.gfxSpeed, 6);
                case ItemType.Hi:
                    return new Gfx(Resources.gfxHi, 6);
                case ItemType.Screw:
                    return new Gfx(Resources.gfxScrew, 6);
                case ItemType.Space:
                    return new Gfx(Resources.gfxSpace, 6);
                case ItemType.Grip:
                    return new Gfx(Resources.gfxGrip, 6);
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

        public static ItemType FromLogicName(string name)
        {
            switch (name)
            {
                case "None":
                    return ItemType.None;
                case "E-Tank":
                    return ItemType.Energy;
                case "Missile":
                    return ItemType.Missile;
                case "Super Missile":
                    return ItemType.Super;
                case "Power Bombs":
                    return ItemType.Power;
                case "Long Beam":
                    return ItemType.Long;
                case "Charge Beam":
                    return ItemType.Charge;
                case "Ice Beam":
                    return ItemType.Ice;
                case "Wave Beam":
                    return ItemType.Wave;
                case "Plasma Beam":
                    return ItemType.Plasma;
                case "Bombs":
                    return ItemType.Bomb;
                case "Varia Suit":
                    return ItemType.Varia;
                case "Gravity Suit":
                    return ItemType.Gravity;
                case "Morph":
                    return ItemType.Morph;
                case "Speed Booster":
                    return ItemType.Speed;
                case "Hi-Jump":
                    return ItemType.Hi;
                case "Screw Attack":
                    return ItemType.Screw;
                case "Space Jump":
                    return ItemType.Space;
                case "Power Grip":
                    return ItemType.Grip;
                default:
                    throw new FormatException();
            }
        }

        public static string LogicName(this ItemType type)
        {
            switch (type)
            {
                case ItemType.Undefined:
                case ItemType.None:
                    return "None";
                case ItemType.Energy:
                    return "E-Tank";
                case ItemType.Missile:
                    return "Missile";
                case ItemType.Super:
                    return "Super Missile";
                case ItemType.Power:
                    return "Power Bombs";
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
                    return "Bombs";
                case ItemType.Varia:
                    return "Varia Suit";
                case ItemType.Gravity:
                    return "Gravity Suit";
                case ItemType.Morph:
                    return "Morph";
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
