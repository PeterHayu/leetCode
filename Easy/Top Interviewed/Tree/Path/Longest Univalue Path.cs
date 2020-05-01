using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Tree.Path
{
    public class Longest_Univalue_Path
    {
        int result;
        public int LongestUnivaluePath(TreeNode root)
        {
            result = 0;
            if (root == null)
                return 0;
            MaxDepth(root, root.val);
            return result;
        }

        //same as maxDepth
        //in max depth we add 1 in path regardless 
        //here we only add 1 when the previous root val = current root val
        private int MaxDepth(TreeNode root, int val)
        {
            if (root == null)
                return 0;
            var left = MaxDepth(root.left, root.val);
            var right = MaxDepth(root.right, root.val);

            //the path from node left + the path from node right
            result = Math.Max(result, left + right);

            if (root.val == val)
                return Math.Max(left, right) + 1;
            return 0;
        }
    }
}
