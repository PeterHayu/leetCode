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
            int a = 0;
            int b = 0;
            for (int i = 0; i < length; i++)
            {
                if (i % 2 == 0)
                    a = Math.Max(a + nums[i], b);
                else
                    b = Math.Max(b + nums[i], a);
            }
            return Math.Max(a, b);
        }
    }
}
