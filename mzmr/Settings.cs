using Common.SaveData;
using mzmr.ItemRules;
using mzmr.Items;
using mzmr.Utility;
using System;
using System.Collections.Generic;

namespace mzmr
{
    public enum Swap { Unchanged, LocalPool, GlobalPool }
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

        // locations
        public Dictionary<int, ItemType> CustomAssignments;

        // rules
        public List<ItemRule> rules;

        // logic
        public bool customLogic;
        public SaveData logicData;
        public bool[] logicSettings;

        // enemies
        public bool RandoEnemies;

        // palettes
        public bool TilesetPalettes;
        public bool EnemyPalettes;
        public bool SamusPalettes;
        public bool BeamPalettes;
        public int HueMinimum;
        public int HueMaximum;

        // tweaks
        public bool EnableItemToggle;
        public bool ObtainUnkItems;
        public bool HardModeAvailable;
        public bool PauseScreenInfo;
        public bool RemoveCutscenes;
        public bool SkipSuitless;
        public bool SkipDoorTransitions;
        public bool DisableInfiniteBombJump;
        public bool DisableWallJump;

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
                case "1.4.0":
                    LoadSettings_1_4_0(btr);
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

            // logic
            customLogic = btr.ReadBool();
            if (btr.ReadBool())
            {
                int count = btr.ReadNumber(7);
                logicSettings = new bool[count];
                for (int i = 0; i < count; i++)
                    logicSettings[i] = btr.ReadBool();
            }

            // rules
            if (btr.ReadBool())
            {
                int count = btr.ReadNumber(7);
                rules = new List<ItemRule>();
                for (int i = 0; i < count; i++)
                {
                    var rule = new ItemRule();
                    rule.ItemType = (RuleTypes.RuleItemType)btr.ReadNumber(5);
                    rule.RuleType = (RuleTypes.RuleType)btr.ReadNumber(4);
                    rule.Value = btr.ReadNumber(7);
                    rules.Add(rule);
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

            // misc
            EnableItemToggle = btr.ReadBool();
            ObtainUnkItems = btr.ReadBool();
            HardModeAvailable = btr.ReadBool();
            PauseScreenInfo = btr.ReadBool();
            RemoveCutscenes = btr.ReadBool();
            SkipSuitless = btr.ReadBool();
            SkipDoorTransitions = btr.ReadBool();
            DisableInfiniteBombJump = btr.ReadBool();
            DisableWallJump = btr.ReadBool();
        }

        private void LoadSettings_1_4_0(BinaryTextReader btr)
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

            // logic
            customLogic = btr.ReadBool();
            if (btr.ReadBool())
            {
                int count = btr.ReadNumber(7);
                logicSettings = new bool[count];
                for (int i = 0; i < count; i++)
                    logicSettings[i] = btr.ReadBool();
            }

            // rules
            if (btr.ReadBool())
            {
                int count = btr.ReadNumber(7);
                rules = new List<ItemRule>();
                for (int i = 0; i < count; i++)
                {
                    var rule = new ItemRule();
                    rule.ItemType = (RuleTypes.RuleItemType)btr.ReadNumber(5);
                    rule.RuleType = (RuleTypes.RuleType)btr.ReadNumber(4);
                    rule.Value = btr.ReadNumber(7);
                    rules.Add(rule);
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
                NumItemsRemoved = btr.ReadNumber(7);
            if (SwapOrRemoveItems)
            {
                Completion = (GameCompletion)btr.ReadNumber(2);
                IceNotRequired = btr.ReadBool();
                PlasmaNotRequired = btr.ReadBool();
                NoPBsBeforeChozodia = btr.ReadBool();
                ChozoStatueHints = btr.ReadBool();
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
                    HueMinimum = btr.ReadNumber(8);
                if (btr.ReadBool())
                    HueMaximum = btr.ReadNumber(8);
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

            // locations
            CustomAssignments = new Dictionary<int, ItemType>();
            
            // logic
            customLogic = false;
            logicSettings = null;

            // enemies
            RandoEnemies = false;

            // palettes
            TilesetPalettes = false;
            EnemyPalettes = false;
            SamusPalettes = false;
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
            DisableInfiniteBombJump = false;
            DisableWallJump = false;
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
                else
                {
                    btw.AddBool(false);
                }
            }
            if (SwapOrRemoveItems)
            {
                btw.AddNumber((int)Completion, 2);
                btw.AddBool(IceNotRequired);
                btw.AddBool(PlasmaNotRequired);
                btw.AddBool(NoPBsBeforeChozodia);
                btw.AddBool(ChozoStatueHints);
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

            // logic
            btw.AddBool(customLogic);

            if (logicSettings == null)
                btw.AddBool(false);
            else
            {
                btw.AddBool(true);
                btw.AddNumber(logicSettings.Length, 7);
                for (int i = 0; i < logicSettings.Length; i++)
                    btw.AddBool(logicSettings[i]);
            }

            // rules
            if (rules.Count == 0)
                btw.AddBool(false);
            else
            {
                btw.AddBool(true);
                btw.AddNumber(rules.Count, 7);
                foreach (var rule in rules)
                {
                    btw.AddNumber((int)rule.ItemType, 5);
                    btw.AddNumber((int)rule.RuleType, 4);
                    btw.AddNumber(rule.Value, 7);
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

            // misc
            btw.AddBool(EnableItemToggle);
            btw.AddBool(ObtainUnkItems);
            btw.AddBool(HardModeAvailable);
            btw.AddBool(PauseScreenInfo);
            btw.AddBool(RemoveCutscenes);
            btw.AddBool(SkipSuitless);
            btw.AddBool(SkipDoorTransitions);
            btw.AddBool(DisableInfiniteBombJump);
            btw.AddBool(DisableWallJump);

            return btw.GetOutputString();
        }

    }
}
