using System;
using System.Collections.Generic;
using System.Text;

namespace Hard
{
    class Regular_Expression_Matching___DP
    {
        public bool IsMatch(string s, string p)
        {

            //dp means: 0-i of s matches 0-j of p
            var dp = new bool[s.Length + 1, p.Length + 1];
            dp[0, 0] = true;


            //scenario: * and deleted (aab, c*a*b) = true
            for (int j = 0; j < p.Length; j++)
            {
                //if from beginning, s match some following part of p after *
                if (p[j] == '*' && dp[0, j - 1])
                {
                    //mark it s matches p[0..i+1] (following part of p after *)
                    dp[0, j + 1] = true;
                }
            }


            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < p.Length; j++)
                {
                    //if matches directly, set as true
                    if (s[i] == p[j])
                        dp[i + 1, j + 1] = dp[i, j];
                    //if find . (can be anything), set as true
                    if (p[j] == '.')
                        dp[i + 1, j + 1] = dp[i, j];
                    if (p[j] == '*')
                    {
                        //if not .*,  (baa, bb*aa) = true because * and delete scenario
                        //this cannot be combined with leading * and delete scenario 
                        if (s[i] != p[j - 1] && p[j - 1] != '.')
                        {
                            //compare the first b, if they match means can be deleted
                            dp[i + 1, j + 1] = dp[i + 1, j - 1];
                        }
                        else
                        {
                            //sceanrio: a* && aa(add), aaa && ab*a*c*a"(delete)
                            dp[i + 1, j + 1] = dp[i, j + 1] || dp[i + 1, j - 1];
                        }
                    }
                }
            }


            return dp[s.Length, p.Length];

        }
    }
}
