using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mzmr
{
    public class RandomMusic : RandomAspect
    {
        public RandomMusic(ROM rom, Settings settings, Random rng) : base(rom, settings, rng)
        {

        }

        public override bool Randomize()
        {
            // get all unique music tracks
            byte[] roomsPerArea = ROM.RoomsPerArea;
            HashSet<ushort> musicTracks = new HashSet<ushort>();
            for (int a = 0; a < roomsPerArea.Length; a++)
            {
                int offset = rom.ReadPtr(ROM.AreaRoomEntryOffset + a * 4);
                byte numRooms = roomsPerArea[a];
                for (int r = 0; r < numRooms; r++)
                {
                    ushort musicTrack = rom.Read16(offset + 0x3A);
                    musicTracks.Add(musicTrack);
                    offset += 0x3C;
                }
            }

            // assign replacements randomly
            ushort[] trackList = musicTracks.ToArray();
            Dictionary<ushort, ushort> replacements = new Dictionary<ushort, ushort>();
            foreach (ushort musicTrack in trackList)
            {
                int index = rng.Next(trackList.Length);
                ushort newTrack = trackList[index];
                replacements[musicTrack] = newTrack;
            }

            // write replacements
            for (int a = 0; a < roomsPerArea.Length; a++)
            {
                int offset = rom.ReadPtr(ROM.AreaRoomEntryOffset + a * 4);
                byte numRooms = roomsPerArea[a];
                for (int r = 0; r < numRooms; r++)
                {
                    ushort musicTrack = rom.Read16(offset + 0x3A);
                    musicTrack = replacements[musicTrack];
                    rom.Write16(offset + 0x3A, musicTrack);
                    offset += 0x3C;
                }
            }

            // set music for start of game
            int startOffset = rom.ReadPtr(ROM.AreaRoomEntryOffset);
            ushort startTrack = rom.Read16(startOffset + 0x3A);
            rom.Write8(0x605F8, (byte)startTrack);

            return true;
        }

        public override string GetLog()
        {
            return "Music: Unchanged" + Environment.NewLine;
        }


    }
}
