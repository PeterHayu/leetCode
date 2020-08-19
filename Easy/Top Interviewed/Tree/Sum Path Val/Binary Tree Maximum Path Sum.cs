using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Tree.Sum_Path_Val
{
    class Binary_Tree_Maximum_Path_Sum
    {
        //global variable to store the result
        //this is Post Order Traversal, goes from bottom up to the top
        //for the result, we add all positive values of left subtree,right subtree and root and find the maximum
        //for the recursive return call, we return only the larger sum path from bottom up, either the left or the right, because from a root you can only choose one direction to sum
        private int result = Int32.MinValue;

        public int MaxPathSum(TreeNode root)
        {
            Traverse(root);
            return result;
        }

        private int Traverse(TreeNode root)
        {
            if (root == null)
                return 0;
            //only sum up the positive 
            var left = Math.Max(0, Traverse(root.left));
            var right = Math.Max(0, Traverse(root.right));
            //compare the sum of all nodes on this path to the stored maximum sum
            result = Math.Max(result, left + right + root.val);
            //Console.WriteLine(result + " "+ (int)(left+right+root.val));
            //to make sure its going through a path not a branch. you have to choose either left or right, so we choose the max one
            //except for the root, because its the first layer of recursion
            return Math.Max(left, right) + root.val;
        }

    }
}
