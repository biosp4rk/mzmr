using System;
using System.Collections.Generic;
using System.Text;

namespace mzmr
{
    public class RandomPalettes : RandomAspect
    {
        public RandomPalettes(ROM rom, Settings settings, Random rng) : base(rom, settings, rng)
        {

        }

        public override bool Randomize()
        {
            if (settings.tilesetPalettes)
            {
                RandomizeTilesets();
            }
            if (settings.enemyPalettes)
            {
                RandomizeSprites();
            }
            if (settings.beamPalettes)
            {
                RandomizeBeams();
            }
            FixPalettes();
            return true;
        }

        private int GetHueShift()
        {
            int shift = rng.Next(settings.hueMinimum, settings.hueMaximum + 1);
            if (rng.NextDouble() >= 0.5) { shift += 180; }
            return shift;
        }

        private void RandomizeTilesets()
        {
            Dictionary<int, object> randomizedPals = new Dictionary<int, object>();
            int tsOffset = rom.TilesetOffset;
            int tsCount = ROM.NumOfTilesets;

            for (int i = 0; i < tsCount; i++)
            {
                int palOffset = rom.ReadPtr(tsOffset + 4);
                tsOffset += 0x14;
                if (randomizedPals.ContainsKey(palOffset)) { continue; }

                // shift hue by a random amount
                randomizedPals.Add(palOffset, null);
                Palette pal = new Palette(rom, palOffset + 0x20, 13);
                int shift = GetHueShift();
                pal.ShiftHue(shift);
                pal.Write();
            }

            // animated tilesets
            int animPalOffset = ROM.AnimPaletteOffset;
            int animPalCount = ROM.NumOfAnimPalettes;
            for (int i = 0; i < animPalCount; i++)
            {
                byte rows = rom.Read8(animPalOffset + 2);
                int palOffset = rom.ReadPtr(animPalOffset + 4);                
                animPalOffset += 8;
                if (randomizedPals.ContainsKey(palOffset)) { continue; }

                // shift hue by a random amount
                randomizedPals.Add(palOffset, null);
                Palette pal = new Palette(rom, palOffset, rows);
                int shift = GetHueShift();
                pal.ShiftHue(shift);
                pal.Write();
            }
        }

        private void RandomizeSprites()
        {
            byte[] excluded = new byte[] { 0x10, 0x11, 0x8A };
            Dictionary<int, object> randomizedPals = new Dictionary<int, object>();
            int gfxPtr = ROM.SpriteGfxOffset;
            int palPtr = ROM.SpritePaletteOffset;
            int spCount = 0xCE;

            for (byte i = 0x10; i < spCount; i++)
            {
                int gfxOffset = rom.ReadPtr(gfxPtr);
                int palOffset = rom.ReadPtr(palPtr);
                gfxPtr += 4;
                palPtr += 4;
                if (Array.IndexOf(excluded, i) >= 0) { continue; }
                if (randomizedPals.ContainsKey(palOffset)) { continue; }

                // shift hue by a random amount
                randomizedPals.Add(palOffset, null);
                int rows = (rom.Read32(gfxOffset) >> 8) / 0x800;
                Palette pal = new Palette(rom, palOffset, rows);
                int shift = GetHueShift();
                pal.ShiftHue(shift);
                pal.Write();
            }
        }

        private void RandomizeBeams()
        {
            int offset = 0x3270E8;
            for (int i = 0; i < 5; i++)
            {
                Palette pal = new Palette(rom, offset, 1);
                int shift = GetHueShift();
                pal.ShiftHue(shift);
                pal.Write();
                offset += 0x20;
            }
        }

        private int GetSpriteOffset(byte spriteID)
        {
            int offset = ROM.SpritePaletteOffset + (spriteID - 0x10) * 4;
            return rom.ReadPtr(offset);
        }

        private int GetTilesetOffset(byte tilesetID)
        {
            int offset = rom.TilesetOffset + tilesetID * 0x14 + 4;
            return rom.ReadPtr(offset);
        }

        private void FixPalettes()
        {
            // fix kraid's body
            int spOffset = GetSpriteOffset(0x6F);
            int tsOffset = GetTilesetOffset(9);
            rom.Copy(spOffset, tsOffset + 0x100, 0x20);

            if (settings.tilesetPalettes)
            {
                // fix kraid elevator statue palette
                spOffset = GetSpriteOffset(0x95);
                tsOffset = GetTilesetOffset(0x35);
                rom.Copy(tsOffset + 0x20, spOffset, 0x20);

                // fix ridley elevator statue palette
                tsOffset = GetTilesetOffset(7);
                rom.Copy(tsOffset + 0x20, spOffset + 0x20, 0x20);

                // fix tourian statues
                spOffset = GetSpriteOffset(0xA3);
                tsOffset = GetTilesetOffset(0x41);
                rom.Copy(tsOffset + 0x60, spOffset, 0x20);

                tsOffset = GetTilesetOffset(0x41);
                int cutsceneOffset = 0x3ED53C;
                rom.Copy(tsOffset, cutsceneOffset, 0xC0);
            }
        }

        public override void GetLog(StringBuilder sb)
        {
            if (!settings.tilesetPalettes && !settings.enemyPalettes && !settings.beamPalettes)
            {
                sb.AppendLine("Palettes: Unchanged");
                return;
            }

            string line = "Palettes: ";
            if (settings.tilesetPalettes)
            {
                line += "Tilesets, ";
            }
            if (settings.enemyPalettes)
            {
                line += "Enemies, ";
            }
            if (settings.beamPalettes)
            {
                line += "Beams, ";
            }

            sb.AppendLine(line.Remove(line.Length - 2));
        }


    }
}
