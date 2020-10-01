using System;
using System.Collections.Generic;

namespace Easy.TopInterviewed.String
{
    public class Ransom_Note
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            if (magazine.Length < ransomNote.Length)
                return false;
            var hs = new Dictionary<char, int>();
            foreach (var m in magazine)
            {
                if (hs.ContainsKey(m))
                {
                    hs[m]++;
                }
                else
                    hs[m] = 1;
            }

            foreach (var r in ransomNote)
            {
                if (hs.ContainsKey(r))
                {
                    hs[r]--;
                }
                else
                    return false;

                if (hs[r] < 0)
                    return false;
            }

            return true;
        }
    }
}
