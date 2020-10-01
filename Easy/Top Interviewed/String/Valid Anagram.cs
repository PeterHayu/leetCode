using System;
using System.Collections.Generic;

namespace Easy
{
    public class Valid_Anagram
    {
        public bool IsAnagram(string s, string t)
        {

            if (s.Length != t.Length)
                return false;

            var result = new Dictionary<int, int>();
            foreach (var l1 in s)
            {
                if (!result.ContainsKey(l1))
                {
                    result[l1] = 1;
                }
                else
                    result[l1]++;
            }
            foreach (var l2 in t)
            {
                if (!result.ContainsKey(l2))
                    return false;
                result[l2]--;
                if (result[l2] < 0)
                    return false;
            }
            return true;
        }
    }
}
