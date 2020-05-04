using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Tree.Path
{
    public class MaxDepthTemplate
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            var left = MaxDepth(root.left);
            var right = MaxDepth(root.right);
            return Math.Max(left, right) + 1;
        }
    }
}
