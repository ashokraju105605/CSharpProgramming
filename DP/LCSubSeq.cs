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

        Console.Write("Length of LCS is" + " " + lcs(s1, s2));
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
}