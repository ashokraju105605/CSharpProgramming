using System;
using System.Linq;

class Knapsack01
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        int[] val = new int[] { 60, 100, 120 };
        int[] wt = new int[] { 10, 20, 30 };
        int W = 50;
        int n = val.Length;

        Console.WriteLine(knapSack(W, wt, val, n));
    }
    static int knapSack(int W, int[] wt, int[] val, int n)
    {
        int[,] table = new int[W + 1, n + 1];
        for (int i = 0; i < table.GetLength(0); i++)
            for (int j = 0; j < table.GetLength(1); j++)
            {
                if (i == 0 || j == 0)
                    table[i, j] = 0;
                else if (wt[j - 1] <= i) // forgot to add the equality condition
                    table[i, j] = Math.Max(val[j - 1] + table[i - wt[j - 1], j - 1], table[i, j - 1]);
                else
                    table[i, j] = table[i, j - 1];
            }
        return table[W, n];
    }
}