using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace mzmr
{
    public enum GameCompletion { Unchanged, Beatable, AllItems }

    public class Settings
    {
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
        public Settings()
        {
            SetDefaults();
        }

        public static Settings LoadSettings(string config = null)
        {
            if (string.IsNullOrEmpty(config))
            {
                return new Settings();
            }

            try
            {
                return JsonConvert.DeserializeObject<Settings>(config);
            }
            catch (FormatException)
            {
                throw new FormatException("Settings string is not valid.");
            }
        }

        private void SetDefaults()
        {
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
            removeCutscenes = true;
            skipSuitless = false;
            skipDoorTransitions = false;
        }

        public string GetString(bool indent = false)
        {
            Formatting f = indent ? Formatting.Indented : Formatting.None;
            return JsonConvert.SerializeObject(this, f, new StringEnumConverter());
        }


    }
}
