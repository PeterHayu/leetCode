using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_100.Array
{
    public static class FindUnsortedSubarray
    {
        public static int findUnsortedSubarray(int[] nums)
        {
            int l = nums.Length;
            int begin = -1, end = -2;
            int maxStartingFromLeft = nums[0], minStartingFromRight = nums[l - 1];
            for (int i = 0; i < l; i++)
            {
                maxStartingFromLeft = Math.Max(maxStartingFromLeft, nums[i]);
                minStartingFromRight = Math.Min(minStartingFromRight, nums[l - i - 1]);
                if (nums[i] < maxStartingFromLeft)
                    end = i;
                if (nums[l - i - 1] > minStartingFromRight)
                    begin = l - i - 1;
            }
            return end - begin + 1;
        }

        public static int findUnsortedSubarray2(int[] nums)
        {
            if (nums.Length <= 1)
                return 0;
            var num2 = (int[])nums.Clone();
            System.Array.Sort(num2);
            int begin = -1;
            int end = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != num2[i])
                {
                    if (begin == -1)
                        begin = i;
                    else
                        end = i;
                }
            }
            return begin == -1? 0:end - begin + 1;
        }
    }
}
