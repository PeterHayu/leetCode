using Easy.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Tree
{
    class IsSameTree
    {
        public bool isSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            if (p == null || q == null)
                return false;
            if (p.val != q.val)
                return false;
            //this is wrong - if two node equal we need to continue not return true
            /*      else
                       return true; */
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
    }
}
