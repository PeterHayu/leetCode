using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.DP
{
    public class Divisor_Game
    {
        public bool DivisorGame(int N)
        {
            //the result of people start with the number i
            bool[] dp = new bool[N + 1];
            dp[0] = false;
            dp[1] = false;

            //brute force
            for (int i = 2; i <= N; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    //each j smaller than i, we try and see if it reaches a designated result
                    if (i % j == 0)
                    {
                        //if one of the previous solution can lead to false
                        //the initiator can pick this i-j value and win the game
                        //thus this result will lead to definite win
                        if (!dp[i - j])
                        {
                            dp[i] = true;
                            break;
                        }
                    }
                }
            }
            return dp[N];
        }

    }
}
