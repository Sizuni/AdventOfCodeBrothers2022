using System;

namespace Day03RucksackReorganization.Services
{
    public class ItemService
    {
        public static char FindCommonItem(params string[] itemCollections)
        {
            if (itemCollections.Length < 2)
            {
                return '0';
            }

            int[][] itemCountPerCollection = new int[itemCollections.Length][];
            for (int i = 0; i < itemCollections.Length; i++)
            {
                string items = itemCollections[i];
                itemCountPerCollection[i] = new int[52];
                foreach (char item in items)
                {
                    if (char.IsLower(item))
                    {
                        itemCountPerCollection[i][item - 'a']++;
                    }
                    else
                    {
                        itemCountPerCollection[i][item - 'A' + 26]++;
                    }
                }
            }

            bool[][] itemFoundPerCollection = new bool[itemCollections.Length][];
            for (int i = 0; i < itemCollections.Length; i++)
            {
                itemFoundPerCollection[i] = Array.ConvertAll(itemCountPerCollection[i], count => count > 0);
            }

            for (int itemIndex = 0; itemIndex < 52; itemIndex++)
            {
                bool commonItemFound = false;
                for (int collectionIndex = 0; collectionIndex < itemCollections.Length - 1; collectionIndex++)
                {
                    if (!(itemFoundPerCollection[collectionIndex][itemIndex] && itemFoundPerCollection[collectionIndex + 1][itemIndex]))
                    {
                        break;
                    }
                    if (collectionIndex == itemCollections.Length - 2)
                    {
                        commonItemFound = true;
                    }
                }

                if (commonItemFound)
                {
                    if (itemIndex < 26)
                    {
                        return Convert.ToChar(itemIndex + 'a');
                    }
                    return Convert.ToChar(itemIndex - 26 + 'A');
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
