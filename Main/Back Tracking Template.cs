using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    class Back_Tracking_Template
    {
        public IList<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            Backtrack(result, "", 0, 0, n);
            return result;
        }

        private void Backtrack(List<string> result, string path, int left, int right, int max)
        {
            //negative condition to return
            if (left > max) return;
            if (right > left) return;
            if (path.Length == max * 2)
            {
                //positive condition to add to result and return
                result.Add(path);
                return;
            }

            //pre-order traversal to add
            path += "(";
            Backtrack(result, path, left + 1, right, max);
            //post-order traversal to remove
            path = path.Remove(path.Length - 1);

            //pre-order traversal to add
            path += ")";
            Backtrack(result, path, left, right + 1, max);
            //post-order traversal to remove
            path = path.Remove(path.Length - 1);
        }
    }
}
