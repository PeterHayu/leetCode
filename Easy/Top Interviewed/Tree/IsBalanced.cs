
using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Tree
{
    public class IsTreeBalanced
    {
        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
                return true;
            var left = Height(root.left);
            var right = Height(root.right);
            return Math.Abs(left - right) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
        }

        private int Height(TreeNode root)
        {
            if (root == null)
                return 0;
            return Math.Max(Height(root.left), Height(root.right)) + 1;
        }

        public bool IsBalanced2(TreeNode root)
        {
            return CheckBalanced(root) != -1;
        }

        private int CheckBalanced(TreeNode root)
        {
            if (root == null)
                return 0;
            int left = CheckBalanced(root.left);
            if (left == -1) return -1;
            int right = CheckBalanced(root.right);
            if (right == -1) return -1;

            if (Math.Abs(left - right) > 1) return -1;

            return Math.Max(left, right) + 1;
        }
    }
}
