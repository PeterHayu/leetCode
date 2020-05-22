using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public static class Group_Anagrams
    {
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var result = new List<IList<string>>();
            var window = new Dictionary<string, List<string>>();
            foreach (var str in strs)
            {
                var c = str.ToCharArray();
                Array.Sort(c);
                //trap
                var key = new string(c);
                if (window.ContainsKey(key))
                    window[key].Add(str);
                else
                    window[key] = new List<string>() { str };
            }
            foreach (var w in window)
            {
                result.Add(w.Value);
            }
            return result;
        }
    }
}
