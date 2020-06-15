﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    class Quick_Sort_Template
    {
        public int FindKthLargest(int[] nums, int k)
        {
            QuickSort(nums, 0, nums.Length - 1, k);
            return nums[nums.Length - k];
        }

        private void QuickSort(int[] nums, int low, int high, int k)
        {
            if (low < high)
            {
                int pi = Partition(nums, low, high);
                // Recursively sort elements before 
                // partition and after partition 
                //usually would not change
                if (pi > nums.Length - k)
                    QuickSort(nums, low, pi - 1, k);
                else if (pi < nums.Length - k)
                    QuickSort(nums, pi + 1, high, k);
                else
                    return;
            }
        }

        private int Partition(int[] nums, int low, int high)
        {
            //pivot decides the sorting logic
            //might change due to requirement
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
