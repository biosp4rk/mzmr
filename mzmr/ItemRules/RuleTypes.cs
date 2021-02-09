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

        public static string ItemTypeToName(Items.ItemType itemType)
        {
            switch (itemType)
            {
                case Items.ItemType.Morph:
                    return "Morph";
                case Items.ItemType.Bomb:
                    return "Bombs";
                case Items.ItemType.Grip:
                    return "Power Grip";
                case Items.ItemType.Hi:
                    return "Hi-Jump";
                case Items.ItemType.Speed:
                    return "Speed Booster";
                case Items.ItemType.Screw:
                    return "Screw Attack";
                case Items.ItemType.Space:
                    return "Space Jump";
                case Items.ItemType.Missile:
                    return "Missile";
                case Items.ItemType.Super:
                    return "Super Missile";
                case Items.ItemType.Power:
                    return "Power Bomb";
                case Items.ItemType.Charge:
                    return "Charge Beam";
                case Items.ItemType.Long:
                    return "Long Beam";
                case Items.ItemType.Ice:
                    return "Ice Beam";
                case Items.ItemType.Wave:
                    return "Wave Beam";
                case Items.ItemType.Plasma:
                    return "Plasma Beam";
                case Items.ItemType.Varia:
                    return "Varia Suit";
                case Items.ItemType.Gravity:
                    return "Gravity Suit";
                case Items.ItemType.Energy:
                    return "E-Tank";
                case Items.ItemType.None:
                default:
                    return "Select Item";
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
