using mzmr.Properties;
using mzmr.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace mzmr.Randomizers
{
    internal class RandomBosses : RandomAspect
    {

        //rooms are imported in the same order as this emum
        public enum Bosses
        {
            Yakuza, Serris, Nightmare, BOX, MegaX, Arachnus, Kraid, Ridley, Mecha
        }
        private static Bosses newKraid = Bosses.Kraid, newRidley = Bosses.Ridley, newMecha = Bosses.Mecha;
        private const byte serrisID = 0xD2, yakuzaID = 0x8A, nightmareID = 0x6C, boxID = 0xD3,
            arachnusID = 0xD4, variaxID = 0xD5;
        private const Int32 kraidSpriteset = 0x2B2198, kraidDoorData = 0x33EAAC, ridleySpriteset = 0x2B2334,
            ridleyDoorData = 0x33F5EC, mechaSpriteset = 0x2B24F0, mechaDoorData = 0x33FE14;
        private bool kraidUsed = false, ridleyUsed = false, mechaUsed = false; //keeps track of what secondaries were replaced
        private readonly Int32 primaryStats, secondaryStats;

        public RandomBosses(Rom rom, Settings settings, Random rng) : base(rom, settings, rng)
        {
            primaryStats = rom.ReadPtr(0xE684);
            secondaryStats = rom.ReadPtr(0xE654);
        }


        public static string GetBoss(Bosses boss)
        {
            if (boss == Bosses.Mecha)
                return Enum.GetName(typeof(Bosses), newMecha);
            else if (boss == Bosses.Kraid)
                return Enum.GetName(typeof(Bosses), newKraid);
            else 
                return Enum.GetName(typeof(Bosses), newRidley);
        }
        public override RandomizeResult Randomize(CancellationToken cancellationToken)
        {
            if (!settings.RandoBosses)
                return new RandomizeResult(true);
            rom.ExpandROM();
            Patch.Apply(rom, Resources.ZM_U_bossRooms);
            Patch.Apply(rom, Resources.ZM_U_bossBase);
            GetNewBosses();
            ChangeKraid();
            ChangeRidley();
            ChangeMecha();
            return new RandomizeResult(true);

        }

        private void ChangeKraid()
        {
            switch (newKraid)   //adjust door data for room 
            {
                case Bosses.Yakuza:
                    rom.Write8(kraidSpriteset, yakuzaID);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 4, 0x11);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 5, 0x14);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 4, 0x1A);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 5, 0x1D);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 1, 0x2A);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 1, 0x2A);
                    rom.Write16(primaryStats + (yakuzaID * 0x12), 0x320); //health
                    break;
                case Bosses.Serris:
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 4, 0x7);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 5, 0xA);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 4, 0x10);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 5, 0x13);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 1, 0x2B);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 1, 0x2B);
                    rom.Write8(kraidSpriteset, serrisID);
                    rom.Write16(primaryStats + (serrisID * 0x12), 0x136); //health
                    break;
                case Bosses.Nightmare:
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 2, 0x13);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 3, 0x13);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 4, 0x8);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 5, 0xB);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 4, 0x11);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 5, 0x14);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 1, 0x2C);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 1, 0x2C);
                    rom.Write8(kraidSpriteset, nightmareID);
                    rom.Write16(primaryStats + (nightmareID * 0x12), 0x28A); //health
                    break;
                case Bosses.BOX:
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 4, 0x24);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 1, 0x2D);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 1, 0x2D);
                    rom.Write8(kraidSpriteset, boxID);
                    break;
                case Bosses.Arachnus:
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 4, 0x24);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 1, 0x2E);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 1, 0x2E);
                    rom.Write8(kraidSpriteset, arachnusID);
                    rom.Write16(primaryStats + (arachnusID * 0x12), 0x258); //health
                    break;
                case Bosses.Ridley:
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 4, 0x5);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 5, 0x8);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 4, 0xE);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 5, 0x11);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 1, 0x2F);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 1, 0x2F);
                    rom.Write8(0x32242, 0x1E); //event
                    rom.Write8(0x33CDC, 0x1E); //event
                    rom.Write8(0x33CE2, 0x1E); //event
                    rom.Write16(0x322C8, 0xE006); //skip gravity event check
                    rom.Write8(kraidSpriteset, 0x61);
                    rom.Write16(primaryStats + (0x61 * 0x12), 0x320); //health
                    break;
                case Bosses.MegaX:
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 4, 0x24);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 1, 0x30);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 1, 0x30);
                    rom.Write8(kraidSpriteset, variaxID);
                    break;
                default:
                    break;
            }
            if (newKraid !=Bosses.Kraid)
                rom.Write8(kraidDoorData + (0x51 * 0xC), 4);
        }

        private void ChangeRidley()
        {
            switch (newRidley)  //adjust door data and spriteset data for room
            {
                case Bosses.Yakuza:
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 4, 0x18);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 5, 0x1B);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 4, 0x18);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 5, 0x1B);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 1, 0x21);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 1, 0x21);
                    rom.Write16(primaryStats + (yakuzaID * 0x12), 0x3E8); //health
                    rom.Write16(primaryStats + 2 + (yakuzaID * 0x12), 0x32); //damage
                    rom.Write8(ridleySpriteset, yakuzaID);
                    break;
                case Bosses.Serris:
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 2, 0x1F);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 3, 0x1F);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 4, 0xE);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 5, 0x11);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 2, 2);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 3, 2);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 4, 0xE);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 5, 0x11);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 1, 0x22);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 1, 0x22);
                    rom.Write16(primaryStats + (serrisID * 0x12), 0x258); //health
                    rom.Write16(primaryStats + 2 + (serrisID * 0x12), 0x32); //damage
                    rom.Write8(ridleySpriteset, serrisID);
                    break;
                case Bosses.Nightmare:
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 2, 0x13);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 3, 0x13);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 4, 0xE);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 5, 0x11);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 2, 0x2);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 3, 0x2);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 4, 0xE);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 5, 0x11);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 1, 0x23);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 1, 0x23);
                    rom.Write16(primaryStats + (nightmareID * 0x12), 0x320); //health
                    rom.Write16(primaryStats + 2 + (nightmareID * 0x12), 0x32); //damage
                    rom.Write8(ridleySpriteset, nightmareID);
                    break;
                case Bosses.BOX:
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 2, 0x1C);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 3, 0x1C);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 2, 5);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 3, 5);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 1, 0x24);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 1, 0x24);
                    rom.Write8(ridleySpriteset, boxID);
                    break;
                case Bosses.Arachnus:
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 1, 0x25);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 1, 0x25);
                    rom.Write16(primaryStats + (arachnusID * 0x12), 0x320); //health
                    rom.Write16(primaryStats + 2 + (arachnusID * 0x12), 0x32); //damage
                    rom.Write8(ridleySpriteset, arachnusID);
                    break;
                case Bosses.Kraid:
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 2, 0x1F);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 3, 0x1F);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 4, 0x24);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 5, 0x27);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 2, 2);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 3, 2);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 4, 0x24);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 5, 0x27);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC), 2);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 1, 0x26);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 1, 0x26);
                    rom.Write8(0x19BBA, 0x25); //event
                    rom.Write8(0x19BC0, 0x25); //event
                    rom.Write16(primaryStats + (0x6F * 0x12), 0x3E8); //health
                    rom.Write16(primaryStats + 2 + (0x6F * 0x12), 0x3C); //main sprite damage
                    rom.Write16(0x2B1BE6 + (0x3 * 0x12), 0x3C); //secondaries damage
                    rom.Write16(0x2B1BE6 + (0x1C * 0x12), 0x4B);
                    rom.Write16(0x2B1BE6 + (0x1D * 0x12), 0x32);
                    rom.Write8(ridleySpriteset, 0x6F);
                    break;
                case Bosses.MegaX:
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 2, 0x1C);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 3, 0x1C);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 2, 5);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 3, 5);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 1, 0x27);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 1, 0x27);
                    rom.Write8(ridleySpriteset, variaxID);
                    break;
                default:
                    break;
            }
        }

        private void ChangeMecha()
        {
            switch (newMecha)
            {
                case Bosses.Yakuza:
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 1, 0x73);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 2, 0xA);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 3, 0xA);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 4, 0x1B);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 5, 0x1E);
                    rom.Write16(primaryStats + (yakuzaID * 0x12), 0x4B0); //health
                    rom.Write16(primaryStats + 2 + (yakuzaID * 0x12), 0x4B); //damage
                    rom.Write8(mechaSpriteset, yakuzaID);
                    break;
                case Bosses.Serris:
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 1, 0x74);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 4, 0x10);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 5, 0x13);
                    rom.Write16(primaryStats + (serrisID * 0x12), 0x320); //health
                    rom.Write16(primaryStats + 2 + (serrisID * 0x12), 0x64); //damage
                    rom.Write8(mechaSpriteset, serrisID);
                    break;
                case Bosses.Nightmare:
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 1, 0x75);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 4, 0x10);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 5, 0x13);
                    rom.Write16(primaryStats + (nightmareID * 0x12), 0x3E8); //health
                    rom.Write16(primaryStats + 2 + (nightmareID * 0x12), 0x64); //damage
                    rom.Write8(mechaSpriteset, nightmareID);
                    break;
                case Bosses.BOX:
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 1, 0x76);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 4, 0x10);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 5, 0x13);
                    rom.Write8(mechaSpriteset, boxID);
                    break;
                case Bosses.Arachnus:
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 1, 0x77);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 4, 0x10);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 5, 0x13);
                    rom.Write16(primaryStats + (arachnusID * 0x12), 0x3E8); //health
                    rom.Write16(primaryStats + 2 + (arachnusID * 0x12), 0x64); //damage
                    rom.Write8(mechaSpriteset, arachnusID);
                    break;
                case Bosses.Ridley:
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 1, 0x78);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 4, 0xE);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 5, 0x11);
                    rom.Write8(0x32242, 0x4A); //event
                    rom.Write16(0x322C8, 0xE006); //skip gravity event check
                    rom.Write16(0x33CDC, 0x4901);   //changes ridley code to call custom function for setting event and escape
                    rom.Write16(0x33CDE, 0xF056);
                    rom.Write16(0x33CE0, 0xFF8D);
                    rom.Write16(0x33CE2, 0xE012);
                    rom.WritePtr(0x33CE4, 0x80D3A5);
                    rom.Write16(primaryStats + (0x61 * 0x12), 0x5DC); //health
                    rom.Write16(primaryStats + 2 + (0x61 * 0x12), 0x4B); //main sprite damage
                    rom.Write16(0x2B1BE6 + (0x17 * 0x12), 0x4B); // secondary damage
                    rom.Write16(0x2B1BE6 + (0x18 * 0x12), 0x7D);
                    rom.Write16(0x2B1BE6 + (0x21 * 0x12), 0x28);
                    rom.Write16(0x2B1BE6 + (0x43 * 0x12), 0x4B);
                    rom.Write8(mechaSpriteset, 0x61);
                    break;
                case Bosses.MegaX:
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 1, 0x79);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 4, 0x10);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 5, 0x13);
                    rom.Write8(mechaSpriteset, variaxID);
                    break;
                default:
                    break;

            }
        }

        private void GetNewBosses()
        {
            //prevents the same boss from being chosen, prevents mecha from being anywhere other than its own room
            do
            {
                newKraid = (Bosses)rng.Next(0, Enum.GetValues(typeof(Bosses)).Cast<int>().Max() + 1);
            } while (newKraid == Bosses.Mecha);
            do
            {             
                newRidley = (Bosses)rng.Next(0, Enum.GetValues(typeof(Bosses)).Cast<int>().Max() + 1);
            } while (newRidley == newKraid || newRidley == Bosses.Mecha); 
            do
            {
                newMecha = (Bosses)rng.Next(0, Enum.GetValues(typeof(Bosses)).Cast<int>().Max() + 1);
            } while ((newMecha == newKraid) || (newMecha == newRidley) || (newMecha == Bosses.Kraid)); //kraid cannot be in mecha room

        }
        
        private bool IsUsed(Bosses boss)    //checks if vanilla boss is used in any boss location
        {
            if (newKraid == boss)
                return true;
            else if (newRidley == boss)
                return true;
            else if (newMecha == boss)
                return true;
            else
                return false;
        }

        public override string GetLog()
        {
            var changed = new List<string>();
            if (settings.RandoBosses)
            {
                changed.Add("Kraid: " + Enum.GetName(typeof(Bosses), newKraid));
                changed.Add("Ridley: " + Enum.GetName(typeof(Bosses), newRidley));
                changed.Add("Mecha: " + Enum.GetName(typeof(Bosses), newMecha));
            }
            if (changed.Count == 0)
                return "Bosses: Unchanged\n";
            return "Bosses: " + string.Join(", ", changed) + Environment.NewLine;
        }
    }
}
