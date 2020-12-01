using System;
using System.Collections.Generic;
using System.Text;

namespace mzmr.Randomizers
{
    public class RandomEnemies : RandomAspect
    {
        public enum EnemyType { Crawling, Ground, Ceiling, Floor, Lava, Flying, Pipe }

        private class Enemy
        {
            public byte SpriteID;
            public string Name;
            public EnemyType Type;
            public bool CanReplace;
            public int GfxOffset;
            public int GfxRows;

            public Enemy()
            {

            }

            public void SetGfxInfo(Rom rom)
            {
                GfxOffset = rom.ReadPtr(Rom.SpriteGfxOffset + (this.SpriteID - 0x10) * 4);
                GfxRows = (rom.Read32(GfxOffset) >> 8) / 0x800;
            }

            public static Enemy GetEnemy(int spriteID)
            {
                switch (spriteID)
                {
                    case 0x12:
                        return new Enemy
                        {
                            SpriteID = 0x12,
                            Name = "Zoomer (yellow)",
                            Type = EnemyType.Crawling,
                            CanReplace = true
                        };
                    case 0x13:
                        return new Enemy
                        {
                            SpriteID = 0x13,
                            Name = "Zoomer (red)",
                            Type = EnemyType.Crawling,
                            CanReplace = true
                        };
                    case 0x14:
                        return new Enemy
                        {
                            SpriteID = 0x14,
                            Name = "Zeela",
                            Type = EnemyType.Crawling,
                            CanReplace = true
                        };
                    case 0x15:
                        return new Enemy
                        {
                            SpriteID = 0x15,
                            Name = "Zeela (red)",
                            Type = EnemyType.Crawling,
                            CanReplace = true
                        };
                    case 0x16:
                        return new Enemy
                        {
                            SpriteID = 0x16,
                            Name = "Ripper (brown)",
                            Type = EnemyType.Flying,
                            CanReplace = true
                        };
                    case 0x17:
                        return new Enemy
                        {
                            SpriteID = 0x17,
                            Name = "Ripper (purple)",
                            Type = EnemyType.Flying,
                            CanReplace = true
                        };
                    case 0x18:
                        return new Enemy
                        {
                            SpriteID = 0x18,
                            Name = "Zeb",
                            Type = EnemyType.Pipe,
                            CanReplace = true
                        };
                    case 0x19:
                        return new Enemy
                        {
                            SpriteID = 0x19,
                            Name = "Zeb (blue)",
                            Type = EnemyType.Pipe,
                            CanReplace = true
                        };
                    case 0x1F:
                        return new Enemy
                        {
                            SpriteID = 0x1F,
                            Name = "Skree (green)",
                            Type = EnemyType.Ceiling,
                            CanReplace = true
                        };
                    case 0x20:
                        return new Enemy
                        {
                            SpriteID = 0x20,
                            Name = "Skree (blue)",
                            Type = EnemyType.Ceiling,
                            CanReplace = true
                        };
                    case 0x32:
                        return new Enemy
                        {
                            SpriteID = 0x32,
                            Name = "Sova (purple)",
                            Type = EnemyType.Crawling,
                            CanReplace = true
                        };
                    case 0x33:
                        return new Enemy
                        {
                            SpriteID = 0x33,
                            Name = "Sova (orange)",
                            Type = EnemyType.Crawling,
                            CanReplace = true
                        };
                    case 0x34:
                        return new Enemy
                        {
                            SpriteID = 0x34,
                            Name = "Multiviola",
                            Type = EnemyType.Flying,
                            CanReplace = true
                        };
                    case 0x36:
                        return new Enemy
                        {
                            SpriteID = 0x36,
                            Name = "Geruta (red)",
                            Type = EnemyType.Flying,
                            CanReplace = true
                        };
                    case 0x37:
                        return new Enemy
                        {
                            SpriteID = 0x37,
                            Name = "Geruta (green)",
                            Type = EnemyType.Flying,
                            CanReplace = true
                        };
                    case 0x38:
                        return new Enemy
                        {
                            SpriteID = 0x38,
                            Name = "Squeept",
                            Type = EnemyType.Lava,
                            CanReplace = true
                        };
                    case 0x3B:
                        return new Enemy
                        {
                            SpriteID = 0x3B,
                            Name = "Dragon",
                            Type = EnemyType.Lava,
                            CanReplace = true
                        };
                    case 0x3F:
                        return new Enemy
                        {
                            SpriteID = 0x3F,
                            Name = "Reo (green wings)",
                            Type = EnemyType.Flying,
                            CanReplace = true
                        };
                    case 0x40:
                        return new Enemy
                        {
                            SpriteID = 0x40,
                            Name = "Reo (purple wings)",
                            Type = EnemyType.Flying,
                            CanReplace = true
                        };
                    case 0x45:
                        return new Enemy
                        {
                            SpriteID = 0x45,
                            Name = "Skultera",
                            Type = EnemyType.Flying,
                            CanReplace = true
                        };
                    case 0x46:
                        return new Enemy
                        {
                            SpriteID = 0x46,
                            Name = "Dessgeega",
                            Type = EnemyType.Floor,
                            CanReplace = true
                        };
                    case 0x48:
                        return new Enemy
                        {
                            SpriteID = 0x48,
                            Name = "Waver",
                            Type = EnemyType.Flying,
                            CanReplace = true
                        };
                    case 0x4A:
                        return new Enemy
                        {
                            SpriteID = 0x4A,
                            Name = "Mellow",
                            Type = EnemyType.Flying,
                            CanReplace = true
                        };
                    case 0x56:
                        return new Enemy
                        {
                            SpriteID = 0x56,
                            Name = "Gamet (blue, single)",
                            Type = EnemyType.Pipe,
                            CanReplace = true
                        };
                    case 0x57:
                        return new Enemy
                        {
                            SpriteID = 0x57,
                            Name = "Gamet (red, single)",
                            Type = EnemyType.Pipe,
                            CanReplace = true
                        };
                    case 0x5B:
                        return new Enemy
                        {
                            SpriteID = 0x5B,
                            Name = "Zebbo (green)",
                            Type = EnemyType.Pipe,
                            CanReplace = true
                        };
                    case 0x5C:
                        return new Enemy
                        {
                            SpriteID = 0x5C,
                            Name = "Zebbo (yellow)",
                            Type = EnemyType.Pipe,
                            CanReplace = true
                        };
                    case 0x5D:
                        return new Enemy
                        {
                            SpriteID = 0x5D,
                            Name = "Worker robot",
                            Type = EnemyType.Ground,
                            CanReplace = true
                        };
                    case 0x67:
                        return new Enemy
                        {
                            SpriteID = 0x67,
                            Name = "Polyp",
                            Type = EnemyType.Ground,
                            CanReplace = true
                        };
                    case 0x68:
                        return new Enemy
                        {
                            SpriteID = 0x68,
                            Name = "Viola (blue)",
                            Type = EnemyType.Crawling,
                            CanReplace = true
                        };
                    case 0x69:
                        return new Enemy
                        {
                            SpriteID = 0x69,
                            Name = "Viola (orange)",
                            Type = EnemyType.Crawling,
                            CanReplace = true
                        };
                    case 0x6B:
                        return new Enemy
                        {
                            SpriteID = 0x6B,
                            Name = "Holtz",
                            Type = EnemyType.Flying,
                            CanReplace = true
                        };
                    case 0x71:
                        return new Enemy
                        {
                            SpriteID = 0x71,
                            Name = "Ripper II",
                            Type = EnemyType.Flying,
                            CanReplace = true
                        };
                    case 0x72:
                        return new Enemy
                        {
                            SpriteID = 0x72,
                            Name = "Mella",
                            Type = EnemyType.Flying,
                            CanReplace = true
                        };
                    case 0x73:
                        return new Enemy
                        {
                            SpriteID = 0x73,
                            Name = "Atomic",
                            Type = EnemyType.Flying,
                            CanReplace = true
                        };
                    case 0x79:
                        return new Enemy
                        {
                            SpriteID = 0x79,
                            Name = "Sidehopper",
                            Type = EnemyType.Floor,
                            CanReplace = true
                        };
                    case 0x7A:
                        return new Enemy
                        {
                            SpriteID = 0x7A,
                            Name = "Geega",
                            Type = EnemyType.Pipe,
                            CanReplace = true
                        };
                    case 0x7B:
                        return new Enemy
                        {
                            SpriteID = 0x7B,
                            Name = "Geega (white)",
                            Type = EnemyType.Pipe,
                            CanReplace = true
                        };
                    case 0x93:
                        return new Enemy
                        {
                            SpriteID = 0x93,
                            Name = "Baristute",
                            Type = EnemyType.Floor,
                            CanReplace = true
                        };
                    case 0x9D:
                        return new Enemy
                        {
                            SpriteID = 0x9D,
                            Name = "Gamet (blue, leader)",
                            Type = EnemyType.Pipe,
                            CanReplace = true
                        };
                    case 0x9F:
                        return new Enemy
                        {
                            SpriteID = 0x9F,
                            Name = "Geega (leader)",
                            Type = EnemyType.Pipe,
                            CanReplace = true
                        };
                    case 0xA1:
                        return new Enemy
                        {
                            SpriteID = 0xA1,
                            Name = "Zebbo (green, leader)",
                            Type = EnemyType.Pipe,
                            CanReplace = true
                        };
                    case 0xC3:
                        return new Enemy
                        {
                            SpriteID = 0xC3,
                            Name = "Baristute (Kraid, upper)",
                            Type = EnemyType.Ground,
                            CanReplace = true
                        };
                    case 0xC8:
                        return new Enemy
                        {
                            SpriteID = 0xC8,
                            Name = "Baristute (Kraid, lower)",
                            Type = EnemyType.Ground,
                            CanReplace = true
                        };
                    default:
                        return null;
                }
            }

