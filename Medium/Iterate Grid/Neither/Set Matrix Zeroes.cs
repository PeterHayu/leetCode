using System;
namespace Medium.IterateGrid.Neither
{
    public class Set_Matrix_Zeroes
    {
        public void SetZeroes(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0)
                return;

            //make the first column and first row as row0 and col0 indicator
            //however, this will screw up the first column and first row
            //bc we cannot confirm if it has zero from the beginning
            //or being updated with indicator 0
            //lets define two variable
            var col0 = false;
            var row0 = false;
            var n = matrix.Length;
            var m = matrix[0].Length;

            //check if initial row has zero
            for (int i = 0; i < n; i++)
            {
                if (matrix[i][0] == 0)
                {
                    row0 = true;
                    break;
                }
            }

            //check if initial column has zero
            for (int j = 0; j < m; j++)
            {
                if (matrix[0][j] == 0)
                {
                    col0 = true;
                    break;
                }
            }

            //first, handle except the first col and row
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        //safely mark as 0 as the indicator
                        //however this indicator should not lead to first rol/col to be zero, if col0/row0=false
                        matrix[0][j] = 0;
                        matrix[i][0] = 0;
                    }
                }
            }

            //change the rows except first row
            for (int i = 1; i < n; i++)
            {
                if (matrix[i][0] == 0)
                {
                    for (int j = 1; j < m; j++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }


            //change the column except first column
            for (int j = 1; j < m; j++)
            {
                if (matrix[0][j] == 0)
                {
                    for (int i = 1; i < n; i++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            //safely mark the first row as all 0s
            if (row0)
            {
                for (int i = 0; i < n; i++)
                {
                    matrix[i][0] = 0;
                }
            }

            //safely mark the first col as all 0s
            if (col0)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[0][j] = 0;
                }
            }
        }
    }
}
