using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Tree
{
    public class Binary_Tree_Sum
    {
        public int Sum(TreeNode root) {
            if (root == null)
                return 0;
            return root.val + Sum(root.left) + Sum(root.right);
        }
    }
}
