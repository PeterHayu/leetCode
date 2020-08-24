using System;
using System.Collections.Generic;
using System.Text;

namespace Hard
{
    class Max_Points_on_a_Line
    {
        public int MaxPoints(int[][] points)
        {

            if (points == null)
            {
                return 0;
            }

            //if two points then must on same line
            if (points.Length <= 2)
            {
                return points.Length;
            }

            //a Dictionary to store the combination of x and y.
            //cannot use y/x to calculate slope due to precision
            Dictionary<int, Dictionary<int, int>> slope = new
                Dictionary<int, Dictionary<int, int>>();

            int result = 0;

            for (int i = 0; i < points.Length; i++)
            {
                //clearing the slope dictionary after max numbers of line has been record in the result varaible
                slope.Clear();
                int max = 0, same = 0;

                for (int j = i + 1; j < points.Length; j++)
                {
                    //delta x and delta y for slope calculation
                    int x = points[j][0] - points[i][0];
                    int y = points[j][1] - points[i][1];

                    //edge case: same point as input, will messed up slope calculation
                    if (x == 0 && y == 0)
                    {
                        same++;
                        continue;
                    }

                    //greatest common denominator
                    //we define unique as the combination (x,y)
                    //(1,1) and (2,2) are same, but need to process with gcd
                    int g = gcd(x, y);
                    if (g != 0)
                    {
                        x = x / g;
                        y = y / g;
                    }

                    //for dictionary slope
                    //think of key as x coordinate
                    //value as y coordinate, and the count of points already on this (x,y) combination
                    if (slope.ContainsKey(x))
                    {
                        if (slope[x].ContainsKey(y))
                        {
                            slope[x][y] += 1;
                        }
                        else
                        {
                            slope[x].Add(y, 1);
                        }
                    }
                    else
                    {
                        Dictionary<int, int> ytemp = new Dictionary<int, int>();
                        ytemp.Add(y, 1);
                        slope.Add(x, ytemp);
                    }
                    //store max numbers of points for lines starting from point i
                    max = Math.Max(max, slope[x][y]);
                }
                //compare with max numbers of points for lines starting from other points
                result = Math.Max(result, max + same + 1);
            }

            return result;
        }

        private int gcd(int a, int b)
        {
            if (b == 0) return a;
            else return gcd(b, a % b);
        }

    }
}
