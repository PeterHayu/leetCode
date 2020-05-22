using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public static class Jump_Game
    {
        public static bool CanJump(int[] nums)
        {
            //result is bool
            //dp array should be bool array
            var dp = new bool[nums.Length];
            for (int i =0;i<dp.Length;i++)
            {
                dp[i] =false;
            }
            //last element is a true 
            dp[nums.Length - 1] = true;
            int trueIndex = nums.Length - 1;
            //start from second to last element
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] + i >= trueIndex)
                {
                    dp[i] = true;
                    trueIndex = i;
                }
            }

            return dp[0];
        }
    }
}
