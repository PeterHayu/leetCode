using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    class Divide_
    {
        public int Divide(int dividend, int divisor)
        {
            //edge case
            if (dividend == Int32.MinValue && divisor == -1) return Int32.MaxValue;
            //check if they are same sign, in the end return
            bool sign = (dividend < 0) == (divisor < 0);
            //change to all negative to avoid overflow
            dividend = dividend > 0 ? -dividend : dividend;
            divisor = divisor > 0 ? -divisor : divisor;

            int res = DivideHelper(dividend, divisor);
            return sign ? res : -res;
        }

        public int DivideHelper(int dividend, int divisor)
        {
            if (divisor < dividend) return 0;
            int sum = divisor, m = 1;
            //same logic as bit manipulation
            //keep doubling until the closet possible to dividend
            //m is part of the result 
            //edge case for dividend = Int32.MaxValue
            while ((Int32.MinValue - sum < sum) && (sum + sum > dividend))
            {
                sum += sum;
                m += m;
            }
            //recursively process the mod, and sum all m up
            return m + DivideHelper(dividend - sum, divisor);
        }
    }
}
