
using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_100.Tree
{
    public static class MaxDepthOfLeaf
    {
        //Maximum Depth of Binary Tree
        //this need to go down to depth, so should be DFS and can be written recursively
        public static int MaxDepthRecursive(TreeNode root) {
            if (root == null)
                return 0;
            return Math.Max(MaxDepthRecursive(root.left), MaxDepthRecursive(root.right)) + 1;
        }

        //written with stack and iterative DFS
        public static int MaxDepthIterative(TreeNode root) {
            if (root == null)
                return 0;
            var s = new Stack<TreeNode>();
            var level = new Stack<int>();
            //initiate first value
            s.Push(root);
            level.Push(1);
            int max = 0;
            while (s.Count != 0) {
                var t = s.Pop();
                var c = level.Pop();
                max = Math.Max(c, max);
                //first push right, so left get pop and checked first
                if (t.right != null) {
                    s.Push(t.right);
                    level.Push(c + 1);
                }
                //then push left, so right get pop and checked secod
                if (t.left != null)
                {
                    s.Push(t.left);
                    level.Push(c + 1);
                }
            }
            return max;
        }
    }
}
