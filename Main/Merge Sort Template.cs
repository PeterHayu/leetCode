using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    class Merge_Sort_Template
    {
        public int[] MergeSortedArrays(int[]nums1, int[] nums2) {
            int l1 = nums1.Length;
            int l2 = nums2.Length;
            int i1 = 0;
            int i2 = 0;
            var result = new int[l1 + l2];
            int i = 0;
            while (i1 < l1 && i2 < l2) {
                result[i++] = nums1[i1] <= nums2[i2] ? nums1[i1++] : nums2[i2++];
            }

            while (i1 < l1) {
                result[i++] = nums1[i1++];
            }

            while (i2 < l2)
            {
                result[i++] = nums2[i2++];
            }

            return result;
        }
    }
}
