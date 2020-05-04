using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Tree
{
    public class Sum_Root_To_Leaf
    {
        public int SumRootToLeaf(TreeNode root)
        {
            if (root == null)
                return 0;
            return Traverse(root, 0);
        }

        private int Traverse(TreeNode root, int sum)
        {
            if (root == null)
                return 0;
            sum = 2 * sum + root.val;
            //make sure restart summing when reaches path end
            if (root.left == null && root.right == null)
                return sum;
            return Traverse(root.left, sum) + Traverse(root.right, sum);
        }
    }
}
