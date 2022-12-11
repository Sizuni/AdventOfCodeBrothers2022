using BenchmarkDotNet.Attributes;
using Day09RopeBridge.Domain;
using Day09RopeBridge.Services;
using System;
using System.Collections.Generic;
using Util;

namespace Day09RopeBridge
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
            RopePositionMapperService service = new RopePositionMapperService(new ShortRope());
            foreach (string line in input)
            {
                string[] lineInfo = line.Split(' ');
                string direction = lineInfo[0];
                int amount = Convert.ToInt32(lineInfo[1]);
                switch(direction)
                {
                    case "R":
                        for (int i = 0; i < amount; i++)
                        {
                            service.MoveRight();
                        }
                        break;
                    case "L":
                        for (int i = 0; i < amount; i++)
                        {
                            service.MoveLeft();
                        }
                        break;
                    case "U":
                        for (int i = 0; i < amount; i++)
                        {
                            service.MoveUp();
                        }
                        break;
                    case "D":
                        for (int i = 0; i < amount; i++)
                        {
                            service.MoveDown();
                        }
                        break;
                }
            }

            return service.GetAmountOfPositionsVisited();
        }

        public static int PartTwo()
        {
            List<string> input = FileReader.ReadAllLinesFromInputFile();
            RopePositionMapperService service = new RopePositionMapperService(new LongRope(10));
            foreach (string line in input)
            {
                string[] lineInfo = line.Split(' ');
                string direction = lineInfo[0];
                int amount = Convert.ToInt32(lineInfo[1]);
                switch (direction)
                {
                    case "R":
                        for (int i = 0; i < amount; i++)
                        {
                            service.MoveRight();
                        }
                        break;
                    case "L":
                        for (int i = 0; i < amount; i++)
                        {
                            service.MoveLeft();
                        }
                        break;
                    case "U":
                        for (int i = 0; i < amount; i++)
                        {
                            service.MoveUp();
                        }
                        break;
                    case "D":
                        for (int i = 0; i < amount; i++)
                        {
                            service.MoveDown();
                        }
                        break;
                }
            }

            return service.GetAmountOfPositionsVisited();
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
