using System;
using System.Collections.Generic;
using System.Text;

namespace mzmr.Items
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

        // misc
        private bool CanIBJ;
        private bool BombBlock;
        private bool BombChain;
        private bool Launcher;
        private bool BallSpark;
        private bool HeatImmune;
        private bool CanFreeze;
        private bool NorShaft;
        private bool NorHeatRun;
        private bool ChoLavaRun;
        private bool FullyPowered;
        private bool ActiveSpace;
        private bool ActiveGravity;
        private bool ActivePlasma;
        private bool Ledge_4_5;
        private bool LedgeNW_5;
        private bool Ledge_6_7;
        private bool LedgeNW_6_7;
        private bool Ledge_8p;
        private bool LedgeNW_8p;
        private bool CeilingTunnel_1_2;
        private bool CeilingTunnel_3_4;
        private bool CeilingTunnel_5;
        private bool CeilingTunnel_6_7;
        private bool CeilingTunnelNW_6_7;
        private bool CeilingTunnel_8p;
        private bool CeilingTunnelNW_8p;
        private bool Tunnel_1_3;
        private bool Tunnel_4_5;
        private bool TunnelNW_4_5;
        private bool Tunnel_6_7;
        private bool TunnelNW_6_7;
        private bool Tunnel_8p;
        private bool TunnelNW_8p;

        // settings
        private readonly bool IceNotReq;
        private readonly bool PlasmaNotReq;
        private readonly bool IWJ;
        private readonly bool IBJ;
        private readonly bool RandEnemies;
        private readonly bool Hard;
        private readonly bool ItemToggle;
        private readonly bool ObtainUnkItems;
        //private readonly bool ChozoHints;

        private readonly Location[] locations;
        private readonly bool[] reachable;
        private readonly List<List<int>> collectionOrder;

        public Conditions(Settings settings, Location[] locations)
        {
            IceNotReq = settings.IceNotRequired;
            PlasmaNotReq = settings.PlasmaNotRequired;
            IWJ = settings.WallJumping;
            IBJ = settings.InfiniteBombJump;
            RandEnemies = settings.RandoEnemies;
            Hard = false;
            ItemToggle = settings.EnableItemToggle;
            ObtainUnkItems = settings.ObtainUnkItems;
            //ChozoHints = settings.chozoStatueHints;

            this.locations = locations;

            // set all unobtained
            Energy = 0;
            Missile = 0;
            Super = 0;
            Power = 0;

            // find all obtainable items
            reachable = new bool[100];
            collectionOrder = new List<List<int>>();
            while (true)
            {
                bool updated = UpdateReplacements();
                List<int> collected = new List<int>();

                for (int i = 0; i < 100; i++)
                {
                    if (!reachable[i] && IsObtainable(i))
                    {
                        reachable[i] = true;
                        if (locations[i].NewItem != ItemType.None)
                        {
                            SetObtainable(locations[i].NewItem);
                            collected.Add(i);
                        }
                    }
                }

                if (!updated && collected.Count == 0) { break; }
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

        private bool Item(int locNum, ItemType type)
        {
            return locations[locNum].NewItem == type;
        }

        private bool EnergyX(int num)
        {
            int inc = Hard ? 50 : 100;
            return 100 + Energy * inc > num;
        }

        private bool AnyX(int num)
        {
            int incM = Hard ? 2 : 5;
            int incS = Hard ? 1 : 2;
            return Missile * incM + Super * incS >= num;
        }

        private bool MissileX(int num)
        {
            int inc = Hard ? 2 : 5;
            return Missile * inc >= num;
        }

        private bool SuperX(int num)
        {
            int inc = Hard ? 1 : 2;
            return Super * inc >= num;
        }

        private bool PowerX(int num)
        {
            int inc = Hard ? 1 : 2;
            return Power * inc >= num;
        }

        public bool IsBeatable()
        {
            return FullyPowered && (Plasma || PlasmaNotReq);
        }

        public bool Is100able(int removed)
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

        private bool UpdateReplacements()
        {
            bool increase = false;

            if (!CanIBJ)
            {
                CanIBJ = IBJ && Morph && Bomb;
                increase |= CanIBJ;
            }
            if (!BombChain)
            {
                BombChain = Morph && (Bomb || PowerX(1));
                increase |= BombChain;
            }
            if (!BombBlock)
            {
                BombBlock = BombChain || Screw;
                increase |= BombBlock;
            }
            if (!Launcher)
            {
                Launcher = Morph && Bomb;
                increase |= Launcher;
            }
            if (!BallSpark)
            {
                BallSpark = Morph && Speed && Hi;
                increase |= BallSpark;
            }
            if (!HeatImmune)
            {
                HeatImmune = Varia || ActiveGravity;
                increase |= HeatImmune;
            }
            if (!CanFreeze)
            {
                CanFreeze = !RandEnemies && Ice && ItemToggle;
                increase |= CanFreeze;
            }
            if (!NorShaft)
            {
                NorShaft = BombChain && (LedgeNW_5 || Speed);
                increase |= NorShaft;
            }
            if (!NorHeatRun)
            {
                NorHeatRun = reachable[47] && (HeatImmune || EnergyX(200)) && (Speed || LedgeNW_8p);
                increase |= NorHeatRun;
            }
            if (!ChoLavaRun)
            {
                ChoLavaRun = (Gravity || (Varia && EnergyX(200)) || EnergyX(300)) && Ledge_8p;
                increase |= ChoLavaRun;
            }
            if (!FullyPowered)
            {
                FullyPowered = reachable[25] && reachable[57] && (Ice || IceNotReq) && ChoLavaRun;
                increase |= FullyPowered;
            }
            if (!ActiveSpace)
            {
                ActiveSpace = Space && (ObtainUnkItems || FullyPowered);
                increase |= ActiveSpace;
            }
            if (!ActiveGravity)
            {
                ActiveGravity = Gravity && (ObtainUnkItems || FullyPowered);
                increase |= ActiveGravity;
            }
            if (!ActivePlasma)
            {
                ActivePlasma = Plasma && (ObtainUnkItems || FullyPowered);
                increase |= ActivePlasma;
            }
            if (!Ledge_4_5)
            {
                Ledge_4_5 = Hi || Grip || IWJ || CanIBJ || ActiveSpace;
                increase |= Ledge_4_5;
            }
            if (!LedgeNW_5)
            {
                LedgeNW_5 = Hi || Grip || CanIBJ || ActiveSpace;
                increase |= LedgeNW_5;
            }
            if (!Ledge_6_7)
            {
                Ledge_6_7 = (Hi && Grip) || IWJ || CanIBJ || ActiveSpace;
                increase |= Ledge_6_7;
            }
            if (!LedgeNW_6_7)
            {
                LedgeNW_6_7 = (Hi && Grip) || CanIBJ || ActiveSpace;
                increase |= LedgeNW_6_7;
            }
            if (!Ledge_8p)
            {
                Ledge_8p = IWJ || CanIBJ || ActiveSpace;
                increase |= Ledge_8p;
            }
            if (!LedgeNW_8p)
            {
                LedgeNW_8p = CanIBJ || ActiveSpace;
                increase |= LedgeNW_8p;
            }
            if (!CeilingTunnel_1_2)
            {
                CeilingTunnel_1_2 = Morph && (Bomb || Hi);
                increase |= CeilingTunnel_1_2;
            }
            if (!CeilingTunnel_3_4)
            {
                CeilingTunnel_3_4 = (Morph && (Grip || Hi)) || CanIBJ;
                increase |= CeilingTunnel_3_4;
            }
            if (!CeilingTunnel_5)
            {
                CeilingTunnel_5 = (Morph && Grip) || CanIBJ;
                increase |= CeilingTunnel_5;
            }
            if (!CeilingTunnel_6_7)
            {
                CeilingTunnel_6_7 = (Morph && Grip && (Hi || ActiveSpace || IWJ)) || CanIBJ;
                increase |= CeilingTunnel_6_7;
            }
            if (!CeilingTunnelNW_6_7)
            {
                CeilingTunnelNW_6_7 = (Morph && Grip && (Hi || ActiveSpace)) || CanIBJ;
                increase |= CeilingTunnelNW_6_7;
            }
            if (!CeilingTunnel_8p)
            {
                CeilingTunnel_8p = (Morph && Grip && (ActiveSpace || IWJ)) || CanIBJ;
                increase |= CeilingTunnel_8p;
            }
            if (!CeilingTunnelNW_8p)
            {
                CeilingTunnelNW_8p = (Morph && Grip && ActiveSpace) || CanIBJ;
                increase |= CeilingTunnelNW_8p;
            }
            if (!Tunnel_1_3)
            {
                Tunnel_1_3 = Morph;
                increase |= Tunnel_1_3;
            }
            if (!Tunnel_4_5)
            {
                Tunnel_4_5 = (Morph && (Grip || Hi || ActiveSpace || IWJ)) || CanIBJ;
                increase |= Tunnel_4_5;
            }
            if (!TunnelNW_4_5)
            {
                TunnelNW_4_5 = (Morph && (Grip || Hi || ActiveSpace)) || CanIBJ;
                increase |= TunnelNW_4_5;
            }
            if (!Tunnel_6_7)
            {
                Tunnel_6_7 = (Morph && ((Grip && Hi) || ActiveSpace || IWJ)) || CanIBJ;
                increase |= Tunnel_6_7;
            }
            if (!TunnelNW_6_7)
            {
                TunnelNW_6_7 = (Morph && ((Grip && Hi) || ActiveSpace)) || CanIBJ;
                increase |= TunnelNW_6_7;
            }
            if (!Tunnel_8p)
            {
                Tunnel_8p = (Morph && (ActiveSpace || IWJ)) || CanIBJ;
                increase |= Tunnel_8p;
            }
            if (!TunnelNW_8p)
            {
                TunnelNW_8p = (Morph && ActiveSpace) || CanIBJ;
                increase |= TunnelNW_8p;
            }

            return increase;
        }

        private bool IsObtainable(int locNum)
        {
            switch (locNum)
            {
                case 0:
                    return Item(0, ItemType.Morph) || (ObtainUnkItems && Item(0, ItemType.Space) && Item(3, ItemType.Morph));
                case 1:
                    return Launcher;
                case 2:
                    return Morph &&
                        (Long || Ice || Wave || ActivePlasma || AnyX(1) || BombChain || Item(2, ItemType.Long) ||
                        Item(2, ItemType.Ice) || Item(2, ItemType.Wave) || (Item(2, ItemType.Plasma) && ObtainUnkItems) ||
                        Item(2, ItemType.Missile) || Item(2, ItemType.Super) || Item(2, ItemType.Power) || Item(2, ItemType.Bomb));
                case 3:
                    return ActiveSpace || CanIBJ || (Hard && CanFreeze);
                case 4:
                    return Morph && Ledge_6_7 && BombBlock;
                case 5:
                    return BallSpark;
                case 6:
                    return CeilingTunnel_8p && (CeilingTunnel_1_2 || BombBlock);
                case 7:
                    return BombChain && CeilingTunnel_1_2;
                case 8:
                    return reachable[07] && LedgeNW_6_7 && CeilingTunnelNW_6_7 && AnyX(1);
                case 9:
                    return Morph && MissileX(1);
                case 10:
                    return reachable[07] && LedgeNW_6_7 && (HeatImmune || EnergyX(150) || Item(10, ItemType.Energy));
                case 11:
                    return Morph;
                case 12:
                    return Morph && AnyX(1);
                case 13:
                    return Morph && AnyX(1) && BombBlock;
                case 14:
                    return Morph && AnyX(1);
                case 15:
                    return reachable[07];
                case 16:
                    return MissileX(1) && BombChain && CeilingTunnel_1_2;
                case 17:
                    return Morph && AnyX(1);
                case 18:
                    return Morph && AnyX(1);
                case 19:
                    return BombBlock && CeilingTunnel_3_4 && (reachable[29] || (ActiveGravity && LedgeNW_8p));
                case 20:
                    return Morph && BombBlock && (BombChain || (AnyX(1) && BallSpark));
                case 21:
                    return Morph && BombBlock && ((Ledge_4_5 && reachable[29]) || (Grip && IWJ));
                case 22:
                    return reachable[23] && AnyX(1) && (Launcher || Speed);
                case 23:
                    return reachable[19] && BombChain;
                case 24:
                    return BombBlock && CeilingTunnel_3_4 && ActiveGravity && BallSpark;
                case 25:
                    return reachable[23] && AnyX(1);
                case 26:
                    return reachable[29];
                case 27:
                    return Morph && BombBlock && AnyX(1);
                case 28:
                    return reachable[23];
                case 29:
                    return BombBlock && AnyX(1) && Launcher && (Grip || Ledge_8p) && CeilingTunnel_5;
                case 30:
                    return Morph && BombBlock && AnyX(1) && Speed;
                case 31:
                    return BombBlock && AnyX(1) && Launcher;
                case 32:
                    return NorHeatRun && AnyX(3) && CeilingTunnel_1_2 && ActiveGravity && LedgeNW_8p;
                case 33:
                    return NorHeatRun && AnyX(3) && ((ActiveGravity && Ledge_4_5) || (Grip && ((Varia && EnergyX(350)) || EnergyX(600))));
                case 34:
                    return NorHeatRun && Ledge_8p && (Screw || AnyX(4));
                case 35:
                    return NorHeatRun && Ledge_8p && Screw;
                case 36:
                    return BombChain && CeilingTunnel_5;
                case 37:
                    return BombChain && (Long || Wave || ActivePlasma || AnyX(1) || BombChain) && CeilingTunnel_5;
                case 38:
                    return NorHeatRun;
                case 39:
                    return NorShaft && (Speed || Screw) && SuperX(1);
                case 40:
                    return NorHeatRun && CeilingTunnel_3_4 && LedgeNW_6_7;
                case 41:
                    return NorHeatRun && LedgeNW_6_7;
                case 42:
                    return NorShaft && (Speed || Screw) && SuperX(1);
                case 43:
                    return NorHeatRun && SuperX(1) && (LedgeNW_8p || (CanFreeze && CeilingTunnel_3_4));
                case 44:
                    return NorHeatRun && SuperX(1) && (CeilingTunnelNW_8p || CanFreeze);
                case 45:
                    return NorShaft && (Grip || CanIBJ || ActiveSpace || IWJ);
                case 46:
                    return NorShaft && (HeatImmune || EnergyX(120) || locations[46].NewItem == ItemType.Energy);
                case 47:
                    return (reachable[45] && CeilingTunnel_8p) || (NorShaft && (Speed || Screw) && AnyX(1));
                case 48:
                    return BombChain && (LedgeNW_8p || Speed);
                case 49:
                    return reachable[45] && ((Ice && !RandEnemies && CeilingTunnel_3_4) || CeilingTunnel_8p);
                case 50:
                    return NorHeatRun && Speed && CeilingTunnel_3_4 && (Bomb || PowerX(1) || ActivePlasma);
                case 51:
                    return (reachable[45] && CeilingTunnel_8p) || (NorShaft && (Speed || Screw) && CeilingTunnel_6_7);
                case 52:
                    return (reachable[45] && CeilingTunnel_8p) || reachable[50];
                case 53:
                    return reachable[52] && Speed && Grip;
                case 54:
                    return reachable[52] && Speed && Grip;
                case 55:
                    return reachable[52] && (Launcher || Speed);
                case 56:
                    return reachable[52] && (Launcher || Speed);
                case 57:
                    return reachable[52] && (Launcher || Speed);
                case 58:
                    return reachable[52] && (Launcher || Speed);
                case 59:
                    return reachable[52] && (Launcher || Speed);
                case 60:
                    return reachable[52] && (Launcher || Speed);
                case 61:
                    return reachable[52] && (Launcher || Speed);
                case 62:
                    return reachable[52] && (Launcher || Speed);
                case 63:
                    return reachable[52] && (Launcher || Speed);
                case 64:
                    return reachable[52] && (Launcher || Speed);
                case 65:
                    return reachable[52] && (Launcher || Speed);
                case 66:
                    return reachable[52] && (Launcher || Speed);
                case 67:
                    return reachable[52] && (Launcher || Speed) && SuperX(1);
                case 68:
                    return reachable[52] && (Launcher || Speed);
                case 69:
                    return reachable[52] && (Launcher || Speed);
                case 70:
                    return reachable[52] && (Launcher || Speed) && LedgeNW_8p;
                case 71:
                    return reachable[52] && Speed && Grip;
                case 72:
                    return reachable[52] && Speed && Wave;
                case 73:
                    return FullyPowered && SuperX(1) && Speed;
                case 74:
                    return FullyPowered && SuperX(1);
                case 75:
                    return reachable[36] && BallSpark && PowerX(1);
                case 76:
                    return reachable[36];
                case 77:
                    return reachable[36];
                case 78:
                    return reachable[36];
                case 79:
                    return reachable[36];
                case 80:
                    return reachable[36] && BallSpark;
                case 81:
                    return reachable[36] && Speed;
                case 82:
                    return FullyPowered;
                case 83:
                    return FullyPowered;
                case 84:
                    return FullyPowered;
                case 85:
                    return FullyPowered;
                case 86:
                    return FullyPowered;
                case 87:
                    return FullyPowered && Gravity && Speed;
                case 88:
                    return FullyPowered;
                case 89:
                    return FullyPowered && Speed;
                case 90:
                    // gravity not technically required
                    return FullyPowered && Gravity;
                case 91:
                    return FullyPowered;
                case 92:
                    return FullyPowered;
                case 93:
                    return FullyPowered;
                case 94:
                    return FullyPowered && Gravity && Speed;
                case 95:
                    return FullyPowered;
                case 96:
                    return FullyPowered;
                case 97:
                    return FullyPowered;
                case 98:
                    return FullyPowered && Speed;
                case 99:
                    return FullyPowered;
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
                if (items.Count == 0) { break; }

                var itemStrings = items.ConvertAll(n => $"{n}-{locations[n].NewItem}");
                string line = string.Join(", ", itemStrings.ToArray());
                sb.AppendLine($"Round {round}");
                sb.AppendLine(line);
                round++;
            }

            return sb.ToString().Trim();
        }

    }
}
