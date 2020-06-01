using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_100.Array
{
    public static class FindDisappearNumber
    {
        public static IList<int> FindDisappearedNumbers(int[] nums)
        {
            var s = new HashSet<int>();
            var result = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                s.Add(nums[i]);
            }
            for (int j = 1; j < nums.Length + 1; j++)
            {
                if (!s.Contains(j))
                    result.Add(j);
            }
            return result;
        }

        public static IList<int> FindDisappearedNumbersAns(int[] nums)
        {
            var result = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var index = Math.Abs(nums[i]) - 1;
                nums[index] = -Math.Abs(nums[index]);
            }
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] > 0)
                    result.Add(j + 1);
            }
            return result;
        }
    }
}
