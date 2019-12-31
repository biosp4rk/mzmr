using System;

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

        // complete
        private bool VariaFromLeft;
        private bool VariaFromRight;
        private bool BeforeVaria;
        private bool BriTopPath;
        private bool KraStart;
        private bool KraAcidPit;
        private bool KraZiplines;
        private bool KraBossUpperArea;
        private bool KraBossLowerArea;
        private bool NorKraShortcut;
        private bool KraBoss;
        private bool NorStart;
        private bool NorTopLeft;
        private bool NorPastVine;
        private bool NorFallDownShaft;
        private bool HiJumpFromAbove;
        private bool HiJumpFromBelow;
        private bool NorHeatRun;
        private bool KraNorShortcut;
        private bool NorBottomLeft;
        private bool NorPastCaterpillars;
        private bool NorBottomOfShaft;
        private bool RidStart;
        private bool RidRightPath;
        private bool RidLeftPath;
        private bool RidRightShaft;
        private bool RidBoss;
        private bool CraBigRoom;
        private bool CraGrip;
        private bool CraViaBri;
        private bool EscapeZebes;
        private bool ChozoGhost;
        private bool FullyPowered;
        private bool CraToChoTop;
        private bool CraToChoBottom;
        private bool MotherShip;

        // segments
        private bool LeaveLongBeam1;
        private bool LeaveLongBeam2;
        private bool NorShortcut;
        private bool LeaveKraid;
        private bool KraReoRoom;
        private bool NorFirstGap;
        private bool LeaveNorViaBri;
        private bool LeaveRid;
        private bool RidBossGap;
        private bool LeaveRidBoss;
        private bool CraElevatorToBri;
        private bool ToShipFromLeft;
        private bool ChoLavaRun;

        // misc
        private bool BallJump;
        private bool CanIBJ;
        private bool BombBlock;
        private bool BombChain;
        private bool BallLauncher;
        private bool BallSpark;
        private bool HeatImmune;
        private bool ActiveUnkItems;
        private bool ActiveSpace;
        private bool ActiveGravity;
        private bool ActivePlasma;
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
        private readonly bool ChozoHints;
        private readonly bool IBJ;
        private readonly bool IWJ;
        private readonly bool NoSoftlocks;
        private readonly bool ObtainUnkItems;

        private readonly Location[] locations;

        public Conditions(Settings settings, Location[] locations)
        {
            IceNotReq = settings.iceNotRequired;
            PlasmaNotReq = settings.plasmaNotRequired;
            ChozoHints = settings.chozoStatueHints;
            IBJ = settings.infiniteBombJump;
            IWJ = settings.wallJumping;
            NoSoftlocks = false;
            ObtainUnkItems = settings.obtainUnkItems;

            this.locations = locations;

            // set all unobtained
            Energy = 0;
            Missile = 0;
            Super = 0;
            Power = 0;

            // find all obtainable items
            bool[] reachableLocations = new bool[100];
            while (true)
            {
                bool increase = UpdateReplacements();

                for (int i = 0; i < 100; i++)
                {
                    if (!reachableLocations[i] && IsObtainable(i))
                    {
                        reachableLocations[i] = true;
                        SetObtainable(locations[i].NewItem);
                        increase = true;
                        //Console.Write(i + ",");
                    }
                }
                //Console.WriteLine();
                if (!increase) { break; }
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
            return MotherShip && (Plasma || PlasmaNotReq);
        }

        public bool Is100Able(int removed)
        {
            if (!(Plasma || PlasmaNotReq)) { return false; }

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

            if (!VariaFromLeft)
            {
                VariaFromLeft = BombBlock && CeilingTunnel_1_2;
                increase |= VariaFromLeft;
            }
            if (!VariaFromRight)
            {
                VariaFromRight = MissileX(1) && (CanIBJ || ActiveSpace || (Ice && Hi && IWJ)) && CeilingTunnel_1_2;
                increase |= VariaFromRight;
            }
            if (!BeforeVaria)
            {
                BeforeVaria = (VariaFromLeft || VariaFromLeft) && (Hi || CanIBJ || ActiveSpace);
                increase |= BeforeVaria;
            }
            if (!BriTopPath)
            {
                BriTopPath = VariaFromLeft && Morph && (Bomb || Hi || Grip) && CeilingTunnel_3_4 && !ChozoHints;
                increase |= BriTopPath;
            }
            if (!KraStart)
            {
                KraStart = BombBlock;
                increase |= KraStart;
            }
            if (!KraAcidPit)
            {
                KraAcidPit = KraStart && CeilingTunnel_3_4 && BombChain && CeilingTunnel_1_2 && (KraZiplines || ActiveSpace || (ActiveGravity && CanIBJ));
                increase |= KraAcidPit;
            }
            if (!KraZiplines)
            {
                KraZiplines = KraStart && MissileX(1) && BallLauncher && (CanIBJ || Grip);
                increase |= KraZiplines;
            }
            if (!KraBossUpperArea)
            {
                KraBossUpperArea = KraAcidPit && (Bomb || PowerX(2)) && LeaveKraid;
                increase |= KraBossUpperArea;
            }
            if (!KraBossLowerArea)
            {
                KraBossLowerArea = KraBossUpperArea || NorKraShortcut;
                increase |= KraBossLowerArea;
            }
            if (!NorKraShortcut)
            {
                NorKraShortcut = NorHeatRun && MissileX(1) && CeilingTunnel_6_7 && PowerX(1) && Screw;
                increase |= NorKraShortcut;
            }
            if (!KraBoss)
            {
                KraBoss = KraBossLowerArea && MissileX(1);
                increase |= KraBoss;
            }
            if (!NorStart)
            {
                NorStart = Morph && BombChain && (LeaveNorViaBri || CraElevatorToBri);
                increase |= NorStart;
            }
            if (!NorTopLeft)
            {
                NorTopLeft = NorStart && (Long || MissileX(1) || Bomb || PowerX(1)) && (NoSoftlocks || CeilingTunnel_3_4 || CraElevatorToBri);
                increase |= NorTopLeft;
            }
            if (!NorPastVine)
            {
                NorPastVine = NorStart;
                increase |= NorPastVine;
            }
            if (!NorFallDownShaft)
            {
                NorFallDownShaft = NorPastVine && ((Grip && (Ice || IWJ || ActiveSpace)) || CanIBJ) && MissileX(1) && BombChain;
                increase |= NorFallDownShaft;
            }
            if (!HiJumpFromAbove)
            {
                HiJumpFromAbove = NorPastVine && (Screw || Speed) && MissileX(1);
                increase |= HiJumpFromAbove;
            }
            if (!HiJumpFromBelow)
            {
                HiJumpFromBelow = NorBottomOfShaft && ((BallJump && MissileX(1) && (Wave || Bomb || PowerX(1))) || Speed);
                increase |= HiJumpFromBelow;
            }
            if (!NorHeatRun)
            {
                NorHeatRun = (HiJumpFromAbove || HiJumpFromBelow) && MissileX(1) && BombChain && ((Speed && IWJ) || CanIBJ || ActiveSpace) && (HeatImmune || EnergyX(5));
                increase |= NorHeatRun;
            }
            if (!KraNorShortcut)
            {
                KraNorShortcut = KraBossLowerArea && Screw && Morph && PowerX(1) && MissileX(1);
                increase |= KraNorShortcut;
            }
            if (!NorBottomLeft)
            {
                NorBottomLeft = NorHeatRun || KraNorShortcut;
                increase |= NorBottomLeft;
            }
            if (!NorPastCaterpillars)
            {
                NorPastCaterpillars = NorBottomLeft && Morph && (Hi || (Bomb && (Grip || CanIBJ))) && (((Wave || MissileX(2)) && (Bomb || ActivePlasma)) || PowerX(1));
                increase |= NorPastCaterpillars;
            }
            if (!NorBottomOfShaft)
            {
                NorBottomOfShaft = NorFallDownShaft || NorPastCaterpillars;
                increase |= NorBottomOfShaft;
            }
            if (!RidStart)
            {
                RidStart = NorBottomOfShaft && MissileX(1) && BombChain && LeaveRid;
                increase |= RidStart;
            }
            if (!RidRightPath)
            {
                RidRightPath = RidStart && MissileX(1) && (CanIBJ || Ice || ActiveSpace) && (Bomb || PowerX(1)) && CeilingTunnel_5;
                increase |= RidRightPath;
            }
            if (!RidLeftPath)
            {
                RidLeftPath = RidStart && SuperX(1);
                increase |= RidLeftPath;
            }
            if (!RidRightShaft)
            {
                RidRightShaft = RidRightPath || RidLeftPath;
                increase |= RidRightShaft;
            }
            if (!RidBoss)
            {
                RidBoss = RidRightShaft && CeilingTunnel_3_4 && LeaveRidBoss;
                increase |= RidBoss;
            }
            if (!CraBigRoom)
            {
                CraBigRoom = NorTopLeft && (CeilingTunnel_1_2 || (ActiveSpace && Screw));
                increase |= CraBigRoom;
            }
            if (!CraGrip)
            {
                CraGrip = CraBigRoom && (Grip || CanIBJ || ActiveSpace);
                increase |= CraGrip;
            }
            if (!CraViaBri)
            {
                CraViaBri = Morph && PowerX(1) && BallLauncher;
                increase |= CraViaBri;
            }
            if (!EscapeZebes)
            {
                EscapeZebes = KraBoss && RidBoss && (Ice || IceNotReq) && ToShipFromLeft;
                increase |= EscapeZebes;
            }
            if (!ChozoGhost)
            {
                ChozoGhost = EscapeZebes || CraToChoTop || CraToChoBottom;
                increase |= ChozoGhost;
            }
            if (!FullyPowered)
            {
                FullyPowered = ChozoGhost && (ChoLavaRun || (PowerX(1) && (Bomb || PowerX(3)) && Screw));
                increase |= FullyPowered;
            }
            if (!CraToChoTop)
            {
                CraToChoTop = CraBigRoom && (CanIBJ || Speed || ActiveSpace) && PowerX(1) && MissileX(1);
                increase |= CraToChoTop;
            }
            if (!CraToChoBottom)
            {
                CraToChoBottom = NorTopLeft && PowerX(1);
                increase |= CraToChoBottom;
            }
            if (!MotherShip)
            {
                MotherShip = FullyPowered || CraToChoTop || CraToChoBottom;
                increase |= MotherShip;
            }
            if (!LeaveLongBeam1)
            {
                LeaveLongBeam1 = Bomb || Long || Wave || ActivePlasma || MissileX(1) || SuperX(1) || PowerX(1);
                increase |= LeaveLongBeam1;
            }
            if (!LeaveLongBeam2)
            {
                ItemType item = locations[2].NewItem;
                LeaveLongBeam2 = item == ItemType.Bomb || item == ItemType.Long || item == ItemType.Wave ||
                    (item == ItemType.Plasma && ActiveUnkItems) || item == ItemType.Missile || item == ItemType.Super || item == ItemType.Power;
                increase |= LeaveLongBeam2;
            }
            if (!NorShortcut)
            {
                NorShortcut = Screw && Morph && PowerX(1) && MissileX(1);
                increase |= NorShortcut;
            }
            if (!LeaveKraid)
            {
                LeaveKraid = NoSoftlocks || KraReoRoom || (NorShortcut && NorHeatRun);
                increase |= LeaveKraid;
            }
            if (!KraReoRoom)
            {
                KraReoRoom = KraZiplines || Speed || ActiveSpace;
                increase |= KraReoRoom;
            }
            if (!NorFirstGap)
            {
                NorFirstGap = Speed || Hi || Grip || ActiveSpace || CanIBJ;
                increase |= NorFirstGap;
            }
            if (!LeaveNorViaBri)
            {
                LeaveNorViaBri = NoSoftlocks || Screw || ((Grip && (Ice || IWJ || Speed || ActiveSpace)) || (Ice && (CanIBJ || Hi)) || (SuperX(2) && CanIBJ)) || BallSpark;
                increase |= LeaveNorViaBri;
            }
            if (!LeaveRid)
            {
                LeaveRid = NoSoftlocks || (CeilingTunnel_3_4 && (Speed || BallLauncher));
                increase |= LeaveRid;
            }
            if (!RidBossGap)
            {
                RidBossGap = Ice || Hi || IWJ || CanIBJ || ActiveSpace;
                increase |= RidBossGap;
            }
            if (!LeaveRidBoss)
            {
                LeaveRidBoss = NoSoftlocks || Ice || CanIBJ || ActiveSpace;
                increase |= LeaveRidBoss;
            }
            if (!CraElevatorToBri)
            {
                CraElevatorToBri = Morph && PowerX(1) && ActiveGravity && Speed;
                increase |= CraElevatorToBri;
            }
            if (!ToShipFromLeft)
            {
                ToShipFromLeft = Speed || (Hi && IWJ) || CanIBJ || ActiveSpace;
                increase |= ToShipFromLeft;
            }
            if (!ChoLavaRun)
            {
                ChoLavaRun = (IWJ && (EnergyX(3) || (Varia && EnergyX(2)))) || (Gravity && (IWJ || Space));
                increase |= ChoLavaRun;
            }
            if (!BallJump)
            {
                BallJump = Morph && (Bomb || Hi);
                increase |= BallJump;
            }
            if (!CanIBJ)
            {
                CanIBJ = IBJ && Morph && Bomb;
                increase |= CanIBJ;
            }
            if (!BombBlock)
            {
                BombBlock = (Morph && (Bomb || PowerX(1))) || Screw;
                increase |= BombBlock;
            }
            if (!BombChain)
            {
                BombChain = Morph && (Bomb || PowerX(1));
                increase |= BombChain;
            }
            if (!BallLauncher)
            {
                BallLauncher = Morph && Bomb;
                increase |= BallLauncher;
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
            if (!ActiveUnkItems)
            {
                ActiveUnkItems = ObtainUnkItems || FullyPowered;
                increase |= ActiveUnkItems;
            }
            if (!ActiveSpace)
            {
                ActiveSpace = Space && ActiveUnkItems;
                increase |= ActiveSpace;
            }
            if (!ActiveGravity)
            {
                ActiveGravity = Gravity && ActiveUnkItems;
                increase |= ActiveGravity;
            }
            if (!ActivePlasma)
            {
                ActivePlasma = Plasma && ActiveUnkItems;
                increase |= ActivePlasma;
            }
            if (!CeilingTunnel_1_2)
            {
                CeilingTunnel_1_2 = BallJump;
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
                    return true;
                case 1:
                    return BallLauncher;
                case 2:
                    return Morph && (NoSoftlocks || LeaveLongBeam1 || LeaveLongBeam2);
                case 3:
                    return CanIBJ || ActiveSpace;
                case 4:
                    return Morph && BombBlock;
                case 5:
                    return BallSpark;
                case 6:
                    return CeilingTunnel_8p && (NoSoftlocks || (Morph && BombBlock) || CeilingTunnel_1_2);
                case 7:
                    return BombChain && BallJump;
                case 8:
                    return BeforeVaria && CeilingTunnel_1_2 && (Grip || CanIBJ) && BombChain && MissileX(1);
                case 9:
                    return Morph && Missile > 0;
                case 10:
                    return BeforeVaria && CeilingTunnel_1_2 && (HeatImmune || EnergyX(1) || locations[10].NewItem == ItemType.Energy) && (Long || MissileX(5) || Bomb || PowerX(1));
                case 11:
                    return Morph;
                case 12:
                    return Morph && (MissileX(1) || BriTopPath);
                case 13:
                    return Morph && (MissileX(1) || BriTopPath) && (Bomb || (NoSoftlocks && (Screw || PowerX(1))));
                case 14:
                    return Morph && (MissileX(1) || BriTopPath);
                case 15:
                    return VariaFromLeft || VariaFromRight;
                case 16:
                    return Morph && MissileX(1) && (Bomb || (PowerX(1) && Hi));
                case 17:
                    return Morph && MissileX(1);
                case 18:
                    return Morph && (MissileX(1) || BriTopPath);
                case 19:
                    return KraAcidPit && CeilingTunnel_5;
                case 20:
                    return KraStart && (Bomb || PowerX(1) || (MissileX(1) && BallSpark));
                case 21:
                    return KraZiplines && BallJump;
                case 22:
                    return KraBossUpperArea && MissileX(1) && KraZiplines;
                case 23:
                    return KraBossUpperArea && CeilingTunnel_3_4;
                case 24:
                    return KraStart && BombChain && BallSpark && ActiveGravity;
                case 25:
                    return KraBoss;
                case 26:
                    return KraZiplines;
                case 27:
                    return KraStart && MissileX(1);
                case 28:
                    return KraBossLowerArea;
                case 29:
                    return KraZiplines;
                case 30:
                    return KraStart && MissileX(1) && Speed;
                case 31:
                    return KraStart && MissileX(1) && BallLauncher;
                case 32:
                    return NorBottomLeft && MissileX(3) && (CanIBJ || ActiveSpace) && ActiveGravity;
                case 33:
                    return NorHeatRun && MissileX(3) && (EnergyX(10) || (Varia && EnergyX(6)) || ActiveGravity);
                case 34:
                    return (NorHeatRun && IWJ && (MissileX(2) || Screw)) || (RidBoss && Speed);
                case 35:
                    return Screw && ((NorHeatRun && IWJ && MissileX(1)) || (RidBoss && Speed));
                case 36:
                    return NorStart && (Grip || (Ice && Hi) || CanIBJ);
                case 37:
                    return NorTopLeft && CeilingTunnel_5;
                case 38:
                    return NorBottomLeft && (MissileX(1) || PowerX(1)) && BombChain;
                case 39:
                    return NorPastVine && (Screw || Speed) && SuperX(1) && (EnergyX(2) || (EnergyX(1) && Speed) || HeatImmune) && BombChain;
                case 40:
                    return NorBottomLeft && CeilingTunnel_3_4 && (EnergyX(1) || HeatImmune || locations[40].NewItem == ItemType.Energy || locations[41].NewItem == ItemType.Energy);
                case 41:
                    return NorBottomLeft && (EnergyX(1) || HeatImmune || locations[41].NewItem == ItemType.Energy || locations[40].NewItem == ItemType.Energy);
                case 42:
                    return NorPastVine && (Screw || Speed) && SuperX(1) && (EnergyX(2) || (EnergyX(1) && Speed) || HeatImmune);
                case 43:
                    return NorHeatRun && SuperX(1) && ((CanIBJ && (Hi || ActiveGravity)) || (Ice && (CanIBJ || Hi)) || (ActiveSpace && Grip));
                case 44:
                    return NorHeatRun && SuperX(1) && (CanIBJ || (Hi && (Ice || ActiveGravity)) || ActiveSpace);
                case 45:
                    return NorPastVine && (Grip || Hi || IWJ || ActiveSpace || CanIBJ);
                case 46:
                    return NorPastVine;
                case 47:
                    return (HiJumpFromAbove || HiJumpFromBelow) && MissileX(1);
                case 48:
                    return NorStart && NorFirstGap && (Speed || CanIBJ || ActiveSpace || (Ice && (Hi || Grip)));
                case 49:
                    return NorPastVine && ((Grip && (Ice || IWJ || ActiveSpace)) || CanIBJ);
                case 50:
                    return NorPastCaterpillars && MissileX(1);
                case 51:
                    return (HiJumpFromAbove && CeilingTunnel_6_7) || HiJumpFromBelow;
                case 52:
                    return NorBottomOfShaft && BallJump;
                case 53:
                    return RidRightShaft && MissileX(4) && Speed && Grip;
                case 54:
                    return RidRightShaft && MissileX(1) && Speed && Grip;
                case 55:
                    return RidLeftPath || (RidRightPath && MissileX(1) && (CanIBJ || (Grip && ActiveSpace)));
                case 56:
                    return RidBoss;
                case 57:
                    return RidBoss;
                case 58:
                    return (RidLeftPath && (Grip || Ice || IWJ || CanIBJ || ActiveSpace)) || (RidRightPath && (CanIBJ || (Grip && ActiveSpace)));
                case 59:
                    return RidRightShaft && RidBossGap && CeilingTunnel_3_4 && (NoSoftlocks || BallLauncher);
                case 60:
                    return RidRightShaft && RidBossGap && CeilingTunnel_3_4 && (NoSoftlocks || BallLauncher);
                case 61:
                    return RidStart;
                case 62:
                    return RidRightShaft && RidBossGap && CeilingTunnel_3_4;
                case 63:
                    return RidRightShaft && RidBossGap;
                case 64:
                    return RidRightShaft;
                case 65:
                    return RidRightShaft && RidBossGap;
                case 66:
                    return RidRightShaft && CeilingTunnel_3_4;
                case 67:
                    return RidRightShaft && CeilingTunnel_3_4 && SuperX(1);
                case 68:
                    return RidRightShaft && CeilingTunnel_5;
                case 69:
                    return RidRightShaft && CeilingTunnel_3_4;
                case 70:
                    return (RidBoss || RidRightPath) && (Ice || (Hi && Grip && IWJ) || CanIBJ || ActiveSpace);
                case 71:
                    return RidRightShaft && Speed && Grip;
                case 72:
                    return RidRightShaft && Wave && Speed;
                case 73:
                    return FullyPowered && Speed;
                case 74:
                    return FullyPowered && SuperX(1);
                case 75:
                    return FullyPowered && BallSpark && PowerX(1);
                case 76:
                    return CraGrip;
                case 77:
                    return NorTopLeft;
                case 78:
                    return NorTopLeft && CeilingTunnel_1_2;
                case 79:
                    return NorTopLeft && CeilingTunnel_1_2;
                case 80:
                    return CraBigRoom && (IWJ || ActiveSpace) && BallSpark;
                case 81:
                    return CraBigRoom && (IWJ || ActiveSpace) && Speed;
                case 82:
                    return CraToChoTop;
                case 83:
                    return CraToChoBottom && ((Grip && Hi) || CanIBJ) && (Bomb || PowerX(2));
                case 84:
                    return CraToChoBottom && ((Grip && Hi) || CanIBJ);
                case 85:
                    return MotherShip && MissileX(1);
                case 86:
                    return FullyPowered && MissileX(2);
                case 87:
                    return FullyPowered && Speed && Gravity;
                case 88:
                    return FullyPowered && MissileX(1);
                case 89:
                    return CraToChoBottom && Speed;
                case 90:
                    return ChozoGhost && ChoLavaRun && ((Gravity && CeilingTunnel_3_4) || Grip);
                case 91:
                    return MotherShip;
                case 92:
                    return MotherShip && PowerX(1);
                case 93:
                    return CraToChoBottom && Speed;
                case 94:
                    return FullyPowered && Speed && Gravity;
                case 95:
                    return MotherShip && (SuperX(1) || PowerX(1));
                case 96:
                    return MotherShip;
                case 97:
                    return MotherShip && PowerX(1);
                case 98:
                    return MotherShip && Speed;
                case 99:
                    return MotherShip && SuperX(1) && PowerX(1);
                default:
                    throw new ArgumentException();
            }
        }


    }
}
