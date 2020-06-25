using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Iterate_Grid.DFS
{
    class Number_of_Islands
    {
        public int NumIslands(char[][] grid)
        {
            if (grid.Length < 1)
                return 0;
            int result = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        Traverse(grid, i, j);
                        result++;
                    }
                }
            }
            return result;
        }

        private void Traverse(char[][] grid, int i, int j)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] != '1')
                return;

            //visited
            grid[i][j] = '0';

            Traverse(grid, i, j + 1);
            Traverse(grid, i + 1, j);
            Traverse(grid, i - 1, j);
            Traverse(grid, i, j - 1);
        }



    }
}
