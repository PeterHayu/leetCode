using System;

namespace Hard
{
    public class Median_of_Two_Sorted_Arrays
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            //first, always made the nums1 the shorter array
            //if nums1 long then swap
            //because the longer array partition can be derive from shorter one
            if (nums1.Length > nums2.Length)
            {
                return FindMedianSortedArrays(nums2, nums1);
            }



            //we want to find a partition for both nums1 and nums2 in the middle
            //and the medium is either the 
            //Max of the two from left of partition(odd length, returning the middle number)
            //or the 
            //Average of (Max twoof the two from the left of partition)
            //and the (Min of the two from the right of partition)
            //(even length, returning the average of two numbers in the middle)
            //only need to do binary search on the shorter array 
            int l = 0;
            int r = nums1.Length;
            int combinedL = r + nums2.Length;


            while (l <= r)
            {
                //to ensure len(left_part)==len(right_part), we have the partion as the below
                int partX = (l + r) / 2;
                int partY = (combinedL + 1) / 2 - partX;

                //helper method to get the left/right number from the partition boundary
                int leftX = GetLeft(partX, nums1);
                int rightX = GetRight(partX, nums1);

                int leftY = GetLeft(partY, nums2);
                int rightY = GetRight(partY, nums2);

                //implement the logic from above
                //and the exit condition of this binary search
                if (leftX <= rightY && leftY <= rightX)
                {
                    //odd
                    if (combinedL % 2 != 0)
                        return (double)Math.Max(leftX, leftY);
                    else
                        return (Math.Max(leftX, leftY) + Math.Min(rightX, rightY)) / 2.0;
                }
                else
                {
                    //binary search
                    if (leftX > rightY)
                    {
                        r = partX - 1;
                    }
                    else
                    {
                        l = partX + 1;
                    }
                }
            }
            //not able to find mid point
            return -1;

        }

        //the reason need helper method is because we need to consider the boundary doesnt have anything on left/right side, we return infinity
        private int GetLeft(int partition, int[] nums)
        {
            if (partition == 0)
                return Int32.MinValue;
            return nums[partition - 1];
        }

        private int GetRight(int partition, int[] nums)
        {
            if (partition == nums.Length)
                return Int32.MaxValue;
            return nums[partition];
        }
    }
}
