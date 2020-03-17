using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    public static class IsPalidrome
    {
         public static bool isPalindrome(int x)
            {
                int temp = x;
                if (x < 0)
                    return false;
                if (x == 0)
                    return true;
                if (x % 10 == 0)
                    return false;
                int rev = 0;
                int max = 2147483647;
                while (x > 0)
                {
                    int lastDigit = x % 10;
                    x /= 10;
                    if (rev > max / 10 || (rev == max / 10 && lastDigit > 7))
                    {
                        return false;
                    }
                    rev = rev * 10 + lastDigit;
                }
                return rev == temp;
            }

        public static bool isPalindromeAnswer(int x)
        {
            if (x < 0)
                return false;
            if (x == 0)
                return true;
            if (x % 10 == 0)
                return false;
            int rev = 0;
            while (x > rev)
            {
                rev = rev * 10 + x % 10;
                x /= 10;
            }
            return x == rev || x == rev / 10;
        }
    }
    }
