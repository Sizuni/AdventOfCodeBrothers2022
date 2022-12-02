﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Day02RockPaperScissors.Services;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace Day02RockPaperScissors
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
            RockPaperScissorsService service = new RockPaperScissorsByShapeService();

            return input.Select(service.GetRoundResult).Sum();
        }

        public static int PartTwo()
        {
            List<string> input = FileReader.ReadAllLinesFromInputFile();
            RockPaperScissorsService service = new RockPaperScissorsByRoundResultService();

            return input.Select(service.GetRoundResult).Sum();
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
}