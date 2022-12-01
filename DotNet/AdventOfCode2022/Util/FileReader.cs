using System.Collections.Generic;
using System.IO;

namespace Util
{
    public class FileReader
    {
        public static string InputFileName => "input.txt";
        public static string TestInputFileName => "testInput.txt";

        public static List<string> ReadAllLinesFromInputFile()
        {
            return ReadAllLinesFrom(InputFileName);
        }

        public static List<List<string>> ReadAllLinesFromInputFileGroupedByBlankLine()
        {
            return ReadAllLinesGroupedByBlankLineFrom(InputFileName);
        }

        public static List<string> ReadAllLinesFromTestInputFile()
        {
            return ReadAllLinesFrom(TestInputFileName);
        }

        public static List<List<string>> ReadAllLinesFromTestInputFileGroupedByBlankLine()
        {
            return ReadAllLinesGroupedByBlankLineFrom(TestInputFileName);
        }

        private static List<string> ReadAllLinesFrom(string file)
        {
            string currentFolder = Directory.GetCurrentDirectory();
            string inputFile = Path.Combine(currentFolder, file);
            return new List<string>(File.ReadAllLines(inputFile));
        }

        private static List<List<string>> ReadAllLinesGroupedByBlankLineFrom(string file)
        {
            List<string> inputLines = ReadAllLinesFrom(file);
            List<List<string>> result = new List<List<string>>();

            List<string> group = new List<string>();
            foreach (string line in inputLines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    group.Add(line);
                }
                else
                {
                    result.Add(group);
                    group = new List<string>();
                }
            }
            return result;
        }
    }
}
