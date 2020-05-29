using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medium.Tree
{
    public class Validate_BST
    {
        long pre = Int64.MinValue;
        public bool IsValidBST(TreeNode root)
        {
            return Traverse(root);
        }

        private bool Traverse(TreeNode root)
        {
            if (root == null)
                return true;
            var left = Traverse(root.left);
            if (!left) return false;
            if (pre != Int64.MinValue && root.val <= pre)
            { return false; }
            pre = root.val;
            return Traverse(root.right);
        }


        public bool IsValidBST2(TreeNode root)
        {
            if (root == null)
                return true;
            var stack = new Stack<TreeNode>();
            var curr = root;
            var pre = Int64.MinValue;

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
                if (curr.val <= pre)
                {
                    return false;
                }
                pre = curr.val;
                curr = curr.right;
            }

            return true;
        }
    }
}
