using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    public static class LongestCommonPrefix
    {
        public static string longestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
                return "";
            Array.Sort(strs, (x, y) => x.Length.CompareTo(y.Length));
            var index = 0;
            var result = "";
            HashSet<char> Set = new HashSet<char>();

            while (index < strs[0].Length)
            {
                foreach (var str in strs)
                {
                    var stAry = str.ToCharArray();
                    Set.Add(stAry[index]);
                }

                if (Set.Count == 1)
                {
                    index++;
                    foreach (var s in Set)
                    {
                        result += s;
                    }
                    Set.Clear();
                }
                else
                { return result; }
            }
            return result;
        }

        //vertical comparison
        public static string longestCommonPrefixAsw(string[] strs)
        {
            if (strs == null || strs.Length == 0) return "";
            for (int i = 0; i < strs[0].Length; i++)
            {
                char c = strs[0][i];
                for (int j = 1; j < strs.Length; j++)
                {
                    if (i == strs[j].Length || strs[j][i] != c)
                        return strs[0].Substring(0, i);
                }
            }
            return strs[0];
        }
    }
}
