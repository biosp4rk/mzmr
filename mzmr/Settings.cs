using mzmr.Items;
using mzmr.Utility;
using System;
using System.Collections.Generic;

namespace mzmr
{
    public enum Swap { Unchanged, LocalPool, GlobalPool }
    public enum Song { Unchanged, NoLogic, Structured }
    public enum Change { Unchanged, Shuffle, Random }
    public enum GameCompletion { NoLogic, Beatable, AllItems }

    public class Settings
    {
        public bool SwapOrRemoveItems
        {
            get
            {
                return AbilitySwap > Swap.Unchanged ||
                    TankSwap > Swap.Unchanged ||
                    NumItemsRemoved > 0;
            }
        }
        public bool RemoveSpecificItems => NumAbilitiesRemoved != null;
        public bool RandomPalettes
        {
            get { return TilesetPalettes ||
                    EnemyPalettes || SamusPalettes || BeamPalettes; }
        }

        public bool RandomStats
        { 
            get { return EnemyWeakness || EnemyHealth || EnemyDamage;  } 
        }

        // items
        public Swap AbilitySwap;
        public Swap TankSwap;
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
        public bool SamusPalettes;
        public bool BeamPalettes;
        public int HueMinimum;
        public int HueMaximum;

        //music
        public Song RoomMusic;
        public Song BossMusic;

        //text
        public bool ItemText;
        public bool AreaText;
        public bool MiscText;
        public bool CutsceneText;

        //stats
        public bool EnemyHealth;
        public bool EnemyDamage;
        public bool EnemyWeakness;
        public bool EnemyDrops;
        public int HealthMinimum;
        public int HealthMaximum;
        public int DamageMinimum;
        public int DamageMaximum;

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
            AbilitySwap = (Swap)btr.ReadNumber(2);
            TankSwap = (Swap)btr.ReadNumber(2);
            if (btr.ReadBool())
            {
                NumItemsRemoved = btr.ReadNumber(7);
                if (btr.ReadBool())
                    NumAbilitiesRemoved = btr.ReadNumber(4);
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
            SamusPalettes = btr.ReadBool();
            BeamPalettes = btr.ReadBool();
            if (RandomPalettes)
            {
                if (btr.ReadBool())
                    HueMinimum = btr.ReadNumber(8);
                if (btr.ReadBool())
                    HueMaximum = btr.ReadNumber(8);
            }

            //music
            RoomMusic = (Song)btr.ReadNumber(2);
            BossMusic = (Song)btr.ReadNumber(2);

            //text
            ItemText = btr.ReadBool();
            AreaText = btr.ReadBool();
            MiscText = btr.ReadBool();
            CutsceneText = btr.ReadBool();

            //stats
            EnemyHealth = btr.ReadBool();
            EnemyDamage = btr.ReadBool();
            EnemyWeakness = btr.ReadBool();
            EnemyDrops = btr.ReadBool();
            if (EnemyHealth)
            {
                HealthMinimum = btr.ReadNumber(9);
                HealthMaximum = btr.ReadNumber(9);
            }
            if (EnemyDamage)
            {
                DamageMinimum = btr.ReadNumber(9);
                DamageMaximum = btr.ReadNumber(9);
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
            if (randAbilities && randTanks)
            {
                AbilitySwap = Swap.GlobalPool;
                TankSwap = Swap.GlobalPool;
            }
            else if (randAbilities) AbilitySwap = Swap.LocalPool;
            else if (randTanks) TankSwap = Swap.LocalPool;

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
            AbilitySwap = Swap.Unchanged;
            TankSwap = Swap.Unchanged;
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
            SamusPalettes = false;
            BeamPalettes = false;
            HueMinimum = 0;
            HueMaximum = 180;

            //music
            RoomMusic = Song.Unchanged;
            BossMusic = Song.Unchanged;

            //text
            ItemText = false;
            AreaText = false;
            MiscText = false;
            CutsceneText = false;

            //stats
            EnemyHealth = false;
            EnemyDamage = false;
            EnemyWeakness = false;
            EnemyDrops = false;
            HealthMinimum = 50;
            HealthMaximum = 200;
            DamageMinimum = 50;
            DamageMaximum = 200;

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
            btw.AddNumber((int)AbilitySwap, 2);
            btw.AddNumber((int)TankSwap, 2);
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
            if (SwapOrRemoveItems)
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
                btw.AddBool(false);
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
            btw.AddBool(SamusPalettes);
            btw.AddBool(BeamPalettes);
            if (RandomPalettes)
            {
                if (HueMinimum == 0)
                    btw.AddBool(false);
                else
                {
                    btw.AddBool(true);
                    btw.AddNumber(HueMinimum, 8);
                }
                if (HueMaximum == 180)
                    btw.AddBool(false);
                else
                {
                    btw.AddBool(true);
                    btw.AddNumber(HueMaximum, 8);
                }
            }

            //music
            btw.AddNumber((int)RoomMusic, 2);
            btw.AddNumber((int)BossMusic, 2);

            //text
            btw.AddBool(ItemText);
            btw.AddBool(AreaText);
            btw.AddBool(MiscText);
            btw.AddBool(CutsceneText);

            //stats
            btw.AddBool(EnemyHealth);
            btw.AddBool(EnemyDamage);
            btw.AddBool(EnemyWeakness);
            btw.AddBool(EnemyDrops);
            if (EnemyHealth)
            {
                btw.AddNumber(HealthMinimum, 9);
                btw.AddNumber(HealthMaximum, 9);
            }
            if (EnemyDamage)
            {
                btw.AddNumber(DamageMinimum, 9);
                btw.AddNumber(DamageMaximum, 9);
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
