using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Day05SupplyStacks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Util;

namespace Day05SupplyStacks
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var summary = BenchmarkRunner.Run<ProgramBenchmarker>();
            SolutionWriter<string>.WriteSolution(PartOne(), PartTwo());
        }

        public static string PartOne()
        {
            List<List<string>> input = FileReader.ReadAllLinesFromInputFileGroupedByBlankLine();
            List<string> stacksInput = input[0];
            List<string> procedureInput = input[1];

            List<SupplyStack> supplyStacks = ParseSupplyStacksFromInput(stacksInput);
            List<ProcedureInstruction> procedureInstructions = ParseProcedureInstructionsFromInput(procedureInput);

            ShipCargo shipCargo = new ShipCargo();
            foreach (var supplyStack in supplyStacks)
            {
                shipCargo.AddSupplyStack(supplyStack);
            }

            foreach (var procedureInstruction in procedureInstructions)
            {
                for (int i = 0; i < procedureInstruction.Amount; i++)
                {
                    shipCargo.MoveCrate(procedureInstruction.From, procedureInstruction.To);
                }
            }

            return shipCargo.ReadTopOfEachStack();
        }

        public static string PartTwo()
        {
            List<List<string>> input = FileReader.ReadAllLinesFromInputFileGroupedByBlankLine();
            List<string> stacksInput = input[0];
            List<string> procedureInput = input[1];

            List<SupplyStack> supplyStacks = ParseSupplyStacksFromInput(stacksInput);
            List<ProcedureInstruction> procedureInstructions = ParseProcedureInstructionsFromInput(procedureInput);

            ShipCargo shipCargo = new ShipCargo();
            foreach (var supplyStack in supplyStacks)
            {
                shipCargo.AddSupplyStack(supplyStack);
            }

            foreach (var procedureInstruction in procedureInstructions)
            {
                shipCargo.MoveCrate(procedureInstruction.From, procedureInstruction.To, procedureInstruction.Amount);
            }

            return shipCargo.ReadTopOfEachStack();
        }

        private static List<SupplyStack> ParseSupplyStacksFromInput(List<string> input)
        {
            input.Reverse(); // Read the stack from bottom to top
            input.RemoveAt(0); // Remove the line with stack numbers
            List<string[]> cratesPerLayer = input.Select(line =>
                line.Replace("    ", " ") // An empty spot is represented by 3 spaces, so 4 spaces can be replaced by 1
                    .Replace("[", "")
                    .Replace("]", "")
                    .Split(" "))
                .ToList();
            int amountOfStacks = cratesPerLayer[0].Length;

            List<SupplyStack> supplyStacks = new List<SupplyStack>();
            for (int i = 0; i < amountOfStacks; i++)
            {
                supplyStacks.Add(new SupplyStack());
            }

            foreach (string[] crates in cratesPerLayer)
            {
                int stackIndex = 0;
                foreach (string crate in crates)
                {
                    if (!string.IsNullOrEmpty(crate))
                    {
                        supplyStacks[stackIndex].AddCrate(new Crate(crate));
                    }
                    stackIndex++;
                }
            }


            return supplyStacks;
        }

        private static List<ProcedureInstruction> ParseProcedureInstructionsFromInput(List<string> input)
        {
            List<ProcedureInstruction> instructions = new List<ProcedureInstruction>();
            return input.Select(line => Regex.Split(line, @"\D+").Skip(1).ToArray()) // Skip 1 because using regex will place an empty value on the first index
                .Select(stringValues => Array.ConvertAll(stringValues, int.Parse))
                .Select(values => new ProcedureInstruction(values[0], values[1], values[2]))
                .ToList();
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
