using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.DP
{
    public static class Maximum_Product_Subarray
    {
        public static int MaxProduct(int[] nums)
        {
            if (nums.Length < 1)
                return Int32.MinValue;
            //dp is the product so far.
            int max = nums[0];
            int min = nums[0];
            int result = nums[0];

            //if we encounter a negative, we know min and max will need to switch
            for (int i = 1; i < nums.Length; i++)
            {

                if (nums[i] < 0)
                {
                    var temp = min;
                    min = max;
                    max = temp;
                }

                min = Math.Min(nums[i] * min, nums[i]);
                max = Math.Max(nums[i] * max, nums[i]);
                result = Math.Max(result, max);
            }
            return result;
        }
    }
}
