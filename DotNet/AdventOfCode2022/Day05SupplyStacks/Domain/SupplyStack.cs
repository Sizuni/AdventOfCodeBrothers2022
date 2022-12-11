using System.Collections.Generic;

namespace Day05SupplyStacks.Domain
{
    public class SupplyStack
    {
        public List<Crate> Crates { get; set; }

        public SupplyStack()
        {
            Crates = new List<Crate>();
        }

        public void AddCrate(Crate crate)
        {
            Crates.Add(crate);
        }

        public void AddCrates(IList<Crate> crates)
        {
            Crates.AddRange(crates);
        }

        public IList<Crate> TakeCrates(int amount = 1)
        {
            List<Crate> crates = Crates.GetRange(Crates.Count - amount, amount);
            Crates.RemoveRange(Crates.Count - amount, amount);
            return crates;
        }

        public Crate PeekTopCrate()
        {
            return Crates[Crates.Count - 1];
        }
    }
}
