using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    public static class RemoveDuplicateWithinArray
    {
        public static int RemoveDuplicatesfromSortedArray(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    nums[i + 1] = nums[j];
                    i++;
                }
            }
            return i + 1;
        }
    }
}
