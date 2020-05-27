using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Back_Tracking
{
    public static class Subset
    {
        //back tracking combination template
        public static IList<IList<int>> Subsets(int[] nums)
        {
            var result = new List<IList<int>>();
            Backtrack(result, new List<int>(), nums, 0);
            return result;
        }

        public static void Backtrack(List<IList<int>> result, List<int> path, int[] nums, int start)
        {
            //add current path to result
            result.Add(new List<int>(path));

            //i=start to remove duplicate
            for (int i = start; i < nums.Length; i++)
            {
                //add the ith number
                path.Add(nums[i]);
                //recursively add the next (i+1) numbers
                Backtrack(result, path, nums, i + 1);
                //when no more combination, removed the previous choice
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
