using System.Collections.Generic;
using System.IO;

namespace Util
{
    public class FileReader
    {
        public static List<string> ReadAllLinesFromInputFile()
        {
            return ReadAllLinesFrom("input.txt");
        }

        public static List<List<string>> ReadAllLinesFromInputFileGroupedByBlankLine()
        {
            List<string> inputLines = ReadAllLinesFromInputFile();
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

        public static List<string> ReadAllLinesFromTestInputFile()
        {
            return ReadAllLinesFrom("testInput.txt");
        }

        private static List<string> ReadAllLinesFrom(string file)
        {
            string currentFolder = Directory.GetCurrentDirectory();
            string inputFile = Path.Combine(currentFolder, file);
            return new List<string>(File.ReadAllLines(inputFile));
        }
    }
}
