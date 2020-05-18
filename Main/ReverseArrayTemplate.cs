using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    public class ReverseArrayTemplate
    {
        void reverse(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left < right)
            {
                // swap(nums[left], nums[right])
                int temp = nums[left];
                nums[left] = nums[right];
                nums[right] = temp;
                left++; right--;
            }
        }
    }
}
