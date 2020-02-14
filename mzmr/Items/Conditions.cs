using System;
using System.Collections.Generic;
using System.Text;

namespace mzmr
{
    public class Conditions
    {
        // items
        private int Energy;
        private int Missile;
        private int Super;
        private int Power;
        private bool Long;
        private bool Charge;
        private bool Ice;
        private bool Wave;
        private bool Plasma;
        private bool Bomb;
        private bool Varia;
        private bool Gravity;
        private bool Morph;
        private bool Speed;
        private bool Hi;
        private bool Screw;
        private bool Space;
        private bool Grip;

        // settings
        private readonly bool IceNotReq;
        private readonly bool PlasmaNotReq;
        private readonly bool ChozoHints;
        private readonly bool IBJ;
        private readonly bool IWJ;
        private readonly bool ObtainUnkItems;

        private readonly Location[] locations;
        private readonly List<List<int>> collectionOrder;

        public Conditions(Settings settings, Location[] locations)
        {
            IceNotReq = settings.iceNotRequired;
            PlasmaNotReq = settings.plasmaNotRequired;
            ChozoHints = settings.chozoStatueHints;
            IBJ = settings.infiniteBombJump;
            IWJ = settings.wallJumping;
            ObtainUnkItems = settings.obtainUnkItems;

            this.locations = locations;

            // set all unobtained
            Energy = 0;
            Missile = 0;
            Super = 0;
            Power = 0;

            // find all obtainable items
            bool[] reachableLocations = new bool[100];
            collectionOrder = new List<List<int>>();
            while (true)
            {
                List<int> collected = new List<int>();

                for (int i = 0; i < 100; i++)
                {
                    if (!reachableLocations[i] && IsObtainable(i))
                    {
                        reachableLocations[i] = true;
                        SetObtainable(locations[i].NewItem);
                        collected.Add(i);
                    }
                }

                if (collected.Count == 0) { break; }
                collectionOrder.Add(collected);
            }
        }

        private void SetObtainable(ItemType type)
        {
            switch (type)
            {
                case ItemType.Energy:
                    Energy++;
                    break;
                case ItemType.Missile:
                    Missile++;
                    break;
                case ItemType.Super:
                    Super++;
                    break;
                case ItemType.Power:
                    Power++;
                    break;
                case ItemType.Long:
                    Long = true;
                    break;
                case ItemType.Charge:
                    Charge = true;
                    break;
                case ItemType.Ice:
                    Ice = true;
                    break;
                case ItemType.Wave:
                    Wave = true;
                    break;
                case ItemType.Plasma:
                    Plasma = true;
                    break;
                case ItemType.Bomb:
                    Bomb = true;
                    break;
                case ItemType.Varia:
                    Varia = true;
                    break;
                case ItemType.Gravity:
                    Gravity = true;
                    break;
                case ItemType.Morph:
                    Morph = true;
                    break;
                case ItemType.Speed:
                    Speed = true;
                    break;
                case ItemType.Hi:
                    Hi = true;
                    break;
                case ItemType.Screw:
                    Screw = true;
                    break;
                case ItemType.Space:
                    Space = true;
                    break;
                case ItemType.Grip:
                    Grip = true;
                    break;
            }
        }

        private bool EnergyX(int num)
        {
            return (Energy >= num);
        }

        private bool MissileX(int num)
        {
            return (Missile * 2 + Super >= num);
        }

        private bool SuperX(int num)
        {
            return Super >= num;
        }

        private bool PowerX(int num)
        {
            return (Power >= num);
        }

        public bool IsBeatable()
        {
            return Morph && Bomb && (Plasma || PlasmaNotReq);
        }

        public bool Is100Able(int removed)
        {
            if (!IsBeatable()) { return false; }

            int total = Energy + Missile + Super + Power;

            if (Long) { total++; }
            if (Charge) { total++; }
            if (Ice) { total++; }
            if (Wave) { total++; }
            if (Plasma) { total++; }
            if (Bomb) { total++; }
            if (Varia) { total++; }
            if (Gravity) { total++; }
            if (Morph) { total++; }
            if (Speed) { total++; }
            if (Hi) { total++; }
            if (Screw) { total++; }
            if (Space) { total++; }
            if (Grip) { total++; }

            return total == (100 - removed);
        }

