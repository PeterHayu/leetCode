
using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_100.Tree
{
    public static class InvertTree
    {
        public static TreeNode InvertTreeBFS(TreeNode root)
        {
            if (root == null)
                return null;
            var q = new Queue<TreeNode>();

            q.Enqueue(root);

            while (q.Count != 0)
            {
                //traversing tree
                var t = q.Dequeue();

                if (t.left != null)
                    q.Enqueue(t.left);
                if (t.right != null)
                    q.Enqueue(t.right);

                //reverse order 
                var temp = t.left;
                t.left = t.right;
                t.right = temp;
            }
            return root;
        }

        public static TreeNode InvertTreeRecursive(TreeNode root)
        {
            if (root == null)
                return null;

            var temp = InvertTreeRecursive(root.left);
            root.left = InvertTreeRecursive(root.right);
            root.right = temp;
            return root;
        }
    }
}
