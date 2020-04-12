using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    public class PlusOne
    {
        public int[] plusOneOptimized(int[] digits)
        {

            int n = digits.Length;
            for (int i = n - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }

                digits[i] = 0;
            }

            int[] newNumber = new int[n + 1];
            newNumber[0] = 1;

            return newNumber;
        }

        public int[] plusOne(int[] digits)
        {
            digits[digits.Length - 1] += 1;

            for (int i = digits.Length - 1; i > 0; i--)
            {
                if (digits[i] == 10)
                {
                    digits[i] = 0;
                    if (i != 0)
                        digits[i - 1] += 1;
                    else
                        digits[i] = 10;
                }
                else
                {
                    return digits;
                }
            }

            if (digits[0] == 10)
            {
                var digitsClone = new int[digits.Length + 1];
                digitsClone[0] = 1;
                /*
                for(int j = 1;j<digitsClone.Length;j++){
                    digitsClone[j]=0;
                }
                */
                return digitsClone;
            }

            return digits;
        }
    }
}
