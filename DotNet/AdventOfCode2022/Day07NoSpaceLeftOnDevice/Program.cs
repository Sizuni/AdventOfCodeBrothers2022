using BenchmarkDotNet.Attributes;
using Day07NoSpaceLeftOnDevice.Domain;
using Day07NoSpaceLeftOnDevice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace Day07NoSpaceLeftOnDevice
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
            Directory root = ParseRootDirectoryInput(input);
            List<Directory> directories = DirectoryService.FindSubDirectoriesWithSizeLessThan(root, 100000);

            return directories.Select(d => d.GetSize()).Sum();
        }

        public static int PartTwo()
        {
            List<string> input = FileReader.ReadAllLinesFromInputFile();
            Directory root = ParseRootDirectoryInput(input);
            int totalDiskSpace = 70000000;
            int requiredFreeSpace = 30000000;
            int currentFreeSpace = totalDiskSpace - root.GetSize();
            int minimumSpaceToBeDeleted = requiredFreeSpace - currentFreeSpace;

            return DirectoryService.FindSubDirectoriesWithSizeGreaterThanrOrEqualTo(root, minimumSpaceToBeDeleted)
                .Min(d => d.GetSize());
        }

        private static Directory ParseRootDirectoryInput(List<string> input)
        {
            Directory root = new Directory("/", null);
            Directory currentDirectory = root;
            foreach (string line in input)
            {
                if (line.StartsWith('$'))
                {
                    // It's a command
                    string[] splitCommand = line.Split(' ');
                    if (splitCommand[1].Equals("cd"))
                    {
                        string target = splitCommand[2];
                        if (target.Equals("/"))
                        {
                            currentDirectory = root;
                        }
                        else if (target.Equals(".."))
                        {
                            currentDirectory = currentDirectory.ParentDirectory;
                        }
                        else
                        {
                            currentDirectory = currentDirectory.FindSubDirectory(target);
                        }
                    }
                    // Ignore lines with ls command
                }
                else
                {
                    // It's an output line of the ls command
                    string[] splitOutputLine = line.Split(' ');
                    if (splitOutputLine[0].Equals("dir"))
                    {
                        // Subdirectory
                        string name = splitOutputLine[1];
                        currentDirectory.AddSubDirectory(name);
                    }
                    else
                    {
                        // File
                        int size = Convert.ToInt32(splitOutputLine[0]);
                        string name = splitOutputLine[1];
                        currentDirectory.AddFile(name, size);
                    }
                }
            }
            return root;
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
