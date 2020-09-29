using System;
namespace Medium
{
    public class Basic_Calculator_2
    {
        public int Calculate(string s)
        {
            int sum = 0;
            int tempSum = 0;
            int num = 0;
            char lastSign = '+';
            s = s.Trim();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                //update num to the correct representation from char to int
                if (Char.IsDigit(c)) num = num * 10 + c - '0';
                //if (c == ' ') continue;
                //when we reach operation sign, we need to operate on the next number
                //for + and -, we assign corresponding sign to current result 
                //and perform the operation of update sum at next iteration
                //for * and /. we do not immediately update the number to sum
                //instead we perform the operation and add it to tempsum
                //until we hit + and -
                if (i == s.Length - 1 || !Char.IsDigit(c) && c != ' ')
                {
                    //when it encounter a sign, it perform operation based on the previous sign not the current
                    switch (lastSign)
                    {
                        case '+':
                            sum += tempSum;
                            //the current num is stored in tempsum for next iteration to operate
                            tempSum = num;
                            break;
                        case '-':
                            sum += tempSum;
                            tempSum = -num;
                            break;
                        case '*':
                            tempSum *= num;
                            break;
                        case '/':
                            tempSum /= num;
                            break;
                    }
                    //the current sign is stored for next operation
                    lastSign = c;
                    //reset num so that we store the next num correctly
                    num = 0;
                }
            }
            sum += tempSum;
            return sum;
        }
    }
}
