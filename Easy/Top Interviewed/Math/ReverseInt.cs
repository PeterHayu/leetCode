using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    public static class ReverseInt
    {
        public static int reverse(int x)
        {
            int rev = 0;
            while (Convert.ToBoolean(x))
            {
                var lastDigit = x % 10;      //pop the last digit
                x = x / 10;         //make earlier digit become last digit

                if (rev > Int32.MaxValue / 10 || (rev == Int32.MaxValue / 10 && lastDigit > 7))
                    return 0;
                if (rev < Int32.MinValue / 10 || (rev == Int32.MinValue / 10 && lastDigit < -8))
                    return 0;

                rev = rev * 10 + lastDigit;   //push the exisiting last digit to top, and add                                       //the new lastdigit  = reverse
            }
            return rev;

        }

    }
}
