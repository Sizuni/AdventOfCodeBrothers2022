using System;
using System.Collections.Generic;
using System.Text;

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
            int[] itemCountFirstRucksack = new int[52];
            foreach (char item in FirstRucksack.Content)
            {
                if (char.IsLower(item))
                {
                    itemCountFirstRucksack[item - 'a']++;
                }
                else
                {
                    itemCountFirstRucksack[item - 'A' + 26]++;
                }
            }

            int[] itemCountSecondRucksack = new int[52];
            foreach (char item in SecondRucksack.Content)
            {
                if (char.IsLower(item))
                {
                    itemCountSecondRucksack[item - 'a']++;
                }
                else
                {
                    itemCountSecondRucksack[item - 'A' + 26]++;
                }
            }

            int[] itemCountThirdRucksack = new int[52];
            foreach (char item in ThirdRucksack.Content)
            {
                if (char.IsLower(item))
                {
                    itemCountThirdRucksack[item - 'a']++;
                }
                else
                {
                    itemCountThirdRucksack[item - 'A' + 26]++;
                }
            }

            bool[] itemContentFirstRucksack = Array.ConvertAll(itemCountFirstRucksack, count => count > 0);
            bool[] itemContentSecondRucksack = Array.ConvertAll(itemCountSecondRucksack, count => count > 0);
            bool[] itemContentThirdRucksack = Array.ConvertAll(itemCountThirdRucksack, count => count > 0);

            for (int i = 0; i < 52; i++)
            {
                if (itemContentFirstRucksack[i] && itemContentSecondRucksack[i] && itemContentThirdRucksack[i])
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
    }
}
