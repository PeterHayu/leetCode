using System;
using System.Collections.Generic;

namespace Medium.Greedy
{
    public class Task_Scheduler
    {
        public int LeastInterval(char[] tasks, int requiredIdels)
        {

            /*
            Logic: least number of unit of times = # tasks + # idels
            # tasks = task.Length
            # idels = (maxFrequencyOfTasks - 1) * requiredIdels
            */
            if (requiredIdels == 0)
                return tasks.Length;

            //1, collect the frequency of each tasks and find the maxFrequencyOfTasks and the tasks
            Dictionary<char, int> taskCounts = new Dictionary<char, int>();
            int maxFrequency = 0;
            char maxFrequencyChar = 'a';//default to a
            int maxCoolDownUnitsExpected;

            foreach (char c in tasks)
            {
                if (!taskCounts.TryAdd(c, 1))
                    taskCounts[c]++;

                //save the max frequency and the task
                if (taskCounts[c] > maxFrequency)
                {
                    maxFrequency = taskCounts[c];
                    maxFrequencyChar = c;
                }
            }



            //2, Remove the maxFrequency Character or any one of the character which is equal
            //to maxFrequency, so we dont subtract it in the foreach loop below.
            taskCounts.Remove(maxFrequencyChar);
            //The reason we do maxFrequency - 1 is because we dont need coolDOwnUnits
            //after the last maxFrequency character (AB-AB-AB).
            maxCoolDownUnitsExpected = (maxFrequency - 1) * requiredIdels;

            //substract those that can be combined with maxFrequency character. Ex AB-AB-AB is equivalent to ABC-ABC-ABC
            foreach (KeyValuePair<char, int> kvp in taskCounts)
            {
                int currentCharacterCount = kvp.Value;

                if (currentCharacterCount == maxFrequency)
                    //we subtract 1 for the same reason that we subtract 1 from the maxFrequency
                    //to get maxCoolDownUnitsExpected.
                    currentCharacterCount--;

                maxCoolDownUnitsExpected -= currentCharacterCount;
            }

            //greated than 0 means there are extra tasks that could not fit by idels, else all can be combined into idles and not extra idels needed
            return maxCoolDownUnitsExpected > 0 ? maxCoolDownUnitsExpected + tasks.Length : tasks.Length;
        }
    }
}
