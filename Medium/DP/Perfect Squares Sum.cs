using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.DP
{
    class Perfect_Squares_Sum
    {
        public int NumSquares(int n)
        {
            //dp:  least number of perfect square numbers which sum to n.
            var dp = new int[n + 1];
            System.Array.Fill(dp, Int32.MaxValue);
            dp[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                //while n-j*j > 0
                //solution equals the minimum number of a previous solution + 1
                // to find out which previous solution we have:
                for (int j = 1; j * j <= i; j++)
                {
                    dp[i] = Math.Min(dp[i - j * j] + 1, dp[i]);
                }
            }

            return dp[n];
        }
    }
}
