using mzmr.Data;
using mzmr.Items;
using mzmr.Properties;
using mzmr.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace mzmr.Randomizers
{
    public class RandomAll
    {
        private readonly Rom rom;
        private readonly Settings settings;
        private readonly int seed;

        private RandomItems randItems;
        private RandomEnemies randEnemies;
        private RandomPalettes randPals;
        private RandomMusic randMusic;
        private RandomText randText;
        private RandomStats randStats;

        public RandomAll(Rom rom, Settings settings, int seed)
        {
            this.rom = rom;
            this.settings = settings;
            this.seed = seed;
        }

        public bool Randomize()
        {
            // allow palettes to be randomized separately
            Random rng = new Random(seed);

            // randomize palette
            randPals = new RandomPalettes(rom, settings, rng);
            randPals.Randomize();

            rng = new Random(seed);

            // randomize items
            randItems = new RandomItems(rom, settings, rng);
            bool success = randItems.Randomize();
            if (!success) { return false; }

            // randomize enemies
            randEnemies = new RandomEnemies(rom, settings, rng);
            randEnemies.Randomize();

            // randomize music
            randMusic = new RandomMusic(rom, settings, rng);
            randMusic.Randomize();

            //randomize text
            randText = new RandomText(rom, settings, rng);
            randText.Randomize();

            //randomize enemy stats
            randStats = new RandomStats(rom, settings, rng);
            randStats.Randomize();

            ApplyTweaks();
            DrawFileSelectHash();
            if (!settings.CutsceneText)
                 WriteVersion();
            Patch.Apply(rom, Resources.ZM_U_titleGraphics);

            return true;
        }

        private void ApplyTweaks()
        {
            if (settings.IceNotRequired)
                Patch.Apply(rom, Resources.ZM_U_metroidIce);
            if (settings.PlasmaNotRequired)
                Patch.Apply(rom, Resources.ZM_U_blackPiratePlasma);
            if (settings.EnableItemToggle)
                Patch.Apply(rom, Resources.ZM_U_itemToggle);
            if (settings.ObtainUnkItems)
                Patch.Apply(rom, Resources.ZM_U_unkItems);
            if (settings.HardModeAvailable)
                Patch.Apply(rom, Resources.ZM_U_hardModeAvailable);
            if (settings.PauseScreenInfo)
                Patch.Apply(rom, Resources.ZM_U_pauseScreenInfo);
            if (settings.RemoveCutscenes)
                Patch.Apply(rom, Resources.ZM_U_removeCutscenes);
            if (settings.SkipSuitless)
                Patch.Apply(rom, Resources.ZM_U_skipSuitless);
            if (settings.SkipDoorTransitions)
                Patch.Apply(rom, Resources.ZM_U_skipDoorTransitions);
        }

        private void DrawFileSelectHash()
        {
            // apply tweak for hash icons
            Patch.Apply(rom, Resources.ZM_U_hashIcons);

            // compute the hash based on settings and seed
            string s = settings.GetString() + seed;
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            int hash = 5381;
            foreach (byte b in bytes)
                hash = (hash << 5) + hash + b;

            const int palPtr = 0x7C7CC;
            const int gfxPtr = 0x7C7E0;
            const int tmPtr = 0x7C80C;

            // get palette, graphics, and tile table
            int palOffset = rom.ReadPtr(palPtr);
            Palette filePal = new Palette(rom, palOffset, 7, palPtr);
            Gfx fileGfx = new Gfx(rom, gfxPtr, 32);
            Tilemap fileTm = new Tilemap(rom, tmPtr, true);

            for (int i = 0; i < 4; i++)
            {
                int index = hash & 15;
                hash >>= 4;
                ItemType item = (index + ItemType.Super);

                // modify palette
                filePal.AppendPalette(item.AbilityPalette());

                // modify graphics
                Gfx itemGfx = item.AbilityGraphics();
                Rectangle rect = new Rectangle(0, 0, 2, 2);
                fileGfx.AddGfx(itemGfx, rect, i * 3, 17);

                // modify tile table
                int x = 9 + i * 3;
                int pal = i + 7;
                fileTm.SetPalette(pal, x, 1);
                fileTm.SetPalette(pal, x, 2);
                fileTm.SetPalette(pal, x + 1, 1);
                fileTm.SetPalette(pal, x + 1, 2);
                fileTm.SetTileNumber(0, x + 2, 1);
                fileTm.SetTileNumber(0, x + 2, 2);
            }

            // write palette, graphics, and tile table
            filePal.Write();
            fileGfx.Write();
            fileTm.Write();
        }

        private void WriteVersion()
        {
            // add underscore character
            Patch.Apply(rom, Resources.ZM_U_underscore);

            // format config string
            string temp = "Settings: " + settings.GetString();
            int lineWidth = 0;
            string config = "";
            foreach (char c in temp)
            {
                int charWidth = Text.GetCharWidth(rom, c);
                if (lineWidth + charWidth < 220)
                    lineWidth += charWidth;
                else
                {
                    config += '\n';
                    lineWidth = charWidth;
                }
                config += c;
            }

            // MZM Randomizer v1.4.0
            // Seed: <seed>
            // Settings: <settings>
            string text = $"MZM Randomizer v{Program.Version}\n" +
                $"Seed: {seed}\n{config}\n";
            byte[] values = Text.BytesFromText(text);
            rom.ArrayToRom(values, 0, Rom.IntroTextOffset, values.Length);
        }

        public string GetLog()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Seed: {seed}");
            sb.AppendLine($"Settings: {settings.GetString()}");
            sb.AppendLine();

            sb.AppendLine(randItems.GetLog());
            sb.AppendLine(randEnemies.GetLog());
            sb.AppendLine(randPals.GetLog());
            sb.AppendLine(randMusic.GetLog());
            sb.AppendLine(randText.GetLog());
            sb.AppendLine(randStats.GetLog());

            return sb.ToString();
        }

        public Bitmap[] GetMaps()
        {
            return randItems.GetMaps();
        }

        public static void ShuffleList<T>(Random rng, List<T> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                T temp = list[j];
                list[j] = list[i];
                list[i] = temp;
            }
        }

    }
}
