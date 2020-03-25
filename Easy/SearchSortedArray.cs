using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    public static class SearchSortedArray
    {
        public static int SearchInsert(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= target)
                {
                    return i;
                }
            }
            return nums.Length;
        }

        public static int BinarySearch(int[] nums, int target) {
            int l = 0;
            int u = nums.Length - 1;

            while (l <= u)
            {
                int mid = (u + l) / 2;
                if (nums[mid] == target) //and nums[mid-1]!=target, for duplicate input
                    return mid;
                else if (nums[mid] > target)
                    u = mid - 1;
                else if (nums[mid] < target)
                    l = mid + 1;
            }
            return l;
        }
    }
}
