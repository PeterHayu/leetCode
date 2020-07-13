using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.DP
{
    class Decode_Ways
    {
        public int NumDecodings(string s)
        {
            //same idea as fibonacci, with condition check for in range of 26 letters
            var dp = new int[s.Length + 1];
            if (s.Length <= 0)
                return 0;
            //dp is the number of combination for length n string
            dp[0] = 1;
            //edge case: "0"
            dp[1] = s[0] == '0' ? 0 : 1;

            for (int i = 2; i <= s.Length; i++)
            {
                var oneDigit = Convert.ToInt32(s.Substring(i - 1, 1));
                var twoDigit = Convert.ToInt32(s.Substring(i - 2, 2));
                //edge case: "10" , or any 0 in the middle
                if (oneDigit > 0)
                {
                    //if the current last digit is not zero
                    //add only previous combination
                    dp[i] += dp[i - 1];
                }

                //if the current last two digit is btw 10 and 26, add also the combination from i-2, any other possibility, remains only the possibilities from i-1
                if (twoDigit >= 10 && twoDigit <= 26)
                    dp[i] += dp[i - 2];
            }

            return dp[s.Length];


        }
    }
}
