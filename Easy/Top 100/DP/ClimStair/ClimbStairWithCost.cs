using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_100.DP.ClimStair
{
    public class ClimbStairWithCost
    {
        public int MinCostClimbingStairs(int[] cost)
        {
            int first = cost[0];
            int second = cost[1];
            for (int i = 2; i < cost.Length; i++)
            {
                int current = cost[i] + Math.Min(first, second);
                first = second;
                second = current;
            }
            //not return the current because dont need to pay the cost of last step, if not to continue
            return Math.Min(first, second);
        }

        public int MinCostClimbingStairsArray(int[] cost)
        {
            //dp is the cost to climb to step i
            int[] dp = new int[cost.Length + 1];
            dp[0] = 0;
            dp[1] = Math.Min(dp[0], cost[1]); //we can also assign 0, because the min is always d[0]=0
            for (int i = 2; i <= cost.Length; i++)
            {
                dp[i] = Math.Min(cost[i - 1] + dp[i - 1], cost[i - 2] + dp[i - 2]);
            }
            return dp[cost.Length];
        }
    }
}
