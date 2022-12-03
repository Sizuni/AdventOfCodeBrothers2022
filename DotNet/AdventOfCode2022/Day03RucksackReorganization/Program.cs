using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Day03RucksackReorganization.Domain;
using Day03RucksackReorganization.Services;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace Day03RucksackReorganization
{
    public class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ProgramBenchmarker>();
            SolutionWriter<int>.WriteSolution(PartOne(), PartTwo());
        }

        public static int PartOne()
        {
            List<string> input = FileReader.ReadAllLinesFromInputFile();

            return input.Select(line => new Rucksack(line))
                .Select(r => r.FindCommonItemInBothCompartments())
                .Select(ItemService.GetPriorityForItem)
                .Sum();
        }

        public static int PartTwo()
        {
            List<string> input = FileReader.ReadAllLinesFromInputFile();

            int sum = 0;
            for (int i = 0; i < input.Count; i += 3)
            {
                Group group = new Group(new Rucksack(input[i]), new Rucksack(input[i + 1]), new Rucksack(input[i + 2]));
                sum += ItemService.GetPriorityForItem(group.FindCommonItemInAllRucksacks());
            }

            return sum;
        }
    }

    [MemoryDiagnoser]
    public class ProgramBenchmarker
    {
        [Benchmark]
        public void PartOne()
        {
            Program.PartOne();
        }

        [Benchmark]
        public void PartTwo()
        {
            Program.PartTwo();
        }
    }
}
