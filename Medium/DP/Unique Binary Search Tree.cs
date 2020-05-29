using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.DP
{
    public static class Unique_Binary_Search_Tree
    {
        public static int NumTrees(int n)
        {
            if (n < 1)
                return -1;
            //because BST always has left sub tree values smaller than root
            //and root values smaller than right subtree
            //total number of BST for [1..n] is
            //sum of total number of BST for root being 1, 2, 3....n
            //which equals to #(left sub tree) * # (right sub tree) for root being 1,2...n
            var dp = new int[n + 1];
            //[1,2...i....n]
            //dp[i]=dp[n-i] * dp[i-1]
            //ans[n] = dp[1]+dp[2]+....dp[n]
            //notice ans[1] = dp[1], ans[2] = dp[1]+dp[2]
            //we can replace ans with dp, storing the sum value
            //ans[i] = for([1..i]) dp[i]+=dp[i-1];
            dp[0] = 1;
            dp[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    dp[i] += dp[i - j] * dp[j - 1];
                }
            }
            return dp[n];
        }
    }
}
