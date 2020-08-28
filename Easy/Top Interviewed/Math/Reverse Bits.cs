using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Math
{
    class Reverse_Bits
    {
        public uint reverseBits(uint n)
        {
            uint ans = 0;
            for (int i = 0; i < 32; i++)
            {
                //shift one bit from the right of answer 
                ans <<= 1;
                //n & 1 obtain the last bit from n, while ans | last bit adds the bit to answer
                ans = ans | (n & 1);
                //shift one bit left from n, updating the last bit of n to latest
                n >>= 1;
            }
            return ans;
        }
    }
}
