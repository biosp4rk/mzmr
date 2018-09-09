using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace mzmr
{
    public class RandomAll
    {
        private ROM rom;
        private Settings settings;
        private int seed;

        private RandomItems randItems;
        private RandomEnemies randEnemies;
        private RandomPalettes randPals;

        public RandomAll(ROM rom, Settings settings, int seed)
        {
            this.rom = rom;
            this.settings = settings;
            this.seed = seed;
        }

        public bool Randomize()
        {
            Random rng = new Random(seed);

            // randomize palette
            randPals = new RandomPalettes(rom, settings, rng);
            randPals.Randomize();

            // randomize items
            randItems = new RandomItems(rom, settings, rng);
            bool result = randItems.Randomize();
            if (result == false) { return false; }

            // TODO: randomize enemies
            //randEnemies = new RandomEnemies(rom, settings, rng);
            //randEnemies.Randomize();

            ApplyTweaks();
            WriteVersion();

            return true;
        }

        private void ApplyTweaks()
        {
            if (settings.iceNotRequired)
            {
                Patch.Apply(rom, Properties.Resources.ZM_U_metroidIce);
            }
            if (settings.plasmaNotRequired)
            {
                Patch.Apply(rom, Properties.Resources.ZM_U_blackPiratePlasma);
            }
            if (settings.enableItemToggle)
            {
                Patch.Apply(rom, Properties.Resources.ZM_U_itemToggle);
            }
            if (settings.obtainUnkItems)
            {
                Patch.Apply(rom, Properties.Resources.ZM_U_unkItems);
            }
            if (settings.hardModeAvailable)
            {
                Patch.Apply(rom, Properties.Resources.ZM_U_hardModeAvailable);
            }
            if (settings.pauseScreenInfo)
            {
                Patch.Apply(rom, Properties.Resources.ZM_U_pauseScreenInfo);
            }
            if (settings.removeElevatorCutscenes)
            {
                Patch.Apply(rom, Properties.Resources.ZM_U_removeElevatorCutscenes);
            }
            if (settings.removeNorfairVine)
            {
                Patch.Apply(rom, Properties.Resources.ZM_U_removeNorfairVine);
            }
            if (settings.removeVariaAnimation)
            {
                Patch.Apply(rom, Properties.Resources.ZM_U_removeVariaAnim);
            }
            if (settings.skipSuitless)
            {
                Patch.Apply(rom, Properties.Resources.ZM_U_skipSuitless);
            }
        }

        private void WriteVersion()
        {
            // MZM Randomizer v1.2.0
            // Seed: <seed>
            // Settings:
            // <settings>
            string text = string.Format("MZM Randomizer v{0}\nSeed: {1}\nSettings:\n{2}\n\n",
                Program.Version, seed, settings.ConvertToString());
            ushort[] values = Text.BytesFromText(text);
            rom.ArrayToRom(values, 0, ROM.InfoOffset, values.Length * 2);
        }

        public string GetLog()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Seed: " + seed);
            sb.AppendLine("Settings: " + settings.ConvertToString());
            sb.AppendLine();

            // items
            randItems.GetLog(sb);
            sb.AppendLine();

            // TODO: enemies
            // randEnemies.GetLog(sb);
            sb.AppendLine();

            // palettes
            randPals.GetLog(sb);

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
