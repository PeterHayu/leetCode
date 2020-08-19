using System;
using System.Collections.Generic;
using System.Text;

namespace Hard
{
    public static class LongestConsecutiveSequence
    {
        public int LongestConsecutive(int[] nums)
        {
            //convert array to set for O(1) lookup time
            var s = new HashSet<int>(nums);
            int longestStreak = 0;


            foreach (var n in s)
            {
                //try to start counting from the smallest number of the sequence
                if (!s.Contains(n - 1))
                {
                    int temp = n;
                    int tempStreak = 1;

                    //start lookup n's consecutive number
                    while (s.Contains(temp + 1))
                    {
                        temp++;
                        tempStreak++;
                    }

                    //record the max streak
                    longestStreak = Math.Max(longestStreak, tempStreak);
                }
            }

            return longestStreak;
        }
    }
}
