using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Tree
{
    public class Second_Minimum_Node_in_Binary_Tree
    {
        public int FindSecondMinimumValue(TreeNode root)
        {
            //base case    
            if (root == null)
            {
                return -1;
            }
            // if reaches a leaf, return an indicator like -1
            if (root.left == null && root.right == null)
            {
                return -1;
            }

            //usually the second min is the min of the two
            int left = root.left.val;
            int right = root.right.val;

            //However one possibility is that through the smallest route there exist a smaller element
            // Traverse only through the smallest route
            if (left == root.val)
            {
                left = FindSecondMinimumValue(root.left);
            }
            if (right == root.val)
            {
                right = FindSecondMinimumValue(root.right);
            }

            if (left != -1 && right != -1)
            {
                //this is the final comparison between the second smallest in smallest route, and the second smallest in the left and right subtree
                return Math.Min(left, right);
            }
            else
            {
                // this is to retrieve the second smallest in smallest route
                return Math.Max(left, right);
            }
        }
    }
}