        private bool IsObtainable(int locNum)
        {
            switch (locNum)
            {
                case 0:
                    return true;
                case 1:
                    return Morph && Bomb;
                case 2:
                    return Morph;
                case 3:
                    return (Morph && Bomb) || Space;
                case 4:
                    return Morph && Bomb;
                case 5:
                    return Morph && Speed && Hi;
                case 6:
                    return Morph && Bomb;
                case 7:
                    return Morph && Bomb;
                case 8:
                    return Morph && Bomb;
                case 9:
                    return Morph && Missile > 0;
                case 10:
                    return Morph && Bomb;
                case 11:
                    return Morph;
                case 12:
                    return Morph && Bomb;
                case 13:
                    return Morph && Bomb;
                case 14:
                    return Morph && Bomb;
                case 15:
                    return Morph && Bomb;
                case 16:
                    return Morph && Bomb;
                case 17:
                    return Morph && Bomb;
                case 18:
                    return Morph && Bomb;
                case 19:
                    return Morph && Bomb;
                case 20:
                    return Morph && Bomb;
                case 21:
                    return Morph && Bomb;
                case 22:
                    return Morph && Bomb;
                case 23:
                    return Morph && Bomb;
                case 24:
                    return Morph && Bomb && Gravity && Speed && Hi;
                case 25:
                    return Morph && Bomb;
                case 26:
                    return Morph && Bomb;
                case 27:
                    return Morph && Bomb;
                case 28:
                    return Morph && Bomb;
                case 29:
                    return Morph && Bomb;
                case 30:
                    return Morph && Bomb && Speed;
                case 31:
                    return Morph && Bomb;
                case 32:
                    return Morph && Bomb && Gravity;
                case 33:
                    return Morph && Bomb;
                case 34:
                    return Morph && Bomb;
                case 35:
                    return Morph && Bomb && Screw;
                case 36:
                    return Morph && Bomb;
                case 37:
                    return Morph && Bomb;
                case 38:
                    return Morph && Bomb;
                case 39:
                    return Morph && Bomb;
                case 40:
                    return Morph && Bomb;
                case 41:
                    return Morph && Bomb;
                case 42:
                    return Morph && Bomb;
                case 43:
                    return Morph && Bomb;
                case 44:
                    return Morph && Bomb;
                case 45:
                    return Morph && Bomb;
                case 46:
                    return Morph && Bomb;
                case 47:
                    return Morph && Bomb;
                case 48:
                    return Morph && Bomb;
                case 49:
                    return Morph && Bomb;
                case 50:
                    return Morph && Bomb && Speed;
                case 51:
                    return Morph && Bomb;
                case 52:
                    return Morph && Bomb;
                case 53:
                    return Morph && Bomb && Speed && Grip;
                case 54:
                    return Morph && Bomb && Speed && Grip;
                case 55:
                    return Morph && Bomb;
                case 56:
                    return Morph && Bomb;
                case 57:
                    return Morph && Bomb;
                case 58:
                    return Morph && Bomb;
                case 59:
                    return Morph && Bomb;
                case 60:
                    return Morph && Bomb;
                case 61:
                    return Morph && Bomb;
                case 62:
                    return Morph && Bomb;
                case 63:
                    return Morph && Bomb;
                case 64:
                    return Morph && Bomb;
                case 65:
                    return Morph && Bomb;
                case 66:
                    return Morph && Bomb;
                case 67:
                    return Morph && Bomb;
                case 68:
                    return Morph && Bomb;
                case 69:
                    return Morph && Bomb;
                case 70:
                    return Morph && Bomb;
                case 71:
                    return Morph && Bomb && Speed && Grip;
                case 72:
                    return Morph && Bomb && Speed && Wave;
                case 73:
                    return Morph && Bomb && Speed;
                case 74:
                    return Morph && Bomb;
                case 75:
                    return Morph && Bomb && Speed && Hi;
                case 76:
                    return Morph && Bomb;
                case 77:
                    return Morph && Bomb;
                case 78:
                    return Morph && Bomb;
                case 79:
                    return Morph && Bomb;
                case 80:
                    return Morph && Bomb && Speed && Hi;
                case 81:
                    return Morph && Bomb && Speed;
                case 82:
                    return Morph && Bomb && PowerX(1);
                case 83:
                    return Morph && Bomb && PowerX(1);
                case 84:
                    return Morph && Bomb && PowerX(1);
                case 85:
                    return Morph && Bomb && PowerX(1);
                case 86:
                    return Morph && Bomb && PowerX(1);
                case 87:
                    return Morph && Bomb && PowerX(1) && Gravity && Speed;
                case 88:
                    return Morph && Bomb && PowerX(1);
                case 89:
                    return Morph && Bomb && PowerX(1) && Speed;
                case 90:
                    return Morph && Bomb && PowerX(1);
                case 91:
                    return Morph && Bomb && PowerX(1);
                case 92:
                    return Morph && Bomb && PowerX(1);
                case 93:
                    return Morph && Bomb && PowerX(1);
                case 94:
                    return Morph && Bomb && PowerX(1) && Gravity && Speed;
                case 95:
                    return Morph && Bomb && PowerX(1);
                case 96:
                    return Morph && Bomb && PowerX(1);
                case 97:
                    return Morph && Bomb && PowerX(1);
                case 98:
                    return Morph && Bomb && PowerX(1) && Speed;
                case 99:
                    return Morph && Bomb && PowerX(1);
                default:
                    throw new ArgumentException();
            }
        }

        public string GetCollectionOrder()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Collection order:");
            int round = 1;
            foreach (List<int> items in collectionOrder)
            {
                List<string> itemStrings = items.ConvertAll<string>(num => num.ToString());
                string line = string.Join(", ", itemStrings.ToArray());
                sb.AppendLine($"Round {round}");
                sb.AppendLine(line);
                round++;
            }

            return sb.ToString().Trim();
        }


    }
}
