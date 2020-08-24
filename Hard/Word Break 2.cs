using System;
using System.Collections.Generic;
using System.Text;

namespace Hard
{
    class Word_Break_2
    {
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            return Helper(s, wordDict, new Dictionary<string, List<string>>());
        }
        //BFS
        private IList<string> Helper(string s, IList<string> wordDict, Dictionary<string, List<string>> memo)
        {
            var result = new List<string>();

            //to save previous stored result and skip the recursion process
            if (memo.ContainsKey(s))
            {
                return memo[s];
            }

            //base case
            if (s.Length == 0)
            {
                result.Add("");
                return result;
            }

            //break the following string into substring
            foreach (var w in wordDict)
            {

                if (s.StartsWith(w))
                {
                    //get substring except the first word, staring index w
                    var sub = s.Substring(w.Length);
                    var subStrings = Helper(sub, wordDict, memo);

                    //nested for loop to store result inside if
                    foreach (var st in subStrings)
                    {
                        //end of substring, no more substrings
                        if (st == "")
                            result.Add(w + st);
                        else
                            result.Add(w + " " + st);
                    }
                }

            }
            memo.Add(s, result);
            return result;
        }

    }
}
