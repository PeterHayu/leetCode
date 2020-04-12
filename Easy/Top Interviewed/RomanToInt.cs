using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    public static class RomanToInt
    {
        public static int romanToInt(string s)
        {
            int result = 0;
            var charArray = s.ToCharArray();
            for (int i = charArray.Length - 1; i >= 0; i--)
            {
                var Char = charArray[i];
                switch(Char)
                {
                    case 'I':
                        result += (result >= 5 ? -1 : 1);
                        break;
                    case 'V':
                        result += 5;
                        break;
                    case 'X':
                        result += (result >= 50 ? -10 : 10);
                        break;
                    case 'C':
                        result += (result >= 500 ? -100 : 100);
                        break;
                    case 'L':
                        result += 50;
                        break;
                    case 'D':
                        result += 500;
                        break;
                    case 'M':
                        result += 1000;
                        break;
                    default:
                        result += 0;
                        break;
                }
            }
            return result;
        }
    }
}

