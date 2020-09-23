using System;
using System.Collections.Generic;

namespace Hard
{
    public class Word_Search_2
    {
        public class Trie
        {
            public Trie[] children = new Trie[26];
            public String wrd; //instead of boolean isEnd as we need to return list<String> it should be a word
        }
        public List<String> FindWords(char[][] board, String[] words)
        {
            var res = new List<String>();
            Trie root = buildTrie(words); //build trie of words and search in matrix
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    dfs(board, i, j, root, res);
                }
            }
            return res;
        }

        public void dfs(char[][] board, int i, int j, Trie p, List<String> res)
        {
            if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length || board[i][j] == '#' || p.children[board[i][j] - 'a'] == null)
                return; //if i or j is out of bound or if char(board[i][j]) is already visited('#') or its child is null rerturn
            char c = board[i][j]; //storing char of board[i][j] to c to restore after backtracking
            p = p.children[c - 'a'];//if the char is present in child i.e. not null then move root to char
            if (p.wrd != null)
            {   // check if word is found i.e. reached at end of the word 
                res.Add(p.wrd); //add it to list
                p.wrd = null;     // setting word as null to avoid reuse of word and to avoid adding again to list
            }
            board[i][j] = '#'; //change char to # to avoid revisiting
            dfs(board, i - 1, j, p, res); //check in all directions
            dfs(board, i + 1, j, p, res);
            dfs(board, i, j - 1, p, res);
            dfs(board, i, j + 1, p, res);
            board[i][j] = c; //restoring char after backtracking from # to char
        }
        private Trie buildTrie(String[] words)
        {
            Trie root = new Trie();
            foreach (var word in words)
            {
                Trie temp = root;
                foreach (char c in word)
                {
                    if (temp.children[c - 'a'] == null)
                    {//if char is not in the trie
                        temp.children[c - 'a'] = new Trie();//create new node for that char
                    }
                    temp = temp.children[c - 'a'];//move node to next char
                }
                temp.wrd = word;//update temp.wrd to current word that can be used later
            }
            return root;
        }
    }
}
