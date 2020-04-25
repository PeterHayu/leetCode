
using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_100.Tree
{
    public class Diameter_of_Binary_Tree
    {
        int maxDiameter = 0;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            //this is the same as max depth of root.
            //because the longest path ALWAYS go through the root node
            //we just need to find the left max depth and the right max depth
            //And add them
            if (root == null)
                return 0;
            maxDepth(root);
            return maxDiameter;
        }

        //Max depth of leaf V2
        public int maxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            var left = maxDepth(root.left);
            var right = maxDepth(root.right);
            //update the maxDiameter if current root max Diameter is larger
            //note value here is left+right, no need to +1
            maxDiameter = Math.Max(maxDiameter, left + right);
            return Math.Max(left, right) + 1;
        }

    }
}
