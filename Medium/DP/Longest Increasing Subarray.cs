using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.DP
{
    class Max_Length_of_Increasing_Subarray
    {
        public int LengthOfLIS(int[] nums)
        {
            if (nums.Length < 1)
                return 0;
            //dp stores the max length of increasing subarray till index i, which is also the results
            var dp = new int[nums.Length];
            dp[0] = 1;
            //result is the maximum of all result in dp
            int result = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                //how many numbers are smaller than nums[i], minimum of a count is 0
                int currentMaxCount = 0;
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        //use max to ensure increasing order
                        currentMaxCount = Math.Max(currentMaxCount, dp[j]);
                    }
                }
                //adding the current element to form the new length
                dp[i] = currentMaxCount + 1;
                //keep track of global max
                result = Math.Max(result, dp[i]);
            }
            return result;
        }
    }
}
