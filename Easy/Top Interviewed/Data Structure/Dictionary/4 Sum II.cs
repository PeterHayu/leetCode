using System;
using System.Collections.Generic;

namespace Easy.TopInterviewed.DataStructure.Dictionary
{
    public class __Sum_II
    {
        public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
        {
            var dic = new Dictionary<int, int>();
            foreach (var a in A)
            {
                foreach (var b in B)
                {
                    int sum = a + b;
                    if (dic.ContainsKey(sum))
                        dic[sum]++;
                    else
                        dic[sum] = 1;
                }
            }

            int ans = 0;
            foreach (var c in C)
            {
                foreach (var d in D)
                {
                    int sum = -(c + d);
                    if (dic.ContainsKey(sum))
                    {
                        ans += dic[sum];
                    }
                }
            }

            return ans;
        }
    }
}
