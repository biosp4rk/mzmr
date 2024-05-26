using System;
using System.Windows.Forms;

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

        public Location()
        {
            NewItem = ItemType.None;
        }

        public static Location SR387Location(int number)
        {
            switch (number) 
            {
                case 0:
                    return new Location
                    {
                        Number = 0,
                        LogicName = "area1missile26",
                        Area = 5,
                        Room = 0x26,
                        MinimapX = 0x7,
                        MinimapY = 0xE,
                        ClipdataOffset = 0x5EF216,
                        BG1Offset = 0x60CADC,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 1:
                    return new Location
                    {
                        Number = 1,
                        LogicName = "area1super3",
                        Area = 5,
                        Room = 0x3,
                        MinimapX = 0xE,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x5F35B4,
                        BG1Offset = 0x604172,
                        OrigItem = ItemType.Super,
                        
                    };
                case 2:
                    return new Location
                    {
                        Number = 2,
                        LogicName = "area1missile7",
                        Area = 5,
                        Room = 0x7,
                        MinimapX = 0x9,
                        MinimapY = 0x11,
                        ClipdataOffset = 0x5E4081,
                        BG1Offset = 0x61B2F0,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 3:
                    return new Location
                    {
                        Number = 3,
                        LogicName = "area1missile1F",
                        Area = 5,
                        Room = 0x1F,
                        MinimapX = 0xE,
                        MinimapY = 0x15,
                        ClipdataOffset = 0x630795,
                        BG1Offset = 0x65A5B5,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 4:
                    return new Location
                    {
                        Number = 4,
                        LogicName = "area1energy14",
                        Area = 5,
                        Room = 0x14,
                        MinimapX = 0x15,
                        MinimapY = 0x12,
                        ClipdataOffset = 0x343C52,
                        BG1Offset = 0x609FF8,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 5:
                    return new Location
                    {
                        Number = 5,
                        LogicName = "area1missile1B",
                        Area = 5,
                        Room = 0x1B,
                        MinimapX = 0x18,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x341232,
                        BG1Offset = 0x631A6B,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 6:
                    return new Location
                    {
                        Number = 6,
                        LogicName = "area1missileE",
                        Area = 5,
                        Room = 0xE,
                        MinimapX = 0x14,
                        MinimapY = 0x17,
                        ClipdataOffset = 0x5EE830,
                        BG1Offset = 0x6A3050,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 7:
                    return new Location
                    {
                        Number = 7,
                        LogicName = "area1missileA",
                        Area = 5,
                        Room = 0xA,
                        MinimapX = 0x5,
                        MinimapY = 0x18,
                        ClipdataOffset = 0x61C895,
                        BG1Offset = 0x6177B9,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 8:
                    return new Location
                    {
                        Number = 8,
                        LogicName = "area1bombC",
                        Area = 5,
                        Room = 0xC,
                        MinimapX = 0x5,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Bomb,
                        
                    };

                case 9:
                    return new Location
                    {
                        Number = 9,
                        LogicName = "area2energy12",
                        Area = 1,
                        Room = 0x12,
                        MinimapX = 0xA,
                        MinimapY = 0xB,
                        ClipdataOffset = 0x5F311A,
                        BG1Offset = 0x61FACF,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 10:
                    return new Location
                    {
                        Number = 10,
                        LogicName = "area2missileC",
                        Area = 1,
                        Room = 0xC,
                        MinimapX = 0xE,
                        MinimapY = 0xB,
                        ClipdataOffset = 0x5E2A76,
                        BG1Offset = 0x621502,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 11:
                    return new Location
                    {
                        Number = 11,
                        LogicName = "area2chargeBeam3",
                        Area = 1,
                        Room = 0x3,
                        MinimapX = 0xE,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Charge,
                        
                    };
                case 12:
                    return new Location
                    {
                        Number = 12,
                        LogicName = "area2missileF",
                        Area = 1,
                        Room = 0xF,
                        MinimapX = 0x15,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x5EEC3E,
                        BG1Offset = 0x621CFC,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 13:
                    return new Location
                    {
                        Number = 13,
                        LogicName = "area2missile30",
                        Area = 1,
                        Room = 0x30,
                        MinimapX = 0x8,
                        MinimapY = 0xF,
                        ClipdataOffset = 0x5E31EA,
                        BG1Offset = 0x60CF9B,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 14:
                    return new Location
                    {
                        Number = 14,
                        LogicName = "area2variaSuit32",
                        Area = 1,
                        Room = 0x32,
                        MinimapX = 0x18,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Varia,
                        
                    };
                case 15:
                    return new Location
                    {
                        Number = 15,
                        LogicName = "area2missile2E",
                        Area = 0x1,
                        Room = 0x2E,
                        MinimapX = 0xA,
                        MinimapY = 0x12,
                        ClipdataOffset = 0x5E3130,
                        BG1Offset = 0x5E3496,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 16:
                    return new Location
                    {
                        Number = 16,
                        LogicName = "area2speedBoost2C",
                        Area = 0x1,
                        Room = 0x2C,
                        MinimapX = 0xC,
                        MinimapY = 0x13,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Speed,
                        
                    };
                case 17:
                    return new Location
                    {
                        Number = 17,
                        LogicName = "area2energyHidden1C",
                        Area = 0x1,
                        Room = 0x1C,
                        MinimapX = 0x4,
                        MinimapY = 0x16,
                        ClipdataOffset = 0x6208FE,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 18:
                    return new Location
                    {
                        Number = 18,
                        LogicName = "area2superHidden1C",
                        Area = 0x1,
                        Room = 0x1C,
                        MinimapX = 0x5,
                        MinimapY = 0x18,
                        ClipdataOffset = 0x620A22,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Super,
                        
                    };
                case 19:
                    return new Location
                    {
                        Number = 19,
                        LogicName = "area2missileHidden34",
                        Area = 0x1,
                        Room = 0x34,
                        MinimapX = 0x18,
                        MinimapY = 0x17,
                        ClipdataOffset = 0x3642D4,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 20:
                    return new Location
                    {
                        Number = 20,
                        LogicName = "area2waveBeam33",
                        Area = 0x1,
                        Room = 0x33,
                        MinimapX = 0x14,
                        MinimapY = 0x17,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Wave,
                        
                    };
                case 21:
                    return new Location
                    {
                        Number = 21,
                        LogicName = "area2spaceJump19",
                        Area = 0x1,
                        Room = 0x19,
                        MinimapX = 0x13,
                        MinimapY = 0x1D,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Space,
                        
                    };

                case 22:
                    return new Location
                    {
                        Number = 22,
                        LogicName = "area3iceBeamD",
                        Area = 0x3,
                        Room = 0xD,
                        MinimapX = 0xF,
                        MinimapY = 0x7,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Ice,
                        
                    };
                case 23:
                    return new Location
                    {
                        Number = 23,
                        LogicName = "area3super1C",
                        Area = 0x3,
                        Room = 0x1C,
                        MinimapX = 0x16,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x6A28C0,
                        BG1Offset = 0x6A2A7D,
                        OrigItem = ItemType.Super,
                        
                    };
                case 24:
                    return new Location
                    {
                        Number = 24,
                        LogicName = "area3energy17",
                        Area = 0x3,
                        Room = 0x17,
                        MinimapX = 0x12,
                        MinimapY = 0xF,
                        ClipdataOffset = 0x6A1B68,
                        BG1Offset = 0x6A1C66,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 25:
                    return new Location
                    {
                        Number = 25,
                        LogicName = "area3missileHidden2A",
                        Area = 0x3,
                        Room = 0x2A,
                        MinimapX = 0x15,
                        MinimapY = 0xF,
                        ClipdataOffset = 0x33F926,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 26:
                    return new Location
                    {
                        Number = 26,
                        LogicName = "area3missile5",
                        Area = 0x3,
                        Room = 0x5,
                        MinimapX = 0x19,
                        MinimapY = 0x11,
                        ClipdataOffset = 0x622C98,
                        BG1Offset = 0x623069,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 27:
                    return new Location
                    {
                        Number = 27,
                        LogicName = "area3missileHidden29",
                        Area = 0x3,
                        Room = 0x29,
                        MinimapX = 0xF,
                        MinimapY = 0x13,
                        ClipdataOffset = 0x620876,
                        BG1Offset = 0x6B8993,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 28:
                    return new Location
                    {
                        Number = 28,
                        LogicName = "area3missile11",
                        Area = 0x3,
                        Room = 0x11,
                        MinimapX = 0xD,
                        MinimapY = 0x14,
                        ClipdataOffset = 0x69F914,
                        BG1Offset = 0x69FFA8,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 29:
                    return new Location
                    {
                        Number = 29,
                        LogicName = "area3missile23",
                        Area = 0x3,
                        Room = 0x23,
                        MinimapX = 0x11,
                        MinimapY = 0x14,
                        ClipdataOffset = 0x6134DF,
                        BG1Offset = 0x61337B,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 30:
                    return new Location
                    {
                        Number = 30,
                        LogicName = "area3energy12",
                        Area = 0x3,
                        Room = 0x12,
                        MinimapX = 0xA,
                        MinimapY = 0x15,
                        ClipdataOffset = 0x406FD1,
                        BG1Offset = 0x627F30,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 31:
                    return new Location
                    {
                        Number = 31,
                        LogicName = "area3superB",
                        Area = 0x3,
                        Room = 0xB,
                        MinimapX = 0x5,
                        MinimapY = 0x16,
                        ClipdataOffset = 0x341A6A,
                        BG1Offset = 0x628026,
                        OrigItem = ItemType.Super,
                        
                    };

                case 32:
                    return new Location
                    {
                        Number = 32,
                        LogicName = "area4missile0",
                        Area = 0x4,
                        Room = 0x0,
                        MinimapX = 0xF,
                        MinimapY = 0x11,
                        ClipdataOffset = 0x632C85,
                        BG1Offset = 0x6A078B,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 33:
                    return new Location
                    {
                        Number = 33,
                        LogicName = "area4screw3",
                        Area = 0x4,
                        Room = 0x3,
                        MinimapX = 0x7,
                        MinimapY = 0xE,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Screw,
                        
                    };
                case 34:
                    return new Location
                    {
                        Number = 34,
                        LogicName = "area4super8",
                        Area = 0x4,
                        Room = 0x8,
                        MinimapX = 0xE,
                        MinimapY = 0xC,
                        ClipdataOffset = 0x64C8E0,
                        BG1Offset = 0x6E574B,
                        OrigItem = ItemType.Super,
                        
                    };
                case 35:
                    return new Location
                    {
                        Number = 35,
                        LogicName = "area4missile3",
                        Area = 0x4,
                        Room = 0x3,
                        MinimapX = 0x7,
                        MinimapY = 0xB,
                        ClipdataOffset = 0x630A8F,
                        BG1Offset = 0x6AC301,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 36:
                    return new Location
                    {
                        Number = 36,
                        LogicName = "area4missile2",
                        Area = 0x4,
                        Room = 0x2,
                        MinimapX = 0xB,
                        MinimapY = 0xB,
                        ClipdataOffset = 0x60E6F3,
                        BG1Offset = 0x7148C4,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 37:
                    return new Location
                    {
                        Number = 37,
                        LogicName = "area4energy8",
                        Area = 0x4,
                        Room = 0x8,
                        MinimapX = 0xE,
                        MinimapY = 0xA,
                        ClipdataOffset = 0x64C860,
                        BG1Offset = 0x6E5545,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 38:
                    return new Location
                    {
                        Number = 38,
                        LogicName = "area4missileHiddenB",
                        Area = 0x4,
                        Room = 0xB,
                        MinimapX = 0x14,
                        MinimapY = 0xB,
                        ClipdataOffset = 0x64E7E1,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Missile,
                        
                    };
                default:
                throw new IndexOutOfRangeException();
            }
        }

        public static Location ScrollsSixLocation(int number)
        {
            switch (number) 
            {
            
                case 0:
                    return new Location
                    {
                        Number = 0,
                        LogicName = "FirstMissile",
                        Area = 0,
                        Room = 9,
                        MinimapX = 0x13,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x60D736,
                        BG1Offset = 0x6103D5,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 1:
                    return new Location
                    {
                        Number = 1,
                        LogicName = "SolHiddenTunnelMissile",
                        Area = 0,
                        Room = 8,
                        MinimapX = 0x14,
                        MinimapY = 0x12,
                        ClipdataOffset = 0x3601AD,
                        BG1Offset = 0x60F1AE,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 2:
                    return new Location
                    {
                        Number = 2,
                        LogicName = "TomeOfPhasing",
                        Area = 0,
                        Room = 0xD,
                        MinimapX = 0x14,
                        MinimapY = 0x13,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Wave,
                        
                    };
                case 3:
                    return new Location
                    {
                        Number = 3,
                        LogicName = "TomeOfFocusing",
                        Area = 0,
                        Room = 0x5,
                        MinimapX = 0x11,
                        MinimapY = 0x14,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Charge,
                        
                    };
                case 4:
                    return new Location
                    {
                        Number = 4,
                        LogicName = "DeoremETank",
                        Area = 0,
                        Room = 0x5,
                        MinimapX = 0x13,
                        MinimapY = 0x14,
                        ClipdataOffset = 0x60D256,
                        BG1Offset = 0x60D632,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 5:
                    return new Location
                    {
                        Number = 5,
                        LogicName = "SolRipperSuper",
                        Area = 0,
                        Room = 0x30,
                        MinimapX = 0x9,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x366451,
                        BG1Offset = 0x768E8B,
                        OrigItem = ItemType.Super,
                        
                    };
                case 6:
                    return new Location
                    {
                        Number = 6,
                        LogicName = "Bombs",
                        Area = 0,
                        Room = 0x7,
                        MinimapX = 0x17,
                        MinimapY = 0x11,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Bomb,
                        
                    };
                case 7:
                    return new Location
                    {
                        Number = 7,
                        LogicName = "SolTowerMissile",
                        Area = 0,
                        Room = 0x33,
                        MinimapX = 0xD,
                        MinimapY = 0xC,
                        ClipdataOffset = 0x55057A,
                        BG1Offset = 0x62DCC7,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 8:
                    return new Location
                    {
                        Number = 8,
                        LogicName = "SolSecretMissile",
                        Area = 0,
                        Room = 0x36,
                        MinimapX = 0xB,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x5725E4,
                        BG1Offset = 0x774540,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 9:
                    return new Location
                    {
                        Number = 9,
                        LogicName = "SolPBs",
                        Area = 0,
                        Room = 0xA,
                        MinimapX = 0x11,
                        MinimapY = 0xC,
                        ClipdataOffset = 0x556177,
                        BG1Offset = 0x555BDB,
                        OrigItem = ItemType.Power,
                        
                    };
                case 10:
                    return new Location
                    {
                        Number = 10,
                        LogicName = "SolSuperCache",
                        Area = 0,
                        Room = 0x38,
                        MinimapX = 0x8,
                        MinimapY = 0xB,
                        ClipdataOffset = 0x366483,
                        BG1Offset = 0x61E13B,
                        OrigItem = ItemType.Super,
                        
                    };
                case 11:
                    return new Location
                    {
                        Number = 11,
                        LogicName = "SolPirateMissile",
                        Area = 0,
                        Room = 0xA,
                        MinimapX = 0x11,
                        MinimapY = 0xA,
                        ClipdataOffset = 0x5560EF,
                        BG1Offset = 0x555A79,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 12:
                    return new Location
                    {
                        Number = 12,
                        LogicName = "SolSpeedboostETank",
                        Area = 0,
                        Room = 0x3B,
                        MinimapX = 0x8,
                        MinimapY = 0x8,
                        ClipdataOffset = 0x6048CE,
                        BG1Offset = 0x625A52,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 13:
                    return new Location
                    {
                        Number = 13,
                        LogicName = "MonHeatedMissile",
                        Area = 1,
                        Room = 0x33,
                        MinimapX = 0x19,
                        MinimapY = 0x18,
                        ClipdataOffset = 0x610F2C,
                        BG1Offset = 0x632583,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 14:
                    return new Location
                    {
                        Number = 14,
                        LogicName = "MonVolcanoETank",
                        Area = 1,
                        Room = 0x34,
                        MinimapX = 0x10,
                        MinimapY = 0x1A,
                        ClipdataOffset = 0x33EAE8,
                        BG1Offset = 0x57286F,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 15:
                    return new Location
                    {
                        Number = 15,
                        LogicName = "MonArachnusRune",
                        Area = 1,
                        Room = 0x13,
                        MinimapX = 0x8,
                        MinimapY = 0x16,
                        ClipdataOffset = 0x44569C,
                        BG1Offset = 0x565A8C,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 16:
                    return new Location
                    {
                        Number = 16,
                        LogicName = "CloakofWisdom",
                        Area = 1,
                        Room = 0x3B,
                        MinimapX = 0x7,
                        MinimapY = 0x15,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Varia,
                        
                    };
                case 17:
                    return new Location
                    {
                        Number = 17,
                        LogicName = "MonHeatedSuper",
                        Area = 1,
                        Room = 0x40,
                        MinimapX = 0xF,
                        MinimapY = 0x14,
                        ClipdataOffset = 0x5DCC93,
                        BG1Offset = 0x58435A,
                        OrigItem = ItemType.Super,
                        
                    };
                case 18:
                    return new Location
                    {
                        Number = 18,
                        LogicName = "MonSparkMissile",
                        Area = 1,
                        Room = 0x37,
                        MinimapX = 0xC,
                        MinimapY = 0x11,
                        ClipdataOffset = 0x57BC8E,
                        BG1Offset = 0x57BDEB,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 19:
                    return new Location
                    {
                        Number = 19,
                        LogicName = "MonCeilingMissile",
                        Area = 1,
                        Room = 0x1,
                        MinimapX = 0x18,
                        MinimapY = 0x12,
                        ClipdataOffset = 0x635A01,
                        BG1Offset = 0x618638,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 20:
                    return new Location
                    {
                        Number = 20,
                        LogicName = "MonHiddenETank",
                        Area = 1,
                        Room = 0x1,
                        MinimapX = 0x19,
                        MinimapY = 0x11,
                        ClipdataOffset = 0x6359A4,
                        BG1Offset = 0x618535,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 21:
                    return new Location
                    {
                        Number = 21,
                        LogicName = "MonKraidRune",
                        Area = 1,
                        Room = 0x12,
                        MinimapX = 0x9,
                        MinimapY = 0x10,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Grip,
                        
                    };
                case 22:
                    return new Location
                    {
                        Number = 22,
                        LogicName = "MonTunnelPBs",
                        Area = 1,
                        Room = 0x1B,
                        MinimapX = 0x1B,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x5DD064,
                        BG1Offset = 0x5DCFEF,
                        OrigItem = ItemType.Power,
                        
                    };
                case 23:
                    return new Location
                    {
                        Number = 23,
                        LogicName = "MonPBsCahce",
                        Area = 1,
                        Room = 0x17,
                        MinimapX = 0xD,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x62621B,
                        BG1Offset = 0x562321,
                        OrigItem = ItemType.Power,
                        
                    };
                case 24:
                    return new Location
                    {
                        Number = 24,
                        LogicName = "TomeOfFreezing",
                        Area = 1,
                        Room = 0x8,
                        MinimapX = 0x15,
                        MinimapY = 0xD,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Ice,
                        
                    };
                case 25:
                    return new Location
                    {
                        Number = 25,
                        LogicName = "MonBeneathPlatformsSuper",
                        Area = 1,
                        Room = 0x6,
                        MinimapX = 0xF,
                        MinimapY = 0xA,
                        ClipdataOffset = 0x55E83F,
                        BG1Offset = 0x587EB9,
                        OrigItem = ItemType.Super,
                        
                    };
                case 26:
                    return new Location
                    {
                        Number = 26,
                        LogicName = "MonIceMissile",
                        Area = 1,
                        Room = 0x3,
                        MinimapX = 0x18,
                        MinimapY = 0xA,
                        ClipdataOffset = 0x2BC61F,
                        BG1Offset = 0x5846DE,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 27:
                    return new Location
                    {
                        Number = 27,
                        LogicName = "MonIceTopSuper",
                        Area = 1,
                        Room = 0xB,
                        MinimapX = 0xB,
                        MinimapY = 0x4,
                        ClipdataOffset = 0x554C56,
                        BG1Offset = 0x588A70,
                        OrigItem = ItemType.Super,
                        
                    };
                case 28:
                    return new Location
                    {
                        Number = 28,
                        LogicName = "SilMapMissile",
                        Area = 2,
                        Room = 0xD,
                        MinimapX = 0x17,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x406DFE,
                        BG1Offset = 0x634668,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 29:
                    return new Location
                    {
                        Number = 29,
                        LogicName = "SilHiddenMissile",
                        Area = 2,
                        Room = 0x1,
                        MinimapX = 0x7,
                        MinimapY = 0xE,
                        ClipdataOffset = 0x66BC6D,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 30:
                    return new Location
                    {
                        Number = 30,
                        LogicName = "SilTreesETank",
                        Area = 2,
                        Room = 0x4,
                        MinimapX = 0xA,
                        MinimapY = 0xE,
                        ClipdataOffset = 0x63264A,
                        BG1Offset = 0x66D5B3,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 31:
                    return new Location
                    {
                        Number = 31,
                        LogicName = "SilTreetopMissile",
                        Area = 2,
                        Room = 0x6,
                        MinimapX = 0xE,
                        MinimapY = 0xE,
                        ClipdataOffset = 0x6372F6,
                        BG1Offset = 0x64F766,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 32:
                    return new Location
                    {
                        Number = 32,
                        LogicName = "SilHangingETank",
                        Area = 2,
                        Room = 0x9,
                        MinimapX = 0x15,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x66BE34,
                        BG1Offset = 0x65BBE2,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 33:
                    return new Location
                    {
                        Number = 33,
                        LogicName = "SilRune",
                        Area = 2,
                        Room = 0x2,
                        MinimapX = 0x7,
                        MinimapY = 0xC,
                        ClipdataOffset = 0x44540A,
                        BG1Offset = 0x554774,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 34:
                    return new Location
                    {
                        Number = 34,
                        LogicName = "SilPBs",
                        Area = 2,
                        Room = 0xE,
                        MinimapX = 0x12,
                        MinimapY = 0xC,
                        ClipdataOffset = 0x6710A8,
                        BG1Offset = 0x67125B,
                        OrigItem = ItemType.Power,
                        
                    };
                case 35:
                    return new Location
                    {
                        Number = 35,
                        LogicName = "BootsofHaste",
                        Area = 2,
                        Room = 0x10,
                        MinimapX = 0xB,
                        MinimapY = 0xB,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Speed,
                        
                    };
                case 36:
                    return new Location
                    {
                        Number = 36,
                        LogicName = "TurPlatormPBs",
                        Area = 3,
                        Room = 0x11,
                        MinimapX = 0xD,
                        MinimapY = 0x15,
                        ClipdataOffset = 0x62D24B,
                        BG1Offset = 0x6220C2,
                        OrigItem = ItemType.Power,
                        
                    };
                case 37:
                    return new Location
                    {
                        Number = 37,
                        LogicName = "TurBlockedMissile",
                        Area = 3,
                        Room = 0x3,
                        MinimapX = 0x10,
                        MinimapY = 0x11,
                        ClipdataOffset = 0x5DF647,
                        BG1Offset = 0x5E19D1,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 38:
                    return new Location
                    {
                        Number = 38,
                        LogicName = "TurPlatformMissile",
                        Area = 3,
                        Room = 0x4,
                        MinimapX = 0xC,
                        MinimapY = 0xF,
                        ClipdataOffset = 0x567C56,
                        BG1Offset = 0x567BD0,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 39:
                    return new Location
                    {
                        Number = 39,
                        LogicName = "TurLargeRoomSuper",
                        Area = 3,
                        Room = 0x7,
                        MinimapX = 0x10,
                        MinimapY = 0xE,
                        ClipdataOffset = 0x56BBED,
                        BG1Offset = 0x60E3F2,
                        OrigItem = ItemType.Super,
                        
                    };
                case 40:
                    return new Location
                    {
                        Number = 40,
                        LogicName = "Eradication",
                        Area = 3,
                        Room = 0x8,
                        MinimapX = 0x13,
                        MinimapY = 0xC,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Screw,
                        
                    };
                case 41:
                    return new Location
                    {
                        Number = 41,
                        LogicName = "TurHiddenPlatformETank",
                        Area = 3,
                        Room = 0xB,
                        MinimapX = 0xE,
                        MinimapY = 0x9,
                        ClipdataOffset = 0x55495F,
                        BG1Offset = 0,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 42:
                    return new Location
                    {
                        Number = 42,
                        LogicName = "TurHiddenPlatformMissile",
                        Area = 3,
                        Room = 0xB,
                        MinimapX = 0x11,
                        MinimapY = 0x9,
                        ClipdataOffset = 0x5549B2,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 43:
                    return new Location
                    {
                        Number = 43,
                        LogicName = "TurHiddenPBs",
                        Area = 3,
                        Room = 0xD,
                        MinimapX = 0x14,
                        MinimapY = 0x6,
                        ClipdataOffset = 0x558758,
                        BG1Offset = 0,
                        OrigItem = ItemType.Power,
                        
                    };
                case 44:
                    return new Location
                    {
                        Number = 44,
                        LogicName = "TurRune",
                        Area = 3,
                        Room = 0x2,
                        MinimapX = 0xC,
                        MinimapY = 0x6,
                        ClipdataOffset = 0x556226,
                        BG1Offset = 0x56582B,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 45:
                    return new Location
                    {
                        Number = 45,
                        LogicName = "ArxETank",
                        Area = 4,
                        Room = 0xB,
                        MinimapX = 0x13,
                        MinimapY = 0x18,
                        ClipdataOffset = 0x556324,
                        BG1Offset = 0x56AF69,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 46:
                    return new Location
                    {
                        Number = 46,
                        LogicName = "ArxSuper",
                        Area = 4,
                        Room = 0x9,
                        MinimapX = 0x13,
                        MinimapY = 0x16,
                        ClipdataOffset = 0x3436F6,
                        BG1Offset = 0x5555C3,
                        OrigItem = ItemType.Super,
                        
                    };
                case 47:
                    return new Location
                    {
                        Number = 47,
                        LogicName = "ArxFallMissile",
                        Area = 4,
                        Room = 0x27,
                        MinimapX = 0x8,
                        MinimapY = 0x11,
                        ClipdataOffset = 0x5671D9,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 48:
                    return new Location
                    {
                        Number = 48,
                        LogicName = "ArxMorphMazeMissile",
                        Area = 4,
                        Room = 0x26,
                        MinimapX = 0x10,
                        MinimapY = 0xE,
                        ClipdataOffset = 0x44590F,
                        BG1Offset = 0x5625C6,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 49:
                    return new Location
                    {
                        Number = 49,
                        LogicName = "ArxPBs",
                        Area = 4,
                        Room = 0x15,
                        MinimapX = 0x19,
                        MinimapY = 0xE,
                        ClipdataOffset = 0x3433C2,
                        BG1Offset = 0x6A0BEF,
                        OrigItem = ItemType.Power,
                        
                    };
                case 50:
                    return new Location
                    {
                        Number = 50,
                        LogicName = "ArxTunnelMissile",
                        Area = 4,
                        Room = 0x1A,
                        MinimapX = 0xC,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x55CE36,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 51:
                    return new Location
                    {
                        Number = 51,
                        LogicName = "ArxSparkMissile",
                        Area = 4,
                        Room = 0x17,
                        MinimapX = 0x19,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x55E780,
                        BG1Offset = 0x56926E,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 52:
                    return new Location
                    {
                        Number = 52,
                        LogicName = "Hops",
                        Area = 4,
                        Room = 0x1E,
                        MinimapX = 0x17,
                        MinimapY = 0x6,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Hi,
                        
                    };
                case 53:
                    return new Location
                    {
                        Number = 53,
                        LogicName = "ArxRune",
                        Area = 4,
                        Room = 0x2,
                        MinimapX = 0x11,
                        MinimapY = 0x4,
                        ClipdataOffset = 0x565A07,
                        BG1Offset = 0x565951,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 54:
                    return new Location
                    {
                        Number = 54,
                        LogicName = "SwoleCloak",
                        Area = 5,
                        Room = 0x19,
                        MinimapX = 0x5,
                        MinimapY = 0x9,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Gravity,
                        
                    };
                case 55:
                    return new Location
                    {
                        Number = 55,
                        LogicName = "LitMorphTunnelPBs",
                        Area = 5,
                        Room = 0x10,
                        MinimapX = 0x7,
                        MinimapY = 0xA,
                        ClipdataOffset = 0x611774,
                        BG1Offset = 0x66E9FE,
                        OrigItem = ItemType.Power,
                        
                    };
                case 56:
                    return new Location
                    {
                        Number = 56,
                        LogicName = "LitSpeedMissile",
                        Area = 5,
                        Room = 0xA,
                        MinimapX = 0xD,
                        MinimapY = 0xB,
                        ClipdataOffset = 0x62517B,
                        BG1Offset = 0x6D7A5F,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 57:
                    return new Location
                    {
                        Number = 57,
                        LogicName = "LitTowerMissile",
                        Area = 5,
                        Room = 0x9,
                        MinimapX = 0x4,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x6E09F2,
                        BG1Offset = 0x6E11FB,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 58:
                    return new Location
                    {
                        Number = 58,
                        LogicName = "LitSuper",
                        Area = 5,
                        Room = 0x15,
                        MinimapX = 0x13,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x3438CB,
                        BG1Offset = 0x6BFEEE,
                        OrigItem = ItemType.Super,
                        
                    };
                case 59:
                    return new Location
                    {
                        Number = 59,
                        LogicName = "LitUnderwaterSpeedMissile",
                        Area = 5,
                        Room = 0xF,
                        MinimapX = 0x10,
                        MinimapY = 0xE,
                        ClipdataOffset = 0x69E6E3,
                        BG1Offset = 0x6C104D,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 60:
                    return new Location
                    {
                        Number = 60,
                        LogicName = "LitSuperRoomMissile",
                        Area = 5,
                        Room = 0x15,
                        MinimapX = 0x13,
                        MinimapY = 0xE,
                        ClipdataOffset = 0x34390E,
                        BG1Offset = 0x6BFF6C,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 61:
                    return new Location
                    {
                        Number = 61,
                        LogicName = "LitHiddenETank",
                        Area = 5,
                        Room = 0x6,
                        MinimapX = 0x7,
                        MinimapY = 0xF,
                        ClipdataOffset = 0x406C22,
                        BG1Offset = 0,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 62:
                    return new Location
                    {
                        Number = 62,
                        LogicName = "LitBombMazeMissile",
                        Area = 5,
                        Room = 0x12,
                        MinimapX = 0xB,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x5581E1,
                        BG1Offset = 0x55CAB5,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 63:
                    return new Location
                    {
                        Number = 63,
                        LogicName = "LitSpeedboostPB",
                        Area = 5,
                        Room = 0xF,
                        MinimapX = 0x12,
                        MinimapY = 0x11,
                        ClipdataOffset = 0x69E822,
                        BG1Offset = 0x6C1708,
                        OrigItem = ItemType.Power,
                        
                    };
                case 64:
                    return new Location
                    {
                        Number = 64,
                        LogicName = "LitRune",
                        Area = 5,
                        Room = 0x2,
                        MinimapX = 0xD,
                        MinimapY = 0x12,
                        ClipdataOffset = 0x565B35,
                        BG1Offset = 0x5E3F04,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 65:
                    return new Location
                    {
                        Number = 65,
                        LogicName = "UmbraMissile",
                        Area = 6,
                        Room = 0,
                        MinimapX = 0x11,
                        MinimapY = 0x11,
                        ClipdataOffset = 0x407517,
                        BG1Offset = 0x6A047E,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 66:
                    return new Location
                    {
                        Number = 66,
                        LogicName = "TomeOfPiercing",
                        Area = 6,
                        Room = 0x7,
                        MinimapX = 0xE,
                        MinimapY = 0x11,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Plasma,
                        
                    };
                case 67:
                    return new Location
                    {
                        Number = 67,
                        LogicName = "UmbraSuper",
                        Area = 6,
                        Room = 0x1,
                        MinimapX = 0xD,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x60ED21,
                        BG1Offset = 0x6A134E,
                        OrigItem = ItemType.Super,
                        
                    };
                case 68:
                    return new Location
                    {
                        Number = 65,
                        LogicName = "UmbraPBs",
                        Area = 6,
                        Room = 0x1,
                        MinimapX = 0xD,
                        MinimapY = 0xF,
                        ClipdataOffset = 0x60ECCA,
                        BG1Offset = 0x6A128C,
                        OrigItem = ItemType.Power,
                        
                    };
                case 69:
                    return new Location
                    {
                        Number = 69,
                        LogicName = "UmbraETank",
                        Area = 6,
                        Room = 0x3,
                        MinimapX = 0x10,
                        MinimapY = 0xF,
                        ClipdataOffset = 0x4457B2,
                        BG1Offset = 0x62FCFA,
                        OrigItem = ItemType.Energy,
                        
                    };
                default:
                    throw new IndexOutOfRangeException();
            }
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
                        BG1Offset = 0x56BA95,
                        OrigItem = ItemType.Power,
                        
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

        public static Location Spooky2Location(int number)
        {
            switch (number)
            {
                case 0:
                    return new Location
                    {
                        Number = 0,
                        LogicName = "crypt_firstMissile",
                        Area = 0x0,
                        Room = 0x5,
                        MinimapX = 0x13,
                        MinimapY = 0x14,
                        ClipdataOffset = 0x5F4C0E,
                        BG1Offset = 0x61B9C9,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 1:
                    return new Location
                    {
                        Number = 1,
                        LogicName = "crypt_powerBomb",
                        Area = 0x0,
                        Room = 0x2B,
                        MinimapX = 0x15,
                        MinimapY = 0x14,
                        ClipdataOffset = 0x6047C4,
                        BG1Offset = 0x61BC20,
                        OrigItem = ItemType.Power,
                        
                    };
                case 2:
                    return new Location
                    {
                        Number = 2,
                        LogicName = "crypt_pillarMissile",
                        Area = 0x0,
                        Room = 0x8,
                        MinimapX = 0x12,
                        MinimapY = 0x11,
                        ClipdataOffset = 0x593B71,
                        BG1Offset = 0x593277,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 3:
                    return new Location
                    {
                        Number = 3,
                        LogicName = "hijump",
                        Area = 0x0,
                        Room = 0x1A,
                        MinimapX = 0x18,
                        MinimapY = 0x11,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Hi,
                        
                    };
                case 4:
                    return new Location
                    {
                        Number = 4,
                        LogicName = "crypt_crateMissile",
                        Area = 0x0,
                        Room = 0x15,
                        MinimapX = 0x1B,
                        MinimapY = 0xF,
                        ClipdataOffset = 0x6137F9,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 5:
                    return new Location
                    {
                        Number = 5,
                        LogicName = "crypt_parcourMissile",
                        Area = 0x0,
                        Room = 0x13,
                        MinimapX = 0x19,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x612AE0,
                        BG1Offset = 0x5F4051,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 6:
                    return new Location
                    {
                        Number = 6,
                        LogicName = "crypt_floorMissile",
                        Area = 0x0,
                        Room = 0xF,
                        MinimapX = 0x16,
                        MinimapY = 0xC,
                        ClipdataOffset = 0x611FD9,
                        BG1Offset = 0x612204,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 7:
                    return new Location
                    {
                        Number = 7,
                        LogicName = "crypt_super",
                        Area = 0x0,
                        Room = 0x10,
                        MinimapX = 0x15,
                        MinimapY = 0x8,
                        ClipdataOffset = 0x61249E,
                        BG1Offset = 0x612599,
                        OrigItem = ItemType.Super,
                        
                    };
                case 8:
                    return new Location
                    {
                        Number = 8,
                        LogicName = "morph",
                        Area = 0x0,
                        Room = 0xB,
                        MinimapX = 0xD,
                        MinimapY = 0xC,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Morph,
                        
                    };
                case 9:
                    return new Location
                    {
                        Number = 9,
                        LogicName = "chargeBeam",
                        Area = 0x0,
                        Room = 0x27,
                        MinimapX = 0xA,
                        MinimapY = 0x15,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Charge,
                        
                    };
                case 10:
                    return new Location
                    {
                        Number = 10,
                        LogicName = "crypt_multipathMissile",
                        Area = 0x0,
                        Room = 0x23,
                        MinimapX = 0x6,
                        MinimapY = 0x12,
                        ClipdataOffset = 0x6145A6,
                        BG1Offset = 0x61DC15,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 11:
                    return new Location
                    {
                        Number = 11,
                        LogicName = "crypt_ceilingMissile",
                        Area = 0x0,
                        Room = 0x1E,
                        MinimapX = 0xB,
                        MinimapY = 0xE,
                        ClipdataOffset = 0x60EE30,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 12:
                    return new Location
                    {
                        Number = 12,
                        LogicName = "crypt_ingMissile1",
                        Area = 0x0,
                        Room = 0x21,
                        MinimapX = 0x6,
                        MinimapY = 0xC,
                        ClipdataOffset = 0x553EA7,
                        BG1Offset = 0x58982F,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 13:
                    return new Location
                    {
                        Number = 13,
                        LogicName = "crypt_ingMissile2",
                        Area = 0x0,
                        Room = 0x21,
                        MinimapX = 0x6,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x553F0C,
                        BG1Offset = 0x5898E5,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 14:
                    return new Location
                    {
                        Number = 14,
                        LogicName = "crypt_energy",
                        Area = 0x0,
                        Room = 0x1C,
                        MinimapX = 0xC,
                        MinimapY = 0x9,
                        ClipdataOffset = 0x5E47CB,
                        BG1Offset = 0x554150,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 15:
                    return new Location
                    {
                        Number = 15,
                        LogicName = "nest_exitSuper",
                        Area = 0x1,
                        Room = 0xA,
                        MinimapX = 0x16,
                        MinimapY = 0x16,
                        ClipdataOffset = 0x60C51A,
                        BG1Offset = 0x653638,
                        OrigItem = ItemType.Super,
                        
                    };
                case 16:
                    return new Location
                    {
                        Number = 16,
                        LogicName = "nest_morphmazeEnergy",
                        Area = 0x1,
                        Room = 0x8,
                        MinimapX = 0xE,
                        MinimapY = 0x15,
                        ClipdataOffset = 0x6324AE,
                        BG1Offset = 0x6326E1,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 17:
                    return new Location
                    {
                        Number = 17,
                        LogicName = "bombs",
                        Area = 0x1,
                        Room = 0xE,
                        MinimapX = 0x10,
                        MinimapY = 0x12,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Bomb,
                        
                    };
                case 18:
                    return new Location
                    {
                        Number = 18,
                        LogicName = "nest_speedMissile",
                        Area = 0x1,
                        Room = 0x14,
                        MinimapX = 0xB,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x616252,
                        BG1Offset = 0x658D2C,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 19:
                    return new Location
                    {
                        Number = 19,
                        LogicName = "nest_sparkMissile",
                        Area = 0x1,
                        Room = 0x15,
                        MinimapX = 0x9,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x33ED4A,
                        BG1Offset = 0x56C0E6,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 20:
                    return new Location
                    {
                        Number = 20,
                        LogicName = "nest_postkraidPb",
                        Area = 0x1,
                        Room = 0x19,
                        MinimapX = 0x6,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x61635D,
                        BG1Offset = 0x666594,
                        OrigItem = ItemType.Power,
                        
                    };
                case 21:
                    return new Location
                    {
                        Number = 21,
                        LogicName = "nest_hiveMissile",
                        Area = 0x1,
                        Room = 0x12,
                        MinimapX = 0x14,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x61278E,
                        BG1Offset = 0x6340F3,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 22:
                    return new Location
                    {
                        Number = 22,
                        LogicName = "nest_vineMissile",
                        Area = 0x1,
                        Room = 0x3,
                        MinimapX = 0x17,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x631427,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 23:
                    return new Location
                    {
                        Number = 23,
                        LogicName = "varia",
                        Area = 0x1,
                        Room = 0x1C,
                        MinimapX = 0x4,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Varia,
                        
                    };
                case 24:
                    return new Location
                    {
                        Number = 24,
                        LogicName = "nest_ceilingEnergy",
                        Area = 0x1,
                        Room = 0x17,
                        MinimapX = 0x9,
                        MinimapY = 0xC,
                        ClipdataOffset = 0x447ED0,
                        BG1Offset = 0x6B9008,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 25:
                    return new Location
                    {
                        Number = 25,
                        LogicName = "nest_hiveMissile2",
                        Area = 0x1,
                        Room = 0x20,
                        MinimapX = 0xD,
                        MinimapY = 0xC,
                        ClipdataOffset = 0x6308D4,
                        BG1Offset = 0x76C5A4,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 26:
                    return new Location
                    {
                        Number = 26,
                        LogicName = "nest_upsparkMissile",
                        Area = 0x1,
                        Room = 0x20,
                        MinimapX = 0x10,
                        MinimapY = 0xB,
                        ClipdataOffset = 0x630820,
                        BG1Offset = 0x76C314,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 27:
                    return new Location
                    {
                        Number = 27,
                        LogicName = "nest_screwMissile",
                        Area = 0x1,
                        Room = 0x20,
                        MinimapX = 0x10,
                        MinimapY = 0xB,
                        ClipdataOffset = 0x630820,
                        BG1Offset = 0x76C314,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 28:
                    return new Location
                    {
                        Number = 28,
                        LogicName = "nest_vineSuper",
                        Area = 0x1,
                        Room = 0x32,
                        MinimapX = 0xE,
                        MinimapY = 0x9,
                        ClipdataOffset = 0x632079,
                        BG1Offset = 0x77DF66,
                        OrigItem = ItemType.Super,
                        
                    };
                case 29:
                    return new Location
                    {
                        Number = 29,
                        LogicName = "space",
                        Area = 0x1,
                        Room = 0x35,
                        MinimapX = 0x12,
                        MinimapY = 0x6,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Space,
                        
                    };
                case 30:
                    return new Location
                    {
                        Number = 30,
                        LogicName = "nest_crumblePb",
                        Area = 0x1,
                        Room = 0x2D,
                        MinimapX = 0x5,
                        MinimapY = 0x3,
                        ClipdataOffset = 0x627F53,
                        BG1Offset = 0x653BF9,
                        OrigItem = ItemType.Power,
                        
                    };
                case 31:
                    return new Location
                    {
                        Number = 31,
                        LogicName = "nest_vinetunnelSuper",
                        Area = 0x1,
                        Room = 0x2C,
                        MinimapX = 0x8,
                        MinimapY = 0x3,
                        ClipdataOffset = 0x615548,
                        BG1Offset = 0x638EE1,
                        OrigItem = ItemType.Super,
                        
                    };
                case 32:
                    return new Location
                    {
                        Number = 32,
                        LogicName = "nest_ripperMissile",
                        Area = 0x1,
                        Room = 0x3C,
                        MinimapX = 0x14,
                        MinimapY = 0x4,
                        ClipdataOffset = 0x633BF8,
                        BG1Offset = 0x699C20,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 33:
                    return new Location
                    {
                        Number = 33,
                        LogicName = "speed",
                        Area = 0x2,
                        Room = 0x38,
                        MinimapX = 0x7,
                        MinimapY = 0x4,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Speed,
                        
                    };
                case 34:
                    return new Location
                    {
                        Number = 34,
                        LogicName = "bone_heatedSuper",
                        Area = 0x2,
                        Room = 0x3B,
                        MinimapX = 0x12,
                        MinimapY = 0x4,
                        ClipdataOffset = 0x67B536,
                        BG1Offset = 0x777FD5,
                        OrigItem = ItemType.Super,
                        
                    };
                case 35:
                    return new Location
                    {
                        Number = 35,
                        LogicName = "bone_upsparkMissile",
                        Area = 0x2,
                        Room = 0x0,
                        MinimapX = 0x15,
                        MinimapY = 0x6,
                        ClipdataOffset = 0x5E3A32,
                        BG1Offset = 0x5E5816,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 36:
                    return new Location
                    {
                        Number = 36,
                        LogicName = "bone_elevatorMissile",
                        Area = 0x2,
                        Room = 0x0,
                        MinimapX = 0x16,
                        MinimapY = 0x6,
                        ClipdataOffset = 0x5E3A12,
                        BG1Offset = 0x5E57D1,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 37:
                    return new Location
                    {
                        Number = 37,
                        LogicName = "bone_wallEnergy",
                        Area = 0x2,
                        Room = 0x2,
                        MinimapX = 0x18,
                        MinimapY = 0x8,
                        ClipdataOffset = 0x698DB6,
                        BG1Offset = 0x5E5DD9,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 38:
                    return new Location
                    {
                        Number = 38,
                        LogicName = "bone_previewMissile",
                        Area = 0x2,
                        Room = 0x4B,
                        MinimapX = 0x4,
                        MinimapY = 0xB,
                        ClipdataOffset = 0x65924B,
                        BG1Offset = 0x6480C0,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 39:
                    return new Location
                    {
                        Number = 39,
                        LogicName = "bone_mazeMissile",
                        Area = 0x2,
                        Room = 0x6E,
                        MinimapX = 0x8,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x7A9CCC,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 40:
                    return new Location
                    {
                        Number = 40,
                        LogicName = "bone_mazeEnergy",
                        Area = 0x2,
                        Room = 0x6E,
                        MinimapX = 0x9,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x7A9F4F,
                        BG1Offset = 0,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 41:
                    return new Location
                    {
                        Number = 41,
                        LogicName = "bone_purplePb",
                        Area = 0x2,
                        Room = 0x20,
                        MinimapX = 0x1E,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x673CE5,
                        BG1Offset = 0x777C1F,
                        OrigItem = ItemType.Power,
                        
                    };
                case 42:
                    return new Location
                    {
                        Number = 42,
                        LogicName = "bone_speedMissile",
                        Area = 0x2,
                        Room = 0x4E,
                        MinimapX = 0xB,
                        MinimapY = 0x12,
                        ClipdataOffset = 0x679D2B,
                        BG1Offset = 0x459D14,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 43:
                    return new Location
                    {
                        Number = 43,
                        LogicName = "bone_platformSuper",
                        Area = 0x2,
                        Room = 0x14,
                        MinimapX = 0x19,
                        MinimapY = 0x13,
                        ClipdataOffset = 0x672A42,
                        BG1Offset = 0x695F45,
                        OrigItem = ItemType.Super,
                        
                    };
                case 44:
                    return new Location
                    {
                        Number = 44,
                        LogicName = "bone_wallMissile",
                        Area = 0x2,
                        Room = 0x50,
                        MinimapX = 0xC,
                        MinimapY = 0x15,
                        ClipdataOffset = 0x44750D,
                        BG1Offset = 0x55447A,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 45:
                    return new Location
                    {
                        Number = 47,
                        LogicName = "bone_forgottenMissile",
                        Area = 0x2,
                        Room = 0x22,
                        MinimapX = 0x19,
                        MinimapY = 0x17,
                        ClipdataOffset = 0x677364,
                        BG1Offset = 0x6775CF,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 46:
                    return new Location
                    {
                        Number = 46,
                        LogicName = "bone_firstSuper",
                        Area = 0x2,
                        Room = 0x2A,
                        MinimapX = 0x17,
                        MinimapY = 0x19,
                        ClipdataOffset = 0x678E24,
                        BG1Offset = 0x678FDD,
                        OrigItem = ItemType.Super,
                        
                    };
                case 47:
                    return new Location
                    {
                        Number = 47,
                        LogicName = "bone_ziplineMissile",
                        Area = 0x2,
                        Room = 0x66,
                        MinimapX = 0xB,
                        MinimapY = 0x1B,
                        ClipdataOffset = 0x632A3A,
                        BG1Offset = 0x797142,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 48:
                    return new Location
                    {
                        Number = 48,
                        LogicName = "bone_morphmazeSuper",
                        Area = 0x2,
                        Room = 0x5F,
                        MinimapX = 0x4,
                        MinimapY = 0x1D,
                        ClipdataOffset = 0x681DBF,
                        BG1Offset = 0x59E00C,
                        OrigItem = ItemType.Super,
                        
                    };
                case 49:
                    return new Location
                    {
                        Number = 49,
                        LogicName = "bone_combatEnergy",
                        Area = 0x2,
                        Room = 0x64,
                        MinimapX = 0xF,
                        MinimapY = 0x1D,
                        ClipdataOffset = 0x2CC510,
                        BG1Offset = 0x60676C,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 50:
                    return new Location
                    {
                        Number = 50,
                        LogicName = "pumpkin_voidEnergy",
                        Area = 0x3,
                        Room = 0x4B,
                        MinimapX = 0x17,
                        MinimapY = 0x1C,
                        ClipdataOffset = 0x40A24C,
                        BG1Offset = 0x5EECEA,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 51:
                    return new Location
                    {
                        Number = 51,
                        LogicName = "pumpkin_upsparkSuper",
                        Area = 0x3,
                        Room = 0xA,
                        MinimapX = 0x11,
                        MinimapY = 0x6,
                        ClipdataOffset = 0x69D3F6,
                        BG1Offset = 0,
                        OrigItem = ItemType.Super,
                        
                    };
                case 52:
                    return new Location
                    {
                        Number = 52,
                        LogicName = "pumpkin_speedpuzzleEnergy",
                        Area = 0x3,
                        Room = 0x2B,
                        MinimapX = 0x16,
                        MinimapY = 0x7,
                        ClipdataOffset = 0x658FFF,
                        BG1Offset = 0x6C9AA7,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 53:
                    return new Location
                    {
                        Number = 53,
                        LogicName = "pumpkin_platformSuper",
                        Area = 0x3,
                        Room = 0x34,
                        MinimapX = 0x1A,
                        MinimapY = 0x9,
                        ClipdataOffset = 0x60EB92,
                        BG1Offset = 0x61DE27,
                        OrigItem = ItemType.Super,
                        
                    };
                case 54:
                    return new Location
                    {
                        Number = 54,
                        LogicName = "pumpkin_hiddenMissile",
                        Area = 0x3,
                        Room = 0x13,
                        MinimapX = 0x7,
                        MinimapY = 0xB,
                        ClipdataOffset = 0x6991AA,
                        BG1Offset = 0x702660,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 55:
                    return new Location
                    {
                        Number = 55,
                        LogicName = "pumpkin_obviousEnergy",
                        Area = 0x3,
                        Room = 0xE,
                        MinimapX = 0x7,
                        MinimapY = 0xC,
                        ClipdataOffset = 0x69E361,
                        BG1Offset = 0x69E45B,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 56:
                    return new Location
                    {
                        Number = 56,
                        LogicName = "pumpkin_platformMissile",
                        Area = 0x3,
                        Room = 0x14,
                        MinimapX = 0x5,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x67A2B6,
                        BG1Offset = 0x6A7EE5,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 57:
                    return new Location
                    {
                        Number = 57,
                        LogicName = "pumpkin_platformMissile",
                        Area = 0x3,
                        Room = 0x14,
                        MinimapX = 0x5,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x67A2B6,
                        BG1Offset = 0x6A7EE5,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 58:
                    return new Location
                    {
                        Number = 58,
                        LogicName = "pumpkin_puzzleMissile",
                        Area = 0x3,
                        Room = 0x2F,
                        MinimapX = 0x1B,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x698735,
                        BG1Offset = 0x77AFC1,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 59:
                    return new Location
                    {
                        Number = 59,
                        LogicName = "pumpkin_ballsparkMissile",
                        Area = 0x3,
                        Room = 0x31,
                        MinimapX = 0x18,
                        MinimapY = 0xE,
                        ClipdataOffset = 0x677EE0,
                        BG1Offset = 0x7B8D63,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 60:
                    return new Location
                    {
                        Number = 60,
                        LogicName = "wave",
                        Area = 0x3,
                        Room = 0x18,
                        MinimapX = 0xA,
                        MinimapY = 0xF,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Wave,
                        
                    };
                case 61:
                    return new Location
                    {
                        Number = 61,
                        LogicName = "pumpkin_crumbleMissile",
                        Area = 0x3,
                        Room = 0x19,
                        MinimapX = 0xA,
                        MinimapY = 0x11,
                        ClipdataOffset = 0x6BC7B2,
                        BG1Offset = 0x6D58FD,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 62:
                    return new Location
                    {
                        Number = 62,
                        LogicName = "pumpkin_firstPb",
                        Area = 0x3,
                        Room = 0x43,
                        MinimapX = 0x19,
                        MinimapY = 0x11,
                        ClipdataOffset = 0x69B4F4,
                        BG1Offset = 0x7FC84C,
                        OrigItem = ItemType.Power,
                        
                    };
                case 63:
                    return new Location
                    {
                        Number = 63,
                        LogicName = "pumpkin_wallMissile",
                        Area = 0x3,
                        Room = 0x1D,
                        MinimapX = 0x8,
                        MinimapY = 0x12,
                        ClipdataOffset = 0x6A2D72,
                        BG1Offset = 0x7C20BC,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 64:
                    return new Location
                    {
                        Number = 64,
                        LogicName = "pumpkin_secretPb",
                        Area = 0x3,
                        Room = 0x56,
                        MinimapX = 0x13,
                        MinimapY = 0x12,
                        ClipdataOffset = 0x5E1A7C,
                        BG1Offset = 0x5E2BE9,
                        OrigItem = ItemType.Power,
                        
                    };
                case 65:
                    return new Location
                    {
                        Number = 65,
                        LogicName = "pumpkin_hallwayMissile",
                        Area = 0x3,
                        Room = 0x24,
                        MinimapX = 0xC,
                        MinimapY = 0x15,
                        ClipdataOffset = 0x6017E8,
                        BG1Offset = 0x607071,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 66:
                    return new Location
                    {
                        Number = 66,
                        LogicName = "glacier_speedSuper",
                        Area = 0x5,
                        Room = 0x2,
                        MinimapX = 0x19,
                        MinimapY = 0x2,
                        ClipdataOffset = 0x6A818C,
                        BG1Offset = 0x71FAB2,
                        OrigItem = ItemType.Super,
                        
                    };
                case 67:
                    return new Location
                    {
                        Number = 67,
                        LogicName = "glacier_shipSuper",
                        Area = 0x5,
                        Room = 0x2F,
                        MinimapX = 0x3,
                        MinimapY = 0x6,
                        ClipdataOffset = 0x64B7EF,
                        BG1Offset = 0x877CEE,
                        OrigItem = ItemType.Super,
                        
                    };
                case 68:
                    return new Location
                    {
                        Number = 68,
                        LogicName = "glacier_wallEnergy",
                        Area = 0x5,
                        Room = 0x4,
                        MinimapX = 0x10,
                        MinimapY = 0x6,
                        ClipdataOffset = 0x5EE7C0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 69:
                    return new Location
                    {
                        Number = 69,
                        LogicName = "glacier_skullMissile",
                        Area = 0x5,
                        Room = 0x7,
                        MinimapX = 0x18,
                        MinimapY = 0x6,
                        ClipdataOffset = 0x5E3068,
                        BG1Offset = 0x6DFD49,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 70:
                    return new Location
                    {
                        Number = 70,
                        LogicName = "glacier_cliffEnergy",
                        Area = 0x5,
                        Room = 0x2D,
                        MinimapX = 0x7,
                        MinimapY = 0x9,
                        ClipdataOffset = 0x733990,
                        BG1Offset = 0x86D1A1,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 71:
                    return new Location
                    {
                        Number = 71,
                        LogicName = "glacier_watterfallMissile1",
                        Area = 0x5,
                        Room = 0x6,
                        MinimapX = 0x15,
                        MinimapY = 0x8,
                        ClipdataOffset = 0x5F6308,
                        BG1Offset = 0x66712D,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 72:
                    return new Location
                    {
                        Number = 72,
                        LogicName = "glacier_watterfallMissile2",
                        Area = 0x5,
                        Room = 0xA,
                        MinimapX = 0x1A,
                        MinimapY = 0x8,
                        ClipdataOffset = 0x5F6E64,
                        BG1Offset = 0x6E18B1,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 73:
                    return new Location
                    {
                        Number = 73,
                        LogicName = "glacier_underwaterMissile",
                        Area = 0x5,
                        Room = 0x2C,
                        MinimapX = 0x1,
                        MinimapY = 0xF,
                        ClipdataOffset = 0x6016BC,
                        BG1Offset = 0x785E52,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 74:
                    return new Location
                    {
                        Number = 74,
                        LogicName = "glacier_brokenshipMissile",
                        Area = 0x5,
                        Room = 0x28,
                        MinimapX = 0x16,
                        MinimapY = 0xF,
                        ClipdataOffset = 0x69B3AB,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 75:
                    return new Location
                    {
                        Number = 75,
                        LogicName = "glacier_crumbleMissile",
                        Area = 0x5,
                        Room = 0x29,
                        MinimapX = 0xE,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x872B90,
                        BG1Offset = 0x605D2C,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 76:
                    return new Location
                    {
                        Number = 76,
                        LogicName = "glacier_underwaterSuper",
                        Area = 0x5,
                        Room = 0x14,
                        MinimapX = 0x1B,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x649B57,
                        BG1Offset = 0x684BCC,
                        OrigItem = ItemType.Super,
                        
                    };
                case 77:
                    return new Location
                    {
                        Number = 77,
                        LogicName = "glacier_shipMissile1",
                        Area = 0x5,
                        Room = 0x27,
                        MinimapX = 0x14,
                        MinimapY = 0x11,
                        ClipdataOffset = 0x6749E7,
                        BG1Offset = 0x69CBE7,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 78:
                    return new Location
                    {
                        Number = 78,
                        LogicName = "glacier_wallPb",
                        Area = 0x5,
                        Room = 0x21,
                        MinimapX = 0x15,
                        MinimapY = 0x11,
                        ClipdataOffset = 0x5E9B5B,
                        BG1Offset = 0x5EA333,
                        OrigItem = ItemType.Power,
                        
                    };
                case 79:
                    return new Location
                    {
                        Number = 79,
                        LogicName = "ice",
                        Area = 0x5,
                        Room = 0x1C,
                        MinimapX = 0x1C,
                        MinimapY = 0x12,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Ice,
                        
                    };
                case 80:
                    return new Location
                    {
                        Number = 80,
                        LogicName = "glacier_shipMissile2",
                        Area = 0x5,
                        Room = 0x2A,
                        MinimapX = 0xA,
                        MinimapY = 0x13,
                        ClipdataOffset = 0x2E196B,
                        BG1Offset = 0x8E64D5,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 81:
                    return new Location
                    {
                        Number = 81,
                        LogicName = "glacier_shipPb",
                        Area = 0x5,
                        Room = 0x26,
                        MinimapX = 0x12,
                        MinimapY = 0x15,
                        ClipdataOffset = 0x61737C,
                        BG1Offset = 0x6BAF97,
                        OrigItem = ItemType.Power,
                        
                    };
                case 82:
                    return new Location
                    {
                        Number = 82,
                        LogicName = "plasma",
                        Area = 0x5,
                        Room = 0x3B,
                        MinimapX = 0x3,
                        MinimapY = 0x18,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Plasma,
                        
                    };
                case 83:
                    return new Location
                    {
                        Number = 83,
                        LogicName = "glacier_boneyardMissile",
                        Area = 0x5,
                        Room = 0x1D,
                        MinimapX = 0x18,
                        MinimapY = 0x17,
                        ClipdataOffset = 0x68085B,
                        BG1Offset = 0x6E3412,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 84:
                    return new Location
                    {
                        Number = 84,
                        LogicName = "spooky_spaceMissile",
                        Area = 0x6,
                        Room = 0x1C,
                        MinimapX = 0x15,
                        MinimapY = 0x5,
                        ClipdataOffset = 0x73BF0D,
                        BG1Offset = 0x5EC3A6,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 85:
                    return new Location
                    {
                        Number = 85,
                        LogicName = "spooky_spacePb",
                        Area = 0x6,
                        Room = 0x1E,
                        MinimapX = 0x13,
                        MinimapY = 0x7,
                        ClipdataOffset = 0x710C43,
                        BG1Offset = 0x74C7CC,
                        OrigItem = ItemType.Power,
                        
                    };
                case 86:
                    return new Location
                    {
                        Number = 86,
                        LogicName = "spooky_spaceEnergy",
                        Area = 0x6,
                        Room = 0x24,
                        MinimapX = 0x1B,
                        MinimapY = 0xA,
                        ClipdataOffset = 0x73848F,
                        BG1Offset = 0x738719,
                        OrigItem = ItemType.Energy,
                        
                    };
                case 87:
                    return new Location
                    {
                        Number = 87,
                        LogicName = "gravity",
                        Area = 0x6,
                        Room = 0x2F,
                        MinimapX = 0x9,
                        MinimapY = 0xB,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Gravity,
                        
                    };
                case 88:
                    return new Location
                    {
                        Number = 88,
                        LogicName = "spooky_platformSuper",
                        Area = 0x6,
                        Room = 0x2B,
                        MinimapX = 0x4,
                        MinimapY = 0xE,
                        ClipdataOffset = 0x62EB4C,
                        BG1Offset = 0x62E8B1,
                        OrigItem = ItemType.Super,
                        
                    };
                case 89:
                    return new Location
                    {
                        Number = 89,
                        LogicName = "spooky_maintowerMissile",
                        Area = 0x6,
                        Room = 0x26,
                        MinimapX = 0x8,
                        MinimapY = 0xE,
                        ClipdataOffset = 0x6997B1,
                        BG1Offset = 0x5EAEBC,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 90:
                    return new Location
                    {
                        Number = 90,
                        LogicName = "spooky_tunnelMissile",
                        Area = 0x6,
                        Room = 0x2D,
                        MinimapX = 0x3,
                        MinimapY = 0xF,
                        ClipdataOffset = 0x6A32C2,
                        BG1Offset = 0x72D5CE,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 91:
                    return new Location
                    {
                        Number = 91,
                        LogicName = "spooky_mansionMissile1",
                        Area = 0x6,
                        Room = 0x18,
                        MinimapX = 0x1,
                        MinimapY = 0x12,
                        ClipdataOffset = 0x734989,
                        BG1Offset = 0x734B2A,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 92:
                    return new Location
                    {
                        Number = 92,
                        LogicName = "spooky_mansionMissile2",
                        Area = 0x6,
                        Room = 0x1B,
                        MinimapX = 0xC,
                        MinimapY = 0x12,
                        ClipdataOffset = 0x33F9FD,
                        BG1Offset = 0x7077EE,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 93:
                    return new Location
                    {
                        Number = 93,
                        LogicName = "spooky_oldpumpkinMissile",
                        Area = 0x6,
                        Room = 0x7,
                        MinimapX = 0xF,
                        MinimapY = 0x13,
                        ClipdataOffset = 0x62397E,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 94:
                    return new Location
                    {
                        Number = 94,
                        LogicName = "spooky_oldbombMissile",
                        Area = 0x6,
                        Room = 0x5,
                        MinimapX = 0x12,
                        MinimapY = 0x12,
                        ClipdataOffset = 0x72EACB,
                        BG1Offset = 0x72EDA8,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 95:
                    return new Location
                    {
                        Number = 95,
                        LogicName = "spooky_oldmorphSuper",
                        Area = 0x6,
                        Room = 0x2,
                        MinimapX = 0x12,
                        MinimapY = 0x13,
                        ClipdataOffset = 0x72DE36,
                        BG1Offset = 0,
                        OrigItem = ItemType.Super,
                        
                    };
                case 96:
                    return new Location
                    {
                        Number = 96,
                        LogicName = "spooky_olddeoremMissile",
                        Area = 0x6,
                        Room = 0x9,
                        MinimapX = 0xC,
                        MinimapY = 0x18,
                        ClipdataOffset = 0x72F992,
                        BG1Offset = 0x5DB7A5,
                        OrigItem = ItemType.Missile,
                        
                    };
                case 97:
                    return new Location
                    {
                        Number = 97,
                        LogicName = "screw",
                        Area = 0x6,
                        Room = 0xE,
                        MinimapX = 0x8,
                        MinimapY = 0x1B,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Screw,
                        
                    };
                case 98:
                    return new Location
                    {
                        Number = 98,
                        LogicName = "spooky_meshMissile",
                        Area = 0x6,
                        Room = 0x13,
                        MinimapX = 0x10,
                        MinimapY = 0x1C,
                        ClipdataOffset = 0x732C7C,
                        BG1Offset = 0x6B5ED0,
                        OrigItem = ItemType.Missile,
                        
                    };

                default: throw new IndexOutOfRangeException();
            }
        }

        public static Location WinterMissionLocation(int number)
        {
            switch (number) 
            {
                case 0:
                    return new Location
                    {
                        Number = 0,
                        LogicName = "Charge_Beam_Screen_Fix",
                        Area = 0x0,
                        Room = 0x0,
                        MinimapX = 0x2,
                        MinimapY = 0xE,
                        ClipdataOffset = 0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Charge,
                    };
                case 1:
                    return new Location
                    {
                        Number = 1,
                        LogicName = "PowerGrip_of_course",
                        Area = 0x0,
                        Room = 0x0,
                        MinimapX = 0x2,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Grip,
                    };
                case 2:
                    return new Location
                    {
                        Number = 2,
                        LogicName = "Your_very_first_missile",
                        Area = 0x0,
                        Room = 0x0,
                        MinimapX = 0x2,
                        MinimapY = 0xE,
                        ClipdataOffset = 0x554F48,
                        BG1Offset = 0x5602DF,
                        OrigItem = ItemType.Missile,
                    };
                case 3:
                    return new Location
                    {
                        Number = 3,
                        LogicName = "morph_at_last",
                        Area = 0x0,
                        Room = 0x0,
                        MinimapX = 0x3,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x5550A7,
                        BG1Offset = 0x5605F9,
                        OrigItem = ItemType.Morph,
                    };
                case 4:
                    return new Location
                    {
                        Number = 4,
                        LogicName = "Dont_forget_this_missile",
                        Area = 0x0,
                        Room = 0x12,
                        MinimapX = 0x16,
                        MinimapY = 0xF,
                        ClipdataOffset = 0x60CA1B,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                    };
                case 5:
                    return new Location
                    {
                        Number = 5,
                        LogicName = "the_missile_above_bombs_come_back_again",
                        Area = 0x0,
                        Room = 0x16,
                        MinimapX = 0xA,
                        MinimapY = 0x11,
                        ClipdataOffset = 0x33E6EC,
                        BG1Offset = 0x61410E,
                        OrigItem = ItemType.Missile,
                    };
                case 6:
                    return new Location
                    {
                        Number = 6,
                        LogicName = "Bombs_before_ball_pshaw",
                        Area = 0x0,
                        Room = 0x16,
                        MinimapX = 0xA,
                        MinimapY = 0x12,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Bomb,
                    };
                case 7:
                    return new Location
                    {
                        Number = 7,
                        LogicName = "the_missile_that_was_apparently_really_fucking_important",
                        Area = 0x5,
                        Room = 0x3,
                        MinimapX = 0x9,
                        MinimapY = 0xA,
                        ClipdataOffset = 0x60DBC7,
                        BG1Offset = 0x615EFC,
                        OrigItem = ItemType.Missile,
                    };
                case 8:
                    return new Location
                    {
                        Number = 8,
                        LogicName = "Long_beam_short_d-",
                        Area = 0x0,
                        Room = 0x5,
                        MinimapX = 0x0,
                        MinimapY = 0xF,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Long,
                    };
                case 9:
                    return new Location
                    {
                        Number = 9,
                        LogicName = "E_tank_you_need_shinespark_for",
                        Area = 0x0,
                        Room = 0x14,
                        MinimapX = 0x1,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x611456,
                        BG1Offset = 0x613362,
                        OrigItem = ItemType.Energy,
                    };
                case 10:
                    return new Location
                    {
                        Number = 10,
                        LogicName = "Power_bomb_in_space",
                        Area = 0x0,
                        Room = 0xA,
                        MinimapX = 0x6,
                        MinimapY = 0xB,
                        ClipdataOffset = 0x60D94B,
                        BG1Offset = 0x60E495,
                        OrigItem = ItemType.Power,
                    };
                case 11:
                    return new Location
                    {
                        Number = 11,
                        LogicName = "super_in_the_ripper_room",
                        Area = 0x0,
                        Room = 0xB,
                        MinimapX = 0x6,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x60DB23,
                        BG1Offset = 0x6104E7,
                        OrigItem = ItemType.Super,
                    };
                case 12:
                    return new Location
                    {
                        Number = 12,
                        LogicName = "missile_in_the_climb_for_power_bomb",
                        Area = 0x0,
                        Room = 0x3,
                        MinimapX = 0xC,
                        MinimapY = 0xD,
                        ClipdataOffset = 0x792514,
                        BG1Offset = 0x56400A,
                        OrigItem = ItemType.Missile,
                    };
                case 13:
                    return new Location
                    {
                        Number = 13,
                        LogicName = "super_missile_in_rinkas_house",
                        Area = 0x0,
                        Room = 0x15,
                        MinimapX = 0x9,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x6137EE,
                        BG1Offset = 0x6139B2,
                        OrigItem = ItemType.Super,
                    };
                case 14:
                    return new Location
                    {
                        Number = 14,
                        LogicName = "Standing_chozos_missile_friend",
                        Area = 0x0,
                        Room = 0x1E,
                        MinimapX = 0xB,
                        MinimapY = 0x10,
                        ClipdataOffset = 0x60CF04,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                    };
                case 15:
                    return new Location
                    {
                        Number = 15,
                        LogicName = "Hi_jump",
                        Area = 0x0,
                        Room = 0x26,
                        MinimapX = 0x3,
                        MinimapY = 0x11,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Hi,
                    };
                case 16:
                    return new Location
                    {
                        Number = 16,
                        LogicName = "you_only_pick_up_this_missile_twice",
                        Area = 0x0,
                        Room = 0x17,
                        MinimapX = 0xA,
                        MinimapY = 0x11,
                        ClipdataOffset = 0x60DD9E,
                        BG1Offset = 0x612D73,
                        OrigItem = ItemType.Missile,
                    };
                case 17:
                    return new Location
                    {
                        Number = 17,
                        LogicName = "Super_in_acid",
                        Area = 0x0,
                        Room = 0x26,
                        MinimapX = 0x3,
                        MinimapY = 0x12,
                        ClipdataOffset = 0x61165B,
                        BG1Offset = 0,
                        OrigItem = ItemType.Super,
                    };
                case 18:
                    return new Location
                    {
                        Number = 18,
                        LogicName = "Varia_guarded_by_that_Reo",
                        Area = 0x0,
                        Room = 0x19,
                        MinimapX = 0x2,
                        MinimapY = 0x13,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Varia,
                    };
                case 19:
                    return new Location
                    {
                        Number = 19,
                        LogicName = "ice_to_see_you",
                        Area = 0x0,
                        Room = 0x11,
                        MinimapX = 0x5,
                        MinimapY = 0x13,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0,
                        OrigItem = ItemType.Ice,
                    };
                case 20:
                    return new Location
                    {
                        Number = 20,
                        LogicName = "supers_after_metroid_heck",
                        Area = 0x0,
                        Room = 0x25,
                        MinimapX = 0xB,
                        MinimapY = 0x13,
                        ClipdataOffset = 0x60D110,
                        BG1Offset = 0x60EC82,
                        OrigItem = ItemType.Super,
                    };
                case 21:
                    return new Location
                    {
                        Number = 21,
                        LogicName = "missile_behind_invisible_wall",
                        Area = 0x0,
                        Room = 0x3,
                        MinimapX = 0xC,
                        MinimapY = 0x13,
                        ClipdataOffset = 0x7926AB,
                        BG1Offset = 0,
                        OrigItem = ItemType.Missile,
                    };
                case 22:
                    return new Location
                    {
                        Number = 22,
                        LogicName = "double_pants",
                        Area = 0x0,
                        Room = 0x1B,
                        MinimapX = 0x6,
                        MinimapY = 0x15,
                        ClipdataOffset = 0x0,
                        BG1Offset = 0x0,
                        OrigItem = ItemType.Speed,
                    };
                case 23:
                    return new Location
                    {
                        Number = 23,
                        LogicName = "Power_bomb_before_imago",
                        Area = 0x0,
                        Room = 0x3,
                        MinimapX = 0xC,
                        MinimapY = 0x15,
                        ClipdataOffset = 0x792723,
                        BG1Offset = 0x564404,
                        OrigItem = ItemType.Power,
                    };
                case 24:
                    return new Location
                    {
                        Number = 24,
                        LogicName = "A_stolen_etank",
                        Area = 0x0,
                        Room = 0x1C,
                        MinimapX = 0x9,
                        MinimapY = 0x18,
                        ClipdataOffset = 0x615536,
                        BG1Offset = 0x77F7A1,
                        OrigItem = ItemType.Energy,
                    };
                case 25:
                    return new Location
                    {
                        Number = 25,
                        LogicName = "A_stolen_etank2",
                        Area = 0x0,
                        Room = 0x1C,
                        MinimapX = 0xA,
                        MinimapY = 0x18,
                        ClipdataOffset = 0x61552B,
                        BG1Offset = 0x77F787,
                        OrigItem = ItemType.Energy,
                    };
                case 26:
                    return new Location
                    {
                        Number = 25,
                        LogicName = "A_stolen_etank3",
                        Area = 0x0,
                        Room = 0x1C,
                        MinimapX = 0xB,
                        MinimapY = 0x18,
                        ClipdataOffset = 0x6154E8,
                        BG1Offset = 0x77F6E8,
                        OrigItem = ItemType.Energy,
                    };
                    default: throw new IndexOutOfRangeException();
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
                case Game.DeepFreeze:
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
                case Game.Spooky2:
                    Count = 99;
                    ChargeBeamst = 9;
                    locations = new Location[Count];
                    for (int i = 0; i < Count; i++)
                        locations[i] = Spooky2Location(i);
                    return locations;
                case Game.ScrollsVI:
                    Count = 70;
                    ChargeBeamst = 3;
                    locations = new Location[Count];
                    for (int i = 0; i < Count; i++)
                        locations[i] = ScrollsSixLocation(i);
                    return locations;
                case Game.SR387:
                    Count = 39;
                    ChargeBeamst = 11;
                    locations = new Location[Count];
                    for (int i = 0; i < Count; i++)
                        locations[i] = SR387Location(i);
                    return locations;
                case Game.WinterMission:
                    Count = 27;
                    ChargeBeamst = 0;
                    locations = new Location[Count];
                    for (int i = 0; i < Count; i++)
                        locations[i] = WinterMissionLocation(i);
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
