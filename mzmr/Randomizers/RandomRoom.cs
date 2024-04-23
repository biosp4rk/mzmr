using mzmr.Properties;
using mzmr.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Threading.Tasks;
using static mzmr.Randomizers.RandomBosses;

namespace mzmr.Randomizers
{
    internal class RandomRoom : RandomAspect
    {
        public RandomRoom(Rom rom, Settings settings, Random rng) : base(rom, settings, rng)
        {

        }

        public override RandomizeResult Randomize(CancellationToken cancellationToken)
        {
            return new RandomizeResult(true);
        }



        public void Import(string filename)
        {
            byte[] roomData = File.ReadAllBytes(filename);

        }




        public override string GetLog()
        {
            return "";
        }
    }
}
