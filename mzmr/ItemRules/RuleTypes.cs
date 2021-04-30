using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mzmr.ItemRules
{
    // TODO fix some proper mapping for the prettynames of these
    public class RuleTypes
    {
        public enum RuleItemType
        {
            Undefined, None,
            Energy, Missile, Super, Power,
            Long, Charge, Ice, Wave, Plasma,
            Bomb,
            Varia, Gravity,
            Morph, Speed, Hi, Screw, Space, Grip,
            AllMajors,
        }

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
                                    "Tourian",
                                    "Major Items"};
        }

        public static string[] GetItemTypeNames()
        {
            return new string[] {   "Select Item", "Major Items",
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
                case "Major Items":
                    return 10; // Special case
                case "Select Area":
                default:
                    return -1;
            }
        }

        public static string AreaIndexToName(int areaIndex)
        {
            switch (areaIndex)
            {
                case 0:
                    return "Brinstar";
                case 1:
                    return "Kraid";
                case 2:
                    return "Norfair";
                case 3:
                    return "Ridley";
                case 4:
                    return "Tourian";
                case 5:
                    return "Crateria";
                case 6:
                    return "Chozodia";
                case 10:
                    return "Major Items"; // Special case
                default:
                    return "Select Area";
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

        public static string RuleTypeToDescription(RuleType type)
        {
            switch (type)
            {
                case RuleType.RestrictedBeforeSearchDepth:
                    return "Is restricted before search depth";
                case RuleType.PrioritizedAfterSearchDepth:
                    return "Is prioritized after search depth";
                case RuleType.InLocation:
                    return "Is in location";
                case RuleType.NotInLocation:
                    return "Is NOT in location";
                case RuleType.InArea:
                    return "Is in area";
                case RuleType.NotInArea:
                    return "Is NOT in area";
                case RuleType.PoolPriority:
                    return "Is prioritized to stay in itempool";
                case RuleType.Undefined:
                default:
                    return "Select Rule";
            }
        }

        public static string ItemTypeToName(RuleItemType itemType)
        {
            switch (itemType)
            {
                case RuleItemType.Morph:
                    return "Morph";
                case RuleItemType.Bomb:
                    return "Bombs";
                case RuleItemType.Grip:
                    return "Power Grip";
                case RuleItemType.Hi:
                    return "Hi-Jump";
                case RuleItemType.Speed:
                    return "Speed Booster";
                case RuleItemType.Screw:
                    return "Screw Attack";
                case RuleItemType.Space:
                    return "Space Jump";
                case RuleItemType.Missile:
                    return "Missile";
                case RuleItemType.Super:
                    return "Super Missile";
                case RuleItemType.Power:
                    return "Power Bomb";
                case RuleItemType.Charge:
                    return "Charge Beam";
                case RuleItemType.Long:
                    return "Long Beam";
                case RuleItemType.Ice:
                    return "Ice Beam";
                case RuleItemType.Wave:
                    return "Wave Beam";
                case RuleItemType.Plasma:
                    return "Plasma Beam";
                case RuleItemType.Varia:
                    return "Varia Suit";
                case RuleItemType.Gravity:
                    return "Gravity Suit";
                case RuleItemType.Energy:
                    return "E-Tank";
                case RuleItemType.AllMajors:
                    return "Major Items";
                case RuleItemType.None:
                default:
                    return "Select Item";
            }
        }

        public static RuleItemType ItemNameToType(string itemName)
        {
            switch(itemName)
            {
                case "Morph":
                    return RuleItemType.Morph;
                case "Bombs":
                    return RuleItemType.Bomb;
                case "Power Grip":
                    return RuleItemType.Grip;
                case "Hi-Jump":
                    return RuleItemType.Hi;
                case "Speed Booster":
                    return RuleItemType.Speed;
                case "Screw Attack":
                    return RuleItemType.Screw;
                case "Space Jump":
                    return RuleItemType.Space;
                case "Missile":
                    return RuleItemType.Missile;
                case "Super Missile":
                    return RuleItemType.Super;
                case "Power Bomb":
                    return RuleItemType.Power;
                case "Charge Beam":
                    return RuleItemType.Charge;
                case "Long Beam":
                    return RuleItemType.Long;
                case "Ice Beam":
                    return RuleItemType.Ice;
                case "Wave Beam":
                    return RuleItemType.Wave;
                case "Plasma Beam":
                    return RuleItemType.Plasma;
                case "Varia Suit":
                    return RuleItemType.Varia;
                case "Gravity Suit":
                    return RuleItemType.Gravity;
                case "E-Tank":
                    return RuleItemType.Energy;
                case "Major Items":
                    return RuleItemType.AllMajors;
                case "Select Item":
                default:
                    return RuleItemType.None;
            }
        }
    }
}
