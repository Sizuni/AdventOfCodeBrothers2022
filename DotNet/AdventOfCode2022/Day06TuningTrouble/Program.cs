using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Util;

namespace Day06TuningTrouble
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
            string input = FileReader.ReadAllLinesFromInputFile()[0];

            return CommunicationSystemService.FindStartOfPacketMarker(input, 4);
        }

        public static int PartTwo()
        {
            string input = FileReader.ReadAllLinesFromInputFile()[0];

            return CommunicationSystemService.FindStartOfPacketMarker(input, 14);
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
