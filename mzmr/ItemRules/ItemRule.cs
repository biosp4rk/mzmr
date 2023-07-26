using Common.Key;
using mzmr.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using Verifier.ItemRules;

namespace mzmr.ItemRules
{
    public class ItemRule : IEquatable<ItemRule>
    {
        public RuleTypes.RuleItemType ItemType { get; set; }
        public RuleTypes.RuleType RuleType { get; set; }
        public int Value { get; set; }

        public List<Guid> ToPrioritizedPoolItems()
        {
            var items = new List<Guid>();
            if (RuleType != RuleTypes.RuleType.PoolPriority)
                return items;

            return ToItems();
        }

        public List<Guid> ToRestrictedPoolItems()
        {
            var items = new List<Guid>();
            if (RuleType != RuleTypes.RuleType.PoolRemovePriority)
                return items;

            return ToItems();
        }

        public List<Guid> ToItems()
        {
            var items = new List<Guid>();
            if (ItemType == RuleTypes.RuleItemType.AllMajors)
            {
                foreach (ItemType item in Enum.GetValues(typeof(ItemType)))
                {
                    if (item.IsAbility())
                    {
                        var keyId = KeyManager.GetKeyFromName(item.LogicName())?.Id ?? Guid.Empty;
                        if (keyId != Guid.Empty)
                            items.Add(keyId);
                    }
                }

                return items;
            }
            else
            {
                var keyId = KeyManager.GetKeyFromName(((ItemType)ItemType).LogicName())?.Id ?? Guid.Empty;
                if (keyId != Guid.Empty)
                    items.Add(keyId);

                return items;
            }
        }

        public List<ItemRuleBase> ToLogicRules()
        {
            var rules = new List<ItemRuleBase>();

            if (ItemType == RuleTypes.RuleItemType.AllMajors)
            {
                foreach (ItemType item in Enum.GetValues(typeof(ItemType)))
                {
                    if (item.IsAbility())
                    {
                        var keyId = KeyManager.GetKeyFromName(item.LogicName())?.Id ?? Guid.Empty;
                        if (keyId != Guid.Empty)
                            rules.AddRange(ToLogicRules(keyId));
                    }
                }

                return rules;
            }
            else
            {
                var keyId = KeyManager.GetKeyFromName(((ItemType)ItemType).LogicName())?.Id ?? Guid.Empty;
                if (keyId == Guid.Empty)
                    return rules;

                return ToLogicRules(keyId);
            }
        }

        private List<ItemRuleBase> ToLogicRules(Guid keyId)
        {
            var rules = new List<ItemRuleBase>();

            try
            {
                if (RuleType == RuleTypes.RuleType.PrioritizedAfterSearchDepth)
                    rules.Add(new ItemRulePrioritizedAfterDepth() { ItemId = keyId, SearchDepth = Value });

                if (RuleType == RuleTypes.RuleType.RestrictedBeforeSearchDepth)
                    rules.Add(new ItemRuleRestrictedBeforeDepth() { ItemId = keyId, SearchDepth = Value });

                if (RuleType == RuleTypes.RuleType.InLocation)
                {
                    var location = Location.GetLocation(Value);
                    rules.Add(new ItemRuleInLocation() { ItemId = keyId, LocationIdentifier = location.LogicName });
                }

                if (RuleType == RuleTypes.RuleType.NotInLocation)
                {
                    var location = Location.GetLocation(Value);
                    rules.Add(new ItemRuleNotInLocation() { ItemId = keyId, LocationIdentifier = location.LogicName });
                }

                if (RuleType == RuleTypes.RuleType.InArea)
                {
                    if (Value == 10) // Special case for Major Items
                    {
                        var locations = Location.GetLocations().Where(location => location.OrigItem.IsAbility());
                        rules.AddRange(locations.Select(location => new ItemRuleInLocation() { ItemId = keyId, LocationIdentifier = location.LogicName }));
                    }
                    else
                    {
                        var locations = Location.GetLocations().Where(location => location.Area == (Value - 1));
                        rules.AddRange(locations.Select(location => new ItemRuleInLocation() { ItemId = keyId, LocationIdentifier = location.LogicName }));
                    }
                }

                if (RuleType == RuleTypes.RuleType.NotInArea)
                {
                    var locations = Location.GetLocations().Where(location => location.Area == (Value - 1));
                    rules.AddRange(locations.Select(location => new ItemRuleNotInLocation() { ItemId = keyId, LocationIdentifier = location.LogicName }));
                }
            }
            catch { }

            return rules;
        }

        public bool Equals(ItemRule other)
        {
            // If parameter is null, return false.
            if (other is null)
                return false;

            // Optimization for a common success case.
            if (ReferenceEquals(this, other))
                return true;

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != other.GetType())
                return false;

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return ItemType == other.ItemType &&
                RuleType == other.RuleType &&
                Value == other.Value;
        }

        public override int GetHashCode()
        {
            return (int)ItemType * 0x1000000 + (int)RuleType * 0x0010000 + Value;
        }

        public override bool Equals(object other)
        {
            // Check for null on left side.
            if (this is null)
            {
                if (other is null)
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return Equals(other);
        }

        public static bool operator ==(ItemRule lhs, ItemRule rhs)
        {
            // Check for null on left side.
            if (lhs is null)
            {
                if (rhs is null)
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ItemRule lhs, ItemRule rhs)
        {
            return !(lhs == rhs);
        }

    }
}
