using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Tree
{
    class Flatten_Binary_Tree_to_Linked_List
    {
        public void Flatten(TreeNode root)
        {
            Traverse(root, null);
        }

        private TreeNode Traverse(TreeNode root, TreeNode prev)
        {
            if (root == null)
                return prev;
            prev = Traverse(root.right, prev);
            prev = Traverse(root.left, prev);
            root.right = prev;
            root.left = null;
            //prev=root;
            return root;
        }
    }
}
