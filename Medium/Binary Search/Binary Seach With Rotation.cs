using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public static class Binary_Seach_With_Rotation
    {
        public static int Search(int[] nums, int target)
        {
            //by rotating
            //the sorted array has been splitted into two sorted sub-arrays, A and B
            //first we need to determined: nums[mid] in A or B
            //then we need to determined: target in A or B
            //we try to update mid so that nums[mid] and target in same sub arrays
            //then we perform binary search
            if (nums.Length <= 0)
                return -1;
            int left = 0, right = nums.Length - 1, startOfA = nums[0];

            while (left <= right)
            {
                int mid = (left + right) / 2;
                //determined if both nums[mid] and target are same array
                int middle = ((nums[mid] < startOfA) == (target < startOfA)) ?
                                nums[mid] //if same set middle as nums[mid] => regular binary search
                                :
                                (target < startOfA) ? Int32.MinValue : Int32.MaxValue; //if not, determined which way to increase mid so that mid and target on same array
                
                //binary search template
                if (middle < target)
                    left = mid + 1;
                else if (middle > target)
                    right = mid - 1;
                else if (middle == target)
                    return mid;
            }
            return -1;
        }
    }
}
