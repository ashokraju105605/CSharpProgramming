using System;
using System.Linq;
class LCS
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        String X = "OldSite:GeeksforGeeks.org";
        String Y = "NewSite:GeeksQuiz.com";

        int m = X.Length;
        int n = Y.Length;

        Console.Write("Length of Longest Common"
        + " Substring is " + LCSubStr(X, Y));
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
}