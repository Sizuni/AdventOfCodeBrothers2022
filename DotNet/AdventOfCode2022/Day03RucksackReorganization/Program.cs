using BenchmarkDotNet.Attributes;
using Day03RucksackReorganization.Domain;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace Day03RucksackReorganization
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var summary = BenchmarkRunner.Run<ProgramBenchmarker>();
            SolutionWriter<int>.WriteSolution(PartOne(), PartTwo());
        }

        public static int PartOne()
        {
            List<string> input = FileReader.ReadAllLinesFromInputFile();

            return input.Select(line => new Rucksack(line))
                .Select(r => r.FindCommonItemInBothCompartments())
                .Select(Rucksack.GetPriorityForItem)
                .Sum();
        }

        public static int PartTwo()
        {
            return 0;
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
