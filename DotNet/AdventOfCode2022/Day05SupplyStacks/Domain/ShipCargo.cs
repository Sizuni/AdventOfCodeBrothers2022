using System.Collections.Generic;
using System.Linq;

namespace Day05SupplyStacks.Domain
{
    public class ShipCargo
    {
        public List<SupplyStack> SupplyStacks { get; set; }

        public ShipCargo()
        {
            SupplyStacks = new List<SupplyStack>();
        }

        public void AddSupplyStack(SupplyStack supplyStack)
        {
            SupplyStacks.Add(supplyStack);
        }

        public void MoveCrate(int from, int to, int amount = 1)
        {
            IList<Crate> crates = SupplyStacks[from - 1].TakeCrates(amount);
            SupplyStacks[to - 1].AddCrates(crates);
        }

        public string ReadTopOfEachStack()
        {
            return string.Join("", SupplyStacks.Select(stack => stack.PeekTopCrate().ToString()));
        }
    }
}
