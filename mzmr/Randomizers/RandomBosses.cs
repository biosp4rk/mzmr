using mzmr.Properties;
using mzmr.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

        private enum Secondaries
        {
            SerrisSegment, SerrisBlock, YakuzaLeg, YakuzaChunk, YakuzaProjectile,
            NightmareBody, NightmareBeam, NightmareChunk, BoxPart, BoxMissile, BoxBrain,
            ArachPart, ArachShell, ArachFire, ArachSwipe, MegaXShell, MegaX, MegaXOrb
        }
        private static Bosses newKraid = Bosses.Kraid, newRidley = Bosses.Ridley, newMecha = Bosses.Mecha;
        private bool kraidUsed = false, ridleyUsed = false, mechaUsed = false; //keeps track of what secondaries were replaced

        public RandomBosses(Rom rom, Settings settings, Random rng) : base(rom, settings, rng)
        {

        }

        private class BossPart
        {

            public ushort[] stats;
            public int offset;
            public int[] iDOffsets;
            public Secondaries name;

            public static BossPart GetBossPartData(Secondaries name)
            {
                switch (name)
                {
                    case Secondaries.SerrisSegment:
                        return new BossPart
                        {
                            offset = 0x8020D0,
                            iDOffsets = new int[] { 0x800480, 0x800496, 0x8004A8, 0x8004BA, 0x8004CC, 0x8004DE, 0x8004F0, 0x800502, 0x800514, 0x800526 },
                            stats = new ushort[] { 1, 0x1E, 0, 0, 0x80, 0x80, 0x200, 0x100, 0 },
                            name = Secondaries.SerrisSegment
                        };

                    case Secondaries.SerrisBlock:
                        return new BossPart
                        {
                            offset = 0x8024F4,
                            iDOffsets = new int[] { 0x8005A6, 0x8005BE, 0x8005D6, 0x8005EE, 0x800606, 0x80061E, 0x800636, 0x80064E, 0x800666 },
                            stats = new ushort[] { 0, 0, 0, 0x400, 0, 0, 0, 0, 0 },
                            name = Secondaries.SerrisBlock
                        };

                    case Secondaries.YakuzaLeg:
                        return new BossPart
                        {
                            offset = 0x8041D4,
                            iDOffsets = new int[] { 0x802D1E, 0x802D36 },
                            stats = new ushort[] { 1, 0x41, 0, 0x400, 0, 0, 0, 0, 0 },
                            name = Secondaries.YakuzaLeg
                        };

                    case Secondaries.YakuzaChunk:
                        return new BossPart
                        {
                            offset = 0x80447C,
                            iDOffsets = new int[] { 0x803598, 0x8035B4, 0x8035CC, 0x8035E8, 0x803602, 0x80361A },
                            stats = new ushort[] { 0, 0, 0, 0x400, 0, 0, 0, 0, 0 },
                            name= Secondaries.YakuzaChunk
                        };

                    case Secondaries.YakuzaProjectile:
                        return new BossPart
                        {
                            offset = 0x80480C,
                            iDOffsets = new int[] { 0x803194, 0x8031AE, 0x8031C8, 0x803776 },
                            stats = new ushort[] { 1, 0x2D, 0x1A, 0x19A, 0x25, 0x10, 0x200, 0x30, 1 },
                               name = Secondaries.YakuzaProjectile
                        };


                    case Secondaries.NightmareChunk:
                        return new BossPart
                        {
                            offset = 0x809A30,
                            iDOffsets = new int[] { 0x807D4E, 0x807E2E, 0x807FD6, 0x80819A, 0x80835A, 0x808522, 0x8086E6, 0x80889E },
                            stats = new ushort[] { 0, 0x20, 0, 0x400, 0, 0, 0, 0, 0 },
                            name= Secondaries.NightmareChunk
                        };


                    case Secondaries.NightmareBeam:
                        return new BossPart
                        {
                            offset = 0x80978C,
                            iDOffsets = new int[] { 0x807C94 },
                            stats = new ushort[] { 1, 0x20, 0, 0x400, 0, 0, 0, 0, 0 },
                            name = Secondaries.NightmareBeam
                        };

                    case Secondaries.NightmareBody:
                        return new BossPart
                        {
                            offset = 0x8095F0,
                            iDOffsets = new int[] { 0x806B06, 0x806B1A, 0x806B2E, 0x806B48, 0x806B6C, 0x806B80, 0x806B94, 0x806BA8, 0x806BBC, 0x806BD0, 0x806BE4, 0x806BF8, 0x806C0C },
                            stats = new ushort[] { 0x2C0, 0x14, 0x1B, 0, 0x100, 0x100, 0x100, 0x80, 0x80 },
                            name = Secondaries.NightmareBody
                        };

                    case Secondaries.BoxPart:
                        return new BossPart
                        {
                            offset = 0x80BE60,
                            iDOffsets = new int[] { 0x809C34, 0x809C4E, 0x809C66, 0x809C7E, 0x809C96, 0x809CAE, 0x809CC6, 0x809CDE, 0x809CF6, 0x809D0E, 0x809D26 },
                            stats = new ushort[] { 0x1F4, 0x5A, 0x19, 0, 0x1A0, 0x200, 0x60, 0, 0 },
                            name = Secondaries.BoxPart
                        };

                    case Secondaries.BoxMissile:
                        return new BossPart
                        {
                            offset = 0x80BF6C,
                            iDOffsets = new int[] { 0x80A86E, 0x80A8A0, 0x80A8CC, 0x80A8F8 },
                            stats = new ushort[] { 5, 0x32, 0x3B, 0, 0x100, 0x60, 0x250, 0x50, 0 },
                            name = Secondaries.BoxMissile
                        };

                    case Secondaries.BoxBrain:
                        return new BossPart
                        {
                            offset = 0x80BFAC,
                            iDOffsets = new int[] { 0x80AC18, 0x80BBC4 },
                            stats = new ushort[] { 1, 0x2D, 0, 0, 0, 0, 0x200, 0x200, 0 },
                            name = Secondaries.BoxBrain
                        };

                    case Secondaries.ArachPart:
                        return new BossPart
                        {
                            offset = 0x8059D8,
                            iDOffsets = new int[] { 0x805468, 0x8054A4, 0x8054C4, 0x8062E0 },
                            stats = new ushort[] { 0, 0, 0, 0, 0x100, 0x100, 0x100, 0x80, 0x80 },
                            name = Secondaries.ArachPart
                        };

                    case Secondaries.ArachShell:
                        return new BossPart
                        {
                            offset = 0x805D08,
                            iDOffsets = new int[] { 0x805448 },
                            stats = new ushort[] { 1, 0x20, 0, 0, 0x80, 0x80, 0x200, 0x100, 0 },
                            name = Secondaries.ArachShell
                        };

                    case Secondaries.ArachFire:
                        return new BossPart
                        {
                            offset = 0x805E48,
                            iDOffsets = new int[] { 0x804F80, 0x805294, 0x8052C0, 0x805330, 0x80609A, 0x8060BA },
                            stats = new ushort[] { 0, 0xA, 0, 0x400, 0, 0, 0, 0, 0 },
                            name = Secondaries.ArachFire
                        };

                    case Secondaries.ArachSwipe:
                        return new BossPart
                        {
                            offset = 0x8061E8,
                            iDOffsets = new int[] { 0x804BB4 },
                            stats = new ushort[] { 0, 0x18, 0, 0x400, 0, 0, 0, 0, 0 },
                            name = Secondaries.ArachSwipe
                        };

                    case Secondaries.MegaXShell:
                        return new BossPart
                        {
                            offset = 0x80CF88,
                            iDOffsets = new int[] { 0x80CA2E },
                            stats = new ushort[] { 0xB4, 0x48, 8, 0, 0x100, 0x60, 0x250, 0x50, 0 },
                            name = Secondaries.MegaXShell
                        };

                    case Secondaries.MegaX:
                        return new BossPart
                        {
                            offset = 0x80C0FC,
                            iDOffsets = new int[] { 0x80CA16 },
                            stats = new ushort[] { 0x64, 0x40, 9, 0x400, 0, 0, 0, 0, 0 },
                            name = Secondaries.MegaX
                        };

                    case Secondaries.MegaXOrb:
                        return new BossPart
                        {
                            offset = 0x80C6BA,
                            iDOffsets = new int[] { 0x80CB3A, 0x80CB52, 0x80CB68, 0x80CB7E, 0x80CB94, 0x80CBAA, 0x80CBC0, 0x80CBD6, 0x80C044},
                            stats = new ushort[] { 1, 0x30, 9, 0x400, 0, 0, 0, 0, 0 },
                            name = Secondaries.MegaXOrb
                        };
                    default:
                        return new BossPart
                        {
                            stats = new ushort[] { 0, 0, 0, 0x400, 0, 0, 0, 0, 0 }
                        };
                }
            }
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
            Patch.Apply(rom, Resources.ZM_U_bossBase);
            GetNewBosses();
            ChangeKraid();
            ChangeRidley();
            ChangeMecha();
            return new RandomizeResult(true);

        }

        private void ChangeKraid()
        {
            Secondaries[] secondaries = null;
            switch (newKraid)   //adjust door data for room 
            {
                case Bosses.Yakuza:
                    secondaries = new Secondaries[] { Secondaries.YakuzaProjectile, Secondaries.YakuzaLeg, Secondaries.YakuzaChunk };
                    rom.Write8(0x33EAAC + (0x48 * 0xC) + 4, 0x11);
                    rom.Write8(0x33EAAC + (0x48 * 0xC) + 5, 0x14);
                    rom.Write8(0x33EAAC + (0x51 * 0xC) + 4, 0x1A);
                    rom.Write8(0x33EAAC + (0x51 * 0xC) + 5, 0x1D);
                    rom.Write8(0x33EAAC + (0x48 * 0xC) + 1, 0x2A);
                    rom.Write8(0x33EAAC + (0x51 * 0xC) + 1, 0x2A);
                    rom.Write16(0x2B0D68 + (0x8A * 0x12), 0x320); //health
                    break;
                case Bosses.Serris:
                    secondaries = new Secondaries[] { Secondaries.SerrisBlock, Secondaries.SerrisSegment };
                    rom.Write8(0x33EAAC + (0x48 * 0xC) + 4, 0x7);
                    rom.Write8(0x33EAAC + (0x48 * 0xC) + 5, 0xA);
                    rom.Write8(0x33EAAC + (0x51 * 0xC) + 4, 0x10);
                    rom.Write8(0x33EAAC + (0x51 * 0xC) + 5, 0x13);
                    rom.Write8(0x33EAAC + (0x48 * 0xC) + 1, 0x2B);
                    rom.Write8(0x33EAAC + (0x51 * 0xC) + 1, 0x2B);
                    rom.Write16(0x2B0D68 + (0x49 * 0x12), 0x136); //health
                    break;
                case Bosses.Nightmare:
                    secondaries = new Secondaries[] { Secondaries.NightmareBeam, Secondaries.NightmareBody, Secondaries.NightmareChunk };
                    rom.Write8(0x33EAAC + (0x48 * 0xC) + 2, 0x13);
                    rom.Write8(0x33EAAC + (0x48 * 0xC) + 3, 0x13);
                    rom.Write8(0x33EAAC + (0x48 * 0xC) + 4, 0x8);
                    rom.Write8(0x33EAAC + (0x48 * 0xC) + 5, 0xB);
                    rom.Write8(0x33EAAC + (0x51 * 0xC) + 4, 0x11);
                    rom.Write8(0x33EAAC + (0x51 * 0xC) + 5, 0x14);
                    rom.Write8(0x33EAAC + (0x48 * 0xC) + 1, 0x2C);
                    rom.Write8(0x33EAAC + (0x51 * 0xC) + 1, 0x2C);
                    rom.Write16(0x2B0D68 + (0x6C * 0x12), 0x28A); //health
                    break;
                case Bosses.BOX:
                    secondaries = new Secondaries[] { Secondaries.BoxBrain, Secondaries.BoxPart, Secondaries.BoxMissile };
                    rom.Write8(0x33EAAC + (0x51 * 0xC) + 4, 0x24);
                    rom.Write8(0x33EAAC + (0x48 * 0xC) + 1, 0x2D);
                    rom.Write8(0x33EAAC + (0x51 * 0xC) + 1, 0x2D);
                    break;
                case Bosses.Arachnus:
                    secondaries = new Secondaries[] { Secondaries.ArachFire, Secondaries.ArachPart, Secondaries.ArachShell, Secondaries.ArachSwipe };
                    rom.Write8(0x33EAAC + (0x51 * 0xC) + 4, 0x24);
                    rom.Write8(0x33EAAC + (0x48 * 0xC) + 1, 0x2E);
                    rom.Write8(0x33EAAC + (0x51 * 0xC) + 1, 0x2E);
                    rom.Write16(0x2B0D68 + (0x39 * 0x12), 0x258); //health
                    break;
                case Bosses.Ridley:
                    rom.Write8(0x33EAAC + (0x48 * 0xC) + 4, 0x5);
                    rom.Write8(0x33EAAC + (0x48 * 0xC) + 5, 0x8);
                    rom.Write8(0x33EAAC + (0x51 * 0xC) + 4, 0xE);
                    rom.Write8(0x33EAAC + (0x51 * 0xC) + 5, 0x11);
                    rom.Write8(0x33EAAC + (0x48 * 0xC) + 1, 0x2F);
                    rom.Write8(0x33EAAC + (0x51 * 0xC) + 1, 0x2F);
                    rom.Write8(0x32242, 0x1E); //event
                    rom.Write8(0x33CDC, 0x1E); //event
                    rom.Write8(0x33CE2, 0x1E); //event
                    rom.Write16(0x322C8, 0xE006); //skip gravity event check
                    rom.Write16(0x2B0D68 + (0x61 * 0x12), 0x320); //health
                    break;
                case Bosses.MegaX:
                    secondaries = new Secondaries[] { Secondaries.MegaX, Secondaries.MegaXOrb, Secondaries.MegaXShell };
                    rom.Write8(0x33EAAC + (0x51 * 0xC) + 4, 0x24);
                    rom.Write8(0x33EAAC + (0x48 * 0xC) + 1, 0x30);
                    rom.Write8(0x33EAAC + (0x51 * 0xC) + 1, 0x30);
                    break;
                default:
                    break;
            }
            if (newKraid !=Bosses.Kraid)
                rom.Write8(0x33EAAC + (0x51 * 0xC), 4);
            if (newKraid <= Bosses.Arachnus)
                ReplaceSecondaries(secondaries, Bosses.Kraid);
        }

        private void ChangeRidley()
        {
            Secondaries[] secondaries = null;
            switch (newRidley)  //adjust door data for room 
            {
                case Bosses.Yakuza:
                    secondaries = new Secondaries[] { Secondaries.YakuzaProjectile, Secondaries.YakuzaLeg, Secondaries.YakuzaChunk };
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 4, 0x18);
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 5, 0x1B);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 4, 0x18);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 5, 0x1B);
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 1, 0x21);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 1, 0x21);
                    rom.Write16(0x2B0D68 + (0x8A * 0x12), 0x3E8); //health
                    rom.Write16(0x2B0D6A + (0x8A * 0x12), 0x32); //damage
                    break;
                case Bosses.Serris:
                    secondaries = new Secondaries[] { Secondaries.SerrisBlock, Secondaries.SerrisSegment };
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 2, 0x1F);
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 3, 0x1F);
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 4, 0xE);
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 5, 0x11);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 2, 2);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 3, 2);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 4, 0xE);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 5, 0x11);
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 1, 0x22);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 1, 0x22);
                    rom.Write16(0x2B0D68 + (0x49 * 0x12), 0x258); //health
                    rom.Write16(0x2B0D6A + (0x49 * 0x12), 0x32); //damage
                    break;
                case Bosses.Nightmare:
                    secondaries = new Secondaries[] { Secondaries.NightmareBeam, Secondaries.NightmareBody, Secondaries.NightmareChunk };
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 2, 0x13);
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 3, 0x13);
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 4, 0xE);
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 5, 0x11);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 2, 0x2);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 3, 0x2);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 4, 0xE);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 5, 0x11);
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 1, 0x23);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 1, 0x23);
                    rom.Write16(0x2B0D68 + (0x6C * 0x12), 0x320); //health
                    rom.Write16(0x2B0D6A + (0x6C * 0x12), 0x32); //damage
                    break;
                case Bosses.BOX:
                    secondaries = new Secondaries[] { Secondaries.BoxBrain, Secondaries.BoxPart, Secondaries.BoxMissile };
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 2, 0x1C);
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 3, 0x1C);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 2, 5);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 3, 5);
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 1, 0x24);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 1, 0x24);
                    break;
                case Bosses.Arachnus:
                    secondaries = new Secondaries[] { Secondaries.ArachFire, Secondaries.ArachPart, Secondaries.ArachShell, Secondaries.ArachSwipe };
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 1, 0x25);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 1, 0x25);
                    rom.Write16(0x2B0D68 + (0x39 * 0x12), 0x320); //health
                    rom.Write16(0x2B0D6A + (0x39 * 0x12), 0x32); //damage
                    break;
                case Bosses.Kraid:
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 2, 0x1F);
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 3, 0x1F);
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 4, 0x24);
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 5, 0x27);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 2, 2);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 3, 2);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 4, 0x24);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 5, 0x27);
                    rom.Write8(0x33F5EC + (0x1E * 0xC), 2);
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 1, 0x26);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 1, 0x26);
                    rom.Write8(0x19BBA, 0x25); //event
                    rom.Write8(0x19BC0, 0x25); //event
                    rom.Write16(0x2B0D68 + (0x6F * 0x12), 0x3E8); //health
                    rom.Write16(0x2B0D6A + (0x6F * 0x12), 0x3C); //main sprite damage
                    rom.Write16(0x2B1BE6 + (0x3 * 0x12), 0x3C); //secondaries damage
                    rom.Write16(0x2B1BE6 + (0x1C * 0x12), 0x4B);
                    rom.Write16(0x2B1BE6 + (0x1D * 0x12), 0x32);
                    break;
                case Bosses.MegaX:
                    secondaries = new Secondaries[] { Secondaries.MegaX, Secondaries.MegaXOrb, Secondaries.MegaXShell };
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 2, 0x1C);
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 3, 0x1C);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 2, 5);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 3, 5);
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 1, 0x27);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 1, 0x27);
                    break;
                default:
                    break;
            }
            if (newRidley <= Bosses.Arachnus)
                ReplaceSecondaries(secondaries, Bosses.Ridley);
        }

        private void ChangeMecha()
        {
            Secondaries[] secondaries = null;
            switch (newMecha)
            {
                case Bosses.Yakuza:
                    secondaries = new Secondaries[] { Secondaries.YakuzaProjectile, Secondaries.YakuzaLeg, Secondaries.YakuzaChunk };
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 1, 0x73);
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 2, 0xA);
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 3, 0xA);
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 4, 0x1B);
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 5, 0x1E);
                    rom.Write16(0x2B0D68 + (0x8A * 0x12), 0x4B0); //health
                    rom.Write16(0x2B0D6A + (0x8A * 0x12), 0x4B); //damage
                    break;
                case Bosses.Serris:
                    secondaries = new Secondaries[] { Secondaries.SerrisBlock, Secondaries.SerrisSegment };
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 1, 0x74);
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 4, 0x10);
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 5, 0x13);
                    rom.Write16(0x2B0D68 + (0x49 * 0x12), 0x320); //health
                    rom.Write16(0x2B0D6A + (0x49 * 0x12), 0x64); //damage
                    break;
                case Bosses.Nightmare:
                    secondaries = new Secondaries[] { Secondaries.NightmareBeam, Secondaries.NightmareBody, Secondaries.NightmareChunk };
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 1, 0x75);
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 4, 0x10);
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 5, 0x13);
                    rom.Write16(0x2B0D68 + (0x6C * 0x12), 0x3E8); //health
                    rom.Write16(0x2B0D6A + (0x6C * 0x12), 0x64); //damage
                    break;
                case Bosses.BOX:
                    secondaries = new Secondaries[] { Secondaries.BoxBrain, Secondaries.BoxPart, Secondaries.BoxMissile };
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 1, 0x76);
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 4, 0x10);
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 5, 0x13);
                    break;
                case Bosses.Arachnus:
                    secondaries = new Secondaries[] { Secondaries.ArachFire, Secondaries.ArachPart, Secondaries.ArachShell, Secondaries.ArachSwipe };
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 1, 0x77);
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 4, 0x10);
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 5, 0x13);
                    rom.Write16(0x2B0D68 + (0x39 * 0x12), 0x3E8); //health
                    rom.Write16(0x2B0D6A + (0x39 * 0x12), 0x64); //damage
                    break;
                case Bosses.Ridley:
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 1, 0x78);
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 4, 0xE);
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 5, 0x11);
                    rom.Write8(0x32242, 0x4A); //event
                    rom.Write16(0x322C8, 0xE006); //skip gravity event check
                    rom.Write16(0x33CDC, 0x4901);   //changes ridley code to call custom function for setting event and escape
                    rom.Write16(0x33CDE, 0xF056);
                    rom.Write16(0x33CE0, 0xFF8D);
                    rom.Write16(0x33CE2, 0xE012);
                    rom.WritePtr(0x33CE4, 0x80D3A4);
                    rom.Write16(0x2B0D68 + (0x61 * 0x12), 0x5DC); //health
                    rom.Write16(0x2B0D6A + (0x61 * 0x12), 0x4B); //main sprite damage
                    rom.Write16(0x2B1BE6 + (0x17 * 0x12), 0x4B); // secondary damage
                    rom.Write16(0x2B1BE6 + (0x18 * 0x12), 0x7D);
                    rom.Write16(0x2B1BE6 + (0x21 * 0x12), 0x28);
                    rom.Write16(0x2B1BE6 + (0x43 * 0x12), 0x4B);
                    break;
                case Bosses.MegaX:
                    secondaries = new Secondaries[] { Secondaries.MegaX, Secondaries.MegaXOrb, Secondaries.MegaXShell };  
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 1, 0x79);
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 4, 0x10);
                    rom.Write8(0x33FE14 + (0x9E * 0xC) + 5, 0x13);
                    break;
                default:
                    break;

            }
            if (newMecha <= Bosses.Arachnus)
                ReplaceSecondaries(secondaries, Bosses.Mecha);
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

        private void ReplaceSecondaries(Secondaries[] secondaryList, Bosses replacement)
        {
            byte[] replacementIDs;
            if (!IsUsed(Bosses.Kraid) && !kraidUsed)      //replace secondaries for which ever boss is not used, mark boss as used afterwards
            {
              replacementIDs = new byte[] { 3, 7, 0x1C, 0x1D };
                kraidUsed = true;
            }
            else if (!IsUsed(Bosses.Ridley) && !ridleyUsed)
            {
                replacementIDs = new byte[] { 0x17, 0x18, 0x21, 0x43 };
                ridleyUsed = true;
            }
            else
            {
                replacementIDs = new byte[] { 0x44, 0x47, 0x48, 0x49 };
                mechaUsed = true;
            }

            for (int i = 0; i < secondaryList.Length; i++)  
            {
               BossPart secondary = BossPart.GetBossPartData(secondaryList[i]);
                ScaleSecondary(secondary, replacement);
                StoreNewSecondaryData(secondary, replacementIDs[i]);
            }
        }

          private void ScaleSecondary(BossPart secondary, Bosses replacement)
          {
            //scale secondary damage and health based on room placed in
            if (replacement == Bosses.Kraid) 
            {
                switch (secondary.name)
                {
                    case Secondaries.NightmareBody:
                        secondary.stats[0] = 0x258;  //health
                        break;
                    case Secondaries.BoxPart:
                        secondary.stats[0] = 0x1F4;
                        break;
                    case Secondaries.MegaX:
                        secondary.stats[0] = 0x104;
                        break;
                    case Secondaries.MegaXShell:
                        secondary.stats[0] = 0x104;
                        break;
                }
            }
            else if (replacement == Bosses.Ridley)
            {
                secondary.stats[1] = (ushort)(secondary.stats[1] * 1.5); //multiplies damage by 1.5 if in ridley room
                switch (secondary.name)
                {
                    case Secondaries.NightmareBody:
                        secondary.stats[0] = 0x2BC;  //health
                        break;
                    case Secondaries.BoxPart:
                        secondary.stats[0] = 0x2BC;
                        break;
                    case Secondaries.MegaX:
                        secondary.stats[0] = 0x12D;
                        break;
                    case Secondaries.MegaXShell:
                        secondary.stats[0] = 0x12C;
                        break;
                }
            }
            else
            {
                secondary.stats[1] *= 2; //multiplies damage by 2 if in mecha room
                switch (secondary.name)
                {
                    case Secondaries.NightmareBody:
                        secondary.stats[0] = 0x320;  //health
                        break;
                    case Secondaries.BoxPart:
                        secondary.stats[0] = 0x3E8;
                        break;
                    case Secondaries.MegaX:
                        secondary.stats[0] = 0x2BC;
                        break;
                    case Secondaries.MegaXShell:
                        secondary.stats[0] = 0x190;
                        break;
                }
            }

          }

        private void StoreNewSecondaryData(BossPart data, byte spriteID)
        {
            rom.WritePtr(0x75F1E8 + (spriteID * 4), data.offset + 1); //ai pointer
            foreach (int offset in data.iDOffsets)          //change secondary id for function calls
                rom.Write8(offset, spriteID);
            int statsoffset = 0x2B1BE4 + (spriteID * 0x12);
            for (int i = 0; i < data.stats.Length; i++)
                rom.Write16(statsoffset + (i * 2), data.stats[i]);
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
