using System;

namespace mzmr.Items
{
    public class Location
    {
        public bool IsHidden
        {
            get { return OrigItem.IsTank() && BG1Offset == 0; }
        }

        public const int ChargeBeamst = 9;
        public const int ImagoCocoon = 50;
        public const int PiratePB = 91;

        public int Number;
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

        public static Location GetLocation(int number)
        {
            switch (number)
            {
                case 0:
                    return new Location
                    {
                        Number = 0,
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

        public static Location[] GetLocations()
        {
            Location[] locations = new Location[100];
            for (int i = 0; i < 100; i++)
            {
                locations[i] = GetLocation(i);
            }
            return locations;
        }

    }
}
