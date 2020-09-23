using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.SlidingWindow
{
    public static class MinWordSubstring
    {
        public static string MinWindow(string s, string t)
        {
            //count frequencyOfEachChar in t(arget)
            Dictionary<char, int> need = new Dictionary<char, int>(), window = new Dictionary<char, int>();
            foreach (char c in t)
            {
                if (need.ContainsKey(c))
                    need[c]++;
                else
                    need[c] = 1;
            }

            int left = 0;
            int right = 0;
            int expectedLength = 0;
            //result related variables
            int maxLength = Int32.MaxValue;
            int start = 0;


            while (right < s.Length)
            {
                char c = s[right];
                if (window.ContainsKey(c))
                    window[c]++;
                else
                    window[c] = 1;
                right++;

                //if count in current window = count in need
                if (need.ContainsKey(c) && need[c] == window[c])
                {
                    expectedLength++;
                }

                //if current window meets the need, execute
                //note, not the length of t, length of the need dictionary
                while (left <= right && expectedLength == need.Count)
                {
                    char d = s[left];

                    //save the current result
                    //if the new window size smaller than previous window size
                    if (right - left < maxLength)
                    {
                        start = left;
                        maxLength = right - left;
                    }

                    //shrink the window
                    if (window.ContainsKey(d))
                        window[d]--;
                    else
                        window[d] = 1;
                    left++;


                    if (need.ContainsKey(d) && need[d] > window[d])
                    {
                        expectedLength--;
                    }

                }
            }
            return maxLength == Int32.MaxValue ? "" : s.Substring(start, maxLength);
        }
    }
}
