using Easy.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_100.Tree
{
    public static class MinDepthOfLeaf
    {
        //This is recursive and DFS, not optimal because in extrame case of linked list it will go all the way
        public static int MinDepthRecursive(TreeNode root)
        {
            if (root == null)
                return 0;
            if (root.left == null || root.right == null)
                return root.left == null ? MinDepthRecursive(root.right) + 1 : MinDepthRecursive(root.left) + 1;
            return Math.Min(MinDepthRecursive(root.left), MinDepthRecursive(root.right)) + 1;
        }

        //This is non recursive BFS
        public static int MinDepthBFSMyAnswer(TreeNode root)
        {
            if (root == null)
                return 0;
            var q = new Queue<TreeNode>();
            var cur = new Queue<int>();
            q.Enqueue(root);
            cur.Enqueue(1);
            int depth = 0;
            while (q.Count != 0)
            {
                var t = q.Dequeue();
                var currentDepth = cur.Dequeue();
                depth = currentDepth;

                if (t.left == null && t.right == null)
                    return depth;
                if (t.left == null)
                {
                    q.Enqueue(t.right);
                    cur.Enqueue(currentDepth + 1);
                }
                else if (t.right == null)
                {
                    q.Enqueue(t.left);
                    cur.Enqueue(currentDepth + 1);
                }
                else
                {
                    q.Enqueue(t.left);
                    cur.Enqueue(currentDepth + 1);
                    q.Enqueue(t.right);
                    cur.Enqueue(currentDepth + 1);
                }         
            }
            return depth;
        }

        public static int MinDepthImproved(TreeNode root)
        {
            if (root == null)
                return 0;
            var q = new Queue<TreeNode>();
            var cur = new Queue<int>();
            q.Enqueue(root);
            cur.Enqueue(1);
            int depth = 0;
            while (q.Count != 0)
            {
                var t = q.Dequeue();
                var currentDepth = cur.Dequeue();
                depth = currentDepth;

                if (t.left == null && t.right == null)
                    return depth;
                if (t.left != null)
                {
                    q.Enqueue(t.left);
                    cur.Enqueue(currentDepth + 1);
                }
                if (t.right != null)
                {
                    q.Enqueue(t.right);
                    cur.Enqueue(currentDepth + 1);
                }
            }
            return depth;
        }

        public static int MinDepthAnswer(TreeNode root)
        {
            if (root == null)
                return 0;
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            int depth = 1;
            while (q.Count != 0)
            {
                var size = q.Count;
                //instead of using another queue to track the current level,
                //we can also use a for loop to ensure we finish the current level before moving to another level
                for (int i = 0; i < size; i++)
                {
                    var t = q.Dequeue();
                    if (t.left == null && t.right == null)
                        return depth;
                    if (t.left != null)
                    {
                        q.Enqueue(t.left);
                    }
                    if (t.right != null)
                    {
                        q.Enqueue(t.right);
                    }
                }
                depth++;
            }
            return depth;
        }
    }
}
