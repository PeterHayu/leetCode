using System;
namespace Medium.IterateGrid.DFS
{
    public class Longest_Increase_Path_in_Matrix
    {

        public int[][] dirs = new int[][]{new int[]{1,0},
                               new int[]{-1,0},
                               new int[]{0,1},
                               new int[]{0,-1}};

        public int dfs(int[][] matrix, int i, int j, int m, int n, int[,] cache)
        {
            if (cache[i, j] != 0)
                return cache[i, j];

            int max = 1;

            foreach (var d in dirs)
            {
                int x = i + d[0];
                int y = j + d[1];
                if (x < 0 || y < 0 || x >= m || y >= n || matrix[x][y] <= matrix[i][j]) continue;
                int len = 1 + dfs(matrix, x, y, m, n, cache);
                max = Math.Max(len, max);
            }
            cache[i, j] = max;
            return max;
        }


        public int LongestIncreasingPath(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0)
                return 0;
            var cache = new int[matrix.Length, matrix[0].Length];
            int result = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    int len = dfs(matrix, i, j, matrix.Length, matrix[0].Length, cache);
                    result = Math.Max(result, len);
                }
            }

            return result;
        }
    }
}
