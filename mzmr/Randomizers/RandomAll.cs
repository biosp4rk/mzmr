using mzmr.Data;
using mzmr.Items;
using mzmr.Properties;
using mzmr.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

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
        private RandomBosses randBosses;

        public RandomAll(Rom rom, Settings settings, int seed)
        {
            this.rom = rom;
            this.settings = settings;
            this.seed = seed;
        }

        public RandomizeResult Randomize(CancellationToken cancellationToken)
        {
            Random rng = new Random(seed);
            rom.NumofAnimGfx = 0x26;
            rom.NumofAnimPal = 0x12;
            rom.NumofTilesets = 0x4F; //defaults

            int endOfData = 0x7D8000;
            switch (settings.SelectedGame) //apply hackes with rando base changes
            {
                case Game.DeepFreeze:
                    rom.ExpandROM();
                    Patch.Apply(rom, Resources.ZM_U_deepFreezeBase);
                    endOfData = 0x800000; break;
                case Game.Spooky:
                    rom.ExpandROM();
                    Patch.Apply(rom, Resources.ZM_U_spookyBase);
                    endOfData = 0x813AB0; break;
                case Game.Spooky2:
                    rom.NumofAnimGfx = 0x2A;
                    rom.NumofAnimPal = 0x13;
                    Patch.ApplyUPS(rom, Resources.ZM_U_spooky2Base);
                    endOfData = 0x11A5C00; break;
                case Game.ScrollsVI:
                    rom.ExpandROM();
                    Patch.Apply(rom, Resources.ZM_U_scrollsbase);
                    rom.NumofTilesets = 0x54;
                    endOfData = 0x8AC300; break;
                case Game.SR387:
                    rom.ExpandROM();
                    Patch.Apply(rom, Resources.ZM_U_SR387Base);
                    rom.NumofAnimGfx = 0x33;
                    endOfData = 0x836000; break;
                case Game.WinterMission:
                    rom.ExpandROM();
                    Patch.Apply(rom, Resources.ZM_U_winterBase);
                    endOfData = 0x811B00; break;
                default:
                    if (settings.RandoBosses || settings.CustomMusic) //expand rom if play vanilla with new bosses and/or music
                        rom.ExpandROM();
                    break;
            }
            rom.FindEndOfData(endOfData);

            //randomize bosses (must be run first to have palettes randomize, and patch must be applied before rando base)
            randBosses = new RandomBosses(rom, settings, rng);
            randBosses.Randomize(cancellationToken);

            // randomize palette
            randPals = new RandomPalettes(rom, settings, rng);
            randPals.Randomize(cancellationToken);

            // randomize items
            randItems = new RandomItems(rom, settings, rng);
            var result = randItems.Randomize(cancellationToken);
            if (!result.Success)
                return result;

            // randomize music
            randMusic = new RandomMusic(rom, settings, rng);
            randMusic.Randomize(cancellationToken);

            // randomize enemies
            randEnemies = new RandomEnemies(rom, settings, rng);
            randEnemies.Randomize(cancellationToken);

            //randomize enemy stats
            randStats = new RandomStats(rom, settings, rng);
            randStats.Randomize(cancellationToken);

            //randomize text
            randText = new RandomText(rom, settings, rng);
            randText.Randomize(cancellationToken);

            ApplyTweaks();
            DrawFileSelectHash();
            if (settings.SelectedGame == Game.Original)
            {
                WriteVersion();
                Patch.Apply(rom, Resources.ZM_U_titleGraphics);
            }
            Credits credits = new Credits(rom, settings, seed);
            credits.WriteCredits(randItems);

            result.Success = true;
            return result;
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
            {
                Patch.Apply(rom, Resources.ZM_U_removeCutscenes);
                if (settings.SkipSuitless)
                {
                    // set room
                    rom.Write8(0x3763AC, 0x28);
                    // set door
                    rom.Write8(0x3763B2, 0x56);
                    // set music
                    rom.Write8(0x3763D4, 3);
                }
            }
            else if (settings.SkipSuitless)
                Patch.Apply(rom, Resources.ZM_U_skipSuitless);
            if (settings.SkipDoorTransitions)
                Patch.Apply(rom, Resources.ZM_U_skipDoorTransitions);
            if (settings.DisableInfiniteBombJump)
                Patch.Apply(rom, Resources.ZM_U_disableMidAirBombJump);
            if (settings.DisableWallJump) 
                Patch.Apply(rom, Resources.ZM_U_disableWallJump);
            if (settings.PBJumping)
                Patch.Apply(rom, Resources.ZM_U_powerBombJump);
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
            string text = $"MZM Randomizer Plus v{Program.Version}\n" +
                $"Seed: {seed}\n{config}\n";
            byte[] values = Text.BytesFromText(text);
            rom.WriteBytes(values, 0, Rom.IntroTextOffset, values.Length);
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
            sb.AppendLine(randBosses.GetLog());
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
