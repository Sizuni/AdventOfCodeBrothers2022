namespace Day05SupplyStacks.Domain
{
    public class Crate
    {
        public string Mark { get; set; }

        public Crate(string mark)
        {
            Mark = mark;
        }

        public override string ToString()
        {
            return Mark;
        }
    }
}
