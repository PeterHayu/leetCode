using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_100
{
    public static class BuySellStock
    {
        public static int MaxProfit(int[] prices)
        {
            if (prices.Length < 1)
                return 0;
            int curr = 0, max = 0, diff = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (diff >= 0)
                {
                    diff = prices[i] - prices[curr];
                    if (diff >= max)
                    {
                        max = diff;
                    }
                }
                if (diff < 0)
                {
                    diff = prices[i];
                    curr = i;
                }
            }
            return max;
        }

        //basically the combined solution of the previous one
        public static int maxProfitAnswer(int[] prices)
        {
            int minprice = Int32.MaxValue;
            int maxprofit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minprice)
                    minprice = prices[i];
                else if (prices[i] - minprice > maxprofit)
                    maxprofit = prices[i] - minprice;
            }
            return maxprofit;
        }
    }
}
