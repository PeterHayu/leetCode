using Easy;
using Easy.Top_100.Tree;
using System;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SymmetricTree.SymmetricTreeRecursive(new TreeNode([1,2,2,3,4,4,3])));
        }
    }
}
