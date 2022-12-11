using System.Collections.Generic;
using System.Linq;

namespace Day07NoSpaceLeftOnDevice.Domain
{
    public class Directory
    {
        public string Name { get; private set; }
        public Directory ParentDirectory { get; private set; }
        public List<Directory> SubDirectories { get; private set; }
        public List<File> Files { get; private set; }

        public Directory(string name, Directory parent)
        {
            Name = name;
            ParentDirectory = parent;
            SubDirectories = new List<Directory>();
            Files = new List<File>();
        }

        public void AddSubDirectory(string name)
        {
            Directory directory = new Directory(name, this);
            SubDirectories.Add(directory);
        }

        public void AddFile(string name, int size)
        {
            File file = new File(name, size);
            Files.Add(file);
        }

        public Directory FindSubDirectory(string name)
        {
            return SubDirectories.Find(d => d.Name.Equals(name));
        }

        public int GetSize()
        {
            return Files.Select(f => f.Size).Sum() + SubDirectories.Select(d => d.GetSize()).Sum();
        }
    }
}
