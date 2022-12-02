namespace Day02RockPaperScissors.Services
{
    public class RockPaperScissorsByRoundResultService : RockPaperScissorsService
    {
        public RockPaperScissorsByRoundResultService()
        {
            ResultDictionary.Add("A X", 3); // Rock Scissors
            ResultDictionary.Add("A Y", 4); // Rock Rock
            ResultDictionary.Add("A Z", 8); // Rock Paper
            ResultDictionary.Add("B X", 1); // Paper Rock
            ResultDictionary.Add("B Y", 5); // Paper Paper
            ResultDictionary.Add("B Z", 9); // Paper Scissors
            ResultDictionary.Add("C X", 2); // Scissors Paper
            ResultDictionary.Add("C Y", 6); // Scissors Scissors
            ResultDictionary.Add("C Z", 7); // Scissors Rock
        }
    }
}
