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
                //         if(t!=null){
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
                //}              
            }
            return depth;
        }
    }
}
