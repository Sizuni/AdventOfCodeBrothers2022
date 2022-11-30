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

        public static List<string> ReadAllLinesFromTestInputFile()
        {
            return ReadAllLinesFrom("testInput.txt");
        }

        public static List<string> ReadAllLinesFrom(string file)
        {
            string currentFolder = Directory.GetCurrentDirectory();
            string inputFile = Path.Combine(currentFolder, file);
            return new List<string>(File.ReadAllLines(inputFile));
        }
    }
}
