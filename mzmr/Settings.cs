using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace mzmr
{
    public enum GameCompletion { Unchanged, Beatable, AllItems }

    public class Settings
    {
        public bool RandomItems => randomAbilities || randomTanks || numItemsRemoved > 0;
        public bool RandomPalettes => tilesetPalettes || enemyPalettes || beamPalettes;

        // seed
        public int seed;

        // items
        public bool randomAbilities;
        public bool randomTanks;
        public int numItemsRemoved;
        public GameCompletion gameCompletion;
        public bool iceNotRequired;
        public bool plasmaNotRequired;
        public bool noPBsBeforeChozodia;
        public bool chozoStatueHints;
        public bool infiniteBombJump;
        public bool wallJumping;

        // locations
        public Dictionary<int, ItemType> customAssignments;

        // enemies
        public bool randomEnemies;

        // palettes
        public bool tilesetPalettes;
        public bool enemyPalettes;
        public bool beamPalettes;
        public int hueMinimum;
        public int hueMaximum;

        // tweaks
        public bool enableItemToggle;
        public bool obtainUnkItems;
        public bool hardModeAvailable;
        public bool pauseScreenInfo;
        public bool removeCutscenes;
        public bool skipSuitless;
        public bool skipDoorTransitions;

        // constructor
        public Settings(string config = null)
        {
            SetDefaults();

            if (string.IsNullOrEmpty(config)) { return; }

            BinaryTextReader btr;
            try
            {
                btr = new BinaryTextReader(config);
            }
            catch (FormatException)
            {
                throw new FormatException("Config string is not valid.");
            }

            // check version
            int major = btr.ReadNumber(4);
            int minor = btr.ReadNumber(4);
            int patch = btr.ReadNumber(4);
            string configVer = $"{major}.{minor}.{patch}";
            if (configVer != Program.Version)
            {
                // convert settings
                switch (configVer)
                {
                    default:
                        throw new FormatException("Config string is not valid.");
                }
            }
            else
            {
                LoadSettings(btr);
            }
        }

        private void LoadSettings(BinaryTextReader btr)
        {
            // seed
            if (btr.ReadBool())
            {
                seed = btr.ReadNumber(32);
            }

            // items
            randomAbilities = btr.ReadBool();
            randomTanks = btr.ReadBool();
            if (btr.ReadBool())
            {
                numItemsRemoved = btr.ReadNumber(7);
            }
            if (RandomItems)
            {
                gameCompletion = (GameCompletion)btr.ReadNumber(2);
                iceNotRequired = btr.ReadBool();
                plasmaNotRequired = btr.ReadBool();
                noPBsBeforeChozodia = btr.ReadBool();
                chozoStatueHints = btr.ReadBool();
                infiniteBombJump = btr.ReadBool();
                wallJumping = btr.ReadBool();
            }

            // locations
            if (btr.ReadBool())
            {
                int count = btr.ReadNumber(7);
                for (int i = 0; i < count; i++)
                {
                    int locNum = btr.ReadNumber(7);
                    ItemType item = (ItemType)btr.ReadNumber(5);
                    customAssignments[locNum] = item;
                }
            }

            // enemies
            randomEnemies = btr.ReadBool();

            // palettes
            tilesetPalettes = btr.ReadBool();
            enemyPalettes = btr.ReadBool();
            beamPalettes = btr.ReadBool();
            if (RandomPalettes)
            {
                if (btr.ReadBool())
                {
                    hueMinimum = btr.ReadNumber(8);
                }
                if (btr.ReadBool())
                {
                    hueMaximum = btr.ReadNumber(8);
                }
            }

            // misc
            enableItemToggle = btr.ReadBool();
            obtainUnkItems = btr.ReadBool();
            hardModeAvailable = btr.ReadBool();
            pauseScreenInfo = btr.ReadBool();
            removeCutscenes = btr.ReadBool();
            skipSuitless = btr.ReadBool();
            skipDoorTransitions = btr.ReadBool();
        }

        private void SetDefaults()
        {
            // seed
            seed = -1;

            // items
            randomAbilities = false;
            randomTanks = false;
            numItemsRemoved = 0;
            gameCompletion = GameCompletion.Beatable;
            iceNotRequired = false;
            plasmaNotRequired = false;
            noPBsBeforeChozodia = false;
            chozoStatueHints = false;
            infiniteBombJump = true;
            wallJumping = true;

            // locations
            customAssignments = new Dictionary<int, ItemType>();

            // enemies
            randomEnemies = false;

            // palettes
            tilesetPalettes = false;
            enemyPalettes = false;
            beamPalettes = false;
            hueMinimum = 0;
            hueMaximum = 180;

            // misc
            enableItemToggle = true;
            obtainUnkItems = false;
            hardModeAvailable = true;
            pauseScreenInfo = false;
            removeCutscenes = true;
            skipSuitless = false;
            skipDoorTransitions = false;
        }

        public string GetString()
        {
            byte[] temp = GetBytes();
            return Encoding.ASCII.GetString(temp);
        }

        public byte[] GetBytes()
        {
            BinaryTextWriter btw = new BinaryTextWriter();

            // version
            string[] nums = Program.Version.Split('.');
            btw.AddNumber(int.Parse(nums[0]), 4);
            btw.AddNumber(int.Parse(nums[1]), 4);
            btw.AddNumber(int.Parse(nums[2]), 4);

            // seed
            if (seed == -1)
            {
                btw.AddBool(false);
            }
            else
            {
                btw.AddBool(true);
                btw.AddNumber(seed, 32);
            }

            // items
            btw.AddBool(randomAbilities);
            btw.AddBool(randomTanks);
            if (numItemsRemoved == 0)
            {
                btw.AddBool(false);
            }
            else
            {
                btw.AddBool(true);
                btw.AddNumber(numItemsRemoved, 7);
            }
            if (randomAbilities || randomTanks)
            {
                btw.AddNumber((int)gameCompletion, 2);
                btw.AddBool(iceNotRequired);
                btw.AddBool(plasmaNotRequired);
                btw.AddBool(noPBsBeforeChozodia);
                btw.AddBool(chozoStatueHints);
                btw.AddBool(infiniteBombJump);
                btw.AddBool(wallJumping);
            }

            // locations
            if (customAssignments.Count == 0)
            {
                btw.AddBool(false);
            }
            else
            {
                btw.AddBool(true);
                btw.AddNumber(customAssignments.Count, 7);
                for (int i = 0; i < 100; i++)
                {
                    if (customAssignments.TryGetValue(i, out ItemType item))
                    {
                        btw.AddNumber(i, 7);
                        btw.AddNumber((int)item, 5);
                    }
                }
            }

            // enemies
            btw.AddBool(randomEnemies);

            // palettes
            btw.AddBool(tilesetPalettes);
            btw.AddBool(enemyPalettes);
            btw.AddBool(beamPalettes);
            if (tilesetPalettes || enemyPalettes || beamPalettes)
            {
                if (hueMinimum == 0)
                {
                    btw.AddBool(false);
                }
                else
                {
                    btw.AddBool(true);
                    btw.AddNumber(hueMinimum, 8);
                }
                if (hueMaximum == 180)
                {
                    btw.AddBool(false);
                }
                else
                {
                    btw.AddBool(true);
                    btw.AddNumber(hueMaximum, 8);
                }
            }

            // misc
            btw.AddBool(enableItemToggle);
            btw.AddBool(obtainUnkItems);
            btw.AddBool(hardModeAvailable);
            btw.AddBool(pauseScreenInfo);
            btw.AddBool(removeCutscenes);
            btw.AddBool(skipSuitless);
            btw.AddBool(skipDoorTransitions);

            return btw.GetOutputString();
        }


    }
}
