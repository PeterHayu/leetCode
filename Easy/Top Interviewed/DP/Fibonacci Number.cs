using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.DP
{
    class Fibonacci_Number
    {
        public int Fib(int N)
        {
            int first = 0;
            int second = 1;
            int result = 0;
            if (N < 0)
                return -1;
            if (N == 0 || N == 1)
                return N;

            for (int i = 2; i <= N; i++)
            {
                result = first + second;
                first = second;
                second = result;
            }

            return result;
        }
    }
}
