using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Iterate_Grid.BFS
{
    class Rotten_Oranges
    {
        public int OrangesRotting(int[][] grid)
        {
            if (grid == null || grid.Length == 0) return 0;
            int rows = grid.Length;
            int cols = grid[0].Length;
            Queue<int[]> queue = new Queue<int[]>();
            int count_fresh = 0;
            //1, iterate through the grid and enqueue all rotten oranges
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        //Put the position of all rotten oranges in queue
                        queue.Enqueue(new int[] { i, j });
                    }
                    else if (grid[i][j] == 1)
                    {
                        //count the number of fresh oranges
                        count_fresh++;
                    }
                }
            }


            //if count of fresh oranges is zero --> return 0 
            if (count_fresh == 0) return 0;

            //same as counting tree level
            int count = 0;
            //four directions
            var dirs = new int[][]{new int[]{1,0},
                               new int[]{-1,0},
                               new int[]{0,1},
                               new int[]{0,-1}};
            //bfs starting from initially rotten oranges
            while (queue.Count != 0)
            {
                count++;
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    int[] point = queue.Dequeue();
                    //iterate through 4 directions of a rotten orange
                    foreach (var dir in dirs)
                    {
                        int x = point[0] + dir[0];
                        int y = point[1] + dir[1];
                        //if x or y is out of bound
                        //or the orange at (x , y) is already rotten
                        //or the cell at (x , y) is empty
                        //we do nothing
                        if (x < 0 || y < 0 || x >= rows || y >= cols || grid[x][y] == 0 || grid[x][y] == 2) continue;
                        //mark the orange at (x , y) as rotten
                        grid[x][y] = 2;
                        //put the new rotten orange at (x , y) in queue
                        queue.Enqueue(new int[] { x, y });
                        //decrease the count of fresh oranges by 1
                        count_fresh--;
                    }
                }
            }
            return count_fresh == 0 ? count - 1 : -1;
        }
    }
}
