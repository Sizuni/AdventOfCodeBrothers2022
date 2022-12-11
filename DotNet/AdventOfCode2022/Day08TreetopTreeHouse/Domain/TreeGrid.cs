using System.Text;

namespace Day08TreetopTreeHouse.Domain
{
    public class TreeGrid
    {
        public int Size { get; private set; }
        private int[,] trees;

        public TreeGrid(int size)
        {
            Size = size;
            trees = new int[Size, Size];
        }

        public void SetTreeHeight(int row, int column, int height)
        {
            trees[column, row] = height;
        }

        public int GetTreeHeight(int row, int column)
        {
            return trees[column, row];
        }

        public override string ToString()
        {
            int count = 0;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (int height in trees)
            {
                if (count % Size == 0 && count != 0)
                {
                    stringBuilder.AppendLine("");
                }
                stringBuilder.Append(height);
                count++;
            }
            return stringBuilder.ToString();
        }
    }
}
