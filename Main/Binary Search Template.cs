using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    class Binary_Search_Template
    {
        int binary_search(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else if (nums[mid] == target)
                {
                    // 直接返回
                    return mid;
                }
            }
            // 直接返回
            return -1;
        }

        //how many elements are stritcly smaller than target?
        int left_bound(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else if (nums[mid] == target)
                {
                    // 别返回，锁定左侧边界
                    right = mid - 1;
                }
            }
            // 最后要检查 left 越界的情况 (left + 1 might > length if left greater than all)
            if (left >= nums.Length || nums[left] != target)
                return -1;
            return left;
        }

        //how many elements are stritcly larger than target?
        int right_bound(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else if (nums[mid] == target)
                {
                    // 别返回，锁定右侧边界
                    left = mid + 1;
                }
            }
            // 最后要检查 right 越界的情况 (right -1 < 0 if right smaller than all)
            if (right < 0 || nums[right] != target)
                return -1;
            return right;
        }

        int BinarySearchRecursive(int[] arr, int l, int r, int x)
        {
            if (r >= l)
            {
                int mid = l + (r - l) / 2;

                // If the element is present at the middle 
                // itself 
                if (arr[mid] == x)
                    return mid;

                // If element is smaller than mid, then 
                // it can only be present in left subarray 
                if (arr[mid] > x)
                    return BinarySearchRecursive(arr, l, mid - 1, x);

                // Else the element can only be present 
                // in right subarray 
                return BinarySearchRecursive(arr, mid + 1, r, x);
            }

            // We reach here when element is not 
            // present in array 
            return -1;
        }

    }
}
