using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public static class Generate_Parentheses
    {
        public static IList<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            Backtrack(result, "", 0, 0, n);
            return result;
        }

        private static void Backtrack(List<string> result, string path, int left, int right, int max)
        {

            if (left > max || right > max) return;
            if (right > left) return;
            if (left == max && right == max)
            {
                result.Add(path);
                return;
            }

            //not finishing adding till n bracket
            path += "(";
            Backtrack(result, path, left + 1, right, max);
            path = path.Remove(path.Length - 1);


            path += ")";
            Backtrack(result, path, left, right + 1, max);
            path = path.Remove(path.Length - 1);
        }
    }
}
