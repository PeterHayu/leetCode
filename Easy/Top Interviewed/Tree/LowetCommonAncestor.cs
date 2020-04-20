using Easy.Class

namespace Easy.Top_Interviewed.Tree
{
    public class LowetCommonAncestor
    {
        public TreeNode LowestCommonAncestorIterative(TreeNode root, TreeNode p, TreeNode q)
        {

            while (root != null)
            {
                if (p.val < root.val && q.val < root.val)
                {
                    root = root.left;
                }
                else if (p.val > root.val && q.val > root.val)
                {
                    root = root.right;
                }
                else
                    return root;
            }
            return root;
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            //BST can identify side with tree node values
            if (p.val < root.val && q.val < root.val)
                return LowestCommonAncestor(root.left, p, q);
            else if (p.val > root.val && q.val > root.val)
                return LowestCommonAncestor(root.right, p, q);
            else
                return root;
        }

    }
}
