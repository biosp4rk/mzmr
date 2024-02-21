using mzmr.Properties;
using mzmr.Utility;
using System;
using System.Collections.Generic;
using System.Threading;

namespace mzmr.Randomizers
{
    public class RandomMusic : RandomAspect
    {
        public RandomMusic(Rom rom, Settings settings, Random rng) : base(rom, settings, rng)
        {
            List<byte> musLst, roomRepLst, bossRepLst;
            List<int> offLst = new List<int>
            {
                0x2149C, 0x25AE0, 0x271BC, 0x28862, 0x3A2B2, 0x3D108, 0x3DE9C, 0x42370, 0x4C2D8,
                0x4CF56, 0x62914, 0x65840, 0x77218, 0x7C85C
            };
            if (settings.CustomMusic)
            {
                musLst = new List<byte>        
                {
                    0x01, 0x02, 0x03, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0B, 0x0C,
                    0x0D, 0x0E, 0x1B, 0x1D, 0x1E, 0x1F, 0x20, 0x21, 0x22, 0x23,
                    0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D,
                    0x2E, 0x2F, 0x30, 0x31, 0x32, 0x33, 0x35, 0x38, 0x3B, 0x3C,
                    0x3D, 0x3E, 0x3F, 0x40, 0x41, 0x44, 0x45, 0x46, 0x47, 0x49,
                    0x4B, 0x4E, 0x51, 0x52, 0x53, 0x55
                };
                roomRepLst = new List<byte> 
                {
                    0x01, 0x02, 0x03, 0x05, 0x06, 0x07, 0x09, 0x0A, 0x0B, 0x0C,
                    0x0D, 0x0E, 0x0F, 0x17, 0x18, 0x19, 0x1B, 0x1D, 0x1E, 0x1F,
                    0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29,
                    0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F, 0x30, 0x31, 0x32, 0x3B,
                    0x44, 0x46, 0x48, 0x49, 0x50, 0x53, 0x54
                };
                bossRepLst = new List<byte>
                {
                    0x08, 0x33, 0x34, 0x35, 0x38, 0x3C, 0x3E, 0x3F, 0x40, 0x41, 0x43,
                    0x45, 0x47, 0x4B, 0x4E, 0x51, 0x52, 0x55
                };
                offLst.AddRange(new int[] { 0x8085AA, 0x80AFD2, 0x80C686, 0x80EB26,
                    0x812B40, 0x814A06, 0x816096 } );
            }
            else
            {
                musLst = new List<byte>
                {
                    0x01, 0x02, 0x03, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0B, 0x0C,
                    0x0D, 0x0E, 0x1B, 0x32, 0x35, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F,
                    0x40, 0x41, 0x44, 0x45, 0x46, 0x49, 0x4B, 0x4E, 0x53, 0x54,
                    0x5A, 0x5B, 0x5C, 0x5E
                };
                roomRepLst = new List<byte>
                {
                    0x01, 0x02, 0x03, 0x05, 0x06, 0x07, 0x09, 0x0A, 0x0B, 0x0C,
                    0x0D, 0x0E, 0x0F, 0x17, 0x18, 0x19, 0x1B, 0x32, 0x3B, 0x44,
                    0x46, 0x48, 0x49, 0x50, 0x53, 0x54
                };
                bossRepLst = new List<byte>
                {
                    0x08, 0x34, 0x35, 0x3C, 0x3E, 0x3F, 0x40, 0x41, 0x43, 0x45, 0x4B,
                    0x4E
                };
            }
            musicList = musLst.ToArray();
            roomReplacemnts = roomRepLst.ToArray();
            bossReplacements = bossRepLst.ToArray();
            bossLocationArray = offLst.ToArray();
        }

        private readonly byte[] musicList; //list of valid music IDs
        private readonly byte[] roomReplacemnts; //list of room music
        private readonly byte[] bossReplacements; //list of boss music
        private readonly int[] bossLocationArray; //array of location where boss song values are;

        public override RandomizeResult Randomize(CancellationToken cancellationToken)
        {
            if (settings.CustomMusic && (settings.BossMusic != Song.Unchanged || settings.RoomMusic != Song.Unchanged))
                Patch.Apply(rom, Resources.ZM_U_musicBase);  //song data starts at 0x764000
            if (settings.RoomMusic == Song.NoLogic)
                RandomizeRoomMusic(musicList);
            else if (settings.RoomMusic == Song.Structured)
                RandomizeRoomMusic(roomReplacemnts);
            if (settings.BossMusic == Song.NoLogic)
                RandomizeBossMusic(musicList);
            else if (settings.BossMusic == Song.Structured)
                RandomizeBossMusic(bossReplacements);
            return new RandomizeResult(true);
        }

