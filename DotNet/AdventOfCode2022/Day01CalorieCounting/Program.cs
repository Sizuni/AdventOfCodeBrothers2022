using System;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace Day01CalorieCounting
{
    class Program
    {
        static void Main(string[] args)
        {
            PartOne();
            PartTwo();
        }

        private static void PartOne()
        {
            List<List<string>> input = FileReader.ReadAllLinesFromInputFileGroupedByBlankLine();
            List<int> caloriesPerElf = new List<int>();
            
            foreach (List<string> inputPerElf in input)
            {
                caloriesPerElf.Add(inputPerElf.ConvertAll(int.Parse).Sum());
            }

            Console.WriteLine($"Result: {caloriesPerElf.Max()}");
        }

        private static void PartTwo()
        {
            List<List<string>> input = FileReader.ReadAllLinesFromInputFileGroupedByBlankLine();
            List<int> caloriesPerElf = new List<int>();

            foreach (List<string> inputPerElf in input)
            {
                caloriesPerElf.Add(inputPerElf.ConvertAll(int.Parse).Sum());
            }
            caloriesPerElf.Sort();

            Console.WriteLine($"Result: {caloriesPerElf.TakeLast(3).Sum()}");
        }
    }
}
