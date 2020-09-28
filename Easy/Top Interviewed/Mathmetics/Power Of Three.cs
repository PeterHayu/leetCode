using System;
namespace Easy.TopInterviewed.Mathmetics
{
    public class Power_Of_Three
    {
        //check if a number is of power of 3
        public bool IsPowerOfThree(int n)
        {
            if (n > 1)  // n = 0 edge case
                while (n % 3 == 0)
                    n /= 3;
            return n == 1;
        }
    }
}
