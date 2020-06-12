using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Tree
{
    public class BST_Inorder_Traversal_Kth_smallest_element
    {
        public int KthSmallest(TreeNode root, int k)
        {
            var q = new Stack<TreeNode>();
            while (true)
            {
                while (root != null)
                {
                    q.Push(root);
                    root = root.left;
                }
                root = q.Pop();
                k--;
                if (k == 0)
                    return root.val;
                root = root.right;
            }
        }
    }
}
