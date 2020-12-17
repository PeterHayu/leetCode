using System;
using System.Collections.Generic;

namespace Easy.TopInterviewed.Mathmetics
{
    public class FizzBuzz
    {
        public IList<string> FizzBuzz2(int n)
        {
            var ans = new List<string>();

            for (int i = 0; i < n; i++)
            {
                int m = i + 1;
                if (i < 2)
                    ans.Add(m + "");
                else
                {
                    if (m % 3 == 0 || m % 5 == 0)
                    {
                        if (m % 3 == 0 && m % 5 == 0)
                            ans.Add("FizzBuzz");
                        else if (m % 3 == 0)
                            ans.Add("Fizz");
                        else if (m % 5 == 0)
                            ans.Add("Buzz");
                    }
                    else
                        ans.Add(m + "");
                }

            }
            return ans;
        }
    }
}
