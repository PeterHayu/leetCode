using Easy.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Tree
{
    class Convert_Sorted_Array_to_Binary_Search_Tree
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            //this is to build a BST tree from list
            //root is always the medium of the nums
            //BTS: left child is the smallest numbers, while right child are the larger ones
            if (nums.Length < 1)
                return null;

            return BuildNewTree(nums, 0, nums.Length - 1); ;
        }

        public TreeNode BuildNewTree(int[] nums, int low, int high)
        {
            //helper method to pass in more value to determine midpoint
            if (low > high)
                return null;
            var mid = (high - low) / 2 + low;
            //tree creation
            var node = new TreeNode(nums[mid]);
            node.left = BuildNewTree(nums, low, mid - 1);
            node.right = BuildNewTree(nums, mid + 1, high);
            return node;
        }
    }
}
