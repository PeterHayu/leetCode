using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed
{
    class String_Palindrome
    {
        public bool IsPalindrome(string s)
        {
            if (s.Length == 0 || s.Length == 1)
                return true;
            int i = 0;
            int j = s.Length - 1;

            while (i < j)
            {
                if (!Char.IsLetterOrDigit(s[i]))
                {
                    i++;
                }
                if (!Char.IsLetterOrDigit(s[j]))
                {
                    j--;
                }
                if (Char.IsLetterOrDigit(s[i]) && Char.IsLetterOrDigit(s[j]))
                {
                    if (Char.ToLower(s[i]) != Char.ToLower(s[j]))
                        return false;
                    i++;
                    j--;
                }
            }
            return true;
        }
    }
}
