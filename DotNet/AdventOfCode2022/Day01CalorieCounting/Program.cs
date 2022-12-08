using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace Day01CalorieCounting
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
            List<List<string>> input = FileReader.ReadAllLinesFromInputFileGroupedByBlankLine();
            List<int> caloriesPerElf = new List<int>();

            foreach (List<string> inputPerElf in input)
            {
                caloriesPerElf.Add(inputPerElf.ConvertAll(int.Parse).Sum());
            }

            return caloriesPerElf.Max();
        }

        public static int PartTwo()
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
