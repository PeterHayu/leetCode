using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Binary_Search
{
    public class Square
    {
        public int SqrtBinarySearch(int x)
        {
            if (x == 0)
                return 0;
            int left = 1, right = x;
            while (true)
            {
                int mid = left + (right - left) / 2;
                if (mid > x / mid)
                {
                    right = mid - 1;
                }
                else
                {
                    if (mid + 1 > x / (mid + 1))
                        return mid;
                    left = mid + 1;
                }
            }
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
