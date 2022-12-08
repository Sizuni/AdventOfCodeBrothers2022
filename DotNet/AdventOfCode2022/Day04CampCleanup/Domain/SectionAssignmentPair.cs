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

        /// <summary>
        /// Checks whether at least one section of one elf overlaps with the other elf.
        /// </summary>
        /// <returns>True when at least one section of one elf is overlapped by the other elf, false otherwise.</returns>
        public bool HasOverlap()
        {
            return (ElfOneFirstSection >= ElfTwoFirstSection && ElfOneFirstSection <= ElfTwoLastSection)
                || (ElfOneLastSection >= ElfTwoFirstSection && ElfOneLastSection <= ElfTwoLastSection)
                || (ElfTwoFirstSection >= ElfOneFirstSection && ElfTwoFirstSection <= ElfOneLastSection)
                || (ElfTwoLastSection >= ElfOneFirstSection && ElfTwoLastSection <= ElfOneLastSection);
        }
    }
}
