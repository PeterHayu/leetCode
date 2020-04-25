using System;


namespace Easy.Top_Interviewed.Tree
{
    public class Convert_BST_to_Greater_Tree
    {
        int sum = 0;
        public TreeNode ConvertBST(TreeNode root)
        {
            Traverse(root);
            return root;
        }

        public void Traverse(TreeNode root)
        {
            if (root == null) return;

            //reverse in order traversal
            Traverse(root.right);
            root.val += sum;
            sum = root.val;
            Traverse(root.left);
        }
    }
}
