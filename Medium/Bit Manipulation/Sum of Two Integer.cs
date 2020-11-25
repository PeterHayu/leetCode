using System;
namespace Medium.BitManipulation
{
    public class Sum_of_Two_Integer
    {
        public int GetSum(int a, int b)
        {
            int c;
            //in binary world, only two 1s will carry fwd, so we have the carry operation as &
            while (b != 0)
            {
                //c here is the carry part (1&1 =1 rest 0)
                c = (a & b);
                //we have XOR as the addition (1^1,0^0 =0, rest 1)
                a = a ^ b;
                //left shift the carry part so that it carries to the left next digit
                b = (c) << 1;
            }
            return a;
        }
    }
}
