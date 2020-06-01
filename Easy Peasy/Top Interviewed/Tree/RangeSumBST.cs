using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Tree
{
    public class RangeSumBST
    {
        private int sum = 0;
        public int rangeSumBST(TreeNode root, int L, int R)
        {
            if (root == null) return 0;

            rangeSumBST(root.left, L, R);
            if (root.val >= L && root.val <= R)
                sum += root.val;
            rangeSumBST(root.right, L, R);

            return sum;
        }


    }
}
