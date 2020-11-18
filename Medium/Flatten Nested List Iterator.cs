using System;
using System.Collections.Generic;
using Medium.Class;

namespace Medium
{
    public class Flatten_Nested_List_Iterator
    {
        public class NestedIterator
        {

            private Queue<int> q = new Queue<int>();

            public NestedIterator(IList<NestedInteger> nestedList)
            {
                flatten(nestedList);
            }

            public bool HasNext()
            {
                return q.Count != 0;
            }

            public int Next()
            {
                return q.Dequeue();
            }

            private void flatten(IList<NestedInteger> nestedList)
            {
                foreach (var l in nestedList)
                {
                    if (l.IsInteger())
                    {
                        q.Enqueue(l.GetInteger());
                    }
                    else
                        flatten(l.GetList());
                }
            }
        }
    }
}
