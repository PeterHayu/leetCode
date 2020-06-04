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

        public static int MaxProduct2(int[] nums)
        {
            if (nums.Length < 1)
                return Int32.MinValue;
            int result = Int32.MinValue;
            int prod = 1;

            //going forward to compare 
            for (int i = 0; i < nums.Length; i++)
            {
                prod *= nums[i];
                result = Math.Max(prod, result);
                if (nums[i] == 0)
                {
                    //start from after 0
                    prod = 1;
                }
            }
            //reset product
            prod = 1;
            //going backward 
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                prod *= nums[i];
                result = Math.Max(prod, result);
                if (nums[i] == 0)
                {
                    //start from after 0
                    prod = 1;
                }
            }

            return result;
        }
    }
}
