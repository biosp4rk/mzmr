using System;
using System.Collections.Generic;

namespace mzmr.Randomizers
{
    public class RandomMusic : RandomAspect
    {
        public RandomMusic(Rom rom, Settings settings, Random rng) : base(rom, settings, rng)
        {

        }

        private static readonly byte[] customMusicList = //list of valid music IDs including custom tracks
        {
                0x01, 0x02, 0x03, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0B, 0x0C,
                0x0D, 0x0E, 0x1B, 0x1D, 0x1E, 0x1F, 0x20, 0x21, 0x22, 0x23,
                0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D,
                0x32, 0x33, 0x35, 0x38, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F, 0x40, 
                0x41, 0x44, 0x45, 0x46, 0x47, 0x49, 0x4B, 0x4E, 0x51, 0x53
        };

        private static readonly byte[] musicList = //list of valid music IDs
{
                0x01, 0x02, 0x03, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0B, 0x0C,
                0x0D, 0x0E, 0x1B, 0x32, 0x35, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F,
                0x40, 0x41, 0x44, 0x45, 0x46, 0x49, 0x4B, 0x4E, 0x53, 0x54,
                0x5A, 0x5B, 0x5C, 0x5E
        };

        private static readonly byte[] customRoomReplacemnts = //list of valid room music replacements, including custom tracks
{
                0x01, 0x02, 0x03, 0x05, 0x06, 0x07, 0x09, 0x0A, 0x0B, 0x0C,
                0x0D, 0x0E, 0x0F, 0x17, 0x18, 0x19, 0x1B, 0x1D, 0x1E, 0x1F,
                0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29,
                0x2A, 0x2B, 0x2C, 0x2D, 0x32, 0x3B, 0x44, 0x46, 0x48, 0x49,
                0x50, 0x53, 0x54
        };

        private static readonly byte[] roomReplacemnts = 
        {
                0x01, 0x02, 0x03, 0x05, 0x06, 0x07, 0x09, 0x0A, 0x0B, 0x0C,
                0x0D, 0x0E, 0x0F, 0x17, 0x18, 0x19, 0x1B, 0x32, 0x3B, 0x44, 
                0x46, 0x48, 0x49, 0x50, 0x53, 0x54, 0x5A, 0x5B, 0x5C, 0x5E
        };

        private static readonly byte[] customBossReplacements =  //boss music replacements with custom trucks
        {
            0x08, 0x33, 0x34, 0x35, 0x38, 0x3C, 0x3E, 0x3F, 0x40, 0x41, 0x43,
            0x45, 0x47, 0x4B, 0x4E, 0x51
        };

        private static readonly byte[] bossReplacements = 
        { 
            0x08, 0x34, 0x35, 0x3C, 0x3E, 0x3F, 0x40, 0x41, 0x43, 0x45, 0x4B,
            0x4E 
        };

        private static readonly int[] bossLocationArray = { 0x2149C, 0x25AE0, 0x271BC, 0x28862, 0x3A2B2, 0x3D108, 0x3DE9C, 0x42370, 0x4C2D8,
                0x4CF56, 0x62914, 0x65840, 0x77218, 0x7C85C };             //array of location where boss song values are

        public override bool Randomize()
        {
            switch (settings.RoomMusic)
            {
                case Song.Unchanged:
                    break;
                case Song.NoLogic:
                    if (settings.CustomMusic)
                        RandomizeRoomMusicNoLogic(customMusicList);
                    else
                        RandomizeRoomMusicNoLogic(musicList);
                    break;
                case Song.Structured:
                    if (settings.CustomMusic)
                        RandomizeRoomMusicLogic(customRoomReplacemnts);
                    else
                        RandomizeRoomMusicLogic(roomReplacemnts);
                    break;
            };
            switch (settings.BossMusic)
            {
                case Song.Unchanged:
                    break;
                case Song.NoLogic:
                    if (settings.CustomMusic)
                        RandomizeBossMusicNoLogic(customMusicList);
                    else
                        RandomizeBossMusicNoLogic(musicList);
                    break;
                case Song.Structured:
                    if (settings.CustomMusic)
                        RandomizeBossMusicLogic(customBossReplacements);
                    else
                        RandomizeBossMusicLogic(bossReplacements);
                    break;
            }; ;
            return true;
        }

        private void RandomizeRoomMusicNoLogic(byte[] arr) 
        {
            int roomCount = 315;  //number of rooms in zero mission
            for (int i = 0; i < roomCount; i++)
            {
                rom.Write8(0x340B0E + (0x3C * i), arr[rng.Next(0, arr.Length)]);

            }
        }

        private void RandomizeRoomMusicLogic(byte[] arr)
        {
            byte[] roomMusic = { 01, 03, 06, 07, 0xA, 0xB, 0xC, 0xD, 0xE, 0xF, 0x17, 0x19, 0x32, 0x3B, 0x3D, 0x50, 0x5A, 0x5B, 0x5C, 0x5E };
            byte[] newRoomMusic = new byte[roomMusic.Length];
            int index;
            for (int i = 0; i < newRoomMusic.Length; i++)
                newRoomMusic[i] = arr[rng.Next(0, arr.Length)];  //assigns songs to replace each room track
            for (int i = 0; i < 315; i++)
            {
                index = Array.BinarySearch(roomMusic, (byte)rom.Read8(0x340B0E + (0x3C * i)));
                if (index < 0)      //failsafe if value is not in array
                    index = 0;
                rom.Write8(0x340B0E + (0x3C * i), newRoomMusic[index]);;
            }
            rom.Write8(0x21E0A, newRoomMusic[0]);
            rom.Write8(0x605F8, newRoomMusic[0]);                //starting song and song after doerem dies is same is brinstar song      
        }

        private void RandomizeBossMusicLogic(byte[] arr)
        {

            for (int i = 0; i < bossLocationArray.Length; i++)
                rom.Write8(bossLocationArray[i], arr[rng.Next(0, arr.Length)]);
        }

        private void RandomizeBossMusicNoLogic(byte[] arr)
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
                    changed.Add("Rooms: Structured");
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
                    changed.Add("Bosses: Structured");
                    break;
            };
            if (changed.Count == 0)
                return "Muisc: Unchanged" + Environment.NewLine;
            return "Music: " + string.Join(", ", changed) + Environment.NewLine;
        }
    }
}
