using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Binary_Search
{
    class Binary_Search_Matrix_2
    {
        public bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix == null || matrix.GetLength(0) < 1 || matrix.GetLength(1) < 1)
                return false;
            //number of rows
            int m = matrix.GetLength(0);
            // number of the column
            int n = matrix.GetLength(1);
            //start from the right upper conner bc tats the middle
            int r = 0, c = n - 1;
            while (c >= 0 && r <= m - 1)
            {
                if (matrix[r, c] == target)
                    return true;
                else if (matrix[r, c] > target)
                    c--;
                else if (matrix[r, c] < target)
                    r++;
            }
            return false;
        }
    }
}
