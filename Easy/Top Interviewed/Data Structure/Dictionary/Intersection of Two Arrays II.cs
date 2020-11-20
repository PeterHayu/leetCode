using System;
using System.Collections.Generic;

namespace Easy.TopInterviewed.DataStructure.Dictionary
{
    public class Intersection_of_Two_Arrays_II
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            var d = new Dictionary<int, int>();
            var result = new List<int>();
            foreach (var n in nums1)
            {
                if (d.ContainsKey(n))
                    d[n]++;
                else
                    d[n] = 1;
            }

            foreach (var n in nums2)
            {
                if (d.ContainsKey(n) && d[n] > 0)
                {
                    d[n]--;
                    result.Add(n);
                }
            }

            return result.ToArray();
        }
    }
}
