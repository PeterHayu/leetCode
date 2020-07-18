using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Iterate_Grid.DFS
{
    class Surrounded_Region
    {
        public void Solve(char[][] board)
        {
            //logic: 
            //a.check boarder first for o to be *
            //b.change all the non boarder o to x
            //c.change all the * to o
            if (board.Length < 1)
                return;

            int n = board.Length;
            int m = board[0].Length;

            //a: check first and last column
            for (int i = 0; i < n; i++)
            {
                Traverse(board, i, 0);
                Traverse(board, i, m - 1);
            }

            //a: check first and last row
            for (int j = 0; j < m; j++)
            {
                Traverse(board, 0, j);
                Traverse(board, n - 1, j);
            }

            //b and c
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (board[i][j] == 'O')
                        board[i][j] = 'X';
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {

                    if (board[i][j] == '*')
                        board[i][j] = 'O';
                }
            }
        }

        private void Traverse(char[][] board, int row, int col)
        {
            if (row < 0 || row >= board.Length || col < 0 || col >= board[0].Length || board[row][col] != 'O')
                return;

            board[row][col] = '*';

            Traverse(board, row - 1, col);
            Traverse(board, row, col - 1);
            Traverse(board, row + 1, col);
            Traverse(board, row, col + 1);
        }
    }
}
