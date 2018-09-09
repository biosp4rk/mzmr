using System;

namespace mzmr
{
    public class Conditions
    {
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

        private bool IceNotRequired;
        private bool PlasmaNotRequired;
        private bool ObtainUnk;
        private bool RemoveVine;
        private Location[] locations;

        // segments
        private bool KraidAcidPit;
        private bool KraidNorfairShortcut;
        private bool VineRoom;
        private bool FallDownShaft;
        private bool NorfairHeatRun;
        private bool KillLarva;
        private bool LeaveNorfair;
        private bool RidleyRightPath;
        private bool LeaveRidleyFight;
        private bool LeaveRidley;
        private bool EnterCrateria;
        private bool ToGrip;
        private bool ChozodiaTop;
        private bool ChozodiaBottom;
        private bool ChozodiaLavaRun;
        private bool LeaveRuinsTest;

        // from start
        private bool PastEnterKraid;
        private bool PastKraidAcidPit;
        private bool PastKraidNorfairShortcut;
        private bool PastEnterNorfair;
        private bool PastVineRoom;
        private bool PastNorfairShaftBottom;
        private bool PastHiJump;
        private bool PastNorfairHeatRun;
        private bool PastEnterRidley;
        private bool PastEnterCrateria;
        private bool PastMotherBrain;
        private bool FullyPowered;
        private bool FullyPoweredInZebes;

        // misc
        private bool GravityInZebes;
        private bool PlasmaInZebes;
        private bool SpaceInZebes;

        public Conditions(Settings settings, Location[] locations)
        {
            IceNotRequired = settings.iceNotRequired;
            PlasmaNotRequired = settings.plasmaNotRequired;
            ObtainUnk = settings.obtainUnkItems;
            RemoveVine = settings.removeNorfairVine;
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
                bool increase = UpdateReachableLocations();

                for (int i = 0; i < 100; i++)
                {
                    if (!reachableLocations[i] && IsObtainable(i))
                    {
                        reachableLocations[i] = true;
                        SetObtainable(locations[i].NewItem);
                        increase = true;
                    }
                }

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
            return ((PastMotherBrain && ChozodiaLavaRun) || (PastEnterCrateria && (ChozodiaTop || ChozodiaBottom))) && (Plasma || PlasmaNotRequired);
        }

        public bool Is100Able()
        {
            if (Energy != 12) { return false; }
            if (Missile != 50) { return false; }
            if (Super != 15) { return false; }
            if (Power != 9) { return false; }

            if (!Long) { return false; }
            if (!Charge) { return false; }
            if (!Ice) { return false; }
            if (!Wave) { return false; }
            if (!Plasma) { return false; }
            if (!Bomb) { return false; }
            if (!Varia) { return false; }
            if (!Gravity) { return false; }
            if (!Morph) { return false; }
            if (!Speed) { return false; }
            if (!Hi) { return false; }
            if (!Screw) { return false; }
            if (!Space) { return false; }
            if (!Grip) { return false; }

            return true;
        }

