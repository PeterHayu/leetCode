using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Tree
{
    public class Binary_Tree_Add_Bracket_Around_Node
    {
        public string Tree2str(TreeNode t)
        {
            if (t == null)
                return "";
            if (t.left == null && t.right == null)
                return t.val + "";
            //if it only have left child, all we have to do is put bracket on the left child and return, we do nothing to the right child(so that there would not be empty bracket)
            if (t.right == null)
                return t.val + "(" + Tree2str(t.left) + ")";

            //putting bracket around each and every node traversed
            //this will put empty bracket if node null
            return t.val + "(" + Tree2str(t.left) + ")(" + Tree2str(t.right) + ")";
        }

        public string tree2str(TreeNode t)
        {
            if (t == null)
                return "";
            string result = t.val + "";
            var left = tree2str(t.left);
            var right = tree2str(t.right);

            if (left == "" && right == "")
                return result;
            if (left == "")
                return result + "()" + right;
            if (right == "")
                return result + "(" + left + ")";
            return result += "(" + left + ")" + "(" + right + ")";
        }
    }
}
