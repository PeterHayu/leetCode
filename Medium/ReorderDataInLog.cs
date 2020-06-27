using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    class ReorderDataInLog
    {
        public string[] ReorderLogFiles(string[] logs)
        {
            /*
            reimplementing 
            if return ==0 // nothing will happen original order will be maintained.
            if return ==1// values will be swapped.
            if return ==-1 //need to keep in same order        
            */
            Array.Sort(logs, (s1, s2) => {
                //split the title and the log part of the string logs
                var split1 = s1.Split(" ", 2);
                var split2 = s2.Split(" ", 2);

                //check log type, built in IsDigit log
                var isDigit1 = Char.IsDigit(split1[1][0]);
                var isDigit2 = Char.IsDigit(split2[1][0]);

                if (!isDigit1 && !isDigit2)
                {
                    // both letter-logs. 
                    int comp = split1[1].CompareTo(split2[1]);
                    if (comp == 0) return split1[0].CompareTo(split2[0]);
                    else return comp;
                }
                else if (isDigit1 && isDigit2)
                {
                    // both digit-logs. So keep them in original order
                    return 0;
                }
                else if (isDigit1 && !isDigit2)
                {
                    // first is digit, second is letter. bring letter to forward.
                    return 1;
                }
                else
                {
                    //first is letter, second is digit. keep them in this order.
                    return -1;
                }
            });
            return logs;
        }
    }
}
