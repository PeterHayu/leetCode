using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Array
{
    class Prison_After_N_Day
    {
        public int[] PrisonAfterNDays(int[] states, int days)
        {

            var reachCycle = false;
            var pattern = new HashSet<string>();
            var cycle = 0;
            //either use for loop or use a new variable to decrease and while loop
            var N = days;
            while (N-- > 0)
            {
                var nextDay = AfterNextDays(states);
                var nextDayPattern = string.Join(",", nextDay);

                if (pattern.Contains(nextDayPattern))
                {
                    //pattern discovered! break the loop, we have all combination
                    reachCycle = true;
                    break;
                }
                else
                {
                    cycle++;
                    pattern.Add(nextDayPattern);
                }
                //update states reference
                states = nextDay;
            }

            if (reachCycle)
            {
                days %= cycle;
                while (days-- > 0)
                {
                    states = AfterNextDays(states);
                }
            }

            //if days end before reaching any cycle, simply return states
            return states;
        }

        //given the current states, return next day states
        private int[] AfterNextDays(int[] states)
        {
            int[] result = new int[states.Length];
            for (int i = 1; i < result.Length - 1; i++)
            {
                result[i] = states[i - 1] == states[i + 1] ? 1 : 0;
            }
            return result;
        }

    }
}
