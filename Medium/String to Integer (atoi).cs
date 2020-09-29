using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public static class String_to_Integer__atoi_
    {
        public static int MyAtoi(string str)
        {
            var i = 0;
            var sign = 1;
            var result = 0;
            if (str.Length < 1)
                return 0;

            while (i < str.Length && str[i] == ' ')
            {
                //requirement1: eliminate leading empty space
                i++;
            }

            //requirement2: set sign
            if (i < str.Length && (str[i] == '+' || str[i] == '-' && i < str.Length))
            {
                if (str[i] == '-')
                    sign *= -1;
                i++;
            }


            while (i < str.Length && str[i] >= '0' && str[i] <= '9')
            {
                //requirement 3: check if base already exceed int limit
                if (result > Int32.MaxValue / 10 || (result == Int32.MaxValue / 10 && (str[str.Length - 1] - '0') > 7))
                {
                    return sign > 0 ? Int32.MaxValue : Int32.MinValue;
                }
                result = 10 * result + (str[i] - '0');
                i++;
            }

            return result * sign;
        }
    }
}
