using System;
namespace Medium
{
    public class Maximal_Square
    {
        public int MaximalSquare(char[][] matrix)
        {
            if (matrix.Length < 0)
                return -1;
            //dp is the max size of 1 squares that right down corner located
            int max = -1;
            var dp = new int[matrix.Length, matrix[0].Length];

            //fill the dp matrix
            for (int i = 0; i < matrix.Length; i++)
            {
                dp[i, 0] = matrix[i][0] == '1' ? 1 : 0;
                max = Math.Max(max, dp[i, 0]);
            }

            for (int j = 0; j < matrix[0].Length; j++)
            {
                dp[0, j] = matrix[0][j] == '1' ? 1 : 0;
                max = Math.Max(max, dp[0, j]);
            }


            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        //dp[i][j] = Min(left,upper,diagonal left upper)
                        dp[i, j] = Math.Min(dp[i - 1, j - 1], Math.Min(dp[i - 1, j], dp[i, j - 1])) + 1;
                        max = Math.Max(max, dp[i, j]);
                    }
                }
            }

            return max * max;
        }

    }
}
