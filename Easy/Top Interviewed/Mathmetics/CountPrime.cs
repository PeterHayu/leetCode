using System;
namespace Easy.TopInterviewed.Math
{
    public class CountPrime
    {
        public int CountPrimes(int n)
        {
            //default to false
            //major logic is to remove non-prime from possible primes
            if (n < 3)
                return 0;

            var s = new bool[n];
            //possible max primes are n/2 for all the even numbers
            var result = n / 2;

            //loop through all the odd numbers, we remove its odd multiples
            for (int i = 3; i * i < n; i += 2)
            {
                if (s[i])
                    continue;

                //removing odd multiples
                //3*5,3*7,3*9
                for (int j = i * i; j < n; j += i * 2)
                {
                    if (!s[j])
                    {
                        s[j] = true;
                        result--;
                    }
                }
            }
            return result;
        }
    }
}
