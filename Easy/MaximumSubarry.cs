using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    public static class MaximumSubarry
    {
        public static int MaxSubArray(int[] nums)
        {
            if (nums.Length < 1)
                return Int32.MinValue;
            //sum of the sub array, and maximum of one element is theirselves
            int sum = nums[0], max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                //if the previous element is positive or zero, we should add the element to increase sub array sum
                if (sum >= 0)
                    sum += nums[i];
                else
                    sum = nums[i];  //if previous sum is negative, we should start from the current element to increase sub array sum
                //here max will save the current max, sum will try reach next element. Need comparison to see if we should go on (add till the end), or stop at current max
                max = Math.Max(sum, max);
            }
            return max;
        }
    }
}
