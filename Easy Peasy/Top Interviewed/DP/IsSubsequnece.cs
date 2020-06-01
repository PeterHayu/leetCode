using System;
using System.Collections.Generic;
using System.Linq;

namespace Easy.Top_Interviewed.DP
{
    public class IsSubsequnece
    {
        public bool isSubsequence(string s, string t)
        {
            if (s.Length <= 0)
                return true;
            if (s.Length >= t.Length)
                return false;

            var q = new Queue<char>();
            foreach (var c in s)
            {
                q.Enqueue(c);
            }
            var el = q.Dequeue();
            foreach (var c in t)
            {
                if (!q.Any())
                {
                    return true;
                }

                if (c == el)
                {
                    el = q.Dequeue();
                }
            }
            return false;
        }

        public bool isSubsequenceAns(string s, string t)
        {
            int count = 0;
            for (int i = 0; i < t.Length && count < s.Length; i++)
            {
                if (t[i] == s[count])
                    count++;
            }
            return count == s.Length;
        }
    }
}
