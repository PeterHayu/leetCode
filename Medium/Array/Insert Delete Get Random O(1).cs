using System;
using System.Collections.Generic;

namespace Medium.Array
{
    public class Insert_Delete_Get_Random_O_1_
    {
        public class RandomizedSet
        {

            //the pairs list records the order it get inserted at index
            public Dictionary<int, int> pairs;
            public List<int> l;
            public Random rand;

            /** Initialize your data structure here. */
            public RandomizedSet()
            {
                pairs = new Dictionary<int, int>();
                l = new List<int>();
                rand = new Random();
            }

            /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
            public bool Insert(int val)
            {
                if (pairs.ContainsKey(val))
                    return false;
                else
                {
                    l.Add(val);
                    pairs[val] = l.Count - 1;
                    return true;
                }
            }

            /** Removes a value from the set. Returns true if the set contained the specified element. */
            public bool Remove(int val)
            {
                if (!pairs.ContainsKey(val))
                    return false;
                else
                {
                    //get the index from dictionary
                    var i = pairs[val];
                    //retrieve the last element tat to be switch
                    var v = l[l.Count - 1];
                    //update the pairs dictionary to store the last element at a new place
                    pairs[v] = i;
                    //switch the new element to the end
                    l[i] = l[l.Count - 1];
                    //do not need this switch step because we are removing the elements here anyways
                    //l[l.Count-1] = val;
                    l.RemoveAt(l.Count - 1);

                    pairs.Remove(val);
                    return true;
                }
            }

            /** Get a random element from the set. */
            public int GetRandom()
            {
                return l[rand.Next(l.Count)];
            }
        }
    }
}
