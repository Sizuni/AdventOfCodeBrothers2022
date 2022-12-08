using Day03RucksackReorganization.Services;

namespace Day03RucksackReorganization.Domain
{
    public class Rucksack
    {
        public string Content { get; private set; }
        public string FirstCompartment { get; private set; }
        public string SecondCompartment { get; private set; }

        public Rucksack(string content)
        {
            Content = content;
            int amount = content.Length;
            FirstCompartment = content.Substring(0, amount / 2);
            SecondCompartment = content.Substring(amount / 2);
        }

        public char FindCommonItemInBothCompartments()
        {
            return ItemService.FindCommonItem(FirstCompartment, SecondCompartment);
        }
    }
}
