using System;
using System.Collections.Generic;

namespace Hard
{
    //DFS
    public class Serialized_and_Deserialzied_Binary_Tree
    {
   
        public string serialize(TreeNode root)
        {
            var result = "";
            return Traverse(result, root);
        }

        private string Traverse(string result, TreeNode root)
        {
            if (root == null)
                return result + "null" + ",";
            //do sth
            result = result + root.val + ",";
            result = Traverse(result, root.left);
            result = Traverse(result, root.right);
            return result;
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            //build a new tree from array
            var q = new Queue<string>(data.Split(","));
            return BuildTree(q);
        }

        //build tree template
        private TreeNode BuildTree(Queue<string> q)
        {
            if (q.Count > 0)
            {
                var nodeVal = q.Dequeue();
                if (nodeVal == "null")
                    return null;
                var node = new TreeNode(Convert.ToInt32(nodeVal));
                node.left = BuildTree(q);
                node.right = BuildTree(q);
                return node;
            }
            return null;
        }
    }


    //BFS
    public class Codec
    {

        public string serialize(TreeNode root)
        {
            if (root == null)
            {
                return "null";
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            string result = "";
            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    TreeNode current = queue.Dequeue();
                    if (current == null)
                    {
                        result += "null,";
                        continue;
                    }
                    result = result + current.val + ",";
                    queue.Enqueue(current.left);
                    queue.Enqueue(current.right);
                }
            }
            return result;
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(String data)
        {
            var nodesQueue = new Queue<string>(data.Split(","));
            var first = nodesQueue.Dequeue();
            if (first == "null")
            {
                return null;
            }
            TreeNode root = new TreeNode(Convert.ToInt32(first));
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    TreeNode current = queue.Dequeue();
                    string currentVal = nodesQueue.Dequeue();
                    if (currentVal != "null")
                    {
                        current.left = new TreeNode(Convert.ToInt32(currentVal));
                        queue.Enqueue(current.left);
                    }
                    currentVal = nodesQueue.Dequeue();
                    if (currentVal != "null")
                    {
                        current.right = new TreeNode(Convert.ToInt32(currentVal));
                        queue.Enqueue(current.right);
                    }
                }
            }
            return root;
        }
    }


}
