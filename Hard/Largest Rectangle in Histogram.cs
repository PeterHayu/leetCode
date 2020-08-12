using System;
using System.Collections.Generic;
using System.Text;

namespace Hard
{
    class Largest_Rectangle_in_Histogram
    {
        public int LargestRectangleArea(int[] heights)
        {
            if (heights.Length <= 0 || heights == null)
                return 0;

            var indexOfLessFromLeft = new int[heights.Length];
            var indexOfLessFromRight = new int[heights.Length];
            var area = 0;

            indexOfLessFromLeft[0] = -1;
            indexOfLessFromRight[heights.Length - 1] = heights.Length;

            //for each position i,get the furthest index to left tat is less than height of i
            for (int i = 1; i < heights.Length; i++)
            {
                var p = i - 1;
                while (p >= 0 && heights[p] >= heights[i])
                {
                    p = indexOfLessFromLeft[p];
                }
                indexOfLessFromLeft[i] = p;
            }

            //for each position i,get the furthest index to right tat is less than height of i
            for (int i = heights.Length - 2; i >= 0; i--)
            {
                var p = i + 1;
                while (p < heights.Length && heights[p] >= heights[i])
                {
                    p = indexOfLessFromRight[p];
                }
                indexOfLessFromRight[i] = p;
            }
            //calculate the max area for each index
            for (int i = 0; i < heights.Length; i++)
            {
                area = Math.Max(area, heights[i] * (indexOfLessFromRight[i] - indexOfLessFromLeft[i] - 1));
            }

            return area;

        }
    }
}
