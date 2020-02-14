using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace mzmr
{
    public class RandomEnemies : RandomAspect
    {
        public enum EnemyType { Crawling, Ground, Ceiling, Floor, Lava, Flying, Pipe }

        private class Enemy
        {
            public byte spriteID;
            public EnemyType type;
            public int gfxOffset;
            public int gfxRows;

            public Enemy(ROM rom, byte spriteID, EnemyType type)
            {
                this.spriteID = spriteID;
                this.type = type;

                gfxOffset = rom.ReadPtr(ROM.SpriteGfxOffset + (spriteID - 0x10) * 4);
                gfxRows = (rom.Read32(gfxOffset) >> 8) / 0x800;
            }
        }


        public RandomEnemies(ROM rom, Settings settings, Random rng) : base(rom, settings, rng)
        {

        }

        public override bool Randomize()
        {
            // get enemies
            Dictionary<byte, Enemy> enemies = new Dictionary<byte, Enemy>();
            JArray arr = JsonConvert.DeserializeObject<JArray>(Properties.Resources.enemies);
            foreach (JObject obj in arr)
            {
                byte spriteID = Convert.ToByte(obj.Value<string>("SpriteID"), 16);
                string enemyType = obj.Value<string>("Type");
                EnemyType type = (EnemyType)Enum.Parse(typeof(EnemyType), enemyType);
                Enemy en = new Enemy(rom, spriteID, type);
                enemies[spriteID] = en;
            }

            // get replacement pools
            Dictionary<EnemyType, List<byte>> replacements = new Dictionary<EnemyType, List<byte>>();
            foreach (EnemyType type in Enum.GetValues(typeof(EnemyType)))
            {
                replacements[type] = new List<byte>();
            }
            foreach (Enemy en in enemies.Values)
            {
                replacements[en.type].Add(en.spriteID);

                switch (en.type)
                {
                    case EnemyType.Crawling:
                        replacements[EnemyType.Ground].Add(en.spriteID);
                        replacements[EnemyType.Ceiling].Add(en.spriteID);
                        replacements[EnemyType.Floor].Add(en.spriteID);
                        replacements[EnemyType.Lava].Add(en.spriteID);
                        break;
                    case EnemyType.Ground:
                        break;
                    case EnemyType.Ceiling:
                        break;
                    case EnemyType.Floor:
                        replacements[EnemyType.Ground].Add(en.spriteID);
                        replacements[EnemyType.Ceiling].Add(en.spriteID);
                        break;
                    case EnemyType.Lava:
                        break;
                    case EnemyType.Flying:
                        break;
                    case EnemyType.Pipe:
                        replacements[EnemyType.Lava].Add(en.spriteID);
                        break;
                }
            }

            // randomize spritesets
            int ptrOffset = ROM.SpritesetOffset;
            for (int i = 0; i < ROM.NumOfSpritesets; i++)
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

                    List<byte> candidates = replacements[en.type];
                    while (true)
                    {
                        int index = rng.Next(candidates.Count);
                        newID = candidates[index];
                        Enemy newEn = enemies[newID];
                        if (newEn.gfxRows <= en.gfxRows)
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

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Enemies:");
            return sb.ToString();
        }

    }
}
