using System;
namespace Medium.String
{
    public class Expressive_Words
    {
        public static int ExpressiveWords(string S, string[] words)
        {
            var result = 0;
            foreach (var w in words)
            {
                if (Check(S, w))
                    result++;
            }
            return result;
        }

        private static bool Check(string S, string W)
        {
            int n = S.Length;
            int m = W.Length;
            int i = 0;
            int j = 0;
            for (int i2 = 0, j2 = 0; i < n && j < m; i = i2, j = j2)
            {
                if (S[i] != W[j])
                    return false;
                while (i2 < n && S[i2] == S[i]) i2++;
                while (j2 < m && W[j2] == W[j]) j2++;
                if (i2 - i != j2 - j && i2 - i < Math.Max(3, j2 - j)) return false;
            }
            return i == n && j == m;
        }
    }
}