            public static Dictionary<byte, Enemy> GetEnemies()
            {
                Dictionary<byte, Enemy> enemies = new Dictionary<byte, Enemy>();
                for (int i = 0; i < 0x100; i++)
                {
                    Enemy en = GetEnemy(i);
                    if (en != null)
                    {
                        enemies.Add(en.SpriteID, en);
                    }
                }
                return enemies;
            }

        }


        public RandomEnemies(Rom rom, Settings settings, Random rng) : base(rom, settings, rng)
        {

        }

        public override bool Randomize()
        {
            if (!settings.randomEnemies) { return true; }

            Dictionary<byte, Enemy> enemies = Enemy.GetEnemies();
            foreach (Enemy en in enemies.Values)
            {
                en.SetGfxInfo(rom);
            }

            // get replacement pools
            Dictionary<EnemyType, List<byte>> replacements = new Dictionary<EnemyType, List<byte>>();
            foreach (EnemyType type in Enum.GetValues(typeof(EnemyType)))
            {
                replacements[type] = new List<byte>();
            }
            foreach (Enemy en in enemies.Values)
            {
                replacements[en.Type].Add(en.SpriteID);

                switch (en.Type)
                {
                    case EnemyType.Crawling:
                        replacements[EnemyType.Ground].Add(en.SpriteID);
                        replacements[EnemyType.Ceiling].Add(en.SpriteID);
                        replacements[EnemyType.Floor].Add(en.SpriteID);
                        replacements[EnemyType.Lava].Add(en.SpriteID);
                        break;
                    case EnemyType.Ground:
                        break;
                    case EnemyType.Ceiling:
                        break;
                    case EnemyType.Floor:
                        replacements[EnemyType.Ground].Add(en.SpriteID);
                        replacements[EnemyType.Ceiling].Add(en.SpriteID);
                        break;
                    case EnemyType.Lava:
                        break;
                    case EnemyType.Flying:
                        break;
                    case EnemyType.Pipe:
                        replacements[EnemyType.Lava].Add(en.SpriteID);
                        break;
                }
            }

            // randomize spritesets
            int ptrOffset = Rom.SpritesetOffset;
            for (int i = 0; i < Rom.NumOfSpritesets; i++)
            {
                int offset = rom.ReadPtr(ptrOffset);
                ptrOffset += 4;
                Dictionary<byte, byte> usedGfxRows = new Dictionary<byte, byte>();

                for (int j = 0; j <= 0xE; j++)
                {
                    byte spriteID = rom.Read8(offset + j * 2);
                    if (spriteID == 0) { break; }
                    if (!enemies.TryGetValue(spriteID, out Enemy en)) { continue; }

                    // check if sprite shares graphics with another
                    byte gfxRow = rom.Read8(offset + j * 2 + 1);
                    if (usedGfxRows.TryGetValue(gfxRow, out byte newID))
                    {
                        rom.Write8(offset + j * 2, newID);
                        continue;
                    }

                    List<byte> candidates = replacements[en.Type];
                    while (true)
                    {
                        int index = rng.Next(candidates.Count);
                        newID = candidates[index];
                        Enemy newEn = enemies[newID];
                        if (newEn.GfxRows <= en.GfxRows)
                        {
                            rom.Write8(offset + j * 2, newID);
                            usedGfxRows[gfxRow] = newID;
                            break;
                        }
                    }
                    
                }
            }

            return true;
        }

        public override string GetLog()
        {
            if (!settings.randomEnemies)
            {
                return "Enemies: Unchanged" + Environment.NewLine;
            }

            return "Enemies: Random" + Environment.NewLine;
        }

    }
}
