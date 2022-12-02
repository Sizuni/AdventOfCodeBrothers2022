using System.Collections.Generic;

namespace Day02RockPaperScissors.Services
{
    public abstract class RockPaperScissorsService
    {
        public Dictionary<string, int> ResultDictionary { get; protected set; }

        protected RockPaperScissorsService()
        {
            ResultDictionary = new Dictionary<string, int>();
        }

        public int GetRoundResult(string input) {
            if (ResultDictionary.TryGetValue(input, out int result))
            {
                return result;
            }
            throw new KeyNotFoundException($"No value found for key: {input}");
        }
    }
}
