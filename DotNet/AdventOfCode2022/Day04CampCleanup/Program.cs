using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Day04CampCleanup.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace Day04CampCleanup
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
            return input.Select(line => line.Split(',', '-'))
                .Select(sectionList => Array.ConvertAll(sectionList, int.Parse))
                .Select(sectionList => new SectionAssignmentPair(sectionList[0], sectionList[1], sectionList[2], sectionList[3]))
                .Where(section => section.HasFullyContainedPair())
                .Count();
        }

        public static int PartTwo()
        {
            List<string> input = FileReader.ReadAllLinesFromInputFile();
            return input.Select(line => line.Split(',', '-'))
                .Select(sectionList => Array.ConvertAll(sectionList, int.Parse))
                .Select(sectionList => new SectionAssignmentPair(sectionList[0], sectionList[1], sectionList[2], sectionList[3]))
                .Where(section => section.HasOverlap())
                .Count();
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