        private void RandomizeRoomMusic(byte[] arr)
        {
            if (settings.RoomMusic == Song.Structured)
            {
                for (int i = 0; i < Rom.RoomsPerArea.Length; i++)
                {
                    if (settings.RandoBosses && (i == 1 || i == 3)) //checks if random bosses and if area is kraid or ridley
                        RandomizeMusicforArea(Rom.RoomsPerArea[i] + Enum.GetNames(typeof(RandomBosses.Bosses)).Length - 2, rom.ReadPtr(Rom.AreaRoomEntryOffset + (i * 4)), arr, i);
                    else
                        RandomizeMusicforArea(Rom.RoomsPerArea[i], rom.ReadPtr(Rom.AreaRoomEntryOffset + (i * 4)), arr, i);
                }
            }
            else
            {
                for (int i = 0; i < Rom.RoomsPerArea.Length; i++)
                {
                    if (settings.RandoBosses && (i == 1 || i == 3)) //checks if random bosses and if area is kraid or ridley
                        RandomizeMusicforAreaNoLogic(Rom.RoomsPerArea[i] + Enum.GetNames(typeof(RandomBosses.Bosses)).Length - 2, rom.ReadPtr(Rom.AreaRoomEntryOffset + (i * 4)), arr, i);
                    else
                        RandomizeMusicforAreaNoLogic(Rom.RoomsPerArea[i], rom.ReadPtr(Rom.AreaRoomEntryOffset + (i * 4)), arr, i);
                }
            }
        }

        private void RandomizeMusicforAreaNoLogic(int length, int offset, byte[] arr, int arNum)
        {
            for (int i = 0; i < length; i++)
                rom.Write8(offset + (0x3C * i) + 0x3A, arr[rng.Next(0, arr.Length)]);
            if (arNum == 0)     //true if changing brinstar music
            {
                rom.Write8(0x21E0A, arr[rng.Next(0, arr.Length)]);
                rom.Write8(0x605F8, arr[rng.Next(0, arr.Length)]);                //starting song and song after doerem dies
            }

        }

        private void RandomizeMusicforArea(int length, int offset, byte[] arr, int arNum)
        {
            byte[] roomMusic = { 01, 03, 06, 07, 0xA, 0xB, 0xC, 0xD, 0xE, 0xF, 0x17, 0x19, 0x32, 0x3B, 0x3D, 0x50, 0x5A, 0x5B, 0x5C, 0x5E };
            byte[] newRoomMusic = new byte[roomMusic.Length];
            int index;
            for (int i = 0; i < newRoomMusic.Length; i++)
                newRoomMusic[i] = arr[rng.Next(0, arr.Length)];  //assigns songs to replace each room track
            for (int i = 0; i < length; i++)
            {
                index = Array.BinarySearch(roomMusic, (byte)rom.Read8(offset + (0x3C * i) + 0x3A));
                if (index < 0)      //failsafe if value is not in array
                    index = 0;
                rom.Write8(offset + (0x3C * i) + 0x3A, newRoomMusic[index]); ;
            }
            if (arNum == 0)     //true if changing brinstar music
            {
                rom.Write8(0x21E0A, newRoomMusic[0]);
                rom.Write8(0x605F8, newRoomMusic[0]);                //starting song and song after doerem dies is same is brinstar song
            }
        }
        private void RandomizeBossMusic(byte[] arr)
        {
                for (int i = 0; i < bossLocationArray.Length; i++)
                    rom.Write8(bossLocationArray[i], arr[rng.Next(0, arr.Length)]);
        }

        public override string GetLog()
        {
            var changed = new List<string>();
            if (settings.CustomMusic)
                changed.Add("Custom Enabled");
            switch (settings.RoomMusic)
            {
                case Song.Unchanged:
                    break;
                case Song.NoLogic:
                    changed.Add("Rooms: No Logic");
                    break;
                case Song.Structured:
                    changed.Add("Rooms: Within own pool.");
                    break;
            };
            switch (settings.BossMusic)
            {
                case Song.Unchanged:
                    break;
                case Song.NoLogic:
                    changed.Add("Bosses: No Logic");
                    break;
                case Song.Structured:
                    changed.Add("Bosses: Within own pool.");
                    break;
            };
            if (changed.Count == 0)
                return "Muisc: Unchanged" + Environment.NewLine;
            return "Music: " + string.Join(", ", changed) + Environment.NewLine;
        }
    }
}
