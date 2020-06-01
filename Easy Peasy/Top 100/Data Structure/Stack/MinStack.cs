using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_100
{
    public class MinStack
    {

        private Stack<int> s;
        private int min;

        /** initialize your data structure here. */
        public MinStack()
        {
            s = new Stack<int>();
            min = Int32.MaxValue;
        }

        public void Push(int x)
        {
            if (x <= min)
            {
                s.Push(min);
                min = x;
            }
            s.Push(x);
        }

        public void Pop()
        {
            var remove = s.Pop();
            if ((int)remove == min)
            {
                min = (int)s.Pop();
            }

        }

        public int Top()
        {
            return (int)s.Peek();
        }

        public int GetMin()
        {
            return min;
        }
    }
}
