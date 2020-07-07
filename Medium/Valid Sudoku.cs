using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public static class Valid_Sudoku
    {
        public static  bool IsValidSudoku(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                bool[] rowCheck = new bool[9];
                bool[] colCheck = new bool[9];
                bool[] boxCheck = new bool[9];
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] != '.')
                    {
                        //check same role contains the repetition
                        if (rowCheck[board[i][j] - '1']) return false;
                        else rowCheck[board[i][j] - '1'] = true;
                    }
                    if (board[j][i] != '.')
                    {
                        //check same column contains
                        if (colCheck[board[j][i] - '1']) return false;
                        else colCheck[board[j][i] - '1'] = true;
                    }
                    int m = i / 3 * 3 + j / 3;
                    int n = i % 3 * 3 + j % 3;
                    if (board[m][n] != '.')
                    {
                        //check 
                        if (boxCheck[board[m][n] - '1']) return false;
                        else boxCheck[board[m][n] - '1'] = true;
                    }
                }
            }
            return true;
        }
    }
}
