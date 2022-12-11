using Day07NoSpaceLeftOnDevice.Domain;
using System.Collections.Generic;

namespace Day07NoSpaceLeftOnDevice.Services
{
    public class DirectoryService
    {
        public static List<Directory> FindSubDirectoriesWithSizeLessThan(Directory directory, int size)
        {
            List<Directory> result = new List<Directory>();

            foreach (Directory subDirectory in directory.SubDirectories)
            {
                result.AddRange(FindSubDirectoriesWithSizeLessThan(subDirectory, size));
            }
            if (directory.GetSize() < size)
            {
                result.Add(directory);
            }

            return result;
        }

        public static List<Directory> FindSubDirectoriesWithSizeGreaterThanrOrEqualTo(Directory directory, int size)
        {
            List<Directory> result = new List<Directory>();

            foreach (Directory subDirectory in directory.SubDirectories)
            {
                result.AddRange(FindSubDirectoriesWithSizeGreaterThanrOrEqualTo(subDirectory, size));
            }
            if (directory.GetSize() >= size)
            {
                result.Add(directory);
            }

            return result;
        }
    }
}
