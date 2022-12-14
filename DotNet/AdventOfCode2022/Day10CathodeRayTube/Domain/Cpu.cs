using System.Collections.Generic;
using System.Linq;

namespace Day10CathodeRayTube.Domain
{
    public class Cpu
    {
        private List<int> _registerValuePerCycle;
        public IReadOnlyList<int> RegisterValuePerCycle => _registerValuePerCycle;

        public int CurrentCycle => _registerValuePerCycle.Count;

        public Cpu()
        {
            _registerValuePerCycle = new List<int>();
            _registerValuePerCycle.Add(1);
        }

        public void Noop()
        {
            _registerValuePerCycle.Add(_registerValuePerCycle.Last());
        }

        public void AddX(int value)
        {
            _registerValuePerCycle.Add(_registerValuePerCycle.Last());
            _registerValuePerCycle.Add(_registerValuePerCycle.Last() + value);
        }

        public int GetSignalStrenghtForCycle(int cycle)
        {
            return _registerValuePerCycle[cycle - 1];
        }
    }
}
