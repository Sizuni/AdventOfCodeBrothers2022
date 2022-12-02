using System.Collections.Generic;

namespace Day02RockPaperScissors.Services
{
    public class RockPaperScissorsService
    {
        public Dictionary<string, int> ResultDictionary { get; private set; }
        public RockPaperScissorsService()
        {
            ResultDictionary = new Dictionary<string, int>();
            ResultDictionary.Add("A X", 4); // Rock Rock
            ResultDictionary.Add("A Y", 8); // Rock Paper
            ResultDictionary.Add("A Z", 3); // Rock Scissors
            ResultDictionary.Add("B X", 1); // Paper Rock
            ResultDictionary.Add("B Y", 5); // Paper Paper
            ResultDictionary.Add("B Z", 9); // Paper Scissors
            ResultDictionary.Add("C X", 7); // Scissors Rock
            ResultDictionary.Add("C Y", 2); // Scissors Paper
            ResultDictionary.Add("C Z", 6); // Scissors Scissors
        }

        public int GetRoundResult(string input)
        {
            if (ResultDictionary.TryGetValue(input, out int result))
            {
                return result;
            }
            throw new KeyNotFoundException($"No value found for key: {input}");
        }
    }
}
