using mzmr.Properties;
using mzmr.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace mzmr.Randomizers
{
    public class RandomBosses : RandomAspect
    {

        public enum Bosses
        {
            Yakuza, Serris, Nightmare, BOX2, MegaX, Arachnus, Netorri, BOX, Kraid, Ridley, Mecha, Mua
        }
        private static Bosses newKraid = Bosses.Kraid, newRidley = Bosses.Ridley, newMecha = Bosses.Mecha;
        private static Bosses newMua = Bosses.Mua;
        private const byte serrisID = 0xD2, yakuzaID = 0x8A, nightmareID = 0x6C, BOX2ID = 0xD3,
            arachnusID = 0xD4, variaxID = 0xD5, BOXID = 0xDA;
        private const Int32 kraidSpriteset = 0x2B2198, ridleySpriteset = 0x2B2334, mechaSpriteset = 0x2B24F0,
            muaSpriteset = 0x2B23DE;
        private readonly Int32 primaryStats, secondaryStats;
        private readonly byte[] nettoriSpriteset = new byte[]{ 0xD6, 0, 0xD9, 0, 0xD7, 0, 0xD8, 0, 0, 0}; 

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
            else if (boss == Bosses.Mua)
                return Enum.GetName(typeof(Bosses), newMua);
            else 
                return Enum.GetName(typeof(Bosses), newRidley);
        }

        public override RandomizeResult Randomize(CancellationToken cancellationToken)
        {
            if (!settings.RandoBosses)
                return new RandomizeResult(true);;
            Patch.Apply(rom, Resources.ZM_U_bossBase);
            rom.WritePtr(0x75F48C, rom.WriteToEnd(nettoriSpriteset)); //change spriteset 6C to nettori set
            GetNewBosses();
            ChangeKraid();
            ChangeMua();
            ChangeRidley();
            ChangeMecha();
            return new RandomizeResult(true);

        }

        private void ChangeKraid()
        {
            switch (newKraid)   //import room and adjust spriteset data for room
            {
                case Bosses.Yakuza:
                    Room.Import(rom, Resources.kraid_yakuza, 0x1E, 1);
                    rom.Write8(kraidSpriteset, yakuzaID);
                    break;
                case Bosses.Serris:
                    Room.Import(rom, Resources.kraid_serris, 0x1E, 1);
                    rom.Write8(kraidSpriteset, serrisID);
                    break;
                case Bosses.Nightmare:
                    Room.Import(rom, Resources.kraid_nightmare, 0x1E, 1);
                    rom.Write8(kraidSpriteset, nightmareID);
                    break;
                case Bosses.BOX2:
                    Room.Import(rom, Resources.kraid_box, 0x1E, 1);
                    rom.Write8(kraidSpriteset, BOX2ID);
                    break;
                case Bosses.Arachnus:
                    Room.Import(rom, Resources.kraid_arachnus, 0x1E, 1);
                    rom.Write8(kraidSpriteset, arachnusID);
                    break;
                case Bosses.Ridley:
                    Room.Import(rom, Resources.kraid_ridley, 0x1E, 1);
                    rom.Write8(0x32242, 0x1E); 
                    rom.Write8(0x33CDC, 0x1E); 
                    rom.Write8(0x33CE2, 0x1E); //event
                    rom.Write16(0x322C8, 0xE006); //skip gravity event check
                    rom.Write8(kraidSpriteset, 0x61);
                    rom.Write16(primaryStats + (0x61 * 0x12), 0x320); //health
                    break;
                case Bosses.MegaX:
                    Room.Import(rom, Resources.kraid_megax, 0x1E, 1);
                    rom.Write8(kraidSpriteset, variaxID);
                    break;
                case Bosses.Netorri:
                    Room.Import(rom, Resources.kraid_nettori, 0x1E, 1);
                    break;
                case Bosses.BOX:
                    Room.Import(rom, Resources.kraid_box, 0x1E, 1);
                    rom.Write8(kraidSpriteset, BOXID);
                    break;

                default:
                    break;
            }
        }

        private void ChangeRidley()
        {
            byte[] secondaryIDs = null, primaryIDs = null;
            switch (newRidley)  //import room and adjust spriteset data for room
            {
                case Bosses.Yakuza:
                    Room.Import(rom, Resources.ridley_yakuza, 0xC, 3);
                    rom.Write8(ridleySpriteset, yakuzaID);
                    secondaryIDs = new byte[] { 0x4D, 0x4E, 0x4F };
                    primaryIDs = new byte[] { yakuzaID };
                    break;
                case Bosses.Serris:
                    Room.Import(rom, Resources.ridley_serris, 0xC, 3);
                    rom.Write8(ridleySpriteset, serrisID);
                    secondaryIDs = new byte[] { 0x28 };
                    primaryIDs = new byte[] { serrisID };
                    break;
                case Bosses.Nightmare:
                    Room.Import(rom, Resources.ridley_nightmare, 0xC, 3);
                    rom.Write8(ridleySpriteset, nightmareID);
                    secondaryIDs = new byte[] { 0x50, 0x51, 0x52 };
                    primaryIDs = new byte[] { nightmareID };
                    break;
                case Bosses.BOX2:
                    Room.Import(rom, Resources.ridley_BOX, 0xC, 3);
                    rom.Write8(ridleySpriteset, BOX2ID);
                    secondaryIDs = new byte[] { 0x53, 0x54 };
                    primaryIDs = new byte[] { BOX2ID };
                    break;
                case Bosses.Arachnus:
                    Room.Import(rom, Resources.ridley_arachnus, 0xC, 3);
                    rom.Write8(ridleySpriteset, arachnusID);
                    secondaryIDs = new byte[] { 0x56, 0x57, 0x58, 0x59 };
                    primaryIDs = new byte[] { arachnusID };
                    break;
                case Bosses.Kraid:
                    Room.Import(rom, Resources.ridley_kraid, 0xC, 3);
                    rom.WritePtr(0x342EB0 + 0x18, 0x638134);  //kraid BG3 pointer
                    rom.Write8(0x19BBA, 0x25); //event
                    rom.Write8(0x19BC0, 0x25); //event
                    secondaryIDs = new byte[] { 0x3, 0x1C, 0x1D };
                    primaryIDs = new byte[] { 0x6F };
                    rom.Write8(ridleySpriteset, 0x6F);
                    break;
                case Bosses.MegaX:
                    Room.Import(rom, Resources.ridley_megax, 0xC, 3);
                    rom.Write8(ridleySpriteset, variaxID);
                    secondaryIDs = new byte[] { 0x5A, 0x5B, 0x5C };
                    primaryIDs = new byte[] { variaxID };
                    break;
                case Bosses.Netorri:
                    Room.Import(rom, Resources.ridley_nettori, 0xC, 3);
                    secondaryIDs = new byte[] { 0x5D, 0x5E, 0x5F };
                    primaryIDs = new byte[] { 0xD6, 0xD7, 0xD8, 0xD9 };
                    break;
                case Bosses.BOX:
                    Room.Import(rom, Resources.ridley_BOX, 0xC, 3);
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
            switch (newMecha) //import room and adjust spriteset data for room
            {
                case Bosses.Yakuza:
                    Room.Import(rom, Resources.mecha_yakuza, 0x48, 6);
                    rom.Write8(mechaSpriteset, yakuzaID);
                    primaryIDs = new byte[] { yakuzaID };
                    secondaryIDs = new byte[] { 0x4D, 0x4E, 0x4F };
                    break;
                case Bosses.Serris:
                    Room.Import(rom, Resources.mecha_serris, 0x48, 6);
                    rom.Write8(mechaSpriteset, serrisID);
                    primaryIDs = new byte[] { serrisID };
                    secondaryIDs = new byte[] { 0x28 };
                    break;
                case Bosses.Nightmare:
                    Room.Import(rom, Resources.mecha_nightmare, 0x48, 6);
                    rom.Write8(mechaSpriteset, nightmareID);
                    secondaryIDs = new byte[] { 0x50, 0x51, 0x52 };
                    primaryIDs = new byte[] { nightmareID };
                    break;
                case Bosses.BOX2:
                    Room.Import(rom, Resources.mecha_box, 0x48, 6);
                    rom.Write8(mechaSpriteset, BOX2ID);
                    secondaryIDs = new byte[] { 0x53, 0x54 };
                    primaryIDs = new byte[] { BOX2ID };
                    break;
                case Bosses.Arachnus:
                    Room.Import(rom, Resources.mecha_arachnus, 0x48, 6);
                    rom.Write8(mechaSpriteset, arachnusID);
                    primaryIDs = new byte[] { arachnusID };
                    secondaryIDs = new byte[] { 0x56, 0x57, 0x58, 0x59 };
                    break;
                case Bosses.Ridley:
                    Room.Import(rom, Resources.mecha_ridley, 0x48, 6);
                    rom.Write8(0x32242, 0x4A); //event
                    rom.Write16(0x322C8, 0xE006); //skip gravity event check
                    rom.Write16(0x33CDC, 0x4901);   //changes ridley code to call custom function for setting event and escape
                    rom.Write16(0x33CDE, 0xF056);
                    rom.Write16(0x33CE0, 0xFF8D);
                    rom.Write16(0x33CE2, 0xE012);
                    rom.WritePtr(0x33CE4, 0x819463);
                    primaryIDs = new byte[] { 0x61 };
                    secondaryIDs = new byte[] { 0x17, 0x18, 0x21, 0x43 };
                    rom.Write8(mechaSpriteset, 0x61);
                    break;
                case Bosses.MegaX:
                    Room.Import(rom, Resources.mecha_megax, 0x48, 6);
                    rom.Write8(mechaSpriteset, variaxID);
                    secondaryIDs = new byte[] { 0x5A, 0x5B, 0x5C };
                    primaryIDs = new byte[] { variaxID };
                    break;
                case Bosses.Netorri:
                    Room.Import(rom, Resources.mecha_netorri, 0x48, 6);
                    secondaryIDs = new byte[] { 0x5D, 0x5E, 0x5F };
                    primaryIDs = new byte[] { 0xD6, 0xD7, 0xD8, 0xD9 };
                    break;
                case Bosses.BOX:
                    Room.Import(rom, Resources.mecha_box, 0x48, 6);
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

        private void ChangeMua()
        {
            byte[] secondaryIDs = null, primaryIDs = null;
            switch (newMua)   //import room and adjust spriteset data for room
            {
                case Bosses.Yakuza:
                    Room.Import(rom, Resources.mua_yakuza, 5, 1);
                    rom.Write8(muaSpriteset, yakuzaID);
                    secondaryIDs = new byte[] { 0x4D, 0x4E, 0x4F };
                    primaryIDs = new byte[] { yakuzaID };
                    break;
                case Bosses.Serris:
                    Room.Import(rom, Resources.mua_serris, 5, 1);
                    rom.Write8(muaSpriteset, serrisID);
                    secondaryIDs = new byte[] { 0x28 };
                    primaryIDs = new byte[] { serrisID };
                    break;
                case Bosses.Nightmare:
                    Room.Import(rom, Resources.mua_nightmare, 5, 1);
                    rom.Write8(muaSpriteset, nightmareID);
                    secondaryIDs = new byte[] { 0x50, 0x51, 0x52 };
                    primaryIDs = new byte[] { nightmareID };
                    break;
                case Bosses.BOX2:
                    Room.Import(rom, Resources.mua_box, 5, 1);
                    rom.Write8(muaSpriteset, BOX2ID);
                    secondaryIDs = new byte[] { 0x53, 0x54 };
                    primaryIDs = new byte[] { BOX2ID };
                    break;
                case Bosses.Arachnus:
                    Room.Import(rom, Resources.mua_arachnus, 5, 1);
                    rom.Write8(muaSpriteset, arachnusID);
                    secondaryIDs = new byte[] { 0x56, 0x57, 0x58, 0x59 };
                    primaryIDs = new byte[] { arachnusID };
                    break;
                case Bosses.Ridley:
                    Room.Import(rom, Resources.mua_ridley, 5, 1);
                    rom.Write8(0x32242, 0x1C);
                    rom.Write8(0x33CDC, 0x1C);
                    rom.Write8(0x33CE2, 0x1C); //event
                    rom.Write16(0x322C8, 0xE006); //skip gravity event check
                    rom.Write8(muaSpriteset, 0x61);
                    primaryIDs = new byte[] { 0x61 };
                    secondaryIDs = new byte[] { 0x17, 0x18, 0x21, 0x43 };
                    break;
                case Bosses.MegaX:
                    Room.Import(rom, Resources.mua_megax, 5, 1);
                    rom.Write8(muaSpriteset, variaxID);
                    secondaryIDs = new byte[] { 0x5A, 0x5B, 0x5C };
                    primaryIDs = new byte[] { variaxID };
                    break;
                case Bosses.Netorri:
                    Room.Import(rom, Resources.mua_nettori, 5, 1);
                    secondaryIDs = new byte[] { 0x5D, 0x5E, 0x5F };
                    primaryIDs = new byte[] { 0xD6, 0xD7, 0xD8, 0xD9 };
                    break;
                case Bosses.BOX:
                    Room.Import(rom, Resources.mua_box, 5, 1);
                    rom.Write8(muaSpriteset, BOXID);
                    secondaryIDs = new byte[] { 0x60, 0x61, 0x62 };
                    primaryIDs = new byte[] { BOXID };
                    break;
                default:
                    break;
            }
            if (newMua != Bosses.Mua)
            {
                rom.Write16(muaSpriteset + 2, 0); //add terminator to spiteset
                ScaleSprites(secondaryIDs, 0.7);
                ScaleSprites(primaryIDs, 0.7, true);
            }
        }
        private void GetNewBosses()
        {
            List<Bosses> availBosses = new List<Bosses>(Enum.GetValues(typeof(Bosses)).Cast<Bosses>().ToList()); //list of bosses available to use
            Bosses replacementBoss;
            //kraid, mecha, and mua are restricted to their default rooms
            availBosses.Remove(Bosses.Kraid);
            availBosses.Remove(Bosses.Mecha);
            replacementBoss = availBosses[rng.Next(availBosses.Count)];
            newMua = replacementBoss;
            if (replacementBoss != Bosses.Mua)      //mua can't be in any other boss room
                availBosses.Remove(Bosses.Mua);     //so remove it from pool
            availBosses.Remove(replacementBoss);
            availBosses.Add(Bosses.Mecha);
            replacementBoss = availBosses[rng.Next(availBosses.Count)];
            newMecha = replacementBoss;
            if (replacementBoss != Bosses.Mecha)      //mecha can't be in any other boss room
                availBosses.Remove(Bosses.Mecha);     //so remove it from pool
            availBosses.Remove(replacementBoss);
            availBosses.Add(Bosses.Kraid);
            replacementBoss = availBosses[rng.Next(availBosses.Count)];
            newKraid = replacementBoss;
            if (replacementBoss != Bosses.Kraid)      //Kraid can't be in any other boss room
                availBosses.Remove(Bosses.Kraid);     //so remove it from pool          
            availBosses.Remove(replacementBoss);
            replacementBoss = availBosses[rng.Next(availBosses.Count)];
            newRidley = replacementBoss;
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
                changed.Add("Mua: " + Enum.GetName(typeof(Bosses), newMua));
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
