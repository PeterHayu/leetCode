using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Greedy
{
    public static class PartitionLabels
    {
        public static IList<int> PartitionLabel(string S)
        {
            if (S == null || S.Length == 0)
            {
                return null;
            }
            var list = new List<int>();
            int[] map = new int[26];  // record the last index of the each char

            for (int i = 0; i < S.Length; i++)
            {
                map[S[i] - 'a'] = i;
            }
            // record the end index of the current sub string
            int last = 0;
            int start = 0;
            for (int i = 0; i < S.Length; i++)
            {
                last = Math.Max(last, map[S[i] - 'a']);
                if (last == i)
                {
                    list.Add(last - start + 1);
                    start = last + 1;
                }
            }
            return list;
        }
    }
}
