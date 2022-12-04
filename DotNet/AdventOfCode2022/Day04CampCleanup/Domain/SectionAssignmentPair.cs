namespace Day04CampCleanup.Domain
{
    public class SectionAssignmentPair
    {
        public int ElfOneFirstSection { get; private set; }
        public int ElfOneLastSection { get; private set; }
        public int ElfTwoFirstSection { get; private set; }
        public int ElfTwoLastSection { get; private set; }

        public SectionAssignmentPair(int elfOneFirstSection, int elfOneLastSection, int elfTwoFirstSection, int elfTwoLastSection)
        {
            ElfOneFirstSection = elfOneFirstSection;
            ElfOneLastSection = elfOneLastSection;
            ElfTwoFirstSection = elfTwoFirstSection;
            ElfTwoLastSection = elfTwoLastSection;
        }

        /// <summary>
        /// Checks whether the sections of one elf is fully contained by the other elf.
        /// </summary>
        /// <returns>True when the sections of one elf is fully contained by the other elf, false otherwise.</returns>
        public bool HasFullyContainedPair()
        {
            return (ElfOneFirstSection >= ElfTwoFirstSection && ElfOneLastSection <= ElfTwoLastSection) 
                || (ElfTwoFirstSection >= ElfOneFirstSection && ElfTwoLastSection <= ElfOneLastSection);
        }
    }
}
