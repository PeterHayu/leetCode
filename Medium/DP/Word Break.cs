using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.DP
{
    public static class Word_Break
    {
        public static bool WordBreak(string s, IList<string> wordDict)
        {
            //dp: whether substring s [i,j] is contained in wordDict
            var dp = new bool[s.Length + 1];
            dp[0] = true;
            var st = new HashSet<string>(wordDict);
            public bool WordBreak(string s, IList<string> wordDict)
            {
                //dp: whether substring s [0,i] is contained in wordDict
                var dp = new bool[s.Length + 1];
                dp[0] = true;
                var st = new HashSet<string>(wordDict);

                for (int i = 1; i <= s.Length; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        //dp here helps to not enter proceed to check in set if previous substring combo has been checked
                        if (dp[j] && st.Contains(s.Substring(j, i - j)))
                        {
                            dp[i] = true;
                            //start the check of next word
                            break;
                        }
                        //some waste here
                    }
                }
                return dp[s.Length];
            }
        }
}
