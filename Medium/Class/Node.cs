using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public class Node
    {
            public int val;
            public Node next;
            public Node random;
            public Node left;
            public Node right;

        public Node() { }

        public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
}
