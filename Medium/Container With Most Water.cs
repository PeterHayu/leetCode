using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    class Container_With_Most_Water
    {

        public int MaxArea(int[] height)
        {
            int area = Int32.MinValue;
            int i = 0;
            int j = height.Length - 1;
            while (j > i)
            {
                area = Math.Max(area, Math.Min(height[j], height[i]) * (j - i));
                if (height[j] > height[i])
                    i++;
                else
                    j--;
            }
            return area;
        }

    }
}
