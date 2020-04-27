using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Tree
{
    public class Subtree_of_Another_Tree
    {
        private bool result;
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            result = false;
            Traverse(s, t);
            return result;
        }

        private void Traverse(TreeNode s, TreeNode t)
        {
            if (s == null)
                return;
            if (result)
                return;
            result = new IsSameTree().isSameTree(s, t);
            Traverse(s.left, t);
            Traverse(s.right, t);
        }

        public bool traverse(TreeNode s, TreeNode t)
        {
            return s != null && (new IsSameTree().isSameTree(s, t) || traverse(s.left, t) || traverse(s.right, t));
        }
    }
}
