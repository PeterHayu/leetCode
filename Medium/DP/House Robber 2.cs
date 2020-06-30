using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.DP
{
    class House_Robber_2
    {
        public int Rob(int[] nums)
        {
            //the decision becomes whether you rob house 1 or not
            //if house one is rob, you can choose from House[1] to House[n-1]
            // if house one is not rob, you can choose from House[2]-House[n]
            int len = nums.Length;
            if (len <= 0)
                return 0;
            if (len == 1) return nums[0];
            return Math.Max(RobHouse(nums[0..(len - 1)]), RobHouse(nums[1..(len)]));
        }

        private int RobHouse(int[] nums)
        {
            //exactly same solution as House Robber I
            int len = nums.Length;
            //dp is the max sum at house i
            var dp = new int[len + 1];
            dp[0] = 0;
            dp[1] = nums[0];
            for (int i = 1; i < len; i++)
            {
                //either not rob = previous max sum
                //or rob = pre pre max sum + current house value
                dp[i + 1] = Math.Max(dp[i], dp[i - 1] + nums[i]);
            }

            return dp[len];
        }
    }
}
