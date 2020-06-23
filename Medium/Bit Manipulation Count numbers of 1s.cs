using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    class Bit_Manipulation_Count_numbers_of_1s
    {
        public int HammingWeight(uint n)
        {
            int result = 0;
            while (n != 0)
            {
                result++;
                n &= n - 1;
            }
            return result;
        }

    }
}
