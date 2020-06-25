using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Iterate_Grid.BFS
{
    class Zombie
    {
        public int MinHours(int rows, int columns, int[][] grid)
        {
            if(grid.Length < 1 || grid[0].Length <1)
                return -1;
            int totalNumberOfExpectedZombie = rows * columns;
            var zombies = new Queue<int[]>();
            var zombieCount = 0;
            var minHour = 0;

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    if (grid[i][j] == 1)
                    {
                        zombies.Enqueue(new int[] { i, j });
                        zombieCount++;
                    }
                }
            }

            int[][] dirs = { new int[]{ 0, 1 },
                new int[]{ 0, -1 },
                new int[]{ 1, 0 },
                new int[]{ -1, 0 } };


            while (zombies.Count != 0) {
                /*
                if (zombieCount == totalNumberOfExpectedZombie)
                    return minHour;
                */
                var size = zombies.Count;

                for (int k = 0; k < size; k++)
                {
                    var z = zombies.Dequeue();
                    foreach (var dir in dirs)
                    {
                        //visiting each direction
                        var x = z[0] + dir[0];
                        var y = z[1] + dir[1];
                        if (x < 0 || x > grid.Length || y < 0 || y > grid.Length || grid[x][y] == 1)
                            continue;
                        grid[x][y] = 1;
                        zombies.Enqueue(new int[] { x, y });
                    }
                }
                minHour++;
            }


            return zombieCount == totalNumberOfExpectedZombie ? minHour : -1;
        }
    }
}
