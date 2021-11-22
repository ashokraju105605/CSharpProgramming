using System;
using System.Linq;

class LCSubSeq
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        String s1 = "AGGTAB";
        String s2 = "GXTXAYB";

        char[] X = s1.ToCharArray();
        char[] Y = s2.ToCharArray();
        int m = X.Length;
        int n = Y.Length;

        Console.WriteLine("Length of LCS is" + " " + lcs(s1, s2));
        Console.Write("Length of LCS is" + " " + lcsRec(X, Y, s1.Length, s2.Length));
    }
    static int lcs(String a, String b)
    {
        int[,] table = new int[a.Length + 1, b.Length + 1];
        for (int i = 0; i <= a.Length; i++)
            for (int j = 0; j <= b.Length; j++)
            {
                if (i == 0 || j == 0)
                {
                    table[i, j] = 0;
                }
                else if (a[i - 1] == b[j - 1]) // string indexes are one less than table indexes , remember.
                    table[i, j] = table[i - 1, j - 1] + 1;
                else
                    table[i, j] = Math.Max(table[i, j - 1], table[i - 1, j]);
            }

        return table[a.Length, b.Length];
    }
    /* Returns length of LCS for X[0..m-1], Y[0..n-1] */
    static int lcsRec(char[] X, char[] Y, int m, int n)
    {
        if (m == 0 || n == 0)
            return 0;
        if (X[m - 1] == Y[n - 1])
            return 1 + lcsRec(X, Y, m - 1, n - 1);
        else
            return Math.Max(lcsRec(X, Y, m, n - 1), lcsRec(X, Y, m - 1, n));
    }
}