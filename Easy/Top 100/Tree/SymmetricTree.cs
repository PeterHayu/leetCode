using Easy.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_100.Tree
{
    public static class SymmetricTree
    {
        public static bool SymmetricTreeRecursive(TreeNode root)
        {
            return isMirror(root, root);
        }

        //we use queue to micmic the going through of a tree using BFS
        public static bool SymmetricTreeNonRecursive(TreeNode root)
        {
        if(root ==null)
            return true;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        q.Enqueue(root);
        while(q.Count!=0){
        var t1 = q.Dequeue();
        var t2 = q.Dequeue();
            if(t1 ==null && t2==null)
                continue;
            if(t1==null || t2==null)
                return false;
            if(t1.val !=t2.val)
                return false;
            if(t1.val == t2.val){
                //add the paired tree node here.
                q.Enqueue(t1.right);
                q.Enqueue(t2.left);
                q.Enqueue(t2.right);
                q.Enqueue(t1.left);
            }
}
        return true;
    }

        private static bool isMirror(TreeNode r1, TreeNode r2)
        {
            if (r1 == null && r2 == null)
                return true;
            if (r1 == null | r2 == null)
                return false;
            return (r1.val == r2.val) && isMirror(r1.left, r2.right) && isMirror(r1.right, r2.left);
        }
    }
}
