using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_100.Tree
{
    public class Merge_Two_Binary_Trees
    {
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
                return null;
            if (t1 == null)
                return t2;
            if (t2 == null)
                return t1;
            else if (t1 != null && t2 != null)
                t1.val += t2.val;


            t1.left = MergeTrees(t1.left, t2.left);
            t1.right = MergeTrees(t1.right, t2.right);

            return t1;

        }
    }
}
