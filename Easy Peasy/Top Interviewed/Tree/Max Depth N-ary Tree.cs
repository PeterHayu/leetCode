using System;
using System.Collections.Generic;


namespace Easy.Top_Interviewed.Tree
{
    public class Max_Depth_N_ary_Tree
    {
        public int MaxDepth(Node root)
        {
            if (root == null)
                return 0;

            int max = Int32.MinValue;
            int temp = 0;
            foreach (var child in root.children)
            {
                temp = Math.Max(MaxDepth(child), max);
                if (temp > max)
                    max = temp;
            }
            return Math.Max(max, temp) + 1;
        }

        public int MaxDepthAns(Node root)
        {
            if (root == null)
                return 0;

            int max = 0;
            foreach (var child in root.children)
            {
                max = Math.Max(MaxDepthAns(child), max);
            }
            return max + 1;
        }

    }
}
