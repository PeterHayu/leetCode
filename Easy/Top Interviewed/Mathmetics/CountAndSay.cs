using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    public static class CountAndSay
    {
        public static string countAndSay(int n)
        {
            if (n == 1)
                return "1";


            string str = countAndSay(n - 1);

            string sb = "";

            char c = '0';
            int count = 0;

            for (int i = 0; i < str.Length; i++)
            {
                //get the new char, reset counter 
                c = str[i];
                count = 1;
                //count repetitive times of the current char C
                while ((i + 1) < str.Length && str[i + 1] == c)
                {
                    count++;
                    i++;
                }
                //string concat of "numbers of count" + "char c", not number addition
                sb += count + "" + c;
            }

            return sb;
        }

    }
}
