using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medium
{
    public static class MergeInterval
    {
        public static int[][] Merge(int[][] intervals)
        {
            //int max = intervals[0][1];
            if (intervals.Length <= 0)
                return new int[0][];
            var result = new List<int[]>();
            intervals = intervals.OrderBy(entry => entry[0]).ToArray();
            result.Add(intervals[0]);
            for (int i = 1; i < intervals.Length; i++)
            {
                //has overalpped
                if (intervals[i][0] <= result[result.Count - 1][1])
                {
                    result[result.Count - 1][1] = Math.Max(result[result.Count - 1][1], intervals[i][1]);
                }
                else
                    result.Add(intervals[i]);
            }
            return result.ToArray();
        }
    }
}
