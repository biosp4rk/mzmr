using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace mzmr.Randomizers
{
    public class RandomMusic : RandomAspect
    {
        public RandomMusic(Rom rom, Settings settings, Random rng) : base(rom, settings, rng)
        {

        }

        public override RandomizeResult Randomize(CancellationToken cancellationToken)
        {
            var trackOffsets = new List<int>();

            // get all room track offsets
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

            // get all boss track offsets
            trackOffsets.AddRange(GetBossTrackOffsets());

            // get all unique music tracks
            var musicTracks = new HashSet<byte>();
            foreach (int offset in trackOffsets)
            {
                musicTracks.Add(rom.Read8(offset));
            }

            // shuffle tracks
            var shuffled = new List<byte>(musicTracks);
            RandomAll.ShuffleList(rng, shuffled);
            var replacements = new Dictionary<byte, byte>();
            int i = 0;
            foreach (byte track in musicTracks)
            {
                replacements[track] = shuffled[i++];
            }

            // write replacements
            foreach (int offset in trackOffsets)
            {
                byte origTrack = rom.Read8(offset);
                byte newTrack = replacements[origTrack];
                rom.Write8(offset, newTrack);
            }
            
            // fix music for Brinstar
            int off = rom.ReadPtr(Rom.AreaRoomEntryOffset);
            byte t = rom.Read8(off + 0x3A);
            // start of game
            rom.Write8(0x605F8, t);
            // Deorem killed
            rom.Write8(0x21E0A, t);
            rom.Write8(0x22072, t);

            return new RandomizeResult(true);
        }

        private List<int> GetBossTrackOffsets()
        {
            return new List<int>
            {
                0x77218,  // 02 Title screen
                0x7C85C,  // 09 File select
                0x042AE,  // 09 File select (options)
                0x1433C,  // 05 Chozo hint
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

        public override string GetLog()
        {
            return "Music: Unchanged" + Environment.NewLine;
        }

    }
}
