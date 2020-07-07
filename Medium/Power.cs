using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public class Power
    {
        public double MyPow(double x, int n)
        {
            bool isNegative = false;
            if (n < 0)
            {
                x = 1 / x;
                isNegative = true;
                //to avoid int overflow
                n = -(n + 1);
            }

            double result = 1;
            double temp = x;

            //main algorithm
            while (n != 0)
            {
                //only multi to result when n is odd
                if (n % 2 == 1)
                {
                    result *= temp;
                }
                temp *= temp;
                n /= 2;
            }

            //for neagtive number we time one time less to avoid overflow
            if (isNegative)
            {
                result *= x;
            }

            return result;
        }
    }
}
