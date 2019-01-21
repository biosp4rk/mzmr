using System;
using System.Collections.Generic;
using System.Text;

namespace mzmr
{
    public enum GameCompletion { Unchanged, Beatable, AllItems }

    public class Settings
    {
        private const int version = 130;  // 1.3.0

        // items
        public bool randomAbilities;
        public bool randomTanks;
        public int removeItems;
        public GameCompletion gameCompletion;
        public bool iceNotRequired;
        public bool plasmaNotRequired;
        public bool noPBsBeforeChozodia;
        public bool chozoStatueHints;
        public bool infiniteBombJump;
        public bool wallJumping;

        public Dictionary<int, ItemType> customAssignments;

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
        public bool removeNorfairVine;
        public bool removeVariaAnimation;
        public bool skipSuitless;

        // constructor
        public Settings(string str = null)
        {
            if (string.IsNullOrEmpty(str))
            {
                SetDefaults();
                return;
            }

            BinaryTextReader btr;
            try
            {
                btr = new BinaryTextReader(str);
            }
            catch (FormatException)
            {
                throw new FormatException("Settings string is not valid.");
            }

            // check version
            int configVer = btr.ReadNumber(10);
            if (configVer != version)
            {
                // convert settings
                SetDefaults();
                switch (configVer)
                {
                    case 100:
                        LoadSettings100(btr);
                        break;
                    case 110:
                        LoadSettings110(btr);
                        break;
                    case 120:
                    case 121:
                        LoadSettings120(btr);
                        break;
                    default:
                        throw new FormatException("Settings string is not valid.");
                }
            }
            else
            {
                LoadSettings(btr);
            }
        }

        private void LoadSettings(BinaryTextReader btr)
        {
            // items
            randomAbilities = btr.ReadBool();
            randomTanks = btr.ReadBool();
            removeItems = btr.ReadNumber(7);
            gameCompletion = (GameCompletion)btr.ReadNumber(2);
            iceNotRequired = btr.ReadBool();
            plasmaNotRequired = btr.ReadBool();
            noPBsBeforeChozodia = btr.ReadBool();
            chozoStatueHints = btr.ReadBool();
            infiniteBombJump = btr.ReadBool();
            wallJumping = btr.ReadBool();

            // palettes
            tilesetPalettes = btr.ReadBool();
            enemyPalettes = btr.ReadBool();
            beamPalettes = btr.ReadBool();
            hueMinimum = btr.ReadNumber(8);
            hueMaximum = btr.ReadNumber(8);

            // misc
            enableItemToggle = btr.ReadBool();
            obtainUnkItems = btr.ReadBool();
            hardModeAvailable = btr.ReadBool();
            pauseScreenInfo = btr.ReadBool();
            removeCutscenes = btr.ReadBool();
            removeNorfairVine = btr.ReadBool();
            removeVariaAnimation = btr.ReadBool();
            skipSuitless = btr.ReadBool();
        }

        private void LoadSettings120(BinaryTextReader btr)
        {
            // items
            randomAbilities = btr.ReadBool();
            randomTanks = btr.ReadBool();

            // excluded items
            for (int i = 0; i < 100; i++)
            {
                btr.ReadBool();
            }

            gameCompletion = (GameCompletion)btr.ReadNumber(2);
            iceNotRequired = btr.ReadBool();
            plasmaNotRequired = btr.ReadBool();
            noPBsBeforeChozodia = btr.ReadBool();
            chozoStatueHints = btr.ReadBool();
            infiniteBombJump = btr.ReadBool();
            wallJumping = btr.ReadBool();

            // palettes
            tilesetPalettes = btr.ReadBool();
            enemyPalettes = btr.ReadBool();
            beamPalettes = btr.ReadBool();
            hueMinimum = btr.ReadNumber(8);
            hueMaximum = btr.ReadNumber(8);

            // misc
            enableItemToggle = btr.ReadBool();
            obtainUnkItems = btr.ReadBool();
            hardModeAvailable = btr.ReadBool();
            pauseScreenInfo = btr.ReadBool();
            removeCutscenes = btr.ReadBool();
            removeNorfairVine = btr.ReadBool();
            removeVariaAnimation = btr.ReadBool();
            skipSuitless = btr.ReadBool();
        }

