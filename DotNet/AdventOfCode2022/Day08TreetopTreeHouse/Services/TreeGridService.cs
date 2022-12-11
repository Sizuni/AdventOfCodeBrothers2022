using Day08TreetopTreeHouse.Domain;
using System.Collections.Generic;

namespace Day08TreetopTreeHouse.Services
{
    public class TreeGridService
    {
        public TreeGrid TreeGrid { get; }

        private TreeGridService(TreeGrid treeGrid)
        {
            TreeGrid = treeGrid;
        }

        public static TreeGridService CreateTreeGridFromInput(List<string> input)
        {
            int size = input.Count;
            TreeGrid treeGrid = new TreeGrid(size);

            int row = 0;
            foreach (string line in input)
            {
                int column = 0;
                foreach (char number in line)
                {
                    treeGrid.SetTreeHeight(row, column, (int)char.GetNumericValue(number));
                    column++;
                }
                row++;
            }
            return new TreeGridService(treeGrid);
        }

        public int CountVisibleTrees()
        {
            bool[,] isVisibleTreeGrid = new bool[TreeGrid.Size, TreeGrid.Size];

            // Check left to right
            for (int row = 0; row < TreeGrid.Size; row++)
            {
                int maxHeightSeen = -1;
                for (int column = 0; column < TreeGrid.Size; column++)
                {
                    int height = TreeGrid.GetTreeHeight(row, column);
                    if (height > maxHeightSeen)
                    {
                        isVisibleTreeGrid[row, column] = true;
                        maxHeightSeen = height;
                    }
                    if (height == 9)
                    {
                        break;
                    }
                }
            }

            // Check right to left
            for (int row = 0; row < TreeGrid.Size; row++)
            {
                int maxHeightSeen = -1;
                for (int column = TreeGrid.Size - 1; column >= 0; column--)
                {
                    int height = TreeGrid.GetTreeHeight(row, column);
                    if (height > maxHeightSeen)
                    {
                        isVisibleTreeGrid[row, column] = true;
                        maxHeightSeen = height;
                    }
                    if (height == 9)
                    {
                        break;
                    }
                }
            }

            // Check top to bottom
            for (int column = 0; column < TreeGrid.Size; column++)
            {
                int maxHeightSeen = -1;
                for (int row = 0; row < TreeGrid.Size; row++)
                {
                    int height = TreeGrid.GetTreeHeight(row, column);
                    if (height > maxHeightSeen)
                    {
                        isVisibleTreeGrid[row, column] = true;
                        maxHeightSeen = height;
                    }
                    if (height == 9)
                    {
                        break;
                    }
                }
            }

            // Check top to bottom
            for (int column = 0; column < TreeGrid.Size; column++)
            {
                int maxHeightSeen = -1;
                for (int row = TreeGrid.Size - 1; row >= 0; row--)
                {
                    int height = TreeGrid.GetTreeHeight(row, column);
                    if (height > maxHeightSeen)
                    {
                        isVisibleTreeGrid[row, column] = true;
                        maxHeightSeen = height;
                    }
                    if (height == 9)
                    {
                        break;
                    }
                }
            }

            int sum = 0;
            foreach (bool isVisible in isVisibleTreeGrid)
            {
                if (isVisible) sum++;
            }
            return sum;
        }

        public int GetScenicScore(int row, int column)
        {
            if (row == 0 || row == TreeGrid.Size - 1
                || column == 0 || column == TreeGrid.Size - 1)
            {
                // The tree is on an edge
                return 0;
            }

            int currentTreeHeight = TreeGrid.GetTreeHeight(row, column);

            int countRight = 0;
            for (int i = column + 1; i < TreeGrid.Size; i++)
            {
                countRight++;
                if (TreeGrid.GetTreeHeight(row, i) >= currentTreeHeight)
                {
                    break;
                }
            }

            int countLeft = 0;
            for (int i = column - 1; i >= 0; i--)
            {
                countLeft++;
                if (TreeGrid.GetTreeHeight(row, i) >= currentTreeHeight)
                {
                    break;
                }
            }

            int countDown = 0;
            for (int i = row + 1; i < TreeGrid.Size; i++)
            {
                countDown++;
                if (TreeGrid.GetTreeHeight(i, column) >= currentTreeHeight)
                {
                    break;
                }
            }

            int countUp = 0;
            for (int i = row - 1; i >= 0; i--)
            {
                countUp++;
                if (TreeGrid.GetTreeHeight(i, column) >= currentTreeHeight)
                {
                    break;
                }
            }

            return countRight * countLeft * countDown * countUp;
        }
    }
}
