using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Tree
{
    class Construct_Binary_Tree_from_Preorder_and_Inorder_Traversal
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            return Build(preorder, inorder);
        }

        private TreeNode Build(int[] preorder, int[] inorder)
        {
            if (preorder.Length <= 0 | inorder.Length <= 0)
                return null;

            var result = new TreeNode(preorder[0]);
            int rootIndex = 0;

            for (int i = 0; i < inorder.Length; i++)
            {
                if (inorder[i] == result.val)
                {
                    rootIndex = i;
                    break;
                }
            }

            result.left = Build(preorder[1..^0], inorder[0..(rootIndex)]);
            result.right = Build(preorder[(rootIndex + 1)..^0], inorder[(rootIndex + 1)..^0]);

            return result;
        }
    }
}
