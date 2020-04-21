using Easy.Class;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Tree
{
    public class Binary_Tree_Path
    {
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            var list = new List<string>();
            Traverse(root, "", list);
            return list;
        }

        private void Traverse(TreeNode root, string path, IList<string> l)
        {
            if (root == null)
                return;
            if (root.left == null && root.right == null)
                l.Add(path + root.val);
            Traverse(root.left, path + root.val + "->", l);
            Traverse(root.right, path + root.val + "->", l);
        }
    }
}