        private bool UpdateReachableLocations()
        {
            bool increase = false;

            // segments
            if (!KraidAcidPit)
            {
                KraidAcidPit = Morph && ((Bomb && (MissileX(1) || Grip)) || (PowerX(1) && Hi && (SpaceInZebes || (GravityInZebes && Speed))));
                increase |= KraidAcidPit;
            }
            if (!KraidNorfairShortcut)
            {
                KraidNorfairShortcut = Screw && Morph && PowerX(1) && MissileX(1);
                increase |= KraidNorfairShortcut;
            }
            if (!VineRoom)
            {
                VineRoom = (Bomb || Grip || Hi || Speed) && (ToGrip || RemoveVine);
                increase |= VineRoom;
            }
            if (!FallDownShaft)
            {
                FallDownShaft = Morph && (Bomb || (PowerX(1) && (Grip || (Ice && Hi)))) && MissileX(1);
                increase |= FallDownShaft;
            }
            if (!NorfairHeatRun)
            {
                NorfairHeatRun = Morph && ((Bomb && (EnergyX(2) || Varia || GravityInZebes)) || (PowerX(1) && ((Hi && Ice && (EnergyX(4) || Varia || GravityInZebes)) || (Speed && (EnergyX(2) || Varia || GravityInZebes)))));
                increase |= NorfairHeatRun;
            }
            if (!KillLarva)
            {
                KillLarva = Morph && (Bomb || (PowerX(1) && Hi));
                increase |= KillLarva;
            }
            if (!LeaveNorfair)
            {
                LeaveNorfair = Screw || Bomb || Grip || (Hi && (Ice || Speed));
                increase |= LeaveNorfair;
            }
            if (!LeaveRidley)
            {
                LeaveRidley = Morph && (Bomb || ((Hi || Grip) && Speed));
                increase |= LeaveRidley;
            }
            if (!RidleyRightPath)
            {
                RidleyRightPath = Bomb || (PowerX(1) && Grip && (Hi || Ice || Speed || SpaceInZebes));
                increase |= RidleyRightPath;
            }
            if (!LeaveRidleyFight)
            {
                LeaveRidleyFight = Bomb || Ice || SpaceInZebes;
                increase |= LeaveRidleyFight;
            }
            if (!EnterCrateria)
            {
                EnterCrateria = Morph && (Bomb || PowerX(1) || MissileX(1) || Long || Wave || Plasma || (Speed && Hi));
                increase |= EnterCrateria;
            }
            if (!ToGrip)
            {
                ItemType item = locations[76].NewItem;
                ToGrip = Morph && (Bomb || (PowerX(1) && Hi && (Grip || item == ItemType.Bomb || item == ItemType.Grip)));
                increase |= ToGrip;
            }
            if (!ChozodiaTop)
            {
                ChozodiaTop = PowerX(1) && (Bomb || ((Hi || Screw) && (Speed || SpaceInZebes)));
                increase |= ChozodiaTop;
            }
            if (!ChozodiaBottom)
            {
                ChozodiaBottom = PowerX(1) && Speed;
                increase |= ChozodiaBottom;
            }
            if (!ChozodiaLavaRun)
            {
                ChozodiaLavaRun = EnergyX(3) || (Varia && EnergyX(2)) || Gravity;
                increase |= ChozodiaLavaRun;
            }
            if (!LeaveRuinsTest)
            {
                LeaveRuinsTest = PowerX(1) && (Bomb || PowerX(4)) && Screw;
                increase |= LeaveRuinsTest;
            }

            // from start
            if (!PastEnterKraid)
            {
                PastEnterKraid = Morph && (Bomb || PowerX(1) || Screw);
                increase |= PastEnterKraid;
            }
            if (!PastKraidAcidPit)
            {
                PastKraidAcidPit = PastEnterKraid && KraidAcidPit;
                increase |= PastKraidAcidPit;
            }
            if (!PastKraidNorfairShortcut)
            {
                PastKraidNorfairShortcut = PastKraidAcidPit && KraidNorfairShortcut;
                increase |= PastKraidNorfairShortcut;
            }
            if (!PastEnterNorfair)
            {
                // TODO: proper solution for leaving Norfair
                PastEnterNorfair = Morph && (Bomb || PowerX(1) && LeaveNorfair);
                increase |= PastEnterNorfair;
            }
            if (!PastVineRoom)
            {
                PastVineRoom = PastEnterNorfair && VineRoom;
                increase |= PastVineRoom;
            }
            if (!PastNorfairShaftBottom)
            {
                // TODO: proper solution for getting back up shaft
                PastNorfairShaftBottom = PastVineRoom && (FallDownShaft || (PastNorfairHeatRun && Speed && KillLarva)) && (Bomb || Speed || Screw);
                increase |= PastNorfairShaftBottom;
            }
            if (!PastHiJump)
            {
                PastHiJump = PastVineRoom && (FallDownShaft || Speed || Screw) && MissileX(1);
                increase |= PastHiJump;
            }
            if (!PastNorfairHeatRun)
            {
                PastNorfairHeatRun = (PastHiJump && NorfairHeatRun) || PastKraidNorfairShortcut;
                increase |= PastNorfairHeatRun;
            }
            if (!PastEnterRidley)
            {
                // TODO: proper solution for leaving Ridley
                PastEnterRidley = PastNorfairShaftBottom && LeaveRidley;
                increase |= PastEnterRidley;
            }
            if (!PastEnterCrateria)
            {
                PastEnterCrateria = PastEnterNorfair && EnterCrateria;
                increase |= PastEnterCrateria;
            }
            if (!PastMotherBrain)
            {
                PastMotherBrain = PastKraidAcidPit && PastNorfairShaftBottom && LeaveRidley && (Ice || IceNotRequired);
                increase |= PastMotherBrain;
            }
            if (!FullyPowered)
            {
                FullyPowered = ((PastEnterCrateria && (ChozodiaTop || ChozodiaBottom)) || PastMotherBrain) && (Bomb || Space);
                increase |= FullyPowered;
            }
            if (!FullyPoweredInZebes)
            {
                FullyPoweredInZebes = FullyPowered && (ChozodiaLavaRun || LeaveRuinsTest) && (Bomb || Grip || (Speed && Hi));
                increase |= FullyPoweredInZebes;
            }

            // misc
            if (!GravityInZebes)
            {
                GravityInZebes = Gravity && (FullyPoweredInZebes || ObtainUnk);
                increase |= GravityInZebes;
            }
            if (!PlasmaInZebes)
            {
                PlasmaInZebes = Plasma && (FullyPoweredInZebes || ObtainUnk);
                increase |= PlasmaInZebes;
            }
            if (!SpaceInZebes)
            {
                SpaceInZebes = Space && (FullyPoweredInZebes || ObtainUnk);
                increase |= SpaceInZebes;
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
                    return Morph && Bomb;
                case 2:  // long beam
                    ItemType item = locations[locNum].NewItem;
                    return Morph && (Bomb || Long || Wave || (Plasma && ObtainUnk) || MissileX(1) || PowerX(1) ||
                        (item == ItemType.Bomb) || (item == ItemType.Long) || 
                        (item == ItemType.Wave) || ((item == ItemType.Plasma) && ObtainUnk) || 
                        (item == ItemType.Missile) || (item == ItemType.Super) || (item == ItemType.Power));
                case 3:  // ceiling energy tank
                    return (Morph && Bomb) || SpaceInZebes;
                case 4:
                    return Morph && (Bomb || PowerX(1) || Screw);
                case 5:  // ball spark
                    return Morph && Speed && Hi;
                case 6:  // connects top of shafts
                    return Morph && (Bomb || (Grip && (PowerX(1) || Screw || Hi)));
                case 7:  // ripper tunnel
                    return Morph && (Bomb || (Hi && (PowerX(1) || Speed)));
                case 8:  // varia suit
                    return Morph && (Bomb || (Hi && ((PowerX(1) || Screw) || (Ice || SpaceInZebes)))) && MissileX(1);
                case 9:  // king worm
                    return Morph && (Missile > 0);
                case 10:  // energy tank by varia
                    item = locations[locNum].NewItem;
                    return Morph && (Bomb || (Hi && ((PowerX(1) || Screw) || (MissileX(1) && (Ice || SpaceInZebes))))) &&
                        (EnergyX(1) || Varia || GravityInZebes || item == ItemType.Energy);
                case 11:
                    return Morph;
                case 12:  // behind hive
                    return Morph && (MissileX(1) || Bomb || ((PowerX(1) || Screw) && (Grip || Hi)));
                case 13:
                    return Morph && (Bomb || ((PowerX(1) || Screw) && (MissileX(1) || Grip || Hi)));
                case 14:
                    return Morph && (MissileX(1) || Bomb || ((PowerX(1) || Screw) && (Grip || Hi)));
                case 15:
                    return Morph && (Bomb || PowerX(1) || Screw || (MissileX(1) && (Ice || SpaceInZebes) && Hi));
                case 16:
                    return Morph && MissileX(1) && (Bomb || (PowerX(1) && Hi));
                case 17:
                    return Morph && MissileX(1);
                case 18:
                    return Morph && (MissileX(1) || Bomb || ((PowerX(1) || Screw) && (Grip || Hi)));
                case 19:  // could do acid worm skip with grip, but too difficult
                    return PastKraidAcidPit && (Bomb || Grip);
                case 20:
                    return PastEnterKraid && (Bomb || PowerX(1) || (MissileX(1) && Speed && Hi));
                case 21:  // sidehoppers and crumble blocks
                    return PastEnterKraid && (Bomb || Grip);
                case 22:  // zipline and crumble blocks
                    return PastKraidAcidPit && MissileX(1) && Bomb;
                case 23:  // space jump
                    return PastKraidAcidPit && (Bomb || PowerX(2) || Screw);
                case 24:  // kraid lava
                    return PastEnterKraid && (Bomb || PowerX(1)) && Speed && Hi && GravityInZebes;
                case 25:  // speed booster
                    return PastKraidAcidPit && (Bomb || PowerX(2) || Screw) && MissileX(1);
                case 26:
                    return PastEnterKraid && Bomb && MissileX(1);
                case 27:
                    return PastEnterKraid && MissileX(1);
                case 28:
                    return PastKraidAcidPit && (Bomb || PowerX(2) || Screw);
                case 29:
                    return PastEnterKraid && Bomb && MissileX(1);
                case 30:
                    return PastEnterKraid && Speed && MissileX(1);
                case 31:
                    return PastEnterKraid && Bomb && MissileX(1);
                case 32:
                    return PastNorfairHeatRun && (Bomb || SpaceInZebes) && MissileX(3) && GravityInZebes;
                case 33:
                    return PastNorfairHeatRun && MissileX(1) && (EnergyX(10) || (Varia && EnergyX(6)) || GravityInZebes);
                case 34:
                    return PastNorfairHeatRun && (MissileX(2) || Screw);
                case 35:
                    return PastNorfairHeatRun && MissileX(2) && Screw;
                case 36:
                    return PastEnterNorfair && (Bomb || Grip || (Ice && Hi));
                case 37:
                    return PastEnterCrateria;
                case 38:
                    return PastNorfairHeatRun && (Bomb || PowerX(1)) && MissileX(1);
                case 39:
                    return PastHiJump && SuperX(1) && (EnergyX(2) || (EnergyX(1) && Speed) || Varia || GravityInZebes);
                case 40:
                    ItemType item40 = locations[40].NewItem;
                    ItemType item41 = locations[41].NewItem;
                    return PastNorfairHeatRun & (EnergyX(1) || Varia || GravityInZebes || item40 == ItemType.Energy || item41 == ItemType.Energy);
                case 41:
                    item40 = locations[40].NewItem;
                    item41 = locations[41].NewItem;
                    return PastNorfairHeatRun & (EnergyX(1) || Varia || GravityInZebes || item40 == ItemType.Energy || item41 == ItemType.Energy);
                case 42:
                    return PastHiJump && SuperX(1) && (EnergyX(2) || (EnergyX(1) && Speed) || Varia || GravityInZebes);
                case 43:
                    return PastNorfairHeatRun && SuperX(1) && ((Bomb && Hi) || (Ice && (Bomb || Hi || Grip)) || (SpaceInZebes && Grip));
                case 44:
                    return PastNorfairHeatRun && SuperX(1) && (Bomb || SpaceInZebes || Ice || (GravityInZebes && Hi));
                case 45:
                    return PastVineRoom;
                case 46:
                    return PastVineRoom;
                case 47:
                    return PastHiJump;
                case 48:
                    return PastEnterNorfair && (Bomb || Speed || ((Grip || Hi) && SpaceInZebes));
                case 49:
                    return PastVineRoom;
                case 50:
                    return PastNorfairHeatRun && Speed && KillLarva;
                case 51:
                    return PastNorfairShaftBottom || (PastVineRoom && (Speed || Screw) && (Bomb || Grip));
                case 52:
                    return PastNorfairShaftBottom;
                case 53:
                    return PastEnterRidley && (RidleyRightPath || SuperX(1)) && MissileX(4) && Speed && Grip;
                case 54:
                    return PastEnterRidley && (RidleyRightPath || SuperX(1)) && MissileX(1) && Speed && Grip;
                case 55:
                    return PastEnterRidley && ((RidleyRightPath && (Bomb || (Grip & SpaceInZebes))) || SuperX(1));
                case 56:
                    return PastEnterRidley && (RidleyRightPath || SuperX(1)) && LeaveRidleyFight;
                case 57:
                    return PastEnterRidley && (RidleyRightPath || SuperX(1)) && LeaveRidleyFight;
                case 58:
                    return PastEnterRidley && ((RidleyRightPath && (Bomb || (Grip & SpaceInZebes))) || SuperX(1));
                case 59:
                    return PastEnterRidley && (RidleyRightPath || SuperX(1)) && (Bomb || Hi || Grip);
                case 60:
                    return PastEnterRidley && (RidleyRightPath || SuperX(1)) && (Bomb || Hi);
                case 61:
                    return PastEnterRidley;
                case 62:
                    return PastEnterRidley && (RidleyRightPath || SuperX(1)) && (Bomb || Hi);
                case 63:
                    return PastEnterRidley && (RidleyRightPath || SuperX(1));
                case 64:
                    return PastEnterRidley && (RidleyRightPath || SuperX(1));
                case 65:
                    return PastEnterRidley && (RidleyRightPath || SuperX(1));
                case 66:
                    return PastEnterRidley && (RidleyRightPath || SuperX(1));
                case 67:
                    return PastEnterRidley && SuperX(1);
                case 68:
                    return PastEnterRidley && (RidleyRightPath || SuperX(1)) && (Bomb || Grip);
                case 69:
                    return PastEnterRidley && (RidleyRightPath || SuperX(1));
                case 70:
                    return PastEnterRidley && RidleyRightPath && (Bomb || Hi || Ice || SpaceInZebes);
                case 71:
                    return PastEnterRidley && (RidleyRightPath || SuperX(1)) && MissileX(1) && Speed && Grip;
                case 72:
                    return PastEnterRidley && (RidleyRightPath || SuperX(1)) && MissileX(1) && Wave && Speed;
                case 73:
                    return FullyPoweredInZebes && Speed;
                case 74:
                    return FullyPoweredInZebes && SuperX(1);
                case 75:
                    return FullyPoweredInZebes && Speed && Hi;
                case 76:
                    return PastEnterCrateria && ToGrip;
                case 77:
                    return PastEnterCrateria;
                case 78:
                    return PastEnterCrateria && (Bomb || Hi);
                case 79:
                    return PastEnterCrateria && (Bomb || Hi);
                case 80:
                    return PastEnterCrateria && Speed && Hi;
                case 81:
                    return PastEnterCrateria && (Bomb || Hi) && Speed;
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
                    return FullyPowered;
                case 88:
                    return FullyPowered;
                case 89:
                    return FullyPowered;
                case 90:
                    return FullyPowered;
                case 91:
                    return FullyPowered;
                case 92:
                    return FullyPowered;
                case 93:
                    return FullyPowered;
                case 94:
                    return FullyPowered;
                case 95:
                    return FullyPowered;
                case 96:
                    return FullyPowered;
                case 97:
                    return FullyPowered;
                case 98:
                    return FullyPowered;
                case 99:
                    return FullyPowered;
                default:
                    throw new ArgumentException();
            }
        }


    }
}
