using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mzmr.ItemRules
{
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
            PoolRemovePriority,
            /*IsSpecificChozoHint:,
              IsOneOfTheChozoHints,
              IsNotOneOfTheChozoHints,*/
        }

        private static Dictionary<int, string> AreaIndexNameMap = new Dictionary<int, string>()
        {
            { 0, "Select Area" },
            { 1, "Brinstar" },
            { 2, "Kraid" },
            { 3, "Norfair" },
            { 4, "Ridley" },
            { 5, "Tourian" },
            { 6, "Crateria" },
            { 7, "Chozodia" },
            { 10, "Major Items" }
        };

        private static Dictionary<RuleType, string> RuleTypeDescriptionMap = new Dictionary<RuleType, string>()
        {
            { RuleType.Undefined, "Select Rule" },
            { RuleType.RestrictedBeforeSearchDepth, "Is restricted before search depth" },
            { RuleType.PrioritizedAfterSearchDepth, "Is prioritized after search depth" },
            { RuleType.InLocation, "Is in location" },
            { RuleType.NotInLocation, "Is NOT in location" },
            { RuleType.InArea, "Is in area" },
            { RuleType.NotInArea, "Is NOT in area" },
            { RuleType.PoolPriority, "Is prioritized to stay in item pool" },
            { RuleType.PoolRemovePriority, "Is removed first from item pool" }
        };

        private static Dictionary<RuleItemType, string> ItemTypeNameMap = new Dictionary<RuleItemType, string>()
        {
            { RuleItemType.Undefined, "Select Item" },
            { RuleItemType.Morph, "Morph" },
            { RuleItemType.Bomb, "Bombs" },
            { RuleItemType.Grip, "Power Grip" },
            { RuleItemType.Hi, "Hi-Jump" },
            { RuleItemType.Speed, "Speed Booster" },
            { RuleItemType.Screw, "Screw Attack" },
            { RuleItemType.Space, "Space Jump" },
            { RuleItemType.Missile, "Missile" },
            { RuleItemType.Super, "Super Missile" },
            { RuleItemType.Power, "Power Bomb" },
            { RuleItemType.Charge, "Charge Beam" },
            { RuleItemType.Long, "Long Beam" },
            { RuleItemType.Ice, "Ice Beam" },
            { RuleItemType.Wave, "Wave Beam" },
            { RuleItemType.Plasma, "Plasma Beam" },
            { RuleItemType.Varia, "Varia Suit" },
            { RuleItemType.Gravity, "Gravity Suit" },
            { RuleItemType.Energy, "E-Tank" },
            { RuleItemType.AllMajors, "Major Items" }
        };

        public static string[] GetRuleDescriptions()
        {
            return RuleTypeDescriptionMap.Values.ToArray();
        }

        public static string[] GetAreaNames()
        {
            return AreaIndexNameMap.Values.ToArray();
        }

        public static string[] GetItemTypeNames()
        {
            return ItemTypeNameMap.Values.ToArray();
        }

        public static int AreaNameToIndex(string areaName)
        {
            return AreaIndexNameMap.FirstOrDefault(area => area.Value == areaName).Key;
        }

        public static string AreaIndexToName(int areaIndex)
        {
            return AreaIndexNameMap[areaIndex];
        }

        public static RuleType RuleDescriptionToType(string ruleName)
        {
            return RuleTypeDescriptionMap.FirstOrDefault(rule => rule.Value == ruleName).Key;
        }

        public static string RuleTypeToDescription(RuleType type)
        {
            return RuleTypeDescriptionMap[type];
        }

        public static string ItemTypeToName(RuleItemType itemType)
        {
            return ItemTypeNameMap[itemType];
        }

        public static RuleItemType ItemNameToType(string itemName)
        {
            return ItemTypeNameMap.FirstOrDefault(item => item.Value == itemName).Key;
        }

    }
}
