using System;
using System.Collections.Generic;
using System.Linq;

namespace mzmr.Randomizers
{
    public class RandomMusic : RandomAspect
    {
        public RandomMusic(Rom rom, Settings settings, Random rng) : base(rom, settings, rng)
        {

        }

        public override bool Randomize()
        {
            if (settings.MusicChange == Change.Unchanged) return true;

            // get track offsets
            var allTracks = new List<int>();
            List<int> roomTracks = GetRoomTrackOffsets();
            List<int> bossTracks = GetBossTrackOffsets();
            List<int> otherTracks = GetOtherTrackOffsets();

            // rooms
            if (settings.MusicRooms == Swap.LocalPool)
                RandomizeTracks(roomTracks);
            else if (settings.MusicRooms == Swap.GlobalPool)
                allTracks.AddRange(roomTracks);

            // bosses
            if (settings.MusicBosses == Swap.LocalPool)
                RandomizeTracks(bossTracks);
            else if (settings.MusicBosses == Swap.GlobalPool)
                allTracks.AddRange(bossTracks);

            // others
            if (settings.MusicOthers == Swap.LocalPool)
                RandomizeTracks(otherTracks);
            else if (settings.MusicOthers == Swap.GlobalPool)
                allTracks.AddRange(otherTracks);

            // all
            if (allTracks.Count > 0)
                RandomizeTracks(allTracks);

            // track of first room
            int off = rom.ReadPtr(Rom.AreaRoomEntryOffset);
            byte t = rom.Read8(off + 0x3A);

            // fix music for file select
            rom.Write8(0x042AE, rom.Read8(0x7C85C));
            // fix music for Brinstar
            rom.Write8(0x605F8, t);
            // fix music when Deorem killed
            rom.Write8(0x21E0A, t);
            rom.Write8(0x22072, t);

            return true;
        }

        private void RandomizeTracks(List<int> trackOffsets)
        {
            // get all unique music tracks
            var musicTracks = new HashSet<byte>();
            foreach (int offset in trackOffsets)
            {
                musicTracks.Add(rom.Read8(offset));
            }

            // shuffle list of music tracks
            var shuffled = new List<byte>(musicTracks);
            RandomAll.ShuffleList(rng, shuffled);

            // assign new values
            if (settings.MusicChange == Change.Shuffle)
            {
                // get track mapping
                var replacements = new Dictionary<byte, byte>();
                int i = 0;
                foreach (byte track in musicTracks)
                {
                    replacements[track] = shuffled[i++];
                }
                // write
                foreach (int offset in trackOffsets)
                {
                    byte origTrack = rom.Read8(offset);
                    byte newTrack = replacements[origTrack];
                    rom.Write8(offset, newTrack);
                }
            }
            else if (settings.MusicChange == Change.Random)
            {
                foreach (int offset in trackOffsets)
                {
                    byte newTrack = shuffled[rng.Next(shuffled.Count)];
                    rom.Write8(offset, newTrack);
                }
            }
        }

        private List<int> GetRoomTrackOffsets()
        {
            var trackOffsets = new List<int>();
            byte[] roomsPerArea = Rom.RoomsPerArea;
            for (int a = 0; a < roomsPerArea.Length; a++)
            {
                int offset = rom.ReadPtr(Rom.AreaRoomEntryOffset + a * 4);
                byte numRooms = roomsPerArea[a];
                for (int r = 0; r < numRooms; r++)
                {
                    trackOffsets.Add(offset + 0x3A);
                    offset += 0x3C;
                }
            }
            return trackOffsets;
        }

        private List<int> GetBossTrackOffsets()
        {
            return new List<int>
            {
                0x2149C,  // 3C Deorem
                0x3DE9C,  // 3C Acid worm
                0x62914,  // 34 Kraid
                0x25AE0,  // 4F Imago larva
                0x271BC,  // 3F Imago cocoon
                0x42370,  // 40 Imago
                0x65840,  // 35 Ridley
                0x3D108,  // 08 Zebes escape
                0x3A2B2,  // 43 Ruins test
                0x4C2D8,  // 41 Robot Ridley
                0x4CF56   // 08 Chozodia escape
            };
        }

        private List<int> GetOtherTrackOffsets()
        {
            return new List<int>
            {
                0x77218,  // 02 Title screen
                0x7C85C,  // 09 File select
                0x1433C   // 05 Chozo hint
            };
        }

        public override string GetLog()
        {
            return "Music: " +
                Enum.GetName(typeof(Change), settings.MusicChange) +
                Environment.NewLine;
        }

    }
}
