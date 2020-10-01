using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    public static class StringIndexOf
    {
        public static int strStr(string haystack, string needle)
        {
            if (needle == "")
                return 0;

            for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
            {
                for (int j = 0; j < needle.Length && needle[j] == haystack[i + j]; j++)
                {
                    if (j == needle.Length -1)
                        return i;
                }
            }
            return -1;
        }
    }
}
