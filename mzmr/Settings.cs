using mzmr.Items;
using mzmr.Utility;
using System;
using System.Collections.Generic;

namespace mzmr
{
    public enum SwapItems { Unchanged, Together, Separate, Abilities, Tanks }
    public enum GameCompletion { NoLogic, Beatable, AllItems }

    public class Settings
    {
        public bool RandomItems
        {
            get { return swapItems > SwapItems.Unchanged || numItemsRemoved > 0; }
        }
        public bool RandomPalettes
        {
            get { return tilesetPalettes || enemyPalettes || beamPalettes; }
        }

        // items
        public SwapItems swapItems;
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
            // convert settings
            switch (configVer)
            {
                case Program.Version:
                    LoadSettings(btr);
                    break;
                case "1.3.0":
                case "1.3.1":
                case "1.3.2":
                    LoadSettings_1_3_2(btr);
                    break;
                default:
                    throw new FormatException("Config string is not valid.");
            }
        }

        private void LoadSettings(BinaryTextReader btr)
        {
            // items
            swapItems = (SwapItems)btr.ReadNumber(3);
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

        private void LoadSettings_1_3_2(BinaryTextReader btr)
        {
            // items
            bool randAbilities = btr.ReadBool();
            bool randTanks = btr.ReadBool();
            if (randAbilities && randTanks) swapItems = SwapItems.Together;
            else if (randAbilities) swapItems = SwapItems.Abilities;
            else if (randTanks) swapItems = SwapItems.Tanks;
            else swapItems = SwapItems.Unchanged;
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
            // items
            swapItems = SwapItems.Unchanged;
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
            BinaryTextWriter btw = new BinaryTextWriter();

            // version
            string[] nums = Program.Version.Split('.');
            btw.AddNumber(int.Parse(nums[0]), 4);
            btw.AddNumber(int.Parse(nums[1]), 4);
            btw.AddNumber(int.Parse(nums[2]), 4);

            // items
            btw.AddNumber((int)swapItems, 3);
            if (numItemsRemoved == 0)
            {
                btw.AddBool(false);
            }
            else
            {
                btw.AddBool(true);
                btw.AddNumber(numItemsRemoved, 7);
            }
            if (swapItems > SwapItems.Unchanged)
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
