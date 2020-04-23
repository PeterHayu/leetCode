using System;
using System.Collections.Generic;
using Easy.Class;

namespace Easy.Top_Interviewed.Tree
{
    public class Find_Most_Frequent_Element_in_BST
    {
        private int currentMaxCount;
        private int current;
        private int currentCount;

        public int[] FindMode(TreeNode root)
        {
            if (root == null) return new int[0];
            currentMaxCount = Int32.MinValue;
            currentCount = 0;
            current = root.val;

            var list = new List<int>();

            Traverse(root, list);
            return list.ToArray();
        }

        public void Traverse(TreeNode root, List<int> list)
        {
            if (root == null)
                return;
            Traverse(root.left, list);
            if (root.val == current)
                currentCount++;
            else
                currentCount = 1;

            if (currentCount > currentMaxCount)
            {
                currentMaxCount = currentCount;
                list.Clear();
                list.Add(root.val);
            }
            //trap, either write this statement before, or use else if. Else will always cause duplicate 
            else if (currentCount == currentMaxCount)
            {
                list.Add(root.val);
            }


            //trap: need to update current root value 
            current = root.val;

            Traverse(root.right, list);
        }
    }
}
