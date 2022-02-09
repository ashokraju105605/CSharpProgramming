using System;
using System.Linq;
class LCS
{
    static String X1, Y1;
    public static void main(String[] args)
    {
        X1 = "abcdxyz";
        Y1 = "xyzabcd";
        Console.WriteLine("Jai Shree Ram");
        String X = "OldSite:GeeksforGeeks.org";
        String Y = "NewSite:GeeksQuiz.com";

        int m = X.Length;
        int n = Y.Length;

        Console.WriteLine("Length of Longest Common"
        + " Substring DP is " + LCSubStr(X, Y));

        Console.WriteLine("Length of Longest Common"
        + " Substring Recursion is " + lcsRec(X1.Length, Y1.Length, 0));

        int[,] dp = new int[X1.Length + 1, Y1.Length + 1];
        for (int i = 0; i < dp.GetLength(0); i++)
            for (int j = 0; j < dp.GetLength(1); j++)
                dp[i, j] = -1;
        Console.WriteLine("Length of Longest Common"
        + " Substring Memoized is " + lcsMem(X1.Length, Y1.Length, 0, dp));
    }

    static int LCSubStr(String a, String b)
    {
        int[,] lcs = new int[a.Length + 1, b.Length + 1];
        int result = 0;
        for (int i = 0; i < lcs.GetLength(0); i++)
            for (int j = 0; j < lcs.GetLength(1); j++)
            {
                if (i == 0 || j == 0)
                    lcs[i, j] = 0;
                else if (a[i - 1] == b[j - 1]) // table index is one greater than string indexes due to the base case addition in table.
                {
                    lcs[i, j] = lcs[i - 1, j - 1] + 1;
                    result = Math.Max(result, lcs[i, j]); // needed because lcs[m,n] can be zero and max substring can be found anywhere.
                }
                else
                {
                    lcs[i, j] = 0; // last chars not same , so substrings ending with these indexes cannot be same.
                }
            }

        return result;
    }
    static int lcsRec(int i, int j, int count)
    {

        if (i == 0 || j == 0)
        {
            return count;
        }

        if (X1[i - 1] == Y1[j - 1])
        {
            count = lcsRec(i - 1, j - 1, count + 1);
        }
        // you still don't know the lower part solutions in top down, so need to recurse
        count = Math.Max(count, Math.Max(lcsRec(i, j - 1, 0),
                                         lcsRec(i - 1, j, 0)));
        return count;
    }

    // not working to give correct output.
    static int lcsMem(int i, int j, int count, int[,] dp)
    {
        if (dp[i, j] != -1)
            return dp[i, j];

        if (i == 0 || j == 0)
        {
            dp[i, j] = count;
            return dp[i, j]; // otherwise going to index out of bounds in next condition, and also not how Rec implemented.
        }

        if (X1[i - 1] == Y1[j - 1])
        {
            dp[i, j] = lcsMem(i - 1, j - 1, count + 1, dp);
        }
        // you still don't know the lower part solutions in top down, so need to recurse
        dp[i, j] = Math.Max(count, Math.Max(lcsMem(i, j - 1, 0, dp),
                                         lcsMem(i - 1, j, 0, dp)));
        return dp[i, j];
    }
}