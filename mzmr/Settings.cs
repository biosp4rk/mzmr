using mzmr.Items;
using mzmr.Utility;
using System;
using System.Collections.Generic;

namespace mzmr
{
    public enum Change { Unchanged, LocalPool, GlobalPool }
    public enum SwapItems { Unchanged, Together, Separate, Abilities, Tanks }
    public enum GameCompletion { NoLogic, Beatable, AllItems }
    public enum ChangeMusic { Unchanged, Shuffle, Random }

    public class Settings
    {
        public bool SwapOrRemoveItems
        {
            get { return ItemSwap > SwapItems.Unchanged || NumItemsRemoved > 0; }
        }
        public int NumTanksRemoved
        {
            get { return NumItemsRemoved - NumAbilitiesRemoved.Value; }
        }
        public bool RemoveSpecificItems => NumAbilitiesRemoved != null;
        public bool RandomPalettes
        {
            get { return TilesetPalettes || EnemyPalettes || BeamPalettes; }
        }

        // items
        public SwapItems ItemSwap;
        public int NumItemsRemoved;
        public int? NumAbilitiesRemoved;
        public GameCompletion Completion;
        public bool IceNotRequired;
        public bool PlasmaNotRequired;
        public bool NoPBsBeforeChozodia;
        public bool ChozoStatueHints;
        public bool InfiniteBombJump;
        public bool WallJumping;

        // locations
        public Dictionary<int, ItemType> CustomAssignments;

        // enemies
        public bool RandoEnemies;

        // palettes
        public bool TilesetPalettes;
        public bool EnemyPalettes;
        public bool BeamPalettes;
        public int HueMinimum;
        public int HueMaximum;

        // music
        public ChangeMusic MusicChange = ChangeMusic.Shuffle;
        public Change MusicRooms = Change.GlobalPool;
        public Change MusicBosses = Change.GlobalPool;
        public Change MusicOthers = Change.GlobalPool;

        // tweaks
        public bool EnableItemToggle;
        public bool ObtainUnkItems;
        public bool HardModeAvailable;
        public bool PauseScreenInfo;
        public bool RemoveCutscenes;
        public bool SkipSuitless;
        public bool SkipDoorTransitions;

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
            ItemSwap = (SwapItems)btr.ReadNumber(3);
            if (btr.ReadBool())
            {
                NumItemsRemoved = btr.ReadNumber(7);
                if (btr.ReadBool())
                {
                    NumAbilitiesRemoved = btr.ReadNumber(4);
                }
            }
            if (SwapOrRemoveItems)
            {
                Completion = (GameCompletion)btr.ReadNumber(2);
                IceNotRequired = btr.ReadBool();
                PlasmaNotRequired = btr.ReadBool();
                NoPBsBeforeChozodia = btr.ReadBool();
                ChozoStatueHints = btr.ReadBool();
                InfiniteBombJump = btr.ReadBool();
                WallJumping = btr.ReadBool();
            }

            // locations
            if (btr.ReadBool())
            {
                int count = btr.ReadNumber(7);
                for (int i = 0; i < count; i++)
                {
                    int locNum = btr.ReadNumber(7);
                    ItemType item = (ItemType)btr.ReadNumber(5);
                    CustomAssignments[locNum] = item;
                }
            }

            // enemies
            RandoEnemies = btr.ReadBool();

            // palettes
            TilesetPalettes = btr.ReadBool();
            EnemyPalettes = btr.ReadBool();
            BeamPalettes = btr.ReadBool();
            if (RandomPalettes)
            {
                if (btr.ReadBool())
                {
                    HueMinimum = btr.ReadNumber(8);
                }
                if (btr.ReadBool())
                {
                    HueMaximum = btr.ReadNumber(8);
                }
            }

            // misc
            EnableItemToggle = btr.ReadBool();
            ObtainUnkItems = btr.ReadBool();
            HardModeAvailable = btr.ReadBool();
            PauseScreenInfo = btr.ReadBool();
            RemoveCutscenes = btr.ReadBool();
            SkipSuitless = btr.ReadBool();
            SkipDoorTransitions = btr.ReadBool();
        }

