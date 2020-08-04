using System;
using System.Collections.Generic;
using System.Text;

namespace Hard
{
    public static class First_Missing_Positive
    {
        public static int FirstMissingPositive(int[] nums)
        {
            //this is a techinique to make an array mapped to a set by using index
            int n = nums.Length;
            //logic: the first missing positive is within 1 to n
            //if nums = [1..n], then return n+1
            for (int i = 0; i < n; i++)
            {
                //mark the unwanted element to 1
                if (nums[i] <= 0 || nums[i] > n)
                    nums[i] = 1;
            }

            //array index: 0 to n-1
            //range of result: 1 to n
            //we can mark a result n as visited, by changing the index at n-1 as negative (the array is already all positive and within 1 to n with the previous move)
            for (int i = 0; i < n; i++)
            {
                //mark the index at n-1 as visited(negative)
                if (nums[Math.Abs(nums[i]) - 1] >= 0)
                    nums[Math.Abs(nums[i])-1] *= -1;
            }
            //now the value of array is an indication of whether the result from 1 to n has visisted
            //nums[0] < 0 means 0+1 is visisted..
            //nums[1] > 0 means 1+1 is not visisted..therefore 1+1 is the missing positive integer
            for (int i = 0; i < n; i++)
            {
                //if the new indicator value is non negative, meaning the result = index+1 has never been visited before
                if (nums[i] > 0)
                    return i + 1;
            }
            //if none of them is negative, meaning the smallest is maxIndex+1 = n+1
            return n + 1;
        }
    }
}
