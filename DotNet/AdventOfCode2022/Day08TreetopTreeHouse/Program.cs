using BenchmarkDotNet.Attributes;
using Day08TreetopTreeHouse.Services;
using System.Collections.Generic;
using Util;

namespace Day08TreetopTreeHouse
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
            TreeGridService service = TreeGridService.CreateTreeGridFromInput(input);

            return service.CountVisibleTrees();
        }

        public static int PartTwo()
        {
            List<string> input = FileReader.ReadAllLinesFromInputFile();
            TreeGridService service = TreeGridService.CreateTreeGridFromInput(input);

            int highestScenicScore = 0;
            for (int row = 0; row < service.TreeGrid.Size; row++)
            {
                for (int column = 0; column < service.TreeGrid.Size; column++)
                {
                    int otherScore = service.GetScenicScore(row, column);
                    if (otherScore > highestScenicScore)
                    {
                        highestScenicScore = otherScore;
                    }
                }
            }
            return highestScenicScore;
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
