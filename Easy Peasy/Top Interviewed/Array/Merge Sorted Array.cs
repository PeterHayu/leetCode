using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Array
{
    public static class Merge_Sorted_Array
    {
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int endOfNum1 = m - 1;
            int endOfNum2 = n - 1;
            int endOfResult = m + n - 1;
            while (endOfNum1 >= 0 && endOfNum2>=0)
            {
                if (nums2[endOfNum2] >= nums1[endOfNum1])
                {
                    nums1[endOfResult] = nums2[endOfNum2];
                    endOfNum2--;
                }
                else
                {
                    nums1[endOfResult] = nums1[endOfNum1];
                    endOfNum1--;
                }
                endOfResult--;
            }
            //edge case: all num2 element smaller than num1
            // all the first loop does is push element back, num2 never updates the first part 
            // thus need a new loop here
            while (endOfNum2 >= 0) {
                nums1[endOfResult--] = nums2[endOfNum2]--;
            }
        }
    }
}
