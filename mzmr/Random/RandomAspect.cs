using System;
using System.Collections.Generic;
using System.Text;

namespace mzmr
{
    public abstract class RandomAspect
    {
        protected ROM rom;
        protected Settings settings;
        protected Random rng;

        public RandomAspect(ROM rom, Settings settings, Random rng)
        {
            this.rom = rom;
            this.settings = settings;
            this.rng = rng;
        }

        public abstract bool Randomize();

        public abstract void GetLog(StringBuilder sb);
    }
}
