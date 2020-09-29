using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    class Merge_Sort_Template
    {
        //Merge Two Sorted Array
        public int[] MergeSortedArrays(int[] nums1, int[] nums2)
        {
            int l1 = nums1.Length;
            int l2 = nums2.Length;
            int i1 = 0;
            int i2 = 0;
            var result = new int[l1 + l2];
            int i = 0;
            while (i1 < l1 && i2 < l2)
            {
                result[i++] = nums1[i1] <= nums2[i2] ? nums1[i1++] : nums2[i2++];
            }

            while (i1 < l1)
            {
                result[i++] = nums1[i1++];
            }

            while (i2 < l2)
            {
                result[i++] = nums2[i2++];
            }

            return result;
        }

        // nums1 has extra spaces with zeroes in the end 
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int endOfNum1 = m - 1;
            int endOfNum2 = n - 1;
            int endOfResult = m + n - 1;
            while (endOfNum1 >= 0 && endOfNum2 >= 0)
            {
                if (nums2[endOfNum2] >= nums1[endOfNum1])
                {
                    //real update
                    nums1[endOfResult] = nums2[endOfNum2];
                    endOfNum2--;
                }
                else
                {
                    //pushing back element only
                    nums1[endOfResult] = nums1[endOfNum1];
                    endOfNum1--;
                }
                endOfResult--;
            }

            //edge case: all num2 element smaller than num1
            // all the first loop does is push element back, num2 never updates the first part 
            // thus need a new loop here
            while (endOfNum2 >= 0)
            {
                nums1[endOfResult--] = nums2[endOfNum2--];
            }

        }
    }
}