        private void LoadSettings110(BinaryTextReader btr)
        {
            // items
            randomAbilities = btr.ReadBool();
            randomTanks = btr.ReadBool();

            // excluded items
            for (int i = 0; i < 100; i++)
            {
                btr.ReadBool();
            }

            iceNotRequired = btr.ReadBool();
            plasmaNotRequired = btr.ReadBool();
            gameCompletion = (GameCompletion)btr.ReadNumber(2);
            noPBsBeforeChozodia = (btr.ReadNumber(2) == 2);

            // palettes
            tilesetPalettes = btr.ReadBool();
            enemyPalettes = btr.ReadBool();
            beamPalettes = btr.ReadBool();
            hueMinimum = btr.ReadNumber(8);
            hueMaximum = btr.ReadNumber(8);

            // misc
            enableItemToggle = btr.ReadBool();
            obtainUnkItems = btr.ReadBool();
            hardModeAvailable = btr.ReadBool();
            pauseScreenInfo = btr.ReadBool();
            removeCutscenes = btr.ReadBool();
            removeNorfairVine = btr.ReadBool();
            removeVariaAnimation = btr.ReadBool();
            skipSuitless = btr.ReadBool();
        }

        private void LoadSettings100(BinaryTextReader btr)
        {
            // items
            randomAbilities = btr.ReadBool();
            randomTanks = btr.ReadBool();

            // excluded items
            for (int i = 0; i < 100; i++)
            {
                btr.ReadBool();
            }

            iceNotRequired = btr.ReadBool();
            plasmaNotRequired = btr.ReadBool();
            gameCompletion = (GameCompletion)btr.ReadNumber(2);
            noPBsBeforeChozodia = (btr.ReadNumber(2) == 2);

            // palettes
            tilesetPalettes = btr.ReadBool();
            enemyPalettes = btr.ReadBool();
            beamPalettes = btr.ReadBool();
            hueMinimum = btr.ReadNumber(8);
            hueMaximum = btr.ReadNumber(8);

            // misc
            enableItemToggle = btr.ReadBool();
            obtainUnkItems = btr.ReadBool();
            hardModeAvailable = btr.ReadBool();
            pauseScreenInfo = btr.ReadBool();
            removeCutscenes = btr.ReadBool();
            removeNorfairVine = btr.ReadBool();
            removeVariaAnimation = btr.ReadBool();
        }

        private void SetDefaults()
        {
            // items
            randomAbilities = false;
            randomTanks = false;
            removeItems = 0;
            gameCompletion = GameCompletion.Beatable;
            iceNotRequired = false;
            plasmaNotRequired = false;
            noPBsBeforeChozodia = false;
            chozoStatueHints = false;
            infiniteBombJump = true;
            wallJumping = true;

            customAssignments = new Dictionary<int, ItemType>();

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
            removeCutscenes = false;
            removeNorfairVine = true;
            removeVariaAnimation = false;
            skipSuitless = false;
        }

        public bool CheckValid()
        {
            if (randomAbilities && !randomTanks)
            {
                if (removeItems > 12)
                {
                    return false;
                }
            }
            else if (randomTanks && !randomAbilities)
            {
                if (removeItems > 84)
                {
                    return false;
                }
            }
            return true;
        }

        private string VersionToString(int ver)
        {
            int major = ver / 100;
            int minor = (ver % 100) / 10;
            int revision = ver % 10;
            return major + "." + minor + "." + revision;
        }

        public string ConvertToString()
        {
            byte[] temp = ConvertToStringBytes();
            return Encoding.ASCII.GetString(temp);
        }

        public byte[] ConvertToStringBytes()
        {
            BinaryTextWriter btw = new BinaryTextWriter();

            // version
            btw.AddNumber(version, 10);

            // items
            btw.AddBool(randomAbilities);
            btw.AddBool(randomTanks);
            btw.AddNumber(removeItems, 7);
            btw.AddNumber((int)gameCompletion, 2);
            btw.AddBool(iceNotRequired);
            btw.AddBool(plasmaNotRequired);
            btw.AddBool(noPBsBeforeChozodia);
            btw.AddBool(chozoStatueHints);
            btw.AddBool(infiniteBombJump);
            btw.AddBool(wallJumping);

            // palettes
            btw.AddBool(tilesetPalettes);
            btw.AddBool(enemyPalettes);
            btw.AddBool(beamPalettes);
            btw.AddNumber(hueMinimum, 8);
            btw.AddNumber(hueMaximum, 8);

            // misc
            btw.AddBool(enableItemToggle);
            btw.AddBool(obtainUnkItems);
            btw.AddBool(hardModeAvailable);
            btw.AddBool(pauseScreenInfo);
            btw.AddBool(removeCutscenes);
            btw.AddBool(removeNorfairVine);
            btw.AddBool(removeVariaAnimation);
            btw.AddBool(skipSuitless);

            return btw.GetOutputString();
        }


    }
}
