using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Tree
{
    public class IsUnivalTree
    {
        public bool issUnivalTree(TreeNode root)
        {
            if (root == null)
                return false;
            return Traverse(root, true, root.val);
        }

        private bool Traverse(TreeNode root, bool isUnival, int target)
        {
            if (root == null)
                return true;
            if (root.val != target)
                return false;
            return Traverse(root.left, isUnival, target) && Traverse(root.right, isUnival, target);
        }
    }
}
