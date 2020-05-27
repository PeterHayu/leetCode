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

       //Subsets : https://leetcode.com/problems/subsets/

public List<List<int>> subsets(int[] nums)
        {
            List<List<int>> list = new List<List<int>>();
            //Array.Sort(nums);
            backtrack(list, new List<int>(), nums, 0);
            return list;
        }

        private void backtrack(List<List<int>> list, List<int> tempList, int[] nums, int start)
        {
            list.Add(new List<int>(tempList));
            for (int i = start; i < nums.Length; i++)
            {
                tempList.Add(nums[i]);
                backtrack(list, tempList, nums, i + 1);
                tempList.RemoveAt(tempList.Count - 1);
            }
        }
        //Subsets II(contains duplicates) : https://leetcode.com/problems/subsets-ii/

public List<List<int>> subsetsWithDup(int[] nums)
        {
            List<List<int>> list = new List<List<int>>();
            Array.Sort(nums);
            Backtrack(list, new List<int>(), nums, 0);
            return list;
        }

        private void Backtrack(List<List<int>> list, List<int> tempList, int[] nums, int start)
        {
            list.Add(new List<int>(tempList));
            for (int i = start; i < nums.Length; i++)
            {
                if (i > start && nums[i] == nums[i - 1]) continue; // skip duplicates
                tempList.Add(nums[i]);
                Backtrack(list, tempList, nums, i + 1);
                tempList.RemoveAt(tempList.Count - 1);
            }
        }
        
        //Permutations : https://leetcode.com/problems/permutations/

public List<List<int>> permute(int[] nums)
        {
            List<List<int>> list = new List<List<int>>();
            // Arrays.sort(nums); // not necessary
            Backtrack(list, new List<int>(), nums);
            return list;
        }

        private void Backtrack(List<List<int>> list, List<int> tempList, int[] nums)
        {
            if (tempList.Count == nums.Length)
            {
                list.Add(new List<int>(tempList));
            }
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (tempList.Contains(nums[i])) continue; // element already exists, skip
                    tempList.Add(nums[i]);
                    Backtrack(list, tempList, nums);
                    tempList.RemoveAt(tempList.Count - 1);
                }
            }
        }
        //Permutations II(contains duplicates) : https://leetcode.com/problems/permutations-ii/

public List<List<int>> permuteUnique(int[] nums)
        {
            List<List<int>> list = new List<List<int>>();
            Array.Sort(nums);
            Backtrack(list, new List<int>(), nums, new bool[nums.Length]);
            return list;
        }

        private void Backtrack(List<List<int>> list, List<int> tempList, int[] nums, bool[] used)
        {
            if (tempList.Count == nums.Length)
            {
                list.Add(new List<int>(tempList));
            }
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (used[i] || i > 0 && nums[i] == nums[i - 1] && !used[i - 1]) continue;
                    used[i] = true;
                    tempList.Add(nums[i]);
                    Backtrack(list, tempList, nums, used);
                    used[i] = false;
                    tempList.RemoveAt(tempList.Count - 1);
                }
            }
        }
       
        //Combination Sum : https://leetcode.com/problems/combination-sum/

public List<List<int>> combinationSum(int[] nums, int target)
        {
            List<List<int>> list = new List<List<int>>();
            Array.Sort(nums);
            Backtrack(list, new List<int>(), nums, target, 0);
            return list;
        }

        private void Backtrack(List<List<int>> list, List<int> tempList, int[] nums, int remain, int start)
        {
            if (remain < 0) return;
            else if (remain == 0) list.Add(new List<int>(tempList));
            else
            {
                for (int i = start; i < nums.Length; i++)
                {
                    tempList.Add(nums[i]);
                    Backtrack(list, tempList, nums, remain - nums[i], i); // not i + 1 because we can reuse same elements
                    tempList.RemoveAt(tempList.Count - 1);
                }
            }
        }
        //Combination Sum II(can't reuse same element) : https://leetcode.com/problems/combination-sum-ii/

public List<List<int>> combinationSum2(int[] nums, int target)
        {
            List<List<int>> list = new List<List<int>>();
            Array.Sort(nums);
            Backtrack2(list, new List<int>(), nums, target, 0);
            return list;

        }

        private void Backtrack2(List<List<int>> list, List<int> tempList, int[] nums, int remain, int start)
        {
            if (remain < 0) return;
            else if (remain == 0) list.Add(new List<int>(tempList));
            else
            {
                for (int i = start; i < nums.Length; i++)
                {
                    if (i > start && nums[i] == nums[i - 1]) continue; // skip duplicates
                    tempList.Add(nums[i]);
                    Backtrack2(list, tempList, nums, remain - nums[i], i + 1);
                    tempList.RemoveAt(tempList.Count - 1);
                }
            }
        }
       
        //Palindrome Partitioning : https://leetcode.com/problems/palindrome-partitioning/

public List<List<String>> partition(String s)
        {
            List<List<string>> list = new List<List<string>>();
            backtrack(list, new List<string>(), s, 0);
            return list;
        }

        public void backtrack(List<List<string>> list, List<string> tempList, string s, int start)
        {
            if (start == s.Length)
                list.Add(new List<string>(tempList));
            else
            {
                for (int i = start; i < s.Length; i++)
                {
                    if (isPalindrome(s, start, i))
                    {
                        tempList.Add(s.Substring(start, i + 1));
                        backtrack(list, tempList, s, i + 1);
                        tempList.RemoveAt(tempList.Count - 1);
                    }
                }
            }
        }

        public bool isPalindrome(String s, int low, int high)
        {
            while (low < high)
                if (s[low++] != s[high--]) return false;
            return true;
        }
    }
}
