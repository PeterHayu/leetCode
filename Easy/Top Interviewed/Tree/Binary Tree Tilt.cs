using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Tree
{
    public class Binary_Tree_Tilt
    {
        int tilt = 0;
        public int FindTilt(TreeNode root)
        {
            if (root == null)
                return 0;

            Sum(root);
            return tilt;
        }

        private int Sum(TreeNode root)
        {
            if (root == null)
                return 0;

            int left = Sum(root.left);
            int right = Sum(root.right);
            //exclude this line, its the addtion of all node algorithm
            tilt += Math.Abs(left - right);

            return root.val + left + right;
        }
    }
}