        private void LoadSettings_1_3_2(BinaryTextReader btr)
        {
            // items
            bool randAbilities = btr.ReadBool();
            bool randTanks = btr.ReadBool();
            if (randAbilities && randTanks) ItemSwap = SwapItems.Together;
            else if (randAbilities) ItemSwap = SwapItems.Abilities;
            else if (randTanks) ItemSwap = SwapItems.Tanks;
            else ItemSwap = SwapItems.Unchanged;
            if (btr.ReadBool())
            {
                NumItemsRemoved = btr.ReadNumber(7);
            }
            if (SwapOrRemoveItems)
            {
                Completion = (GameCompletion)btr.ReadNumber(2);
                IceNotRequired = btr.ReadBool();
                PlasmaNotRequired = btr.ReadBool();
                NoPBsBeforeChozodia = btr.ReadBool();
                ChozoStatueHints = btr.ReadBool();
                InfiniteBombJump = btr.ReadBool();
                WallJumping = btr.ReadBool();
            }

            // locations
            if (btr.ReadBool())
            {
                int count = btr.ReadNumber(7);
                for (int i = 0; i < count; i++)
                {
                    int locNum = btr.ReadNumber(7);
                    ItemType item = (ItemType)btr.ReadNumber(5);
                    CustomAssignments[locNum] = item;
                }
            }

            // enemies
            RandoEnemies = btr.ReadBool();

            // palettes
            TilesetPalettes = btr.ReadBool();
            EnemyPalettes = btr.ReadBool();
            BeamPalettes = btr.ReadBool();
            if (RandomPalettes)
            {
                if (btr.ReadBool())
                {
                    HueMinimum = btr.ReadNumber(8);
                }
                if (btr.ReadBool())
                {
                    HueMaximum = btr.ReadNumber(8);
                }
            }

            // misc
            EnableItemToggle = btr.ReadBool();
            ObtainUnkItems = btr.ReadBool();
            HardModeAvailable = btr.ReadBool();
            PauseScreenInfo = btr.ReadBool();
            RemoveCutscenes = btr.ReadBool();
            SkipSuitless = btr.ReadBool();
            SkipDoorTransitions = btr.ReadBool();
        }

        private void SetDefaults()
        {
            // items
            ItemSwap = SwapItems.Unchanged;
            NumItemsRemoved = 0;
            NumAbilitiesRemoved = null;
            Completion = GameCompletion.Beatable;
            IceNotRequired = false;
            PlasmaNotRequired = false;
            NoPBsBeforeChozodia = false;
            ChozoStatueHints = false;
            InfiniteBombJump = true;
            WallJumping = true;

            // locations
            CustomAssignments = new Dictionary<int, ItemType>();

            // enemies
            RandoEnemies = false;

            // palettes
            TilesetPalettes = false;
            EnemyPalettes = false;
            BeamPalettes = false;
            HueMinimum = 0;
            HueMaximum = 180;

            // misc
            EnableItemToggle = true;
            ObtainUnkItems = false;
            HardModeAvailable = true;
            PauseScreenInfo = false;
            RemoveCutscenes = true;
            SkipSuitless = false;
            SkipDoorTransitions = false;
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
            btw.AddNumber((int)ItemSwap, 3);
            if (NumItemsRemoved == 0)
                btw.AddBool(false);
            else
            {
                btw.AddBool(true);
                btw.AddNumber(NumItemsRemoved, 7);
                if (RemoveSpecificItems)
                {
                    btw.AddBool(true);
                    btw.AddNumber(NumAbilitiesRemoved.Value, 4);
                }
            }
            if (ItemSwap > SwapItems.Unchanged)
            {
                btw.AddNumber((int)Completion, 2);
                btw.AddBool(IceNotRequired);
                btw.AddBool(PlasmaNotRequired);
                btw.AddBool(NoPBsBeforeChozodia);
                btw.AddBool(ChozoStatueHints);
                btw.AddBool(InfiniteBombJump);
                btw.AddBool(WallJumping);
            }

            // locations
            if (CustomAssignments.Count == 0)
            {
                btw.AddBool(false);
            }
            else
            {
                btw.AddBool(true);
                btw.AddNumber(CustomAssignments.Count, 7);
                for (int i = 0; i < 100; i++)
                {
                    if (CustomAssignments.TryGetValue(i, out ItemType item))
                    {
                        btw.AddNumber(i, 7);
                        btw.AddNumber((int)item, 5);
                    }
                }
            }

            // enemies
            btw.AddBool(RandoEnemies);

            // palettes
            btw.AddBool(TilesetPalettes);
            btw.AddBool(EnemyPalettes);
            btw.AddBool(BeamPalettes);
            if (TilesetPalettes || EnemyPalettes || BeamPalettes)
            {
                if (HueMinimum == 0)
                {
                    btw.AddBool(false);
                }
                else
                {
                    btw.AddBool(true);
                    btw.AddNumber(HueMinimum, 8);
                }
                if (HueMaximum == 180)
                {
                    btw.AddBool(false);
                }
                else
                {
                    btw.AddBool(true);
                    btw.AddNumber(HueMaximum, 8);
                }
            }

            // misc
            btw.AddBool(EnableItemToggle);
            btw.AddBool(ObtainUnkItems);
            btw.AddBool(HardModeAvailable);
            btw.AddBool(PauseScreenInfo);
            btw.AddBool(RemoveCutscenes);
            btw.AddBool(SkipSuitless);
            btw.AddBool(SkipDoorTransitions);

            return btw.GetOutputString();
        }

    }
}
