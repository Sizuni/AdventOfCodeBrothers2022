namespace Day05SupplyStacks.Domain
{
    public class ProcedureInstruction
    {
        public int Amount { get; set; }
        public int From { get; set; }
        public int To { get; set; }

        public ProcedureInstruction(int amount, int from, int to)
        {
            Amount = amount;
            From = from;
            To = to;
        }
    }
}
