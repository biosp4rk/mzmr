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
                            offset = 0x8020CC,
                            iDOffsets = new int[] { 0x800480, 0x800496, 0x8004A8, 0x8004BA, 0x8004CC, 0x8004DE, 0x8004F0, 0x800502, 0x800514, 0x800526 },
                            stats = new ushort[] { 1, 0x1E, 0, 0, 0x80, 0x80, 0x200, 0x100, 0 },
                            name = Secondaries.SerrisSegment
                        };

                    case Secondaries.SerrisBlock:
                        return new BossPart
                        {
                            offset = 0x8024F0,
                            iDOffsets = new int[] { 0x8005A6, 0x8005BE, 0x8005D6, 0x8005EE, 0x800606, 0x80061E, 0x800636, 0x80064E, 0x800666 },
                            stats = new ushort[] { 0, 0, 0, 0x400, 0, 0, 0, 0, 0 },
                            name = Secondaries.SerrisBlock
                        };

                    case Secondaries.YakuzaLeg:
                        return new BossPart
                        {
                            offset = 0x8041D0,
                            iDOffsets = new int[] { 0x802D1A, 0x802D32 },
                            stats = new ushort[] { 1, 0x41, 0, 0x400, 0, 0, 0, 0, 0 },
                            name = Secondaries.YakuzaLeg
                        };

                    case Secondaries.YakuzaChunk:
                        return new BossPart
                        {
                            offset = 0x804478,
                            iDOffsets = new int[] { 0x803594, 0x8035B0, 0x8035C8, 0x8035E4, 0x8035FE, 0x803616 },
                            stats = new ushort[] { 0, 0, 0, 0x400, 0, 0, 0, 0, 0 },
                            name= Secondaries.YakuzaChunk
                        };

                    case Secondaries.YakuzaProjectile:
                        return new BossPart
                        {
                            offset = 0x804808,
                            iDOffsets = new int[] { 0x803190, 0x8031AA, 0x8031C4, 0x803772 },
                            stats = new ushort[] { 1, 0x2D, 0x1A, 0x19A, 0x25, 0x10, 0x200, 0x30, 1 },
                               name = Secondaries.YakuzaProjectile
                        };


                    case Secondaries.NightmareChunk:
                        return new BossPart
                        {
                            offset = 0x809A38,
                            iDOffsets = new int[] { 0x807D56, 0x807E36, 0x807FDE, 0x8081A2, 0x808362, 0x80852A, 0x8086EE, 0x8088A6 },
                            stats = new ushort[] { 0, 0, 0, 0x400, 0, 0, 0, 0, 0 },
                            name= Secondaries.NightmareChunk
                        };


                    case Secondaries.NightmareBeam:
                        return new BossPart
                        {
                            offset = 0x809794,
                            iDOffsets = new int[] { 0x807C9C },
                            stats = new ushort[] { 1, 0x20, 0, 0x400, 0, 0, 0, 0, 0 },
                            name = Secondaries.NightmareBeam
                        };

                    case Secondaries.NightmareBody:
                        return new BossPart
                        {
                            offset = 0x8095F8,
                            iDOffsets = new int[] { 0x806B02, 0x806B16, 0x806B2A, 0x806B44, 0x806B68, 0x806B7C, 0x806B90, 0x806BA4, 0x806BB8, 0x806BCC, 0x806BE0, 0x806BF4, 0x806C08 },
                            stats = new ushort[] { 0x2C0, 0x0, 0x1B, 0, 0x100, 0x100, 0x100, 0x80, 0x80 },
                            name = Secondaries.NightmareBody
                        };

                    case Secondaries.BoxPart:
                        return new BossPart
                        {
                            offset = 0x80BE68,
                            iDOffsets = new int[] { 0x809C3C, 0x809C56, 0x809C6E, 0x809C86, 0x809C9E, 0x809CB6, 0x809CCE, 0x809CE6, 0x809CFE, 0x809D16, 0x809D2E },
                            stats = new ushort[] { 0x1F4, 0x5A, 0x19, 0, 0x1A0, 0x200, 0x60, 0, 0 },
                            name = Secondaries.BoxPart
                        };

                    case Secondaries.BoxMissile:
                        return new BossPart
                        {
                            offset = 0x80BF74,
                            iDOffsets = new int[] { 0x80A876, 0x80A8A8, 0x80A8D4, 0x80A900 },
                            stats = new ushort[] { 5, 0x32, 0x3B, 0, 0x100, 0x60, 0x250, 0x50, 0 },
                            name = Secondaries.BoxMissile
                        };

                    case Secondaries.BoxBrain:
                        return new BossPart
                        {
                            offset = 0x80BFB4,
                            iDOffsets = new int[] { 0x80AC20, 0x80BBCC },
                            stats = new ushort[] { 1, 0x2D, 0, 0, 0, 0, 0x200, 0x200, 0 },
                            name = Secondaries.BoxBrain
                        };

                    case Secondaries.ArachPart:
                        return new BossPart
                        {
                            offset = 0x8059D4,
                            iDOffsets = new int[] { 0x805464, 0x8054A0, 0x8054C0, 0x8062DC },
                            stats = new ushort[] { 0, 0, 0, 0, 0x100, 0x100, 0x100, 0x80, 0x80 },
                            name = Secondaries.ArachPart
                        };

                    case Secondaries.ArachShell:
                        return new BossPart
                        {
                            offset = 0x805D04,
                            iDOffsets = new int[] { 0x805444 },
                            stats = new ushort[] { 1, 0x20, 0, 0, 0x80, 0x80, 0x200, 0x100, 0 },
                            name = Secondaries.ArachShell
                        };

                    case Secondaries.ArachFire:
                        return new BossPart
                        {
                            offset = 0x805E44,
                            iDOffsets = new int[] { 0x804F7C, 0x805290, 0x8052BC, 0x80532C, 0x806096,
                                0x8060B6 },
                            stats = new ushort[] { 0, 0xA, 0, 0x400, 0, 0, 0, 0, 0 },
                            name = Secondaries.ArachFire
                        };

                    case Secondaries.ArachSwipe:
                        return new BossPart
                        {
                            offset = 0x8061E4,
                            iDOffsets = new int[] { 0x804BB0 },
                            stats = new ushort[] { 0, 0x18, 0, 0x400, 0, 0, 0, 0, 0 },
                            name = Secondaries.ArachSwipe
                        };

                    case Secondaries.MegaXShell:
                        return new BossPart
                        {
                            offset = 0x80CF90,
                            iDOffsets = new int[] { 0x80CA3A },
                            stats = new ushort[] { 0xB4, 0x48, 8, 0, 0x100, 0x60, 0x250, 0x50, 0 },
                            name = Secondaries.MegaXShell
                        };

                    case Secondaries.MegaX:
                        return new BossPart
                        {
                            offset = 0x80C104,
                            iDOffsets = new int[] { 0x80CA22 },
                            stats = new ushort[] { 0x64, 0x40, 9, 0x400, 0, 0, 0, 0, 0 },
                            name = Secondaries.MegaX
                        };

                    case Secondaries.MegaXOrb:
                        return new BossPart
                        {
                            offset = 0x80C6C2,
                            iDOffsets = new int[] { 0x80CB42, 0x80CB5A, 0x80CB70, 0x80CB86, 0x80CB9C, 0x80CBB2, 0x80CBC8, 0x80CBDE },
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
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 4, 0x11);
                    rom.Write8(0x33F5EC + (0x1D * 0xC) + 5, 0x14);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 2, 0x2);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 3, 0x2);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 4, 0x11);
                    rom.Write8(0x33F5EC + (0x1E * 0xC) + 5, 0x14);
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
                    rom.WritePtr(0x33CE4, 0x80D3AD);
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
                        secondary.stats[0] = 0x12D;
                        break;
                    case Secondaries.MegaXShell:
                        secondary.stats[0] = 0x12C;
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
                        secondary.stats[0] = 0x2BC;
                        break;
                    case Secondaries.MegaXShell:
                        secondary.stats[0] = 0x190;
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
                        secondary.stats[0] = 0x3E8;
                        break;
                    case Secondaries.MegaXShell:
                        secondary.stats[0] = 0x1F4;
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
