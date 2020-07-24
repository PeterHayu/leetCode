using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public static class Fraction_to_Recurring_Decimal
    {
        public static string FractionToDecimal(int numerator, int denominator)
        {
            if (denominator == 0)
                return "-1"; // not existing
            if (numerator == 0)
                return "0";

            var positive = true;
            // different side of 0
            if (numerator * denominator < 0)
            {
                positive = false;
            }

            var num = Math.Abs((long)numerator);
            var denum = Math.Abs((long)denominator);


            // only deal with postive numbers
            var quotient = num / denum; // 2/3 = 0
            var residue = num % denum; // 2/3...2

            var result = quotient.ToString(); //"0"
            var hasDot = false;

            var map = new Dictionary<long, int>();

            while (residue != 0)
            {
                if (hasDot == false)
                {
                    hasDot = true;
                    result += "."; //"0."                               
                }

                //user dictionary to record seen residual (inifinite digits)
                map.Add(residue, result.Length);

                var number = residue * 10; // 20
                                           // next digit
                var nextQuotient = number / denum; // 6
                var nextResidue = number % denum; // 2

                result += nextQuotient.ToString();

                var repeatable = map.ContainsKey(nextResidue);

                if (repeatable)
                {
                    var pos = map[nextResidue];
                    var shortHand = result.Substring(0, pos);
                    shortHand = shortHand + "(" + result.Substring(pos) + ")";

                    if (!positive) //&& shortHand[0] != '-'
                    {
                        shortHand = "-" + shortHand;
                    }

                    return shortHand;
                }

                residue = nextResidue; // 0           
            }


            if (!positive && result[0] != '-')
            {
                result += "-";
            }

            return result;
        }
    }
}
