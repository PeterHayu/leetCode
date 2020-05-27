using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public static class Combination_Sum
    {
        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            Array.Sort(candidates);
            Backtrack(candidates, result, new List<int>(), target, 0);
            return result;
        }

        private static void Backtrack(int[] candidates, List<IList<int>> result, List<int> path, int target, int start)
        {
            if (target == 0)
            {
                result.Add(path);
                return;
            }
            if (target < 0) return;

            //i=start when you want to check the next element in recursion
            for (int i = start; i < candidates.Length; i++)
            {
                path.Add(candidates[i]);
                Backtrack(candidates, result, path, target - candidates[i], i);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
