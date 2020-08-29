using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Math
{
    class Happy_Number
    {
        public bool IsHappy(int n)
        {
            var s = new HashSet<int>();
            //when sum reaches 1, it a happy number
            //major logic: keep adding then deleting the last digit square
            //replace n with the sum in loop (like a recursive way)
            while (n != 1)
            {
                int sum = 0, current = n;
                while (current != 0)
                {
                    //square the last digit and add to sum
                    sum += ((current % 10) * (current % 10));
                    //eliminate the last digit
                    current /= 10;
                }

                //we get into infinite loop
                if (s.Contains(sum))
                {
                    return false;
                }

                s.Add(sum);
                //check for the new number
                n = sum;
            }

            return true;
        }
    }
}
