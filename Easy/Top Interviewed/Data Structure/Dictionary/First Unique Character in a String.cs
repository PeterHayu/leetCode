using System;
using System.Collections.Generic;

namespace Easy.TopInterviewed.DataStructure.Dictionary
{
    public class First_Unique_Character_in_a_String
    {
        public int FirstUniqChar(string s)
        {

            //counting dictionary
            var d = new Dictionary<char, int>();

            foreach (var c in s)
            {
                if (!d.ContainsKey(c))
                {
                    d[c] = 1;
                }
                else
                    d[c]++;
            }


            for (int i = 0; i < s.Length; i++)
            {
                if (!(d[s[i]] > 1))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
