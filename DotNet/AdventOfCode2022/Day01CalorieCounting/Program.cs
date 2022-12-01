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
            SolutionWriter<int>.WriteSolution(PartOne(), PartTwo());
        }

        private static int PartOne()
        {
            List<List<string>> input = FileReader.ReadAllLinesFromInputFileGroupedByBlankLine();
            List<int> caloriesPerElf = new List<int>();
            
            foreach (List<string> inputPerElf in input)
            {
                caloriesPerElf.Add(inputPerElf.ConvertAll(int.Parse).Sum());
            }

            return caloriesPerElf.Max();
        }

        private static int PartTwo()
        {
            List<List<string>> input = FileReader.ReadAllLinesFromInputFileGroupedByBlankLine();
            List<int> caloriesPerElf = new List<int>();

            foreach (List<string> inputPerElf in input)
            {
                caloriesPerElf.Add(inputPerElf.ConvertAll(int.Parse).Sum());
            }
            caloriesPerElf.Sort();

            return caloriesPerElf.TakeLast(3).Sum();
        }
    }
}
