using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public static class WordLadder
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            //put all words into set to obtain constant retrival time
            var wordSet = new HashSet<string>(wordList);
            //edge case
            if (!wordSet.Contains(endWord))
                return 0;


            //begin BFS
            var q = new Queue<string>();
            q.Enqueue(beginWord);
            //result to indicates the length/level of the tree traversed
            //initial level set to 1
            var result = 1;

            while (q.Count != 0)
            {
                var lv = q.Count;
                for (int i = 0; i < lv; i++)
                {
                    var currentWord = q.Dequeue();
                    //loop through each char of current word 
                    //update the all possible combination for this char in alphabet
                    for (int j = 0; j < currentWord.Length; j++)
                    {
                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            if (currentWord[j] == c)
                                continue;

                            //note: dont use string.Replace cause it will replace ALL instance of the char.     
                            //update the char at particular location and return new string                     
                            var temp = new StringBuilder(currentWord);
                            temp[j] = c;
                            var newString = temp.ToString();
                            //if it matches the end result, we know the end result is in the next level then current level
                            if (newString == endWord)
                                return result + 1;

                            //if wordSet Contains the updated word
                            //we added it to the tree/traverse
                            //and go to the next level
                            if (wordSet.Contains(newString))
                            {
                                q.Enqueue(newString);
                                //to avoid duplicate
                                wordSet.Remove(newString);
                            }
                        }
                    }

                }
                result++;
            }

            //no result found
            return 0;
        }
    }
}
