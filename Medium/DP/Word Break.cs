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

        private static bool result2 = false;

        public static bool WordBreak2(string s, IList<string> wordDict)
        {
            Helper(s, wordDict, new Dictionary<string, bool>());
            return result2;
        }
        //BFS
        private static void Helper(string s, IList<string> wordDict, Dictionary<string, bool> memo)
        {

            //to save previous stored result and skip the recursion process
            if (memo.ContainsKey(s))
            {
                return;
            }

            //base case
            if (s.Length == 0)
            {
                result = true;
                return;
            }

            //break the following string into substring
            foreach (var w in wordDict)
            {
                if (s.StartsWith(w))
                {
                    var sub = s.Substring(w.Length);
                    Helper(sub, wordDict, memo);
                }
            }

            memo.Add(s, result);
        }
    }
}
