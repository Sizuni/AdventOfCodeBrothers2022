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
            for (int i = 0; i < amount; i++)
            {
                Crate crate = SupplyStacks[from - 1].TakeCrate();
                SupplyStacks[to - 1].AddCrate(crate);
            }
        }

        public string ReadTopOfEachStack()
        {
            return string.Join("", SupplyStacks.Select(stack => stack.PeekCrate().ToString()));
        }
    }
}
