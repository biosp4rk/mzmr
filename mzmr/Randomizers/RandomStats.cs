using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mzmr.Randomizers
{
    class RandomStats : RandomAspect
    {
        public RandomStats(Rom rom, Settings settings, Random rng) : base(rom, settings, rng)
        {
            primaryStats = rom.PrimarySpriteStats;
            secondaryStats = secondaryStats;
        }

        private readonly Int32 primaryStats, secondaryStats;

        private static readonly byte[] primarySpriteAllList = //list of primary sprites that can have every stat changed
        { 
            0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1F, 0x20, 0x32, 0x33, 0x34, 0x36, 0x37,
            0x38, 0x3B, 0x3F, 0x40, 0x45, 0x46, 0x48, 0x4A, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 
            0x57, 0x5B, 0x5C, 0x66, 0x67, 0x68, 0x69, 0x6B, 0x71, 0x72, 0x73, 0x79, 0x7A, 0x7B, 0x7C, 
            0x84, 0x85, 0x93, 0xA5, 0xA6, 0xA7, 0xC7, 0xC9, 0xCA, 0xCB, 0xCC, 0xCD
        };

        private static readonly byte[] secondarySpriteList = //list of secondary sprites that can have stats changed (will not change weaknesses)
        {
            0x03, 0x06, 0x08, 0x0A, 0x10, 0x12, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1B, 0x1C, 0x1D,
            0x1F, 0x20, 0x21, 0x25, 0x26, 0x29, 0x2F, 0x36, 0x37, 0x39, 0x42, 0x43, 0x44, 0x48, 0x49,
            0x4A
        };

        private static readonly byte[] primarySpriteDamageList =  //list of primary sprites that should only have health and damage changed (bosses etc)
        {
            0x42, 0x43, 0x4B, 0x4D, 0x4F, 0x61, 0x64, 0x65, 0x6D, 0x75, 0x77, 0x80, 0x81, 0x82, 0x83,
            0x86, 0x8B, 0xAD, 0xAE, 0xB7, 0xB8, 0xB9, 0xBD, 0xC3, 0xC6, 0xC8, 0x39, 0x3C, 0x49, 0x6C,
            0x8A, 0x47
        };

        public override RandomizeResult Randomize(CancellationToken cancellationToken)
        {
            if (settings.EnemyHealth)
            {
                RandomizeHealthDamage(primarySpriteAllList, settings.HealthMinimum, settings.HealthMaximum, primaryStats);
                RandomizeHealthDamage(primarySpriteDamageList, settings.HealthMinimum, settings.HealthMaximum, primaryStats);
                RandomizeHealthDamage(secondarySpriteList, settings.HealthMinimum, settings.HealthMaximum, secondaryStats);
            }
            if (settings.EnemyDamage)
            {
                RandomizeHealthDamage(primarySpriteAllList, settings.DamageMinimum, settings.DamageMaximum, primaryStats + 2);
                RandomizeHealthDamage(primarySpriteDamageList, settings.DamageMinimum, settings.DamageMaximum, primaryStats + 2);
                RandomizeHealthDamage(secondarySpriteList, settings.DamageMinimum, settings.DamageMaximum, secondaryStats + 2);
            }
            if (settings.EnemyWeakness)
                RandomizeWeakness();
            if (settings.EnemyDrops)
            {
                RandomizeDrops(primarySpriteAllList, primaryStats + 6);
                RandomizeDrops(primarySpriteDamageList, primaryStats + 6);
                RandomizeDrops(secondarySpriteList, secondaryStats + 6);
            }
            return new RandomizeResult(true);
        }

        private void RandomizeWeakness()
        {
            ushort newVal = 0;
            for (byte i = 0; i < primarySpriteAllList.Length; i++, newVal = 0)
            {
                for (byte j = 1; j <= 0x40; j *= 2)     //should give all flags a 50/50 chance of being on
                {
                    if (rng.Next(2) == 1)       //random bool
                        newVal |= j;
                }
                if (((newVal & 0x3F) == 0) || (((newVal & 2) == 0) && ((rng.Next(3) < 2))))
                    newVal |= 2; //if immune to all, make weak to beam. otherwise another chance (2/3rds) for base beam vulnerability
                rom.Write16(primaryStats + 4 + (primarySpriteAllList[i] * 0x12), newVal);
            }
        }

        private void RandomizeDrops(byte[] arr, int offset)
        {
            int[] dropVals = new int[6];
            float c;
            for (byte i = 0; i < arr.Length; i++)
            {
                for (byte j = 0; j < dropVals.Length; j++)
                    dropVals[j] = rng.Next(0x400);
                c = (float)0x400 / dropVals.Sum();      //coefficient 
                for (byte j = 0; j < dropVals.Length; j++)
                    dropVals[j] = (int)(dropVals[j] * c);   //scale values down to meet 0x400
                while (dropVals.Sum() < 0x400)
                    dropVals[rng.Next(0, 6)]++;         //randomly increase random values in array until sum = 0x400, accounts for rounding error
                for (byte j = 0; j < dropVals.Length; j++)
                {
                    rom.Write16((offset + (j * 2)) + (arr[i] * 0x12), (ushort)dropVals[j]);
                    dropVals[j] = 0;
                }
            }
        }

        //function for randomizing damage and health stats
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
            if (changed.Count == 0)
                return "Enemy Stats: Unchanged";
            return "Enemy Stats: " + string.Join(", ", changed) + Environment.NewLine;
        }
    }
}
