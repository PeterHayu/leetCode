using System;
using System.Collections.Generic;

namespace Easy.Top_Interviewed.Tree
{
    public class Find_minimum_abs_difference_in_BST
    {
        private int currentDiff;
        private int current;
        private int currentMinDiff;
        private bool first;


        public int GetMinimumDifference(TreeNode root)
        {
            if (root == null) return 0;
            first = true;
            currentDiff = 0;
            current = 0;
            currentMinDiff = Int32.MaxValue;
            Traverse(root);
            return currentMinDiff;
        }

        private void Traverse(TreeNode root)
        {
            if (root == null)
                return;

            Traverse(root.left);
            if (!first)
            {
                //can be simplified:  currentMinDiff = Math.Min(root.val - current,currentMinDiff);
                currentDiff = root.val - current;
                if (currentDiff < currentMinDiff)
                    currentMinDiff = currentDiff;
            }
            else
                first = false;
            if (currentMinDiff == 0)
                return;
            current = root.val;
            Traverse(root.right);
        }
    }
}
