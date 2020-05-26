using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public class Unique_Paths
    {
        public int UniquePaths(int m, int n)
        {
            var dp = new int[m, n];
            for (int j = 0; j < n; j++)
            {
                dp[0, j] = 1;
            }
            for (int k = 0; k < m; k++)
            {
                dp[k, 0] = 1;
            }
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }
            return dp[m - 1, n - 1];
        }

        public int UniquePathsImproved(int m, int n) {
            var dp = new int[n];
            for (int j = 0; j < n; j++)
            {
                dp[j] = 1;
            }
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[j] += dp[j - 1];
                }
            }
            return dp[n - 1];
        }
    }
}
