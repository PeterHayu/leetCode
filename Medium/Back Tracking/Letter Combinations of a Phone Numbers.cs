using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Back_Tracking
{
    class Letter_Combinations_of_a_Phone_Numbercs
    {
        public IList<string> LetterCombinations(string digits)
        {
            var ans = new List<string>();
            if (digits == null || digits == "")
                return ans;
            var d = new Dictionary<int, string>()
            {
                ['2'] = "abc",
                ['3'] = "def",
                ['4'] = "ghi",
                ['5'] = "jkl",
                ['6'] = "mno",
                ['7'] = "pqrs",
                ['8'] = "tuv",
                ['9'] = "wxyz"
            };

            //initialized ans to be used in Combine helper method
            ans.Add("");

            foreach (var digit in digits)
            {
                ans = Combine(ans, d[digit]);
            }
            return ans;
        }

        private List<string> Combine(List<string> rs, string digit)
        {
            var result = new List<string>();
            foreach (var r in rs)
            {
                foreach (var c in digit)
                {
                    result.Add(r + c);
                }
            }
            return result;

        }

    }
}
