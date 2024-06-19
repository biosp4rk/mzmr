using mzmr.Properties;
using mzmr.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
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
            musLst = new List<byte>
            {
                0x01, 0x02, 0x03, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0B, 0x0A,
                0x0C, 0x0D, 0x0E, 0x17, 0x19, 0x1B, 0x32, 0x33, 0x35, 0x3B,
                0x3C, 0x3D, 0x3E, 0x3F, 0x40, 0x41, 0x44, 0x45, 0x46, 0x48,
                0x49, 0x4B, 0x4E, 0x50, 0x53, 0x54, 0x5A, 0x5B, 0x5C, 0x5E
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
            if (settings.RandoBosses)
            {
                offLst.AddRange(new int[] { 0x8085AA, 0x80AFD2, 0x80C686, 0x80EB26,
                    0x812B40, 0x814A06, 0x816096, 0x817254 });
             }   
            if (settings.CustomMusic) 
            {
                for (int i = 0; i < 20; i++)
                {
                    musLst.Add((byte)(0x1D + i));
                    roomRepLst.Add((byte)(0x1D + i));
                }

            }
            switch (settings.SelectedGame)
            {
                default:
                    roomsPerArea = Rom.RoomsPerArea; break;
                case Game.Spooky:
                    roomsPerArea = new byte[] { 0x2A, 0x2A, 0x39, 0x2B, 0x14, 0x16, 0x63 };
                    break;
                case Game.Spooky2:
                    roomsPerArea = new byte[] { 0x2D, 0x41, 0x7A, 0x59, 0x22, 0x22, 0x73 };
                    roomRepLst.AddRange(new byte[] { 0x10, 0x11, 0x12, 0x13, 0x14, 0x15 });
                    musLst.AddRange(new byte[] { 0x10, 0x11, 0x12, 0x13, 0x14, 0x15 });
                    roomRepLst.Remove(0x19);
                    bossRepLst.Add(0x19);
                    break;
                case Game.ScrollsVI:
                    roomsPerArea = new byte[] { 0x3D, 0x44, 0x39, 0x21, 0x2F, 0x1B, 0x63 };
                    roomRepLst.Remove(1);
                    roomRepLst.Remove(0xC);
                    roomRepLst.Add(4);
                    bossRepLst.AddRange(new byte[] { 1, 0xC, 0x10 });
                    break;
                case Game.SR387:
                    roomsPerArea = new byte[] { 0x2C, 0x39, 0x39, 0x2F, 0x14, 0x2D, 0x63 };
                    roomRepLst.Remove(1);
                    musLst.Remove(1);
                    roomRepLst.Remove(0x44);
                    musLst.Remove(0x44);
                    roomRepLst.Remove(0x45);
                    musLst.Remove(0x45);        //the above songs crash in SR387
                    roomRepLst.Add(0x43);
                    musLst.Add(0x43);
                    bossRepLst.Remove(0x43);
                    break;

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
        byte[] roomsPerArea;
        private List<byte[]> customRoomTracks = new List<byte[]>
            {
                Resources.song_BowswersRoad, Resources.song_DungeonZelda, Resources.song_CinnabarMansion,
                Resources.song_Duke2, Resources.song_MMX, Resources.song_SMBUnderground,
                Resources.song_Solum, Resources.song_TurtleTemple, Resources.song_Turrim,
                Resources.song_LitoreSand, Resources.song_Boneyard, Resources.song_Th06_05,
                Resources.song_WidePutin, Resources.song_RedBrinstar, Resources.song_GreenBrinstar,
                Resources.song_Maridia, Resources.song_MonsFire, Resources.song_MonsIce,
                Resources.song_spookyCastle, Resources.song_TurretSerenade, Resources.song_ReconScience
            };

        public override RandomizeResult Randomize(CancellationToken cancellationToken)
        {
            //if (settings.CustomMusic && (settings.BossMusic != Song.Unchanged || settings.RoomMusic != Song.Unchanged))
                AddNewTracks();
            //if (settings.RoomMusic == Song.NoLogic)
            //    RandomizeRoomMusic(musicList);
            //else if (settings.RoomMusic == Song.Structured)
            //    RandomizeRoomMusic(roomReplacemnts);
            //if (settings.BossMusic == Song.NoLogic)
            //    RandomizeBossMusic(musicList);
            //else if (settings.BossMusic == Song.Structured)
            //    RandomizeBossMusic(bossReplacements);
            return new RandomizeResult(true);
        }

        private void RandomizeRoomMusic(byte[] arr)
        {
            if (settings.RoomMusic == Song.Structured)
            {
                for (int i = 0; i < roomsPerArea.Length; i++)
                {
                    if (settings.RandoBosses && (i == 1 || i == 3)) //checks if random bosses and if area is kraid or ridley
                        RandomizeMusicforArea(roomsPerArea[i] + Enum.GetNames(typeof(RandomBosses.Bosses)).Length - 2, rom.ReadPtr(Rom.AreaRoomEntryOffset + (i * 4)), arr, i);
                    else
                        RandomizeMusicforArea(roomsPerArea[i], rom.ReadPtr(Rom.AreaRoomEntryOffset + (i * 4)), arr, i);
                }
            }
            else
            {
                for (int i = 0; i < roomsPerArea.Length; i++)
                {
                    if (settings.RandoBosses && (i == 1 || i == 3)) //checks if random bosses and if area is kraid or ridley
                        RandomizeMusicforAreaNoLogic(roomsPerArea[i] + Enum.GetNames(typeof(RandomBosses.Bosses)).Length - 2, rom.ReadPtr(Rom.AreaRoomEntryOffset + (i * 4)), arr, i);
                    else
                        RandomizeMusicforAreaNoLogic(roomsPerArea[i], rom.ReadPtr(Rom.AreaRoomEntryOffset + (i * 4)), arr, i);
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

        private void AddNewTracks()
        {
            //tracks 29 - 49 are not used
 
            for (int i = 0; i < 20 ; i++)
                Import(customRoomTracks[i], 29 + i);

        }

        private void PickTracks() 
        {
            
        }


        private void Import(byte[] data, int num)
        {
            // all song files are originally imported in sappy at 0x760D38
            //function imports those binary files and corrects pointers
            int header = 0, songStart;
            List<int> trackOffsets = new List<int>();
            songStart = rom.WriteToEnd(data);
            for (int i = 0; i < data.Length - 5; i++) 
            {
                if ((data[i] == 0xBC) && (data[i + 1] == 00)) //start of track
                    trackOffsets.Add(i + songStart);
                else if ((data[i] == 0xB2) && (data[i + 5] == 0xB1)) //track loops
                {
                    int loopOffset = data[i + 1] | (data[i + 2] << 8) | (data[i + 3] << 16)
                    | ((data[i + 4] - 8) << 24);
                    loopOffset += songStart - 0x760D38; 
                    rom.WritePtr(songStart + i + 1, loopOffset);
                }
                else if ((data[i] == 0xB3)) //pattern play
                {
                    int patternOffset = data[i + 1] | (data[i + 2] << 8) | (data[i + 3] << 16)
                    | ((data[i + 4] - 8) << 24);
                    patternOffset += songStart - 0x760D38;
                    rom.WritePtr(songStart + i + 1, patternOffset);
                }
            }
            for (int i = data.Length - 1; i > 4; i--)  //find song header
            {
                if ((data[i] == 00) && (data[i - 1] == 00) && (data[i - 2] == 00) && (data[i - 3] > 00) 
                    && (data[i - 3] <= 0xF))
                {
                    header = i - 3 + songStart; break;
                }
            }
            //needed in header so songs dnt cut out in area transition
            rom.Write8(header + 2, 0x82);
            for (int i = 0; i < trackOffsets.Count; i++) //write track offsets to header
                rom.WritePtr(header + 8 + (i * 4) , trackOffsets[i]);
            rom.WritePtr(0x8F2C0 + (num * 8), header); //write to music table

             
            
            

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
