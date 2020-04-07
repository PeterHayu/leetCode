using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    public static class TwoSum
    {
        public static int[] twoSum(int[] nums, int target)
        {
            if (nums.Length < 1)
                return new int[] { };
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                dic[nums[i]] = i;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                var diff = target - nums[i];
                /* 
                if(Array.Exists(nums,el=>el==diff) && Array.IndexOf(nums,diff)!=i)
                     return new int[]{i,Array.IndexOf(nums,diff)};  
                 }
                 */
                if (dic.ContainsKey(diff) && dic[diff] != i)
                {
                    return new int[] { i, dic[diff] };
                }

            }
            return new int[] { };
        }
    }
}
