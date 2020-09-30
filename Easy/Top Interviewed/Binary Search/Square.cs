using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Binary_Search
{
    public class Square
    {
        public int SqrtBinarySearch(int x)
        {
            var left = 1;
            var right = x;
            while (left <= right)
            {
                var mid = (right - left) / 2 + left;
                if (mid == x / mid)
                    return mid;
                else if (mid < x / mid)
                    left = mid + 1;
                else if (mid >= x / mid)
                    right = mid - 1;
            }
            return right;
        }

        public int MySqrtMath(int x) {
            long r = x;
            while (r * r > x)
            {
                r = (x / r + r) / 2;
            }
            return (int)r;
        }
    }
}
