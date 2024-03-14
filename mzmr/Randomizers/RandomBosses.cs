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

        public enum Bosses
        {
            Yakuza, Serris, Nightmare, BOX2, MegaX, Arachnus, Netorri, BOX, Kraid, Ridley, Mecha
        }
        private static Bosses newKraid = Bosses.Kraid, newRidley = Bosses.Ridley, newMecha = Bosses.Mecha;
        private const byte serrisID = 0xD2, yakuzaID = 0x8A, nightmareID = 0x6C, BOX2ID = 0xD3,
            arachnusID = 0xD4, variaxID = 0xD5, BOXID = 0xDA;
        private const Int32 kraidSpriteset = 0x2B2198, kraidDoorData = 0x33EAAC, ridleySpriteset = 0x2B2334,
            ridleyDoorData = 0x33F5EC, mechaSpriteset = 0x2B24F0, mechaDoorData = 0x33FE14;
        private readonly Int32 primaryStats, secondaryStats;

        public RandomBosses(Rom rom, Settings settings, Random rng) : base(rom, settings, rng)
        {
            primaryStats = rom.PrimarySpriteStats;
            secondaryStats = rom.SecondarySpriteStats;
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
            switch (newKraid)   //adjust door and spriteset data for room 
            {
                case Bosses.Yakuza:
                    rom.Write8(kraidSpriteset, yakuzaID);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 4, 0x11);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 5, 0x14);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 4, 0x1A);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 5, 0x1D);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 1, 0x2A);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 1, 0x2A);
                    break;
                case Bosses.Serris:
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 4, 0x7);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 5, 0xA);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 4, 0x10);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 5, 0x13);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 1, 0x2B);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 1, 0x2B);
                    rom.Write8(kraidSpriteset, serrisID);
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
                    break;
                case Bosses.BOX2:
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 4, 0x24);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 1, 0x2D);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 1, 0x2D);
                    rom.Write8(kraidSpriteset, BOX2ID);
                    break;
                case Bosses.Arachnus:
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 4, 0x24);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 1, 0x2E);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 1, 0x2E);
                    rom.Write8(kraidSpriteset, arachnusID);
                    break;
                case Bosses.Ridley:
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 4, 0x5);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 5, 0x8);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 4, 0xE);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 5, 0x11);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 1, 0x2F);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 1, 0x2F);
                    rom.Write8(0x32242, 0x1E); 
                    rom.Write8(0x33CDC, 0x1E); 
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
                case Bosses.Netorri:
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 1, 0x31);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 1, 0x31);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 4, 0x24);
                    break;
                case Bosses.BOX:
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 4, 0x24);
                    rom.Write8(kraidDoorData + (0x48 * 0xC) + 1, 0x2D);
                    rom.Write8(kraidDoorData + (0x51 * 0xC) + 1, 0x2D);
                    rom.Write8(kraidSpriteset, BOXID);
                    break;

                default:
                    break;
            }
            if (newKraid !=Bosses.Kraid)
                rom.Write8(kraidDoorData + (0x51 * 0xC), 4);
        }

        private void ChangeRidley()
        {
            byte[] secondaryIDs = null, primaryIDs = null;
            switch (newRidley)  //adjust door data and spriteset data for room
            {
                case Bosses.Yakuza:
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 4, 0x18);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 5, 0x1B);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 4, 0x18);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 5, 0x1B);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 1, 0x21);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 1, 0x21);
                    rom.Write8(ridleySpriteset, yakuzaID);
                    secondaryIDs = new byte[] { 0x4D, 0x4E, 0x4F };
                    primaryIDs = new byte[] { yakuzaID };
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
                    rom.Write8(ridleySpriteset, serrisID);
                    secondaryIDs = new byte[] { 0x28 };
                    primaryIDs = new byte[] { serrisID };
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
                    rom.Write8(ridleySpriteset, nightmareID);
                    secondaryIDs = new byte[] { 0x50, 0x51, 0x52 };
                    primaryIDs = new byte[] { nightmareID };
                    break;
                case Bosses.BOX2:
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 2, 0x1C);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 3, 0x1C);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 2, 5);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 3, 5);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 1, 0x24);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 1, 0x24);
                    rom.Write8(ridleySpriteset, BOX2ID);
                    secondaryIDs = new byte[] { 0x53, 0x54 };
                    primaryIDs = new byte[] { BOX2ID };
                    break;
                case Bosses.Arachnus:
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 1, 0x25);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 1, 0x25);
                    rom.Write8(ridleySpriteset, arachnusID);
                    secondaryIDs = new byte[] { 0x56, 0x57, 0x58, 0x59 };
                    primaryIDs = new byte[] { arachnusID };
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
                    secondaryIDs = new byte[] { 0x3, 0x1C, 0x1D };
                    primaryIDs = new byte[] { 0x6F };
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
                    secondaryIDs = new byte[] { 0x5A, 0x5B, 0x5C };
                    primaryIDs = new byte[] { variaxID };
                    break;
                case Bosses.Netorri:
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 2, 0x1F);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 3, 0x1F);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 4, 0xE);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 5, 0x11);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 2, 2);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 3, 2);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 4, 0xE);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 5, 0x11);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 1, 0x28);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 1, 0x28);
                    secondaryIDs = new byte[] { 0x5D, 0x5E, 0x5F };
                    primaryIDs = new byte[] { 0xD6, 0xD7, 0xD8, 0xD9 };
                    break;
                case Bosses.BOX:
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 2, 0x1C);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 3, 0x1C);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 2, 5);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 3, 5);
                    rom.Write8(ridleyDoorData + (0x1D * 0xC) + 1, 0x24);
                    rom.Write8(ridleyDoorData + (0x1E * 0xC) + 1, 0x24);
                    rom.Write8(ridleySpriteset, BOXID);
                    secondaryIDs = new byte[] { 0x60, 0x61, 0x62 };
                    primaryIDs = new byte[] { BOXID };
                    break;
                default:
                    break;
            }
            if (newRidley != Bosses.Ridley)
            {
                ScaleSprites(secondaryIDs, 1.3);
                ScaleSprites(primaryIDs, 1.3, true);
            }
        }

        private void ChangeMecha()
        {
            byte[] secondaryIDs = null, primaryIDs = null;
            switch (newMecha) //adjust door data and spriteset data for room
            {
                case Bosses.Yakuza:
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 1, 0x73);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 2, 0xA);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 3, 0xA);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 4, 0x1B);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 5, 0x1E);
                    rom.Write8(mechaSpriteset, yakuzaID);
                    primaryIDs = new byte[] { yakuzaID };
                    secondaryIDs = new byte[] { 0x4D, 0x4E, 0x4F };
                    break;
                case Bosses.Serris:
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 1, 0x74);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 4, 0x10);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 5, 0x13);
                    rom.Write8(mechaSpriteset, serrisID);
                    primaryIDs = new byte[] { serrisID };
                    secondaryIDs = new byte[] { 0x28 };
                    break;
                case Bosses.Nightmare:
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 1, 0x75);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 4, 0x10);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 5, 0x13);
                    rom.Write8(mechaSpriteset, nightmareID);
                    secondaryIDs = new byte[] { 0x50, 0x51, 0x52 };
                    primaryIDs = new byte[] { nightmareID };
                    break;
                case Bosses.BOX2:
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 1, 0x76);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 4, 0x10);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 5, 0x13);
                    rom.Write8(mechaSpriteset, BOX2ID);
                    secondaryIDs = new byte[] { 0x53, 0x54 };
                    primaryIDs = new byte[] { BOX2ID };
                    break;
                case Bosses.Arachnus:
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 1, 0x77);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 4, 0x10);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 5, 0x13);
                    rom.Write8(mechaSpriteset, arachnusID);
                    primaryIDs = new byte[] { arachnusID };
                    secondaryIDs = new byte[] { 0x56, 0x57, 0x58, 0x59 };
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
                    rom.WritePtr(0x33CE4, 0x819462);
                    primaryIDs = new byte[] { 0x61 };
                    secondaryIDs = new byte[] { 0x17, 0x18, 0x21, 0x43 };
                    rom.Write8(mechaSpriteset, 0x61);
                    break;
                case Bosses.MegaX:
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 1, 0x79);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 4, 0x10);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 5, 0x13);
                    rom.Write8(mechaSpriteset, variaxID);
                    secondaryIDs = new byte[] { 0x5A, 0x5B, 0x5C };
                    primaryIDs = new byte[] { variaxID };
                    break;
                case Bosses.Netorri:
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 1, 0x7A);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 4, 0x10);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 5, 0x13);
                    secondaryIDs = new byte[] { 0x5D, 0x5E, 0x5F };
                    primaryIDs = new byte[] { 0xD6, 0xD7, 0xD8, 0xD9 };
                    break;
                case Bosses.BOX:
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 1, 0x76);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 4, 0x10);
                    rom.Write8(mechaDoorData + (0x9E * 0xC) + 5, 0x13);
                    rom.Write8(mechaSpriteset, BOXID);
                    secondaryIDs = new byte[] { 0x60, 0x61, 0x62 };
                    primaryIDs = new byte[] { BOXID };
                    break;
                default:
                    break;
            }
            if (newMecha != Bosses.Mecha)
            {
                ScaleSprites(secondaryIDs, 1.8);
                ScaleSprites(primaryIDs, 1.8, true);
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
        
        private void ScaleSprites(byte[] spriteIds, double Scale, bool isPrimary = false)
        {
            Int32 stats;
            if (isPrimary)
                stats = primaryStats;
            else
                stats = secondaryStats;
            for (int i = 0; i < spriteIds.Length; i++) 
            {
                Int32 offset = stats + (spriteIds[i] * 12);
                int health = rom.Read16(offset);
                if (health > 1) 
                    rom.Write16(offset, (ushort)(health * Scale));
                int damage = rom.Read16(offset + 2);
                if (damage > 1)
                    rom.Write16(offset + 2, (ushort)(damage * Scale));
            }
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
