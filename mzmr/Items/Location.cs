using System;

namespace mzmr.Items
{
    public class Location
    {
        public static int ChargeBeamst = 9;
        public const int ImagoCocoon = 50;
        public const int PiratePB = 91;
        private static int Count = 100;

        public bool IsHidden
        {
            get { return OrigItem.IsTank() && BG1Offset == 0; }
        }

        public int Number;
        public string LogicName;
        public byte Area;
        public byte Room;
        public byte MinimapX;
        public byte MinimapY;
        public int ClipdataOffset;
        public int BG1Offset;
        public ItemType OrigItem;
        public ItemType NewItem;
        public ItemType[] Requirements;

        public Location()
        {
            NewItem = ItemType.None;
        }


        public static Location DeepFreezeLocation(int number)
        {
            switch (number)
            {
                case 0:
                    return new Location
                    {
                        Number = 0,
                        LogicName = "SpawnRoomMissile",
                        Area = 0,
                        Room = 0,
                        MinimapX = 2,
                        MinimapY = 16,
                        ClipdataOffset = 0x567B41,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 1:
                    return new Location
                    {
                        Number = 1,
                        LogicName = "SpawnRoomETank",
                        Area = 0,
                        Room = 0,
                        MinimapX = 4,
                        MinimapY = 15,
                        ClipdataOffset = 0x567AF7,
                        BG1Offset = 0x581215,
                        OrigItem = ItemType.Energy,
                        Requirements = new ItemType[0]
                    };
                case 2:
                    return new Location
                    {
                        Number = 2,
                        LogicName = "SpawnRoomSuper",
                        Area = 0,
                        Room = 0,
                        MinimapX = 1,
                        MinimapY = 14,
                        ClipdataOffset = 0x567A2C,
                        BG1Offset = 0x581058,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[0]
                    };
                case 3:
                    return new Location
                    {
                        Number = 3,
                        LogicName = "ObscuredPairSuper",
                        Area = 0,
                        Room = 1,
                        MinimapX = 6,
                        MinimapY = 18,
                        ClipdataOffset = 0x7869A7,
                        BG1Offset = 0x78A174,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[0]
                    };
                case 4:
                    return new Location
                    {
                        Number = 4,
                        LogicName = "ObscuredPairETank",
                        Area = 0,
                        Room = 1,
                        MinimapX = 5,
                        MinimapY = 18,
                        ClipdataOffset = 0X7869A4,
                        BG1Offset = 0x78A171,
                        OrigItem = ItemType.Energy,
                        Requirements = new ItemType[0]
                    };
                case 5:
                    return new Location
                    {
                        Number = 5,
                        LogicName = "HiJump",
                        Area = 0,
                        Room = 0,
                        MinimapX = 8,
                        MinimapY = 19,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Hi,
                        Requirements = new ItemType[0]
                    };
                case 6:
                    return new Location
                    {
                        Number = 6,
                        LogicName = "LongBeamMissile",
                        Area = 0,
                        Room = 2,
                        MinimapX = 11,
                        MinimapY = 14,
                        ClipdataOffset = 0x567792,
                        BG1Offset = 0x56C7B8,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 7:
                    return new Location
                    {
                        Number = 7,
                        LogicName = "LongBeam",
                        Area = 0,
                        Room = 2,
                        MinimapX = 9,
                        MinimapY = 13,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Long,
                        Requirements = new ItemType[0]
                    };
                case 8:
                    return new Location
                    {
                        Number = 8,
                        LogicName = "LongBeamSuper",
                        Area = 0,
                        Room = 2,
                        MinimapX = 12,
                        MinimapY = 13,
                        ClipdataOffset = 0x567741,
                        BG1Offset = 0x56C723,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[0]
                    };
                case 9:
                    return new Location
                    {
                        Number = 9,
                        LogicName = "WaveBeam",
                        Area = 0,
                        Room = 18,
                        MinimapX = 9,
                        MinimapY = 17,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Wave,
                        Requirements = new ItemType[0]
                    };
                case 10:
                    return new Location
                    {
                        Number = 0,
                        LogicName = "SidehopperHiddenMissle",
                        Area = 0,
                        Room = 4,
                        MinimapX = 16,
                        MinimapY = 15,
                        ClipdataOffset = 0x562EDE,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 11:
                    return new Location
                    {
                        Number = 11,
                        LogicName = "PreRidleyMissile",
                        Area = 0,
                        Room = 6,
                        MinimapX = 16,
                        MinimapY = 12,
                        ClipdataOffset = 0x57ACC7,
                        BG1Offset = 0x792D5C,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 12:
                    return new Location
                    {
                        Number = 12,
                        LogicName = "PreRidleyEtank",
                        Area = 0,
                        Room = 6,
                        MinimapX = 16,
                        MinimapY = 11,
                        ClipdataOffset = 0x57AC6E,
                        BG1Offset = 0x792C88,
                        OrigItem = ItemType.Energy,
                        Requirements = new ItemType[0]
                    };
                case 13:
                    return new Location
                    {
                        Number = 13,
                        LogicName = "IceSuit",
                        Area = 0,
                        Room = 37,
                        MinimapX = 10,
                        MinimapY = 10,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Gravity,
                        Requirements = new ItemType[0]
                    };
                case 14:
                    return new Location
                    {
                        Number = 14,
                        LogicName = "PreSpaceJumpMissile",
                        Area = 0,
                        Room = 20,
                        MinimapX = 12,
                        MinimapY = 19,
                        ClipdataOffset = 0x580B27,
                        BG1Offset = 0x5868DB,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 15:
                    return new Location
                    {
                        Number = 15,
                        LogicName = "SpaceJump",
                        Area = 0,
                        Room = 11,
                        MinimapX = 10,
                        MinimapY = 20,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Space,
                        Requirements = new ItemType[0]
                    };
                case 16:
                    return new Location
                    {
                        Number = 16,
                        LogicName = "GatedPowerBomb",
                        Area = 0,
                        Room = 10,
                        MinimapX = 16,
                        MinimapY = 19,
                        ClipdataOffset = 0x587603,
                        BG1Offset = 0x59C00A,
                        OrigItem = ItemType.Power,
                        Requirements = new ItemType[0]
                    };
                case 17:
                    return new Location
                    {
                        Number = 17,
                        LogicName = "CrateMissile",
                        Area = 0,
                        Room = 10,
                        MinimapX = 19,
                        MinimapY = 18,
                        ClipdataOffset = 0x58755F,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 18:
                    return new Location
                    {
                        Number = 18,
                        LogicName = "GuardedETank",
                        Area = 0,
                        Room = 10,
                        MinimapX = 20,
                        MinimapY = 16,
                        ClipdataOffset = 0x5874F7,
                        BG1Offset = 0x59BD0D,
                        OrigItem = ItemType.Energy,
                        Requirements = new ItemType[0]
                    };
                case 19:
                    return new Location
                    {
                        Number = 19,
                        LogicName = "VessleSuper",
                        Area = 0,
                        Room = 26,
                        MinimapX = 16,
                        MinimapY = 21,
                        ClipdataOffset = 0x56D5C9,
                        BG1Offset = 0x57C06A,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[0]
                    };
                case 20:
                    return new Location
                    {
                        Number = 20,
                        LogicName = "GatedMissile",
                        Area = 0,
                        Room = 26,
                        MinimapX = 17,
                        MinimapY = 21,
                        ClipdataOffset = 0x56D59F,
                        BG1Offset = 0x57C022,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 21:
                    return new Location
                    {
                        Number = 21,
                        LogicName = "DeoremMissile",
                        Area = 0,
                        Room = 19,
                        MinimapX = 18,
                        MinimapY = 14,
                        ClipdataOffset = 0x589785,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 22:
                    return new Location
                    {
                        Number = 22,
                        LogicName = "ChargeBeam",
                        Area = 0,
                        Room = 19,
                        MinimapX = 16,
                        MinimapY = 14,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Charge,
                        Requirements = new ItemType[0]
                    };
                case 23:
                    return new Location
                    {
                        Number = 23,
                        LogicName = "MorphBall",
                        Area = 0,
                        Room = 25,
                        MinimapX = 17,
                        MinimapY = 10,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Morph,
                        Requirements = new ItemType[0]
                    };
                case 24:
                    return new Location
                    {
                        Number = 24,
                        LogicName = "MorphBallMissile",
                        Area = 0,
                        Room = 25,
                        MinimapX = 17,
                        MinimapY = 11,
                        ClipdataOffset = 0x60F417,
                        BG1Offset = 0x78A52B,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 25:
                    return new Location
                    {
                        Number = 25,
                        LogicName = "BigRoomMissileBeforeTunnel",
                        Area = 0,
                        Room = 7,
                        MinimapX = 20,
                        MinimapY = 12,
                        ClipdataOffset = 0x562537,
                        BG1Offset = 0x587F39,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 26:
                    return new Location
                    {
                        Number = 26,
                        LogicName = "BigRoomMissileAfterTunnel",
                        Area = 0,
                        Room = 7,
                        MinimapX = 23,
                        MinimapY = 12,
                        ClipdataOffset = 0x56255D,
                        BG1Offset = 0x587F9A,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 27:
                    return new Location
                    {
                        Number = 27,
                        LogicName = "Bombs",
                        Area = 0,
                        Room = 16,
                        MinimapX = 26,
                        MinimapY = 11,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Bomb,
                        Requirements = new ItemType[0]
                    };
                case 28:
                    return new Location
                    {
                        Number = 28,
                        LogicName = "BombsMissile",
                        Area = 0,
                        Room = 16,
                        MinimapX = 26,
                        MinimapY = 12,
                        ClipdataOffset = 0x60E654,
                        BG1Offset = 0x796837,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 29:
                    return new Location
                    {
                        Number = 29,
                        LogicName = "PreImagoETank",
                        Area = 0,
                        Room = 9,
                        MinimapX = 19,
                        MinimapY = 8,
                        ClipdataOffset = 0x60E387,
                        BG1Offset = 0x7A1277,
                        OrigItem = ItemType.Energy,
                        Requirements = new ItemType[0]
                    };
                case 30:
                    return new Location
                    {
                        Number = 30,
                        LogicName = "ImagoSuper",
                        Area = 0,
                        Room = 38,
                        MinimapX = 14,
                        MinimapY = 6,
                        ClipdataOffset = 0x793332,
                        BG1Offset = 0x7A0D48,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[0]
                    };
                case 31:
                    return new Location
                    {
                        Number = 31,
                        LogicName = "SpeedBooster",
                        Area = 0,
                        Room = 32,
                        MinimapX = 13,
                        MinimapY = 5,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Speed,
                        Requirements = new ItemType[0]
                    };
                case 32:
                    return new Location
                    {
                        Number = 32,
                        LogicName = "PreImagoSuper",
                        Area = 0,
                        Room = 9,
                        MinimapX = 22,
                        MinimapY = 8,
                        ClipdataOffset = 0x60E37F,
                        BG1Offset = 0x7A126B,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[0]
                    };
                case 33:
                    return new Location
                    {
                        Number = 33,
                        LogicName = "PreGravityMissile",
                        Area = 0,
                        Room = 3,
                        MinimapX = 24,
                        MinimapY = 6,
                        ClipdataOffset = 0x56BF41,
                        BG1Offset = 0x56B78D,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 34:
                    return new Location
                    {
                        Number = 34,
                        LogicName = "PreGitGudPowerBomb",
                        Area = 0,
                        Room = 3,
                        MinimapX = 28,
                        MinimapY = 8,
                        ClipdataOffset = 0x56C078,
                        BG1Offset = 0x56BA98,
                        OrigItem = ItemType.Power,
                        Requirements = new ItemType[0]
                    };
                case 35:
                    return new Location
                    {
                        Number = 35,
                        LogicName = "ShinesparkPowerBomb",
                        Area = 0,
                        Room = 3,
                        MinimapX = 27,
                        MinimapY = 4,
                        ClipdataOffset = 0x56BE40,
                        BG1Offset = 0x56B515,
                        OrigItem = ItemType.Power,
                        Requirements = new ItemType[0]
                    };
                case 36:
                    return new Location
                    {
                        Number = 36,
                        LogicName = "PlasmaBeam",
                        Area = 0,
                        Room = 14,
                        MinimapX = 25,
                        MinimapY = 2,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Plasma,
                        Requirements = new ItemType[0]
                    };
                case 37:
                    return new Location
                    {
                        Number = 37,
                        LogicName = "GravityMissile",
                        Area = 0,
                        Room = 24,
                        MinimapX = 23,
                        MinimapY = 5,
                        ClipdataOffset = 0x60D8EF,
                        BG1Offset = 0x614C0B,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 38:
                    return new Location
                    {
                        Number = 38,
                        LogicName = "GravitySuit",
                        Area = 0,
                        Room = 24,
                        MinimapX = 22,
                        MinimapY = 6,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Varia,
                        Requirements = new ItemType[0]
                    };
                case 39:
                    return new Location
                    {
                        Number = 39,
                        LogicName = "GitGudPowerBomb",
                        Area = 0,
                        Room = 27,
                        MinimapX = 5,
                        MinimapY = 2,
                        ClipdataOffset = 0x445E1E,
                        BG1Offset = 0x612C9A,
                        OrigItem = ItemType.Power,
                        Requirements = new ItemType[0]
                    };
                case 40:
                    return new Location
                    {
                        Number = 40,
                        LogicName = "GitGudMissile",
                        Area = 0,
                        Room = 27,
                        MinimapX = 5,
                        MinimapY = 2,
                        ClipdataOffset = 0x445E32,
                        BG1Offset = 0x612CCF,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 41:
                    return new Location
                    {
                        Number = 41,
                        LogicName = "GitGudSuper",
                        Area = 0,
                        Room = 27,
                        MinimapX = 6,
                        MinimapY = 2,
                        ClipdataOffset = 0x445E36,
                        BG1Offset = 0x612CD9,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[0]
                    };
                case 42:
                    return new Location
                    {
                        Number = 42,
                        LogicName = "GitGudETank",
                        Area = 0,
                        Room = 27,
                        MinimapX = 6,
                        MinimapY = 2,
                        ClipdataOffset = 0x445E4E,
                        BG1Offset = 0x612D3A,
                        OrigItem = ItemType.Energy,
                        Requirements = new ItemType[0]
                    };
                case 43:
                    return new Location
                    {
                        Number = 43,
                        LogicName = "ScrewAttackSuper1",
                        Area = 0,
                        Room = 21,
                        MinimapX = 5,
                        MinimapY = 3,
                        ClipdataOffset = 0x566D52,
                        BG1Offset = 0x5894C3,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[0]
                    };
                case 44:
                    return new Location
                    {
                        Number = 44,
                        LogicName = "ScrewAttackSuper2",
                        Area = 0,
                        Room = 21,
                        MinimapX = 4,
                        MinimapY = 3,
                        ClipdataOffset = 0x566D49,
                        BG1Offset = 0x5894B2,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[0]
                    };
                case 45:
                    return new Location
                    {
                        Number = 45,
                        LogicName = "ScrewAttack",
                        Area = 0,
                        Room = 21,
                        MinimapX = 3,
                        MinimapY = 3,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Screw,
                        Requirements = new ItemType[0]
                    };
                case 46:
                    return new Location
                    {
                        Number = 46,
                        LogicName = "UnderwaterETank",
                        Area = 0,
                        Room = 13,
                        MinimapX = 24,
                        MinimapY = 16,
                        ClipdataOffset = 0x60E0DA,
                        BG1Offset = 0x798999,
                        OrigItem = ItemType.Energy,
                        Requirements = new ItemType[0]
                    };
                case 47:
                    return new Location
                    {
                        Number = 47,
                        LogicName = "UnderwaterSuper",
                        Area = 0,
                        Room = 13,
                        MinimapX = 27,
                        MinimapY = 16,
                        ClipdataOffset = 0x60E09C,
                        BG1Offset = 0,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[0]
                    };
                case 48:
                    return new Location
                    {
                        Number = 48,
                        LogicName = "MechaEtank",
                        Area = 0,
                        Room = 41,
                        MinimapX = 27,
                        MinimapY = 18,
                        ClipdataOffset = 0x2EBE67,
                        BG1Offset = 0x562274,
                        OrigItem = ItemType.Energy,
                        Requirements = new ItemType[0]
                    };
                case 49:
                    return new Location
                    {
                        Number = 49,
                        LogicName = "IceBeam",
                        Area = 0,
                        Room = 34,
                        MinimapX = 25,
                        MinimapY = 18,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Ice,
                        Requirements = new ItemType[0]
                    };
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        public static Location SpookyLocation(int number)
        {
            switch (number)
            {
                case 0:
                    return new Location
                    {
                        Number = 0,
                        LogicName = "SpawnRoomMissile",
                        Area = 0,
                        Room = 0x8,
                        MinimapX = 0xC,
                        MinimapY = 0xA,
                        ClipdataOffset = 0x322078,
                        BG1Offset = 0x400E6F,
                        OrigItem = ItemType.Missile
                    };
                case 1:
                    return new Location
                    {
                        Number = 1,
                        LogicName = "Bombs",
                        Area = 0,
                        Room = 0x5,
                        MinimapX = 0xE,
                        MinimapY = 0xC,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Bomb
                    };
                case 2:
                    return new Location
                    {
                        Number = 2,
                        LogicName = "PumpkinEntranceMissile",
                        Area = 0x0,
                        Room = 0x10,
                        MinimapX = 0xC,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x5E49C9,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile
                    };
                case 3:
                    return new Location
                    {
                        Number = 3,
                        LogicName = "BehindMorphMissile",
                        Area = 0x0,
                        Room = 0x25,
                        MinimapX = 0xF,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x2F98B2,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile
                    };
                case 4:
                    return new Location
                    {
                        Number = 4,
                        LogicName = "Morph",
                        Area = 0x0,
                        Room = 0x25,
                        MinimapX = 0x10,
                        MinimapY = 0xD,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Morph
                    };
                case 5:
                    return new Location
                    {
                        Number = 5,
                        LogicName = "ForestEnergyTank",
                        Area = 0x0,
                        Room = 0x29,
                        MinimapX = 0x15,
                        MinimapY = 0xE,
                        ClipdataOffset = 0x5EE87F,
                        BG1Offset = 0x6426ED,
                        OrigItem = ItemType.Energy
                    };
                case 6:
                    return new Location
                    {
                        Number = 6,
                        LogicName = "Charge",
                        Area = 0x0,
                        Room = 0xC,
                        MinimapX = 0x9,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Charge
                    };
                case 7:
                    return new Location
                    {
                        Number = 7,
                        LogicName = "BehindChargeMissile",
                        Area = 0x0,
                        Room = 0xC,
                        MinimapX = 0x8,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x402C46,
                        BG1Offset = 0x407643,
                        OrigItem = ItemType.Missile
                    };
                case 8:
                    return new Location
                    {
                        Number = 8,
                        LogicName = "ForestExitMissile",
                        Area = 0x1,
                        Room = 0x3,
                        MinimapX = 0x5,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x406BB0,
                        BG1Offset = 0x608913,
                        OrigItem = ItemType.Missile
                    };
                case 9:
                    return new Location
                    {
                        Number = 9,
                        LogicName = "CastleBasementMissile",
                        Area = 0x1,
                        Room = 0x8,
                        MinimapX = 0x10,
                        MinimapY = 0xF,
                        ClipdataOffset = 0x5EBA89,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Super
                    };
                case 10:
                    return new Location
                    {
                        Number = 10,
                        LogicName = "BeerRoomSuper",
                        Area = 0x1,
                        Room = 0xB,
                        MinimapX = 0x14,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x558637,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Super
                    };
                case 11:
                    return new Location
                    {
                        Number = 11,
                        LogicName = "SecondEntranceMissile",
                        Area = 0x1,
                        Room = 0x28,
                        MinimapX = 0x12,
                        MinimapY = 0xC,
                        ClipdataOffset = 0x33ECA8,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Missile
                    };
                case 12:
                    return new Location
                    {
                        Number = 12,
                        LogicName = "WaveBeam",
                        Area = 0x1,
                        Room = 0x13,
                        MinimapX = 0x15,
                        MinimapY = 0x11,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Wave
                    };
                case 13:
                    return new Location
                    {
                        Number = 13,
                        LogicName = "Gravity",
                        Area = 0x1,
                        Room = 0xA,
                        MinimapX = 0x19,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Gravity
                    };
                case 14:
                    return new Location
                    {
                        Number = 14,
                        LogicName = "TheOtherBeerRoomSuperMissile",
                        Area = 0x1,
                        Room = 0x6,
                        MinimapX = 0x14,
                        MinimapY = 0xE,
                        ClipdataOffset = 0x2E1C9D,
                        BG1Offset = 0x61A1A6,
                        OrigItem = ItemType.Super
                    };
                case 15:
                    return new Location
                    {
                        Number = 15,
                        LogicName = "CastleEnergyTank",
                        Area = 0x1,
                        Room = 0xD,
                        MinimapX = 0x18,
                        MinimapY = 0xC,
                        ClipdataOffset = 0x2F9E89,
                        BG1Offset = 0x5E8561,
                        OrigItem = ItemType.Energy
                    };
                case 16:
                    return new Location
                    {
                        Number = 16,
                        LogicName = "CastleStashSuper",
                        Area = 0x1,
                        Room = 0x19,
                        MinimapX = 0x13,
                        MinimapY = 0xA,
                        ClipdataOffset = 0x5F6230,
                        BG1Offset = 0x605844,
                        OrigItem = ItemType.Super
                    };
                case 17:
                    return new Location
                    {
                        Number = 17,
                        LogicName = "CastleSpook",
                        Area = 0x1,
                        Room = 0x4,
                        MinimapX = 0x19,
                        MinimapY = 0x6,
                        ClipdataOffset = 0x4010CF,
                        BG1Offset = 0x56B502,
                        OrigItem = ItemType.Power
                    };
                case 18:
                    return new Location
                    {
                        Number = 18,
                        LogicName = "PlasmaBeam",
                        Area = 0x2,
                        Room = 0x12,
                        MinimapX = 0xB,
                        MinimapY = 0xA,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Plasma
                    };
                case 19:
                    return new Location
                    {
                        Number = 19,
                        LogicName = "HeatedMissile",
                        Area = 0x2,
                        Room = 0x6,
                        MinimapX = 0x12,
                        MinimapY = 0xC,
                        ClipdataOffset = 0x2C38F9,
                        BG1Offset = 0x5EB0B9,
                        OrigItem = ItemType.Missile
                    };
                case 20:
                    return new Location
                    {
                        Number = 20,
                        LogicName = "ItemInWallMissile",
                        Area = 0x2,
                        Room = 0x17,
                        MinimapX = 0x13,
                        MinimapY = 0xF,
                        ClipdataOffset = 0x5EECF2,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Missile
                    };
                case 21:
                    return new Location
                    {
                        Number = 21,
                        LogicName = "PreMuaSuper",
                        Area = 0x2,
                        Room = 0x1F,
                        MinimapX = 0xE,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x611746,
                        BG1Offset = 0x635953,
                        OrigItem = ItemType.Super
                    };
                case 22:
                    return new Location
                    {
                        Number = 22,
                        LogicName = "Varia",
                        Area = 0x2,
                        Room = 0xA,
                        MinimapX = 0xB,
                        MinimapY = 0xF,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Varia
                    };
                case 23:
                    return new Location
                    {
                        Number = 23,
                        LogicName = "HeatedEnergyTank",
                        Area = 0x2,
                        Room = 0xC,
                        MinimapX = 0xB,
                        MinimapY = 0x11,
                        ClipdataOffset = 0x2FC7BC,
                        BG1Offset = 0x558A28,
                        OrigItem = ItemType.Energy
                    };
                case 24:
                    return new Location
                    {
                        Number = 24,
                        LogicName = "DesgeegaRoomMissile",
                        Area = 0x2,
                        Room = 0xE,
                        MinimapX = 0x14,
                        MinimapY = 0xA,
                        ClipdataOffset = 0x67108A,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Missile
                    };
                case 25:
                    return new Location
                    {
                        Number = 25,
                        LogicName = "NearMapRoomMissile",
                        Area = 0x2,
                        Room = 0x13,
                        MinimapX = 0x16,
                        MinimapY = 0xC,
                        ClipdataOffset = 0x6170EE,
                        BG1Offset = 0x5FC0F4,
                        OrigItem = ItemType.Missile
                    };
                case 26:
                    return new Location
                    {
                        Number = 26,
                        LogicName = "BehindScrewBlocksEnergyTank",
                        Area = 0x2,
                        Room = 0xF,
                        MinimapX = 0x19,
                        MinimapY = 0xC,
                        ClipdataOffset = 0x5EE0F4,
                        BG1Offset = 0x561E37,
                        OrigItem = ItemType.Energy
                    };
                case 27:
                    return new Location
                    {
                        Number = 27,
                        LogicName = "SuperBlockedSuper",
                        Area = 0x2,
                        Room = 0x15,
                        MinimapX = 0x15,
                        MinimapY = 0x12,
                        ClipdataOffset = 0x631813,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Super
                    };
                case 28:
                    return new Location
                    {
                        Number = 28,
                        LogicName = "HellSpook",
                        Area = 0x2,
                        Room = 0x16,
                        MinimapX = 0x14,
                        MinimapY = 0x12,
                        ClipdataOffset = 0x2C381A,
                        BG1Offset = 0x2C3705,
                        OrigItem = ItemType.Power
                    };
                case 29:
                    return new Location
                    {
                        Number = 29,
                        LogicName = "SpeedBooster",
                        Area = 0x2,
                        Room = 0x1E,
                        MinimapX = 0x18,
                        MinimapY = 0x14,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Speed
                    };
                case 30:
                    return new Location
                    {
                        Number = 30,
                        LogicName = "MansionEnergyTank",
                        Area = 0x3,
                        Room = 0x0,
                        MinimapX = 0x16,
                        MinimapY = 0x12,
                        ClipdataOffset = 0x2FD544,
                        BG1Offset = 0x604F15,
                        OrigItem = ItemType.Energy
                    };
                case 31:
                    return new Location
                    {
                        Number = 31,
                        LogicName = "TheOtherMansionBigRoomMissile",
                        Area = 0x3,
                        Room = 0x5,
                        MinimapX = 0x8,
                        MinimapY = 0x14,
                        ClipdataOffset = 0x5E4030,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Missile
                    };
                case 32:
                    return new Location
                    {
                        Number = 32,
                        LogicName = "MansionBigRoomMissile",
                        Area = 0x3,
                        Room = 0x5,
                        MinimapX = 0x6,
                        MinimapY = 0x16,
                        ClipdataOffset = 0x5E40D2,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Missile
                    };
                case 33:
                    return new Location
                    {
                        Number = 33,
                        LogicName = "FakeMissile",
                        Area = 0x3,
                        Room = 0x24,
                        MinimapX = 0xA,
                        MinimapY = 0x17,
                        ClipdataOffset = 0x5E4DF7,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Missile
                    };
                case 34:
                    return new Location
                    {
                        Number = 34,
                        LogicName = "PreCharlieSuper",
                        Area = 0x3,
                        Room = 0xC,
                        MinimapX = 0x11,
                        MinimapY = 0x17,
                        ClipdataOffset = 0x60457D,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Super
                    };
                case 35:
                    return new Location
                    {
                        Number = 35,
                        LogicName = "IceBeam",
                        Area = 0x3,
                        Room = 0xD,
                        MinimapX = 0x13,
                        MinimapY = 0x18,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Ice
                    };
                case 36:
                    return new Location
                    {
                        Number = 36,
                        LogicName = "OneOfsGreatestRoomEnergyTank",
                        Area = 0x3,
                        Room = 0x26,
                        MinimapX = 0x11,
                        MinimapY = 0xE,
                        ClipdataOffset = 0x55DC9C,
                        BG1Offset = 0x55DA98,
                        OrigItem = ItemType.Energy
                    };
                case 37:
                    return new Location
                    {
                        Number = 37,
                        LogicName = "MansionOutsideSuper",
                        Area = 0x3,
                        Room = 0x3,
                        MinimapX = 0xF,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x608A61,
                        BG1Offset = 0x610640,
                        OrigItem = ItemType.Super
                    };
                case 38:
                    return new Location
                    {
                        Number = 38,
                        LogicName = "HiJump",
                        Area = 0x3,
                        Room = 0x18,
                        MinimapX = 0x9,
                        MinimapY = 0xB,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Hi
                    };
                case 39:
                    return new Location
                    {
                        Number = 39,
                        LogicName = "ClocktowerMissile",
                        Area = 0x3,
                        Room = 0x15,
                        MinimapX = 0x11,
                        MinimapY = 0x9,
                        ClipdataOffset = 0x56257C,
                        BG1Offset = 0x630FB9,
                        OrigItem = ItemType.Missile
                    };
                case 40:
                    return new Location
                    {
                        Number = 40,
                        LogicName = "MansionSpook",
                        Area = 0x3,
                        Room = 0x2A,
                        MinimapX = 0x15,
                        MinimapY = 0x7,
                        ClipdataOffset = 0x5546C3,
                        BG1Offset = 0x5547D1,
                        OrigItem = ItemType.Power
                    };
                case 41:
                    return new Location
                    {
                        Number = 41,
                        LogicName = "SpaceJump",
                        Area = 0x4,
                        Room = 0x0,
                        MinimapX = 0xA,
                        MinimapY = 0xC,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Space
                    };
                case 42:
                    return new Location
                    {
                        Number = 42,
                        LogicName = "ScrewAttack",
                        Area = 0x4,
                        Room = 0x7,
                        MinimapX = 0xE,
                        MinimapY = 0xA,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Screw
                    };
                case 43:
                    return new Location
                    {
                        Number = 43,
                        LogicName = "LastSuper",
                        Area = 0x4,
                        Room = 0x2,
                        MinimapX = 0x14,
                        MinimapY = 0xA,
                        ClipdataOffset = 0x5E7787,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Super
                    };
                default:
                    throw new IndexOutOfRangeException();

            }
        }

        public static Location GetLocation(int number)
        {
            switch (number)
            {
                case 0:
                    return new Location
                    {
                        Number = 0,
                        LogicName = "BrinstarMorph",
                        Area = 0,
                        Room = 0,
                        MinimapX = 0,
                        MinimapY = 15,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Morph,
                        Requirements = new ItemType[0]
                    };
                case 1:
                    return new Location
                    {
                        Number = 1,
                        LogicName = "BrinstarBallCannon",
                        Area = 0,
                        Room = 1,
                        MinimapX = 5,
                        MinimapY = 14,
                        ClipdataOffset = 0x60CDA4,
                        BG1Offset = 0x60CF4A,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[] { ItemType.Bomb }
                    };
                case 2:
                    return new Location
                    {
                        Number = 2,
                        LogicName = "BrinstarLong",
                        Area = 0,
                        Room = 5,
                        MinimapX = 6,
                        MinimapY = 6,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Long,
                        Requirements = new ItemType[0]
                    };
                case 3:
                    return new Location
                    {
                        Number = 3,
                        LogicName = "BrinstarCeilingEtank",
                        Area = 0,
                        Room = 2,
                        MinimapX = 7,
                        MinimapY = 15,
                        ClipdataOffset = 0x60D48C,
                        BG1Offset = 0,
                        OrigItem = ItemType.Energy,
                        Requirements = new ItemType[0]
                    };
                case 4:
                    return new Location
                    {
                        Number = 4,
                        LogicName = "BrinstarAboveSuper",
                        Area = 0,
                        Room = 0x29,
                        MinimapX = 9,
                        MinimapY = 11,
                        ClipdataOffset = 0x617076,
                        BG1Offset = 0x617295,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 5:
                    return new Location
                    {
                        Number = 5,
                        LogicName = "BrinstarSuper",
                        Area = 0,
                        Room = 0x29,
                        MinimapX = 9,
                        MinimapY = 12,
                        ClipdataOffset = 0x6170B3,
                        BG1Offset = 0x61730C,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[] { ItemType.Speed, ItemType.Hi }
                    };
                case 6:
                    return new Location
                    {
                        Number = 6,
                        LogicName = "BrinstarTopMissile",
                        Area = 0,
                        Room = 0x1D,
                        MinimapX = 11,
                        MinimapY = 3,
                        ClipdataOffset = 0x6159DE,
                        BG1Offset = 0x615A90,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 7:
                    return new Location
                    {
                        Number = 7,
                        LogicName = "BrinstarShortcutMissile",
                        Area = 0,
                        Room = 0x28,
                        MinimapX = 11,
                        MinimapY = 12,
                        ClipdataOffset = 0x616ECF,
                        BG1Offset = 0x616F59,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 8:
                    return new Location
                    {
                        Number = 8,
                        LogicName = "BrinstarVaria",
                        Area = 0,
                        Room = 0x1B,
                        MinimapX = 14,
                        MinimapY = 2,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Varia,
                        Requirements = new ItemType[0]
                    };
                case 9:
                    return new Location
                    {
                        Number = 9,
                        LogicName = "BrinstarWorm",
                        Area = 0,
                        Room = 0xC,
                        MinimapX = 14,
                        MinimapY = 12,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Charge,
                        Requirements = new ItemType[0]
                    };
                case 10:
                    return new Location
                    {
                        Number = 10,
                        LogicName = "BrinstarVariaETank",
                        Area = 0,
                        Room = 0x17,
                        MinimapX = 16,
                        MinimapY = 3,
                        ClipdataOffset = 0x614435,
                        BG1Offset = 0x6146D4,
                        OrigItem = ItemType.Energy,
                        Requirements = new ItemType[0]
                    };
                case 11:
                    return new Location
                    {
                        Number = 11,
                        LogicName = "BrinstarFirstMissile",
                        Area = 0,
                        Room = 0xC,
                        MinimapX = 16,
                        MinimapY = 12,
                        ClipdataOffset = 0x610F98,
                        BG1Offset = 0x611384,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 12:
                    return new Location
                    {
                        Number = 12,
                        LogicName = "BrinstarHiveMissile",
                        Area = 0,
                        Room = 0xF,
                        MinimapX = 17,
                        MinimapY = 7,
                        ClipdataOffset = 0x611F4C,
                        BG1Offset = 0x612139,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 13:
                    return new Location
                    {
                        Number = 13,
                        LogicName = "BrinstarUnderBridge",
                        Area = 0,
                        Room = 0xE,
                        MinimapX = 17,
                        MinimapY = 10,
                        ClipdataOffset = 0x611C95,
                        BG1Offset = 0x611E1A,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 14:
                    return new Location
                    {
                        Number = 14,
                        LogicName = "BrinstarPostHiveMissile",
                        Area = 0,
                        Room = 0x13,
                        MinimapX = 22,
                        MinimapY = 8,
                        ClipdataOffset = 0x612BAE,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 15:
                    return new Location
                    {
                        Number = 15,
                        LogicName = "BrinstarPillarMissile",
                        Area = 0,
                        Room = 0x15,
                        MinimapX = 23,
                        MinimapY = 4,
                        ClipdataOffset = 0x61381B,
                        BG1Offset = 0x613AB0,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 16:
                    return new Location
                    {
                        Number = 16,
                        LogicName = "BrinstarBehindBombs",
                        Area = 0,
                        Room = 0x19,
                        MinimapX = 23,
                        MinimapY = 6,
                        ClipdataOffset = 0x614E7C,
                        BG1Offset = 0x61501F,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 17:
                    return new Location
                    {
                        Number = 17,
                        LogicName = "BrinstarBombs",
                        Area = 0,
                        Room = 0x19,
                        MinimapX = 24,
                        MinimapY = 6,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Bomb,
                        Requirements = new ItemType[0]
                    };
                case 18:
                    return new Location
                    {
                        Number = 18,
                        LogicName = "BrinstarPostHiveETank",
                        Area = 0,
                        Room = 0x13,
                        MinimapX = 24,
                        MinimapY = 8,
                        ClipdataOffset = 0x612B30,
                        BG1Offset = 0x612D80,
                        OrigItem = ItemType.Energy,
                        Requirements = new ItemType[0]
                    };
                case 19:
                    return new Location
                    {
                        Number = 19,
                        LogicName = "KraidGiantHoppers",
                        Area = 1,
                        Room = 0x1A,
                        MinimapX = 3,
                        MinimapY = 5,
                        ClipdataOffset = 0x635749,
                        BG1Offset = 0x635B5A,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 20:
                    return new Location
                    {
                        Number = 20,
                        LogicName = "KraidSaveMissile",
                        Area = 1,
                        Room = 7,
                        MinimapX = 6,
                        MinimapY = 6,
                        ClipdataOffset = 0x631FFB,
                        BG1Offset = 0x6322F7,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 21:
                    return new Location
                    {
                        Number = 21,
                        LogicName = "KraidCrumbleMissile",
                        Area = 1,
                        Room = 0xA,
                        MinimapX = 7,
                        MinimapY = 9,
                        ClipdataOffset = 0x632EDF,
                        BG1Offset = 0x63302E,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 22:
                    return new Location
                    {
                        Number = 22,
                        LogicName = "KraidBoringRoom",
                        Area = 1,
                        Room = 0x15,
                        MinimapX = 7,
                        MinimapY = 12,
                        ClipdataOffset = 0x6349BA,
                        BG1Offset = 0x634B84,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 23:
                    return new Location
                    {
                        Number = 23,
                        LogicName = "KraidSpace",
                        Area = 1,
                        Room = 0x21,
                        MinimapX = 7,
                        MinimapY = 14,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Space,
                        Requirements = new ItemType[0]
                    };
                case 24:
                    return new Location
                    {
                        Number = 24,
                        LogicName = "KraidLavaMissile",
                        Area = 1,
                        Room = 8,
                        MinimapX = 8,
                        MinimapY = 8,
                        ClipdataOffset = 0x632624,
                        BG1Offset = 0x632A52,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[] { ItemType.Speed, ItemType.Hi, ItemType.Gravity }
                    };
                case 25:
                    return new Location
                    {
                        Number = 25,
                        LogicName = "KraidSpeed",
                        Area = 1,
                        Room = 0x22,
                        MinimapX = 8,
                        MinimapY = 15,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Speed,
                        Requirements = new ItemType[0]
                    };
                case 26:
                    return new Location
                    {
                        Number = 26,
                        LogicName = "KraidWormMissile",
                        Area = 1,
                        Room = 0x26,
                        MinimapX = 11,
                        MinimapY = 4,
                        ClipdataOffset = 0x637CC0,
                        BG1Offset = 0x637D59,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[] { ItemType.Bomb }
                    };
                case 27:
                    return new Location
                    {
                        Number = 27,
                        LogicName = "KraidPillarMissile",
                        Area = 1,
                        Room = 1,
                        MinimapX = 11,
                        MinimapY = 6,
                        ClipdataOffset = 0x630563,
                        BG1Offset = 0x6307C8,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 28:
                    return new Location
                    {
                        Number = 28,
                        LogicName = "KraidLavaFall",
                        Area = 1,
                        Room = 0x11,
                        MinimapX = 12,
                        MinimapY = 10,
                        ClipdataOffset = 0x6340CC,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 29:
                    return new Location
                    {
                        Number = 29,
                        LogicName = "KraidWormETank",
                        Area = 1,
                        Room = 4,
                        MinimapX = 13,
                        MinimapY = 2,
                        ClipdataOffset = 0x6316F1,
                        BG1Offset = 0x6317C5,
                        OrigItem = ItemType.Energy,
                        Requirements = new ItemType[] { ItemType.Bomb }
                    };
                case 30:
                    return new Location
                    {
                        Number = 30,
                        LogicName = "KraidSpeedJump",
                        Area = 1,
                        Room = 9,
                        MinimapX = 13,
                        MinimapY = 7,
                        ClipdataOffset = 0x632BC5,
                        BG1Offset = 0x632D36,
                        OrigItem = ItemType.Energy,
                        Requirements = new ItemType[] { ItemType.Speed }
                    };
                case 31:
                    return new Location
                    {
                        Number = 31,
                        LogicName = "KraidBallCannon",
                        Area = 1,
                        Room = 2,
                        MinimapX = 15,
                        MinimapY = 4,
                        ClipdataOffset = 0x630B45,
                        BG1Offset = 0x63110A,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[] { ItemType.Bomb }
                    };
                case 32:
                    return new Location
                    {
                        Number = 32,
                        LogicName = "NorfairPowerBomb",
                        Area = 2,
                        Room = 0x37,
                        MinimapX = 3,
                        MinimapY = 11,
                        ClipdataOffset = 0x67CCCD,
                        BG1Offset = 0x67CF78,
                        OrigItem = ItemType.Power,
                        Requirements = new ItemType[] { ItemType.Gravity }
                    };
                case 33:
                    return new Location
                    {
                        Number = 33,
                        LogicName = "NorfairLavaMissile",
                        Area = 2,
                        Room = 0x37,
                        MinimapX = 4,
                        MinimapY = 12,
                        ClipdataOffset = 0x67CD34,
                        BG1Offset = 0x67D05B,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 34:
                    return new Location
                    {
                        Number = 34,
                        LogicName = "NorfairScrew",
                        Area = 2,
                        Room = 0x12,
                        MinimapX = 6,
                        MinimapY = 7,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Screw,
                        Requirements = new ItemType[0]
                    };
                case 35:
                    return new Location
                    {
                        Number = 35,
                        LogicName = "NorfairScrewMissile",
                        Area = 2,
                        Room = 0x11,
                        MinimapX = 8,
                        MinimapY = 7,
                        ClipdataOffset = 0x67219B,
                        BG1Offset = 0x67226A,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[] { ItemType.Screw }
                    };
                case 36:
                    return new Location
                    {
                        Number = 36,
                        LogicName = "NorfairGripMissile",
                        Area = 2,
                        Room = 1,
                        MinimapX = 10,
                        MinimapY = 5,
                        ClipdataOffset = 0x66C015,
                        BG1Offset = 0x66C3D9,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 37:
                    return new Location
                    {
                        Number = 37,
                        LogicName = "NorfairUnderElevator",
                        Area = 2,
                        Room = 3,
                        MinimapX = 10,
                        MinimapY = 6,
                        ClipdataOffset = 0x66CDCE,
                        BG1Offset = 0x66D00B,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 38:
                    return new Location
                    {
                        Number = 38,
                        LogicName = "NorfairWave",
                        Area = 2,
                        Room = 0x1B,
                        MinimapX = 10,
                        MinimapY = 12,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Wave,
                        Requirements = new ItemType[0]
                    };
                case 39:
                    return new Location
                    {
                        Number = 39,
                        LogicName = "NorfairBombSuper",
                        Area = 2,
                        Room = 0x26,
                        MinimapX = 11,
                        MinimapY = 6,
                        ClipdataOffset = 0x6787A9,
                        BG1Offset = 0x6788D0,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[0]
                    };
                case 40:
                    return new Location
                    {
                        Number = 40,
                        LogicName = "NorfairBottomHeatedFirst",
                        Area = 2,
                        Room = 0x1C,
                        MinimapX = 11,
                        MinimapY = 13,
                        ClipdataOffset = 0x674EAC,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 41:
                    return new Location
                    {
                        Number = 41,
                        LogicName = "NorfairBottomHeatedSecond",
                        Area = 2,
                        Room = 0x1C,
                        MinimapX = 13,
                        MinimapY = 13,
                        ClipdataOffset = 0x674EC5,
                        BG1Offset = 0x6750B7,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 42:
                    return new Location
                    {
                        Number = 42,
                        LogicName = "NorfairHeatedSparkMissile",
                        Area = 2,
                        Room = 0x25,
                        MinimapX = 14,
                        MinimapY = 6,
                        ClipdataOffset = 0x677D94,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 43:
                    return new Location
                    {
                        Number = 43,
                        LogicName = "NorfairSpaceBoostMissile",
                        Area = 2,
                        Room = 0x20,
                        MinimapX = 15,
                        MinimapY = 10,
                        ClipdataOffset = 0x676AF5,
                        BG1Offset = 0x676C37,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 44:
                    return new Location
                    {
                        Number = 44,
                        LogicName = "NorfairSpaceBoostSuper",
                        Area = 2,
                        Room = 0x20,
                        MinimapX = 17,
                        MinimapY = 10,
                        ClipdataOffset = 0x676AD6,
                        BG1Offset = 0x676C02,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[0]
                    };
                case 45:
                    return new Location
                    {
                        Number = 45,
                        LogicName = "NorfairIce",
                        Area = 2,
                        Room = 8,
                        MinimapX = 18,
                        MinimapY = 3,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Ice,
                        Requirements = new ItemType[0]
                    };
                case 46:
                    return new Location
                    {
                        Number = 46,
                        LogicName = "NorfairIceHeated",
                        Area = 2,
                        Room = 0xA,
                        MinimapX = 19,
                        MinimapY = 2,
                        ClipdataOffset = 0x670534,
                        BG1Offset = 0x67069B,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 47:
                    return new Location
                    {
                        Number = 47,
                        LogicName = "NorfairHiJump",
                        Area = 2,
                        Room = 0xD,
                        MinimapX = 19,
                        MinimapY = 8,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Hi,
                        Requirements = new ItemType[0]
                    };
                case 48:
                    return new Location
                    {
                        Number = 48,
                        LogicName = "NorfairBigRoom",
                        Area = 2,
                        Room = 4,
                        MinimapX = 20,
                        MinimapY = 4,
                        ClipdataOffset = 0x66D389,
                        BG1Offset = 0x66D6CB,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 49:
                    return new Location
                    {
                        Number = 49,
                        LogicName = "NorfairTopMissile",
                        Area = 2,
                        Room = 0x2F,
                        MinimapX = 21,
                        MinimapY = 1,
                        ClipdataOffset = 0x67A4D1,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 50:
                    return new Location
                    {
                        Number = 50,
                        LogicName = "NorfairLarvaEtank",
                        Area = 2,
                        Room = 0x2A,
                        MinimapX = 21,
                        MinimapY = 11,
                        ClipdataOffset = 0x678E26,
                        BG1Offset = 0,
                        OrigItem = ItemType.Energy,
                        Requirements = new ItemType[] { ItemType.Speed }
                    };
                case 51:
                    return new Location
                    {
                        Number = 51,
                        LogicName = "NorfairBallCannon",
                        Area = 2,
                        Room = 5,
                        MinimapX = 22,
                        MinimapY = 8,
                        ClipdataOffset = 0x66DFC4,
                        BG1Offset = 0x66F173,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 52:
                    return new Location
                    {
                        Number = 52,
                        LogicName = "NorfairShaftBottom",
                        Area = 2,
                        Room = 5,
                        MinimapX = 22,
                        MinimapY = 11,
                        ClipdataOffset = 0x66E1B2,
                        BG1Offset = 0x66F46B,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 53:
                    return new Location
                    {
                        Number = 53,
                        LogicName = "RidleySWPuzzleTop",
                        Area = 3,
                        Room = 0x1D,
                        MinimapX = 3,
                        MinimapY = 8,
                        ClipdataOffset = 0x6A2D2E,
                        BG1Offset = 0x6A2EBF,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[] { ItemType.Speed, ItemType.Grip }
                    };
                case 54:
                    return new Location
                    {
                        Number = 54,
                        LogicName = "RidleySWPuzzleBottom",
                        Area = 3,
                        Room = 0x1D,
                        MinimapX = 3,
                        MinimapY = 9,
                        ClipdataOffset = 0x6A2E3C,
                        BG1Offset = 0x6A3029,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[] { ItemType.Speed, ItemType.Grip }
                    };
                case 55:
                    return new Location
                    {
                        Number = 55,
                        LogicName = "RidleyWestPillar",
                        Area = 3,
                        Room = 6,
                        MinimapX = 4,
                        MinimapY = 6,
                        ClipdataOffset = 0x69C5EB,
                        BG1Offset = 0x69C88F,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 56:
                    return new Location
                    {
                        Number = 56,
                        LogicName = "RidleyStatueETank",
                        Area = 3,
                        Room = 0xD,
                        MinimapX = 5,
                        MinimapY = 7,
                        ClipdataOffset = 0x69E035,
                        BG1Offset = 0x69E277,
                        OrigItem = ItemType.Energy,
                        Requirements = new ItemType[0]
                    };
                case 57:
                    return new Location
                    {
                        Number = 57,
                        LogicName = "RidleyGravity",
                        Area = 3,
                        Room = 0xD,
                        MinimapX = 6,
                        MinimapY = 7,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Gravity,
                        Requirements = new ItemType[0]
                    };
                case 58:
                    return new Location
                    {
                        Number = 58,
                        LogicName = "RidleyFakeFloor",
                        Area = 3,
                        Room = 4,
                        MinimapX = 7,
                        MinimapY = 3,
                        ClipdataOffset = 0x69BF75,
                        BG1Offset = 0x69C05F,
                        OrigItem = ItemType.Energy,
                        Requirements = new ItemType[0]
                    };
                case 59:
                    return new Location
                    {
                        Number = 59,
                        LogicName = "RidleyUpperBallCannon",
                        Area = 3,
                        Room = 0x17,
                        MinimapX = 8,
                        MinimapY = 4,
                        ClipdataOffset = 0x6A1B48,
                        BG1Offset = 0x6A1C35,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 60:
                    return new Location
                    {
                        Number = 60,
                        LogicName = "RidleyLowerBallCannon",
                        Area = 3,
                        Room = 0x17,
                        MinimapX = 8,
                        MinimapY = 5,
                        ClipdataOffset = 0x6A1BBB,
                        BG1Offset = 0x6A1CD1,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 61:
                    return new Location
                    {
                        Number = 61,
                        LogicName = "RidleyImagoSuper",
                        Area = 3,
                        Room = 0x13,
                        MinimapX = 9,
                        MinimapY = 1,
                        ClipdataOffset = 0x6A1152,
                        BG1Offset = 0x6A14F9,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[0]
                    };
                case 62:
                    return new Location
                    {
                        Number = 62,
                        LogicName = "RidleyAboveSuper",
                        Area = 3,
                        Room = 0x16,
                        MinimapX = 9,
                        MinimapY = 4,
                        ClipdataOffset = 0x6A1900,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 63:
                    return new Location
                    {
                        Number = 63,
                        LogicName = "RidleySidehopperSuper",
                        Area = 3,
                        Room = 0x16,
                        MinimapX = 9,
                        MinimapY = 5,
                        ClipdataOffset = 0x6A1942,
                        BG1Offset = 0x6A1A38,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[0]
                    };
                case 64:
                    return new Location
                    {
                        Number = 64,
                        LogicName = "RidleyLongHall",
                        Area = 3,
                        Room = 0x12,
                        MinimapX = 10,
                        MinimapY = 8,
                        ClipdataOffset = 0x6A057A,
                        BG1Offset = 0x6A08F3,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 65:
                    return new Location
                    {
                        Number = 65,
                        LogicName = "RidleyPillarMissile",
                        Area = 3,
                        Room = 9,
                        MinimapX = 12,
                        MinimapY = 5,
                        ClipdataOffset = 0x69D161,
                        BG1Offset = 0x69D262,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 66:
                    return new Location
                    {
                        Number = 66,
                        LogicName = "RidleyBallMissile",
                        Area = 3,
                        Room = 0xA,
                        MinimapX = 13,
                        MinimapY = 5,
                        ClipdataOffset = 0x69D458,
                        BG1Offset = 0x69D664,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 67:
                    return new Location
                    {
                        Number = 67,
                        LogicName = "RidleyBallSuper",
                        Area = 3,
                        Room = 0xA,
                        MinimapX = 14,
                        MinimapY = 4,
                        ClipdataOffset = 0x69D407,
                        BG1Offset = 0,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[0]
                    };
                case 68:
                    return new Location
                    {
                        Number = 68,
                        LogicName = "RidleySidehopperMissile",
                        Area = 3,
                        Room = 0x11,
                        MinimapX = 16,
                        MinimapY = 6,
                        ClipdataOffset = 0x69F9FA,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 69:
                    return new Location
                    {
                        Number = 69,
                        LogicName = "RidleyOwlETank",
                        Area = 3,
                        Room = 0xE,
                        MinimapX = 17,
                        MinimapY = 7,
                        ClipdataOffset = 0x69E3B6,
                        BG1Offset = 0x69E509,
                        OrigItem = ItemType.Energy,
                        Requirements = new ItemType[0]
                    };
                case 70:
                    return new Location
                    {
                        Number = 70,
                        LogicName = "RidleyJumpyJumpy",
                        Area = 3,
                        Room = 0x10,
                        MinimapX = 19,
                        MinimapY = 2,
                        ClipdataOffset = 0x69EE00,
                        BG1Offset = 0x69F57A,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 71:
                    return new Location
                    {
                        Number = 71,
                        LogicName = "RidleyBombPuzzle",
                        Area = 3,
                        Room = 0x1E,
                        MinimapX = 22,
                        MinimapY = 7,
                        ClipdataOffset = 0x6A32CF,
                        BG1Offset = 0x6A3485,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[] { ItemType.Speed, ItemType.Grip }
                    };
                case 72:
                    return new Location
                    {
                        Number = 72,
                        LogicName = "RidleySpeedJump",
                        Area = 3,
                        Room = 0x1F,
                        MinimapX = 24,
                        MinimapY = 5,
                        ClipdataOffset = 0x6A36A0,
                        BG1Offset = 0x6A37A6,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[] { ItemType.Wave, ItemType.Speed }
                    };
                case 73:
                    return new Location
                    {
                        Number = 73,
                        LogicName = "TourianSpaceBoost",
                        Area = 4,
                        Room = 8,
                        MinimapX = 17,
                        MinimapY = 11,
                        ClipdataOffset = 0x6BC9CC,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[] { ItemType.Speed }
                    };
                case 74:
                    return new Location
                    {
                        Number = 74,
                        LogicName = "TourianUnderBrain",
                        Area = 4,
                        Room = 7,
                        MinimapX = 19,
                        MinimapY = 12,
                        ClipdataOffset = 0x6BC698,
                        BG1Offset = 0x6BC701,
                        OrigItem = ItemType.Power,
                        Requirements = new ItemType[0]
                    };
                case 75:
                    return new Location
                    {
                        Number = 75,
                        LogicName = "CrateriaPowerBomb",
                        Area = 5,
                        Room = 0,
                        MinimapX = 9,
                        MinimapY = 4,
                        ClipdataOffset = 0x6DE293,
                        BG1Offset = 0x6DCC78,
                        OrigItem = ItemType.Power,
                        Requirements = new ItemType[] { ItemType.Speed, ItemType.Hi }
                    };
                case 76:
                    return new Location
                    {
                        Number = 76,
                        LogicName = "CrateriaGrip",
                        Area = 5,
                        Room = 0xC,
                        MinimapX = 14,
                        MinimapY = 6,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Grip,
                        Requirements = new ItemType[0]
                    };
                case 77:
                    return new Location
                    {
                        Number = 77,
                        LogicName = "CrateriaMoat",
                        Area = 5,
                        Room = 7,
                        MinimapX = 17,
                        MinimapY = 8,
                        ClipdataOffset = 0x6DF4BC,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 78:
                    return new Location
                    {
                        Number = 78,
                        LogicName = "CrateriaStatueWater",
                        Area = 5,
                        Room = 0xE,
                        MinimapX = 19,
                        MinimapY = 5,
                        ClipdataOffset = 0x6E1F4E,
                        BG1Offset = 0x6E209F,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 79:
                    return new Location
                    {
                        Number = 79,
                        LogicName = "CrateriaPlasma",
                        Area = 5,
                        Room = 0xE,
                        MinimapX = 20,
                        MinimapY = 5,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Plasma,
                        Requirements = new ItemType[0]
                    };
                case 80:
                    return new Location
                    {
                        Number = 80,
                        LogicName = "CrateriaBallSpark",
                        Area = 5,
                        Room = 9,
                        MinimapX = 21,
                        MinimapY = 5,
                        ClipdataOffset = 0x6E09FC,
                        BG1Offset = 0x6E13AE,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[] { ItemType.Speed, ItemType.Hi }
                    };
                case 81:
                    return new Location
                    {
                        Number = 81,
                        LogicName = "CrateriaSuper",
                        Area = 5,
                        Room = 9,
                        MinimapX = 22,
                        MinimapY = 2,
                        ClipdataOffset = 0x6E086F,
                        BG1Offset = 0x6E108C,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[] { ItemType.Speed }
                    };
                case 82:
                    return new Location
                    {
                        Number = 82,
                        LogicName = "ChozodiaCrateriaPowerBomb",
                        Area = 6,
                        Room = 0x22,
                        MinimapX = 4,
                        MinimapY = 18,
                        ClipdataOffset = 0x737B42,
                        BG1Offset = 0,
                        OrigItem = ItemType.Power,
                        Requirements = new ItemType[0]
                    };
                case 83:
                    return new Location
                    {
                        Number = 83,
                        LogicName = "ChozodiaBombMaze",
                        Area = 6,
                        Room = 0x42,
                        MinimapX = 4,
                        MinimapY = 21,
                        ClipdataOffset = 0x741EC6,
                        BG1Offset = 0,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[0]
                    };
                case 84:
                    return new Location
                    {
                        Number = 84,
                        LogicName = "ChozodiaZoomerMaze",
                        Area = 6,
                        Room = 0x41,
                        MinimapX = 6,
                        MinimapY = 21,
                        ClipdataOffset = 0x741A98,
                        BG1Offset = 0,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[0]
                    };
                case 85:
                    return new Location
                    {
                        Number = 85,
                        LogicName = "ChozodiaFirstRuinSuper",
                        Area = 6,
                        Room = 0x59,
                        MinimapX = 7,
                        MinimapY = 19,
                        ClipdataOffset = 0x74830A,
                        BG1Offset = 0,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[0]
                    };
                case 86:
                    return new Location
                    {
                        Number = 86,
                        LogicName = "ChozodiaCharlieSparkMissile",
                        Area = 6,
                        Room = 0x5A,
                        MinimapX = 10,
                        MinimapY = 7,
                        ClipdataOffset = 0x7486A9,
                        BG1Offset = 0x748C58,
                        OrigItem = ItemType.Missile,
                        Requirements = new ItemType[0]
                    };
                case 87:
                    return new Location
                    {
                        Number = 87,
                        LogicName = "ChozodiaCharlieSuper",
                        Area = 6,
                        Room = 0x5A,
                        MinimapX = 10,
                        MinimapY = 8,
                        ClipdataOffset = 0x748784,
                        BG1Offset = 0x748E26,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[] { ItemType.Speed, ItemType.Gravity }
                    };
                case 88:
                    return new Location
                    {
                        Number = 88,
                        LogicName = "ChozodiaOutOfTheWay",
                        Area = 6,
                        Room = 0x1A,
                        MinimapX = 10,
                        MinimapY = 9,
                        ClipdataOffset = 0x735432,
                        BG1Offset = 0x735565,
                        OrigItem = ItemType.Power,
                        Requirements = new ItemType[0]
                    };
                case 89:
                    return new Location
                    {
                        Number = 89,
                        LogicName = "ChozodiaGlassTubeETank",
                        Area = 6,
                        Room = 0x18,
                        MinimapX = 10,
                        MinimapY = 18,
                        ClipdataOffset = 0x73499B,
                        BG1Offset = 0x734B75,
                        OrigItem = ItemType.Energy,
                        Requirements = new ItemType[] { ItemType.Speed }
                    };
                case 90:
                    return new Location
                    {
                        Number = 90,
                        LogicName = "ChozodiaLavaSuper",
                        Area = 6,
                        Room = 0x36,
                        MinimapX = 11,
                        MinimapY = 13,
                        ClipdataOffset = 0x73DF3E,
                        BG1Offset = 0x73E293,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[0]
                    };
                case 91:
                    return new Location
                    {
                        Number = 91,
                        LogicName = "ChozodiaOriginalPowerBomb",
                        Area = 6,
                        Room = 0x2F,
                        MinimapX = 14,
                        MinimapY = 5,
                        ClipdataOffset = 0x73B9CF,
                        BG1Offset = 0x73BAD0,
                        OrigItem = ItemType.Power,
                        Requirements = new ItemType[0]
                    };
                case 92:
                    return new Location
                    {
                        Number = 92,
                        LogicName = "ChozodiaSecondPowerBomb",
                        Area = 6,
                        Room = 0x31,
                        MinimapX = 15,
                        MinimapY = 4,
                        ClipdataOffset = 0x73C4F1,
                        BG1Offset = 0x73C6AC,
                        OrigItem = ItemType.Power,
                        Requirements = new ItemType[0]
                    };
                case 93:
                    return new Location
                    {
                        Number = 93,
                        LogicName = "ChozodiaGlassTubePowerBomb",
                        Area = 6,
                        Room = 0x5F,
                        MinimapX = 15,
                        MinimapY = 13,
                        ClipdataOffset = 0x74A8E0,
                        BG1Offset = 0x74AB44,
                        OrigItem = ItemType.Power,
                        Requirements = new ItemType[0]
                    };
                case 94:
                    return new Location
                    {
                        Number = 94,
                        LogicName = "ChozodiaCharlieSpark",
                        Area = 6,
                        Room = 0x4E,
                        MinimapX = 17,
                        MinimapY = 8,
                        ClipdataOffset = 0x744AAB,
                        BG1Offset = 0x744CB4,
                        OrigItem = ItemType.Energy,
                        Requirements = new ItemType[] { ItemType.Speed, ItemType.Gravity }
                    };
                case 95:
                    return new Location
                    {
                        Number = 95,
                        LogicName = "ChozodiaShortcutSuper",
                        Area = 6,
                        Room = 0x49,
                        MinimapX = 18,
                        MinimapY = 7,
                        ClipdataOffset = 0x743E2F,
                        BG1Offset = 0,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[0]
                    };
                case 96:
                    return new Location
                    {
                        Number = 96,
                        LogicName = "ChozodiaWorkbotSuper",
                        Area = 6,
                        Room = 0xE,
                        MinimapX = 20,
                        MinimapY = 7,
                        ClipdataOffset = 0x731732,
                        BG1Offset = 0x731A05,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[0]
                    };
                case 97:
                    return new Location
                    {
                        Number = 97,
                        LogicName = "ChozodiaHullSuper",
                        Area = 6,
                        Room = 0xA,
                        MinimapX = 21,
                        MinimapY = 15,
                        ClipdataOffset = 0x72FD52,
                        BG1Offset = 0,
                        OrigItem = ItemType.Super,
                        Requirements = new ItemType[0]
                    };
                case 98:
                    return new Location
                    {
                        Number = 98,
                        LogicName = "ChozodiaSpaceJumpETank",
                        Area = 6,
                        Room = 0x47,
                        MinimapX = 22,
                        MinimapY = 2,
                        ClipdataOffset = 0x743783,
                        BG1Offset = 0x743B4E,
                        OrigItem = ItemType.Energy,
                        Requirements = new ItemType[] { ItemType.Speed }
                    };
                case 99:
                    return new Location
                    {
                        Number = 99,
                        LogicName = "ChozodiaHullPowerBomb",
                        Area = 6,
                        Room = 0x57,
                        MinimapX = 26,
                        MinimapY = 14,
                        ClipdataOffset = 0x74793B,
                        BG1Offset = 0,
                        OrigItem = ItemType.Power,
                        Requirements = new ItemType[0]
                    };
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        public static Location[] GetLocations(Game game = Game.Original)
        {
            Location[] locations;
            switch (game)
            {
                case Game.Deep_Freeze:
                    Count = 50;
                    ChargeBeamst = 22;
                    locations = new Location[Count];
                    for (int i = 0; i < Count; i++)
                        locations[i] = DeepFreezeLocation(i);
                    return locations;
                case Game.Spooky:
                    Count = 44;
                    ChargeBeamst = 6;
                    locations = new Location[Count];
                    for (int i = 0; i < Count; i++)
                        locations[i] = SpookyLocation(i);
                    return locations;
                default:
                    Count = 100;
                    ChargeBeamst = 9;
                    locations = new Location[Count];
                    for (int i = 0; i < Count; i++)
                        locations[i] = GetLocation(i);
                    return locations;
            }

        }

    }
}
