using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Back_Tracking
{
    class Permutation
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();
            BackTrack(result, new List<int>(), nums);
            return result;
        }

        private void BackTrack(List<IList<int>> result, List<int> path, int[] nums)
        {
            if (path.Count == nums.Length)
            {
                result.Add(new List<int>(path));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (path.Contains(nums[i])) continue;
                path.Add(nums[i]);
                BackTrack(result, path, nums);
                path.RemoveAt(path.Count - 1);
            }

        }
    }
}
