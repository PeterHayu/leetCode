using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.DP
{
    public static class Min_Path_Sum
    {
        public static int MinPathSum(int[][] grid)
        {
            var dp = new int[grid.Length, grid[0].Length];
            dp[0, 0] = grid[0][0];
            for (int a = 1; a < grid.Length; a++)
            {
                dp[a, 0] = grid[a][0] + dp[a - 1, 0];
            }

            for (int b = 1; b < grid[0].Length; b++)
            {
                dp[0, b] = grid[0][b] + dp[0, b - 1];
            }


            for (int i = 1; i < grid.Length; i++)
            {
                for (int j = 1; j < grid[0].Length; j++)
                {
                    dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
                }
            }
            return dp[grid.Length - 1, grid[0].Length - 1];
        }

        public static int MinPathSumImproved(int[][] grid)
        {
            var dp = new int[grid.Length];
            dp[0] = grid[0][0];
            for (int a = 1; a < grid.Length; a++)
            {
                dp[a] = grid[a][0] + dp[a - 1];
            }


            for (int j = 1; j < grid[0].Length; j++)
            {
                dp[0] += grid[0][j];
                for (int i = 1; i < grid.Length; i++)
                {
                    dp[i] = Math.Min(dp[i - 1], dp[i]) + grid[i][j];
                }
            }
            return dp[grid.Length - 1];
        }
    }
}
