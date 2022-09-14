using System;
using System.Collections.Generic;

namespace mzmr.Randomizers
{
    public class RandomMusic : RandomAspect
    {
        public RandomMusic(Rom rom, Settings settings, Random rng) : base(rom, settings, rng)
        {

        }

        private static readonly byte[] musicList = //list of valid music IDs
        {
                0, 0x1, 0x2, 0x3, 0x5, 0x6, 0x7, 0x8, 0x9, 0x32, 0xB,
                0xC, 0xD, 0xE, 0x1B, 0x35, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F,
                0x40, 0x41, 0x44, 0x45, 0x46, 0x49, 0x4B, 0x4E, 0x53
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
                    RandomizeRoomMusicNoLogic();
                    break;
                case Song.Structured:
                    RandomizeRoomMusicLogic();
                    break;
            };
            switch (settings.BossMusic)
            {
                case Song.Unchanged:
                    break;
                case Song.NoLogic:
                    RandomizeBossMusicNoLogic();
                    break;
                case Song.Structured:
                    RandomizeBossMusicLogic();
                    break;
            }; ;
            return true;
        }

        private void RandomizeRoomMusicNoLogic()
        {
            int roomCount = 315;  //number of rooms in zero mission
            for (int i = 0; i < roomCount; i++)
            {
                rom.Write8(0x340B0E + (0x3C * i), musicList[rng.Next(0, musicList.Length)]);

            }
        }

        private void RandomizeRoomMusicLogic()
        {
            byte[] roomMusic = { 01, 03, 06, 07, 0xA, 0xB, 0xC, 0xD, 0xE, 0xF, 0x17, 0x19, 0x32, 0x3B, 0x3D, 0x50, 0x5A, 0x5B, 0x5C, 0x5E };
            byte[] newRoomMusic = new byte[roomMusic.Length];
            byte[] roomReplacemnts = { 01, 02, 03, 05, 06, 07, 09, 0xA, 0xB, 0xC, 0xD, 0xE, 0xF, 0x17, 0x18,
                0x19, 0x1B, 0x32, 0x3B, 0x44, 0x46, 0x48, 0x49, 0x50, 0x53, 0x54 };
            int index;
            for (int i = 0; i < newRoomMusic.Length; i++)
                newRoomMusic[i] = roomReplacemnts[rng.Next(0, roomReplacemnts.Length)];  //assigns songs to replace each room track
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

        private void RandomizeBossMusicLogic()
        {
            byte[] replacements = { 08, 0x34, 0x35, 0x3C, 0x3E, 0x3F, 0x40, 0x41, 0x43, 0x45, 0x4B, 0x4E };
            for (int i = 0; i < bossLocationArray.Length; i++)
                rom.Write8(bossLocationArray[i], replacements[rng.Next(0, replacements.Length)]);
        }

        private void RandomizeBossMusicNoLogic()
        {
            for (int i = 0; i < bossLocationArray.Length; i++)
                rom.Write8(bossLocationArray[i], musicList[rng.Next(0, musicList.Length)]);
        }

        public override string GetLog()
        {
            var changed = new List<string>();
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
