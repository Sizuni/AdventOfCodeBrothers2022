using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Day10CathodeRayTube.Domain;
using Day10CathodeRayTube.Services;
using System.Collections.Generic;
using Util;

namespace Day10CathodeRayTube
{
    public class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ProgramBenchmarker>();
            SolutionWriter<string>.WriteSolution(PartOne(), PartTwo());
        }

        public static string PartOne()
        {
            List<string> input = FileReader.ReadAllLinesFromInputFile();
            CpuService service = new CpuService(new Cpu());
            foreach (string instruction in input)
            {
                service.ApplyInstruction(instruction);
            }

            int sum = 0;
            foreach (int cycle in new int[] { 20, 60, 100, 140, 180, 220 })
            {
                sum += cycle * service.Cpu.GetSignalStrenghtForCycle(cycle);
            }
            return sum.ToString();
        }

        public static string PartTwo()
        {
            List<string> input = FileReader.ReadAllLinesFromInputFile();
            CpuService service = new CpuService(new Cpu());
            foreach (string instruction in input)
            {
                service.ApplyInstruction(instruction);
            }
            return "\n" + service.DrawImage();
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
