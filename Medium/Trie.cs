using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public class Trie
    {

            private TrieNode t;

            /** Initialize your data structure here. */
            public Trie()
            {
                t = new TrieNode();
            }

            /** Inserts a word into the trie. */
            public void Insert(string word)
            {
                var temp = t;
                foreach (var c in word)
                {
                    if (!temp.ContainsKey(c))
                    {
                        //create a new node with char c and link to the previous head
                        temp.Put(c, new TrieNode());
                    }
                    //move to next node
                    temp = temp.Get(c);
                }
                temp.SetEnd();
            }

            /** Returns if the word is in the trie. */
            public bool Search(string word)
            {
                var end = GetEnd(word);
                return (end != null) && end.IsEnd();
            }

            /** Returns if there is any word in the trie that starts with the given prefix. */
            public bool StartsWith(string prefix)
            {
                var end = GetEnd(prefix);
                return end != null;
            }

            private TrieNode GetEnd(string word)
            {
                var temp = t;
                foreach (var c in word)
                {
                    if (temp.ContainsKey(c))
                    {
                        temp = temp.Get(c);
                    }
                    else
                        return null;
                }
                //note: here returns the end node of the char list
                return temp;
            }

            class TrieNode
            {

                // R links to node children
                private TrieNode[] links;

                private int R = 26;

                private bool isEnd;

                public TrieNode()
                {
                    links = new TrieNode[R];
                }

                public bool ContainsKey(char ch)
                {
                    return links[ch - 'a'] != null;
                }
                public TrieNode Get(char ch)
                {
                    return links[ch - 'a'];
                }
                public void Put(char ch, TrieNode node)
                {
                    links[ch - 'a'] = node;
                }
                public void SetEnd()
                {
                    isEnd = true;
                }
                public bool IsEnd()
                {
                    return isEnd;
                }
            }

        }
    }

