using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Binary_Search
{
    public static class Find_Peak_Element
    {
        public static int FindPeakElement(int[] nums)
        {
            //if on ascending part, its the right most point
            //if on descending part, its the left most point
            //if its not monitone increase/decrease, use binary search
            if (nums.Length == 0)
                return -1;
            int left = 0, right = nums.Length - 1;
            if (left < right)
            {
                //first check boundary valid
                if (nums[left] > nums[left + 1])
                    return left;
                else if (nums[right] > nums[right - 1])
                    return right;
            }
            else
            {
                return 0;
            }



            while (left <= right)
            {
                //if neither, binary search
                int mid = left + (right - left) / 2;
                //always compare to right point, to be convinient
                //on acscending part
                if (nums[mid] < nums[mid + 1])
                {
                    left = mid + 1;
                }
                //on descending part
                else if (nums[mid] > nums[mid + 1])
                {
                    right = mid - 1;
                }
                else
                    return mid;

            }
            return left;
        }
    }
}
