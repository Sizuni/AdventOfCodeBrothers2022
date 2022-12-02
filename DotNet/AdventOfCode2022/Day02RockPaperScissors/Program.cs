using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Day02RockPaperScissors.Services;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace Day02RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            //var summary = BenchmarkRunner.Run<ProgramBenchmarker>();
            SolutionWriter<int>.WriteSolution(PartOne(), 0);
        }

        public static int PartOne()
        {
            List<string> input = FileReader.ReadAllLinesFromInputFile();
            RockPaperScissorsService service = new RockPaperScissorsService();

            return input.Select(service.GetRoundResult).Sum();
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

        //[Benchmark]
        //public void PartTwo()
        //{
        //    Program.PartTwo();
        //}
    }
}
