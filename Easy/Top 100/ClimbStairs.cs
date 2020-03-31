using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    public static class ClimbStairs
    {
        public static int climbStairs(int n) {
            if (n < 0)
                return -1;
            int current = 1;
            int future = 1;
            while (n > 0) {
                current = future;
                future += current;
                n--;
            }
            return current;
        }

        //easier to understand and go on for fourth step
        public static int climbStairsFib(int n) {
            int first = 1;
            int second = 2;
            int third= 0;
            if (n < 0)
                return -1;
            if (n == first)
                return first;
            if (n == second)
                return second;
            for (int i = 2; i < n; i++) {
                third = first + second; //+ third, if 3 elements
                first = second; //
                second = third;
                //third = fourth;
            }
            return third;
        }
    }
}
