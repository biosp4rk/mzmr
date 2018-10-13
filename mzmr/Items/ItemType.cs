using System;

namespace mzmr
{
    public enum ItemType { None, Energy, Missile, Super, Power, Long, Charge, Ice, 
        Wave, Plasma, Bomb, Varia, Gravity, Morph, Speed, Hi, Screw, Space, Grip }

    public static class ItemTypeExtensions
    {
        public static bool IsTank(this ItemType type)
        {
            return type >= ItemType.Energy && type <= ItemType.Power;
        }

        public static bool IsAbility(this ItemType type)
        {
            return type >= ItemType.Long;
        }

        public static byte Clipdata(this ItemType type, bool hidden = false)
        {
            int clip = 0;

            if (type.IsTank())
            {
                clip = 0x5C + (int)type - 1;
            }
            else if (type.IsAbility())
            {
                clip = 0xB0 + (int)type - 5;
            }
            else
            {
                if (hidden) { return 0x52; }
                return 0;
            }

            if (hidden) { clip += 0x10; }

            return (byte)clip;
        }

        public static byte BehaviorType(this ItemType type)
        {
            if (type.IsTank())
            {
                return (byte)(0x38 + (int)type - 1);
            }
            else if (type.IsAbility())
            {
                return (byte)(0x70 + (int)type - 5);
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

        public static byte[] AbilityGFX(this ItemType type)
        {
            switch (type)
            {
                case ItemType.Energy:
                    return Properties.Resources.abilityEnergyGFX;
                case ItemType.Missile:
                    return Properties.Resources.abilityMissileGFX;
                case ItemType.Super:
                    return Properties.Resources.abilitySuperGFX;
                case ItemType.Power:
                    return Properties.Resources.abilityPowerGFX;
                case ItemType.Long:
                    return Properties.Resources.abilityLongGFX;
                case ItemType.Charge:
                    return Properties.Resources.abilityChargeGFX;
                case ItemType.Ice:
                    return Properties.Resources.abilityIceGFX;
                case ItemType.Wave:
                    return Properties.Resources.abilityWaveGFX;
                case ItemType.Plasma:
                    return Properties.Resources.abilityPlasmaGFX;
                case ItemType.Bomb:
                    return Properties.Resources.abilityBombGFX;
                case ItemType.Varia:
                    return Properties.Resources.abilityVariaGFX;
                case ItemType.Gravity:
                    return Properties.Resources.abilityGravityGFX;
                case ItemType.Morph:
                    return Properties.Resources.abilityMorphGFX;
                case ItemType.Speed:
                    return Properties.Resources.abilitySpeedGFX;
                case ItemType.Hi:
                    return Properties.Resources.abilityHiGFX;
                case ItemType.Screw:
                    return Properties.Resources.abilityScrewGFX;
                case ItemType.Space:
                    return Properties.Resources.abilitySpaceGFX;
                case ItemType.Grip:
                    return Properties.Resources.abilityGripGFX;
                default:
                    return null;
            }
        }

        public static byte[] AbilityPalette(this ItemType type)
        {
            switch (type)
            {
                case ItemType.Energy:
                case ItemType.Missile:
                case ItemType.Super:
                case ItemType.Power:
                    return Properties.Resources.palTank;
                case ItemType.Long:
                    return Properties.Resources.palLong;
                case ItemType.Charge:
                    return Properties.Resources.palCharge;
                case ItemType.Ice:
                    return Properties.Resources.palIce;
                case ItemType.Wave:
                    return Properties.Resources.palWave;
                case ItemType.Plasma:
                    return Properties.Resources.palPlasma;
                case ItemType.Bomb:
                    return Properties.Resources.palBomb;
                case ItemType.Varia:
                    return Properties.Resources.palVaria;
                case ItemType.Gravity:
                    return Properties.Resources.palGravity;
                case ItemType.Morph:
                    return Properties.Resources.palMorph;
                case ItemType.Speed:
                    return Properties.Resources.palSpeed;
                case ItemType.Hi:
                    return Properties.Resources.palHi;
                case ItemType.Screw:
                    return Properties.Resources.palScrew;
                case ItemType.Space:
                    return Properties.Resources.palSpace;
                case ItemType.Grip:
                    return Properties.Resources.palGrip;
                default:
                    return null;
            }
        }

        public static string Name(this ItemType type)
        {
            switch (type)
            {
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
                    return "None";
            }
        }

        public static ItemType FromString(string str)
        {
            switch (str)
            {
                case "Energy":
                    return ItemType.Energy;
                case "Missile":
                    return ItemType.Missile;
                case "Super":
                    return ItemType.Super;
                case "Power":
                    return ItemType.Power;
                case "Long":
                    return ItemType.Long;
                case "Charge":
                    return ItemType.Charge;
                case "Ice":
                    return ItemType.Ice;
                case "Wave":
                    return ItemType.Wave;
                case "Plasma":
                    return ItemType.Plasma;
                case "Bomb":
                    return ItemType.Bomb;
                case "Varia":
                    return ItemType.Varia;
                case "Gravity":
                    return ItemType.Gravity;
                case "Morph":
                    return ItemType.Morph;
                case "Speed":
                    return ItemType.Speed;
                case "Hi":
                    return ItemType.Hi;
                case "Screw":
                    return ItemType.Screw;
                case "Space":
                    return ItemType.Space;
                case "Grip":
                    return ItemType.Grip;
                default:
                    throw new FormatException();
            }
        }


    }
}
