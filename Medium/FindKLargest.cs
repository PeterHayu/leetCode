using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public static class FindKLargest
    {
        public static int FindKthLargest(int[] nums, int k)
        {
            QuickSort(nums, 0, nums.Length - 1, k);
            return nums[nums.Length - k];
        }

        private static void QuickSort(int[] nums, int low, int high, int k)
        {
            if (low < high)
            {
                int pi = Partition(nums, low, high);
                // Recursively sort elements before 
                // partition and after partition 
                if (pi > nums.Length - k)
                    QuickSort(nums, low, pi - 1, k);
               else if (pi < nums.Length - k)
                    QuickSort(nums, pi + 1, high, k);
               else
                   return;
            }
        }

        private static int Partition(int[] nums, int low, int high)
        {
            int pivot = nums[high];
            int i = low;
            for (int j = low; j < high; j++)
            {
                if (nums[j] <= pivot)
                {
                    //swap i and j
                    var temp2 = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp2;

                    i++;
                }
            }
            //swap pivot with i
            var temp = nums[i];
            nums[i] = nums[high];
            nums[high] = temp;

            return i;
        }
    }
}
