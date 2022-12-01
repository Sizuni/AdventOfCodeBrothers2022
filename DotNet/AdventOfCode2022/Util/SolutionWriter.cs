using System;

namespace Util
{
    public class SolutionWriter<T>
    {
        public static void WriteSolution(T solutionPartOne, T solutionPartTwo)
        {
            Console.WriteLine($"Result:\n  Part 1: {solutionPartOne}\n  Part 2: {solutionPartTwo}");
        }
    }
}
