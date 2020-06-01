using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_100.Array
{
    public static class MoveNonZero
    {
        public static void MoveZeroes(int[] nums) { 
        
            if(nums == null || nums.Length ==0)
                return;
            var size = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[size] = nums[i];
                    size++;
                }
            }
            for (int j = size; j < nums.Length; j++)
            {
                nums[j] = 0;
            }
        }
    }
}
