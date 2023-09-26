using mzmr.Data;
using System;
using System.Collections.Generic;
using System.Threading;

namespace mzmr.Randomizers
{
    public class RandomPalettes : RandomAspect
    {
        public RandomPalettes(Rom rom, Settings settings, Random rng) : base(rom, settings, rng)
        {

        }

        public override RandomizeResult Randomize(CancellationToken cancellationToken)
        {
            if (settings.TilesetPalettes)
                RandomizeTilesets();
            if (settings.EnemyPalettes)
                RandomizeSprites();
            if (settings.SamusPalettes)
                RandomizeSamus();
            if (settings.BeamPalettes)
                RandomizeBeams();

            FixPalettes();
            return new RandomizeResult(true);
        }

        private int GetHueShift()
        {
            int shift = rng.Next(settings.HueMinimum, settings.HueMaximum + 1);
            if (rng.NextDouble() >= 0.5) shift = 360 - shift;
            return shift;
        }

        private void RandomizeTilesets()
        {
            var randomizedPals = new HashSet<int>();
            int tsOffset = rom.TilesetOffset;
            int tsCount = Rom.NumOfTilesets;

            for (int i = 0; i < tsCount; i++)
            {
                int palPtr = tsOffset + 4;
                int palOffset = rom.ReadPtr(palPtr);
                tsOffset += 0x14;
                if (randomizedPals.Contains(palOffset)) { continue; }

                // shift hue by a random amount
                randomizedPals.Add(palOffset);
                Palette pal = new Palette(rom, palOffset, 13);
                int shift = GetHueShift();
                pal.ShiftHue(shift);
                pal.Write();
            }

            // animated tilesets
            int animPalOffset = Rom.AnimPaletteOffset;
            int animPalCount = Rom.NumOfAnimPalettes;
            for (int i = 0; i < animPalCount; i++)
            {
                byte rows = rom.Read8(animPalOffset + 2);
                int palPtr = animPalOffset + 4;
                int palOffset = rom.ReadPtr(palPtr);                
                animPalOffset += 8;
                if (randomizedPals.Contains(palOffset)) { continue; }

                // shift hue by a random amount
                randomizedPals.Add(palOffset);
                Palette pal = new Palette(rom, palOffset, rows);
                int shift = GetHueShift();
                pal.ShiftHue(shift);
                pal.Write();
            }
        }

        private void RandomizeSprites()
        {
            var excluded = new HashSet<byte>() { 0x10, 0x11, 0x8A };
            var randomizedPals = new HashSet<int>();
            int gfxPtr = Rom.SpriteGfxOffset;
            int palPtr = Rom.SpritePaletteOffset;
            int spCount = 0xCE;

            for (byte i = 0x10; i < spCount; i++)
            {
                int gfxOffset = rom.ReadPtr(gfxPtr);
                int palOffset = rom.ReadPtr(palPtr);

                if (!excluded.Contains(i) && !randomizedPals.Contains(palOffset))
                {
                    // shift hue by a random amount
                    randomizedPals.Add(palOffset);
                    int rows = (rom.Read32(gfxOffset) >> 8) / 0x800;
                    Palette pal = new Palette(rom, palOffset, rows);
                    int shift = GetHueShift();
                    pal.ShiftHue(shift);
                    pal.Write();
                }

                gfxPtr += 4;
                palPtr += 4;
            }
        }

        private void RandomizeSamus()
        {
            int shift = GetHueShift();

            // samus palettes
            Palette pal = new Palette(rom, 0x2376A8, 163);
            pal.ShiftHue(shift);
            pal.Write();

            // file screen cursor
            pal = new Palette(rom, 0x454938, 1);
            pal.ShiftHue(shift);
            pal.Write();
            pal = new Palette(rom, 0x4549B8, 1);
            pal.ShiftHue(shift);
            pal.Write();
        }

        private void RandomizeBeams()
        {
            Palette pal = new Palette(rom, 0x3270E8, 5);
            int shift = GetHueShift();
            pal.ShiftHue(shift);
            pal.Write();
        }

        private int GetSpriteOffset(byte spriteID)
        {
            int offset = Rom.SpritePaletteOffset + (spriteID - 0x10) * 4;
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
            rom.CopyBytes(spOffset, tsOffset + 0x100, 0x20);

            if (settings.TilesetPalettes)
            {
                // fix kraid elevator statue palette
                spOffset = GetSpriteOffset(0x95);
                tsOffset = GetTilesetOffset(0x35);
                rom.CopyBytes(tsOffset + 0x20, spOffset, 0x20);

                // fix ridley elevator statue palette
                tsOffset = GetTilesetOffset(7);
                rom.CopyBytes(tsOffset + 0x20, spOffset + 0x20, 0x20);

                // fix tourian statues
                spOffset = GetSpriteOffset(0xA3);
                tsOffset = GetTilesetOffset(0x41);
                rom.CopyBytes(tsOffset + 0x60, spOffset, 0x20);

                // fix tourian statues (cutscene)
                tsOffset = GetTilesetOffset(0x41);
                rom.CopyBytes(tsOffset, 0x3ED53C, 0xC0);
            }
        }

        public override string GetLog()
        {
            var changed = new List<string>();
            if (settings.TilesetPalettes)
                changed.Add("Tilesets");
            if (settings.EnemyPalettes)
                changed.Add("Enemies");
            if (settings.SamusPalettes)
                changed.Add("Samus");
            if (settings.BeamPalettes)
                changed.Add("Beams");

            if (changed.Count == 0)
                return "Palettes: Unchanged" + Environment.NewLine;
            return "Palettes: " + string.Join(", ", changed) + Environment.NewLine;
        }

    }
}
