using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Back_Tracking
{
    public static class Word_Search
    {
        public static bool Exist(char[][] board, string word)
        {
            if (board.Length < 1 && board[0].Length < 1)
                return false;
            //for each of the board
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    //if we find the starting element
                    if (board[i][j] == word[0])
                        if (Backtrack(board, word, i, j, 0))
                            return true;
                }
            }
            return false;
        }

        private static bool Backtrack(char[][] board, string word, int i, int j, int start)
        {
            //finish searching all words
            if (start == word.Length)
                return true;
            //out of board
            if (i < 0 | j < 0 | i == board.Length | j == board[0].Length)
                return false;
            //not found in the following path
            if (word[start] != board[i][j])
                return false;
  
            //back tracking
            var temp = board[i][j];
            board[i][j] = ' ';
            //need lot of memory, so use || instead of |
            bool result = Backtrack(board, word, i + 1, j, start + 1) ||
                          Backtrack(board, word, i, j + 1, start + 1) ||
                          Backtrack(board, word, i - 1, j, start + 1) ||
                          Backtrack(board, word, i, j - 1, start + 1);
            //backtracking
            board[i][j] = temp;
            return result;
        }
    }
}
