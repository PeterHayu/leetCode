using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public static class Spiral_Matrix
    {
        public static IList<int> SpiralOrder(int[][] matrix)
        {
            //n * m matrix
            var result = new List<int>();
            if (matrix.Length == 0 || matrix[0].Length == 0)
                return result;
            var m = matrix.Length;
            var n = matrix[0].Length;
            var left = 0;
            var right = n - 1;
            var up = 0;
            var down = m - 1;
            while (result.Count < n * m)
            {

                //1,2,3, later 5
                for (int i = left; (i <= right) && (result.Count < n * m); i++)
                {
                    result.Add(matrix[up][i]);
                }

                //6,9
                for (int j = up + 1; (j <= down) && (result.Count < n * m); j++)
                {
                    result.Add(matrix[j][right]);
                }

                //8,7
                for (int k = right - 1; (k >= left) && (result.Count < n * m); k--)
                {
                    result.Add(matrix[down][k]);
                }

                //4
                for (int l = down - 1; (l >= up + 1) && (result.Count < n * m); l--)
                {
                    result.Add(matrix[l][left]);
                }


                left++;
                right--;
                up++;
                down--;
            }

            return result;
        }
    }
}
