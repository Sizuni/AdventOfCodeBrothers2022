using Day03RucksackReorganization.Services;

namespace Day03RucksackReorganization.Domain
{
    public class Group
    {
        public Rucksack FirstRucksack { get; private set; }
        public Rucksack SecondRucksack { get; private set; }
        public Rucksack ThirdRucksack { get; private set; }

        public Group(Rucksack firstRucksack, Rucksack secondRucksack, Rucksack thirdRucksack)
        {
            FirstRucksack = firstRucksack;
            SecondRucksack = secondRucksack;
            ThirdRucksack = thirdRucksack;
        }

        public char FindCommonItemInAllRucksacks()
        {
            return ItemService.FindCommonItem(FirstRucksack.Content, SecondRucksack.Content, ThirdRucksack.Content);
        }
    }
}
