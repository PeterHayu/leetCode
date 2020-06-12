using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Binary_Search
{
    public static class Binary_Search_Matrix
    {
        public static bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix.Length <= 0 || matrix[0].Length <= 0)
                return false;
            int m = matrix.Length;
            int n = matrix[0].Length;
            int l = 0, r = m * n - 1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (matrix[mid / m][mid % m] == target)
                    return true;
                else if (matrix[mid / m][mid % m] > target)
                {
                    r = mid - 1;
                }
                else if (matrix[mid / m][mid % m] < target)
                {
                    l = mid + 1;
                }
            }
            return false;
        }
    }
}

