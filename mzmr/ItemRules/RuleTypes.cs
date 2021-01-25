using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mzmr.ItemRules
{
    public class RuleTypes
    {
        public enum RuleType
        {
            Undefined,
            RestrictedBeforeSearchDepth,
            PrioritizedAfterSearchDepth,
            InLocation,
            NotInLocation,
            InArea,
            NotInArea,
            PoolPriority,
        }

        public static string[] GetRuleDescriptions()
        {
            return new string[] {   "Select Rule",
                                    "Is restricted before search depth",
                                    "Is prioritized after search depth",
                                    "Is in location",
                                    "Is NOT in location",
                                    "Is in area",
                                    "Is NOT in area",
                                    "Is prioritized to stay in itempool",
                                    /*"Is specific Chozo hint:",
                                    "Is one of the Chozo hints",
                                    "Is NOT one of the Chozo hints",*/ };
        }

        public static string[] GetAreaNames()
        {
            return new string[] {   "Select Area",
                                    "Brinstar",
                                    "Norfair",
                                    "Crateria",
                                    "Kraid",
                                    "Ridley",
                                    "Chozodia",
                                    "Tourian" };
        }

        public static string[] GetItemTypeNames()
        {
            return new string[] {   "Select Item",
                                    "Morph", "Bombs", "Power Grip", "Hi-Jump", "Speed Booster", "Screw Attack", "Space Jump",
                                    "Missile", "Super Missile", "Power Bomb",
                                    "Charge Beam", "Long Beam", "Ice Beam", "Wave Beam", "Plasma Beam",
                                    "Varia Suit", "Gravity Suit",
                                    "E-Tank" };
        }

        public static int AreaNameToIndex(string ruleName)
        {
            switch (ruleName)
            {
                case "Brinstar":
                    return 0;
                case "Kraid":
                    return 1;
                case "Norfair":
                    return 2;
                case "Ridley":
                    return 3;
                case "Tourian":
                    return 4;
                case "Crateria":
                    return 5;
                case "Chozodia":
                    return 6;
                case "Select Area":
                default:
                    return -1;
            }
        }

        public static RuleType RuleDescriptionToType(string ruleName)
        {
            switch (ruleName)
            {
                case "Is restricted before search depth":
                    return RuleType.RestrictedBeforeSearchDepth;
                case "Is prioritized after search depth":
                    return RuleType.PrioritizedAfterSearchDepth;
                case "Is in location":
                    return RuleType.InLocation;
                case "Is NOT in location":
                    return RuleType.NotInLocation;
                case "Is in area":
                    return RuleType.InArea;
                case "Is NOT in area":
                    return RuleType.NotInArea;
                case "Is prioritized to stay in itempool":
                    return RuleType.PoolPriority;
                case "Select Rule":
                default:
                    return RuleType.Undefined;
            }
        }

        public static Items.ItemType ItemNameToType(string itemName)
        {
            switch(itemName)
            {
                case "Morph":
                    return Items.ItemType.Morph;
                case "Bombs":
                    return Items.ItemType.Bomb;
                case "Power Grip":
                    return Items.ItemType.Grip;
                case "Hi-Jump":
                    return Items.ItemType.Hi;
                case "Speed Booster":
                    return Items.ItemType.Speed;
                case "Screw Attack":
                    return Items.ItemType.Screw;
                case "Space Jump":
                    return Items.ItemType.Space;
                case "Missile":
                    return Items.ItemType.Missile;
                case "Super Missile":
                    return Items.ItemType.Super;
                case "Power Bomb":
                    return Items.ItemType.Power;
                case "Charge Beam":
                    return Items.ItemType.Charge;
                case "Long Beam":
                    return Items.ItemType.Long;
                case "Ice Beam":
                    return Items.ItemType.Ice;
                case "Wave Beam":
                    return Items.ItemType.Wave;
                case "Plasma Beam":
                    return Items.ItemType.Plasma;
                case "Varia Suit":
                    return Items.ItemType.Varia;
                case "Gravity Suit":
                    return Items.ItemType.Gravity;
                case "E-Tank":
                    return Items.ItemType.Energy;
                case "Select Item":
                default:
                    return Items.ItemType.None;
            }
        }
    }
}
