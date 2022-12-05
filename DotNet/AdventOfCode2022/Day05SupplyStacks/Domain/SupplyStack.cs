using System.Collections.Generic;

namespace Day05SupplyStacks.Domain
{
    public class SupplyStack
    {
        public Stack<Crate> Crates { get; set; }

        public SupplyStack()
        {
            Crates = new Stack<Crate>();
        }

        public void AddCrate(Crate crate)
        {
            Crates.Push(crate);
        }

        public Crate TakeCrate()
        {
            return Crates.Pop();
        }

        public Crate PeekCrate()
        {
            return Crates.Peek();
        }
    }
}
