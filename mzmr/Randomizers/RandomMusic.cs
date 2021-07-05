using System;
using System.Collections.Generic;

namespace mzmr.Randomizers
{
    public class RandomMusic : RandomAspect
    {
        public RandomMusic(Rom rom, Settings settings, Random rng) : base(rom, settings, rng)
        {

        }

        public override RandomizeResult Randomize(CancellationToken cancellationToken)
        {
            return true;
        }

        public override string GetLog()
        {
            throw new NotImplementedException();
        }

    }
}
