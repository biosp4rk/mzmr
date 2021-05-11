using Randomizer;

namespace mzmr.Randomizers
{
    public class RandomizeResult
    {
        public RandomizeResult()
        {
        }

        public RandomizeResult(bool success)
        {
            Success = success;
        }

        public bool Success { get; set; }

        public LogLayer DetailedLog { get; set; }
    }
}
