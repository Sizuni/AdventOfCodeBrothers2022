using System;

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
            int[] itemCountFirstCompartment = new int[52];
            foreach (char item in FirstCompartment)
            {
                if (char.IsLower(item))
                {
                    itemCountFirstCompartment[item - 'a']++;
                }
                else
                {
                    itemCountFirstCompartment[item - 'A' + 26]++;
                }
            }

            int[] itemCountSecondCompartment = new int[52];
            foreach (char item in SecondCompartment)
            {
                if (char.IsLower(item))
                {
                    itemCountSecondCompartment[item - 'a']++;
                }
                else
                {
                    itemCountSecondCompartment[item - 'A' + 26]++;
                }
            }

            bool[] itemContentFirstCompartment = Array.ConvertAll(itemCountFirstCompartment, count => count > 0);
            bool[] itemContentSecondCompartment = Array.ConvertAll(itemCountSecondCompartment, count => count > 0);

            for (int i = 0; i < 52; i++)
            {
                if (itemContentFirstCompartment[i] && itemContentSecondCompartment[i])
                {
                    if (i < 26)
                    {
                        return Convert.ToChar(i + 'a');
                    }
                    return Convert.ToChar(i - 26 + 'A');
                }
            }
            return '0';
        }

        public static int GetPriorityForItem(char item)
        {
            if (char.IsLower(item))
            {
                return item - 'a' + 1;
            }
            return item - 'A' + 27;
        }
    }
}
