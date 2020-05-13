using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public static class LongestPalindromeSubstring
    {
        public static string LongestPalindrome(string s)
        {
            if (s == null || s == "") return "";
            int left = 0, digits = 0;
            for (int i = 0; i < s.Length; i++)
            {
                //odd ceter
                var len1 = ExpandAroundCeter(s, i, i);
                //even center (no center)
                var len2 = ExpandAroundCeter(s, i, i + 1);
                var len = Math.Max(len1, len2);
                //compare with previous max
                if (len > digits)
                {
                    left = i - (len - 1) / 2;
                    digits = len;
                }
            }
            //substring work as starting position, and number of digits
            return s.Substring(left, digits);

        }

        private static int ExpandAroundCeter(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            return right - left - 1;
        }
    }
}
