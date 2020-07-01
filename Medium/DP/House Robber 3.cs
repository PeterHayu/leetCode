using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.DP
{
    class House_Robber_3
    {
        private HashSet<TreeNode> map = new HashSet<TreeNode>();

        public int Rob(TreeNode root)
        {
            if (root == null)
                return 0;
            if (map.Contains(root))
                return root.val;


            int val = 0;

            if (root.left != null)
            {
                val += Rob(root.left.left) + Rob(root.left.right);
            }

            if (root.right != null)
            {
                val += Rob(root.right.left) + Rob(root.right.right);
            }

            //either rob the current root, or Rob its children
            return Math.Max(val + root.val, Rob(root.left) + Rob(root.right));
        }

    }
}
