using System;
using System.Text;

namespace mzmr.Randomizers
{
    public abstract class RandomAspect
    {
        protected Rom rom;
        protected Settings settings;
        protected Random rng;

        public RandomAspect(Rom rom, Settings settings, Random rng)
        {
            this.rom = rom;
            this.settings = settings;
            this.rng = rng;
        }

        public abstract bool Randomize();

        public abstract string GetLog();


    }
}
