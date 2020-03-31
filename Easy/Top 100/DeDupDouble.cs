using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_100
{
    public static class DeDupDouble
    {
        public static int SingleNumber(int[] nums)
        {
            var s = new HashSet<int>();

            foreach (var num in nums)
            {
                if (s.Contains(num))
                {
                    s.Remove(num);
                }
                else
                {
                    s.Add(num);
                }
            }
            foreach (var el in s)
            {
                return el;
            }
            return 0;
        }

        //n ^ n = 0, every same element will cancel themselves out and return 0
        //n ^ 0 = n, the sigular element will take the result to ^0, which returns itself
        public static int SingleNumberXOR(int[] nums)
        {
            int x = 0;
            for (int i = 0; i < nums.Length; i++) x ^= nums[i];
            return x;
        }
    }
}
