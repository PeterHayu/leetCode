using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public static class Sort_Color
    {
        public static void SortColors(int[] nums)
        {
            var dic = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (dic.ContainsKey(num))
                {
                    dic[num] += 1;
                }
                else
                {
                    dic[num] = 1;
                }
            }
            int zero = dic.ContainsKey(0) ? dic[0] : 0;
            var one = dic.ContainsKey(1) ? dic[1] : 0;

            for (int i = 0; i < zero; i++)
            {
                nums[i] = 0;
            }

            for (int i = zero; i < zero + one; i++)
            {
                nums[i] = 1;
            }

            for (int i = zero + one; i < nums.Length; i++)
            {
                nums[i] = 2;
            }
        }

        public static void SortColorsImproved(int[] nums)
        {
            int start = 0, end = nums.Length - 1, i = 0;
            while (i <= end)
            {
                if (nums[i] == 0)
                {
                    var temp = nums[start];
                    nums[start] = 0;
                    nums[i] = temp;
                    start++;
                    i++;
                }
                else if (nums[i] == 2)
                {
                    var temp = nums[end];
                    nums[end] = 2;
                    nums[i] = temp;
                    end--;
                }
                else
                    i++;
            }
        }
    }
}
