using System;
using System.Collections.Generic;
using System.Text;

namespace mzmr
{
    public class RandomEnemies : RandomAspect
    {
        public RandomEnemies(ROM rom, Settings settings, Random rng) : base(rom, settings, rng)
        {

        }

        public override bool Randomize()
        {
            // get enemy replacements
            System.IO.StreamReader sr = new System.IO.StreamReader("EnemyReplacements.txt");

            Dictionary<byte, byte[]> enemyReplacements = new Dictionary<byte, byte[]>();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line == "" || line.StartsWith(";")) { continue; }
                string[] items = line.Split('=');
                if (items.Length != 2) { continue; }

                byte spriteID = Convert.ToByte(items[0], 16);
                string[] replacementIDs = items[1].Split(',');
                byte[] replacements = Array.ConvertAll(replacementIDs, x => Convert.ToByte(x, 16));
                enemyReplacements.Add(spriteID, replacements);

            }

            sr.Close();

            // randomize spritesets
            int ptrOffset = ROM.SpritesetOffset;
            for (int i = 0; i < ROM.NumOfSpritesets; i++)
            {
                int offset = rom.ReadPtr(ptrOffset);
                ptrOffset += 4;

                for (int j = 0; j <= 0xE; j++)
                {
                    byte spriteID = rom.Read8(offset + j * 2);
                    if (spriteID == 0) { break; }

                    byte[] replacements;
                    if (!enemyReplacements.TryGetValue(spriteID, out replacements)) { continue; }

                    int index = rng.Next(replacements.Length);
                    byte newID = replacements[index];
                    rom.Write8(offset, newID);
                }
            }

            return true;
        }

        public override void GetLog(StringBuilder sb)
        {
            if (true)
            {
                sb.AppendLine("Enemies: Unchanged");
                return;
            }

            string line = "Enemies: ";
        }

    }
}
