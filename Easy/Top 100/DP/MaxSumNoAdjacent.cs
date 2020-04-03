using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easy.Top_100
{
    public static class MaxSumNoAdjacent
    {
        //this reuslt in time out when nums too long
        public static int Rob2(int[] nums)
        {
            int length = nums.Length;
            if (length <= 0)
                return 0;
            if (length < 2)
                return nums[0];
            int sumOdd = nums[0];
            int sumEven = nums[1];
            sumOdd += Rob2(nums.Skip(2).Take(length - 2).ToArray());
            sumEven += Rob2(nums.Skip(3).Take(length - 3).ToArray());
            return Math.Max(sumOdd, sumEven);
        }

        public static int Rob(int[] nums)
        {
            int length = nums.Length;
            int even = 0;
            int odd = 0;
            for (int i = 0; i < length; i++)
            {
                if (i % 2 == 0)
                    even = Math.Max(even + nums[i], odd);
                else
                    odd = Math.Max(odd + nums[i], even);
            }
            return Math.Max(even, odd);
        }

        public static int RobDynamicProgrammingTemplate(int[] nums) {
            int length = nums.Length;
            if (length <= 0)
                return 0;
            var maxArray = new int[nums.Length+1];
            //improvement can be made to use only two variables instead of the whole array, which track every record
            maxArray[0] = 0;
            maxArray[1] = nums[0];
            for (int i = 1; i < length; i++) {
                maxArray[i + 1] = Math.Max(maxArray[i], maxArray[i-1]+nums[i]);
            }
            return maxArray[length];
        }

        public static int RobDynamicProgrammingImprove(int[] nums)
        {
            int length = nums.Length;
            if (length <= 0)
                return 0;
            var previousMax = 0;
            var currentMax = nums[0];
            for (int i = 1; i < length; i++)
            {
                int temp = Math.Max(currentMax, previousMax + nums[i]);
                previousMax = currentMax;
                currentMax = temp;
            }
            return currentMax;
        }
    }
}
