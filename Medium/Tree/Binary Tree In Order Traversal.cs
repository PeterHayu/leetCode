using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medium.Tree
{
    public class InOrderTraversal
    {
        //recursive
        public IList<int> InorderTraversal(TreeNode root)
        {
            var l = new List<int>();
            Traverse(root, l);
            return l;
        }

        private void Traverse(TreeNode root, IList<int> l)
        {
            if (root != null)
            {
                Traverse(root.left, l);
                l.Add(root.val);
                Traverse(root.right, l);
            }
        }

        //iterative
        public IList<int> InorderTraversalIterative(TreeNode root)
        {
            var l = new List<int>();
            if (root == null)
                return l;
            var stack = new Stack<TreeNode>();
            var curr = root;

            while (curr != null || stack.Any())
            {
                //go to the left most branch
                while (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.left;
                }
                //pop the last element first
                curr = stack.Pop();
                l.Add(curr.val);
                curr = curr.right;
            }

            return l;

        }

    }
}
