using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mzmr.Randomizers
{
    class RandomStats : RandomAspect
    {
        public RandomStats(Rom rom, Settings settings, Random rng) : base(rom, settings, rng)
        {

        }

        private static readonly byte[] primarySpriteAllList = //list of primary sprites that can have every stat changed
        { 
            0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1F, 0x20, 0x32, 0x33, 0x34, 0x36, 0x37,
            0x38, 0x39, 0x3B, 0x3C, 0x3F, 0x40, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x51, 0x52, 0x53,
            0x54, 0x55, 0x56, 0x57, 0x5B, 0x5C, 0x66, 0x67, 0x68, 0x69, 0x6B, 0x71, 0x72, 0x73, 0x79,
            0x7A, 0x7B, 0x7C, 0x84, 0x85, 0x93, 0xA5, 0xA6, 0xA7, 0xC7, 0xC9, 0xCA, 0xCB, 0xCC, 0xCD
        };

        private static readonly byte[] secondarySpriteList = //list of secondary sprites that can have stats changed (will not change weaknesses)
        {
            0x03, 0x06, 0x08, 0x0A, 0x10, 0x12, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1B, 0x1C, 0x1D,
            0x1F, 0x20, 0x21, 0x25, 0x26, 0x29, 0x2F, 0x36, 0x37, 0x39, 0x42, 0x43, 0x44, 0x48, 0x49,
            0x4A
        };

        private static readonly byte[] primarySpriteDamageList =  //list of primary sprites that should only have health and damage changed (bosses etc)
        {
            0x42, 0x43, 0x4B, 0x4D, 0x4F, 0x61, 0x64, 0x65, 0x6D, 0x6F, 0x75, 0x77, 0x80, 0x81, 0x82,
            0x83, 0x86, 0x8B, 0xAD, 0xAE, 0xB7, 0xB8, 0xB9, 0xBD, 0xC3, 0xC6, 0xC8
        };

        public override bool Randomize()
        {
            if (settings.EnemyHealth)
            {
                RandomizeHealthDamage(primarySpriteAllList, settings.HealthMinimum, settings.HealthMaximum, 0x2B0D68);
                RandomizeHealthDamage(primarySpriteDamageList, settings.HealthMinimum, settings.HealthMaximum, 0x2B0D68);
                RandomizeHealthDamage(secondarySpriteList, settings.HealthMinimum, settings.HealthMaximum, 0x2B1BE4);
            }
            if (settings.EnemyDamage)
            {
                RandomizeHealthDamage(primarySpriteAllList, settings.DamageMinimum, settings.DamageMaximum, 0x2B0D6A);
                RandomizeHealthDamage(primarySpriteDamageList, settings.DamageMinimum, settings.DamageMaximum, 0x2B0D6A);
                RandomizeHealthDamage(secondarySpriteList, settings.DamageMinimum, settings.DamageMaximum, 0x2B1BE6);
            }
            if (settings.EnemyWeakness)
                RandomizeWeakness();
            if (settings.EnemyDrops)
            {
                RandomizeDrops(primarySpriteAllList, 0x2B0D6E);
                RandomizeDrops(primarySpriteDamageList, 0x2B0D6E);
                RandomizeDrops(secondarySpriteList, 0x2B1BEA);
            }
            return true;
        }

        private void RandomizeWeakness()
        {
            ushort newVal;
            for (int i = 0; i < primarySpriteAllList.Length; i++)
            {
                newVal = (ushort)rng.Next(0x1, 0x41);      //sets random values for weakness (valid weakness flags are 0x1 - 0x40)
                if ((newVal & 0xF) == 0)
                    newVal += 2; //add beam weakness if immune to other shootable projectiles. Should prevent too many immune enemies
                rom.Write16(0x2B0D6C + (primarySpriteAllList[i] * 0x12), newVal);

            }
        }

        private void RandomizeDrops(byte[] arr, int offset)
        {
            ushort total, val;
            for (int i = 0; i < arr.Length; i++)
            {
                total = (ushort)rng.Next(0, 0x401);     //0x400 is total allowed in game
                rom.Write16((offset + 2) + (arr[i] * 0x12), total); //small health
                val = (ushort)rng.Next(0, 0x401 - total);
                total += val;
                rom.Write16((offset + 4) + (arr[i] * 0x12), val); //large health
                val = (ushort)rng.Next(0, 0x401 - total);
                total += val;
                rom.Write16((offset + 6) + (arr[i] * 0x12), val); //missile
                val = (ushort)rng.Next(0, 0x401 - total);
                total += val;
                rom.Write16((offset + 8) + (arr[i] * 0x12), val); //super
                val = (ushort)rng.Next(0, 0x401 - total);
                total += val;
                rom.Write16((offset + 10) + (arr[i] * 0x12), val); //PB
                val = (ushort)(0x400 - total); //no drop = whatever is left over out of 0x400
                rom.Write16(offset + (arr[i] * 0x12), val);
            }
        }

        //function for rnadomizing damage and health stats
        private void RandomizeHealthDamage(byte[] arr, int min, int max, int offset)
        {
            float newVal;  
            for (int i = 0; i < arr.Length; i++)
            {
                newVal = rom.Read16(offset + (arr[i] * 0x12));
                newVal *= ((float)rng.Next(min, max) / 100); //random val between min and max / 100
                if (newVal < 1)
                    newVal = 1;
                rom.Write16(offset + (arr[i] * 0x12), (ushort)newVal);
            }
        }

        public override string GetLog()
        {
            var changed = new List<string>();
            if (settings.EnemyHealth)
                changed.Add("Health");
            if (settings.EnemyDamage)
                changed.Add("Damage");
            if (settings.EnemyWeakness)
                changed.Add("Vulnerabilities");
            if (settings.EnemyDrops)
                changed.Add("Drops");
            return "Enemy Stats: " + string.Join(", ", changed) + Environment.NewLine;
        }
    }
}
