using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public static class Bit_Manipulation_Counting_Bits
    {
        public static int[] CountBits(int num)
        {
            int[] f = new int[num + 1];
            for (int i = 1; i <= num; i++) 
                f[i] = f[i >> 1] + (i & 1);
            return f;
        }
    }
}
