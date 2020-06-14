using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.DP
{
    public static class CoinChange
    {
        public static int CoinChanges(int[] coins, int amount)
        {
            //dp: least number of coins used for i amount
            var dp = new int[amount + 1];
            //the max number of coins to fill i amount is all using 1 dollar coins, so we never reach amount+1
            System.Array.Fill(dp, amount + 1);
            dp[0] = 0;

            //fill in each and every amount
            for (int i = 1; i <= amount; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= i)
                    {
                        //given that we have 1 coin j, total amount of coin = combination to reach amount - coin[j] + 1 (coin j)
                        //least total amount is the min for all j possibilities
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                    }
                }
            }

            //if dp[amount] > amount which is the initial impossible value assign, meaning no solution
            return dp[amount] > amount ? -1 : dp[amount];

        }
    }
}
