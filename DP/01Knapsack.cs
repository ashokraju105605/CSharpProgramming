using System;
using System.Linq;

class Knapsack01
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        int[] val = new int[] { 60, 100, 120 };
        int[] wt = new int[] { 10, 20, 30 };
        int W = 50;
        int n = val.Length;

        int[,] table1 = new int[W + 1, n + 1];
        for (int i = 0; i < table1.GetLength(0); i++)
        {
            for (int j = 0; j < table1.GetLength(1); j++)
            {
                table1[i, j] = -1;
            }
        }

        Console.WriteLine(knapSack(W, wt, val, n));
        Console.WriteLine("Recursive ans: " + knapSackR(W, wt, val, n));
        Console.WriteLine("Recursive Mem ans: " + knapSackMem(W, wt, val, n, table1));
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
    static int knapSackR(int W, int[] wt,
                        int[] val, int n)
    {
        if (n == 0 || W == 0)
            return 0;

        if (wt[n - 1] > W)
            return knapSack(W, wt,
                            val, n - 1);
        else
            return Math.Max(val[n - 1]
                       + knapSack(W - wt[n - 1], wt,
                                  val, n - 1),
                       knapSack(W, wt, val, n - 1));
    }
    static int knapSackMem(int W, int[] wt,
                        int[] val, int n, int[,] sol)
    {
        if (sol[W, n] != -1)
            return sol[W, n];

        if (n == 0 || W == 0)
            return 0;

        if (wt[n - 1] > W)
            sol[W, n] = knapSackMem(W, wt,
                            val, n - 1, sol);
        else
            sol[W, n] = Math.Max(val[n - 1]
                       + knapSackMem(W - wt[n - 1], wt,
                                  val, n - 1, sol),
                       knapSackMem(W, wt, val, n - 1, sol));

        return sol[W, n];
    }
}