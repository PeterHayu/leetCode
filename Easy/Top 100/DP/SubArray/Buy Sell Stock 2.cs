using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_100.DP.SubArray
{
    class Buy_Sell_Stock_2
    {
        public int MaxProfit(int[] prices)
        {
            //dp: on day i, whether have stock on hand or not
            var dp = new int[prices.Length, 2];
            //at day 0, if not having stock on hand, max profit is 0
            dp[0, 0] = 0;
            //at day 0, if have stock on hand, max profit is the buy price
            dp[0, 1] = -prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                //if we do not have stock on hand today, it can possibily be
                //1, we do not have stock on hand yesterday and not selling it 
                //2, we have stock on hand yesterday and sold it
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                //if we have stock on hand today, it can possibily be
                //1,we have stock on hand yesterday and not selling it 
                //2, we do not have stock on hand yesterday and buying it today
                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] - prices[i]);
            }
            //always return the max profit of selling on last day because it > holding stock on last day
            return dp[prices.Length - 1, 0];
        }
    }
}
