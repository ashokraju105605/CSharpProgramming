using System;
class EggDrop
{
    static readonly int MAX = 1000;

    static int[,] memo = new int[MAX, MAX];
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        for (int i = 0; i < memo.GetLength(0); i++)
            for (int j = 0; j < memo.GetLength(1); j++)
                memo[i, j] = -1;

        int n = 2, k = 36;
        Console.WriteLine("Minimum number of trials "
                          + "in worst case with " + n + " eggs and "
                          + k + " floors is " + eggDropDP(n, k));
        int n1 = 2, k1 = 10;
        Console.Write("Minimum number of "
                      + "trials in worst case with "
                      + n1 + " eggs and " + k1
                      + " floors is " + eggDropR(n1, k1));
    }
    static int eggDropDP(int n, int k)
    {
        int[,] dp = new int[n + 1, k + 1];
        for (int i = 1; i <= n; i++)
            for (int j = 0; j <= k; j++)
            {
                if (j == 0 || j == 1)
                    dp[i, j] = j;
                else if (i == 1)
                    dp[i, j] = j;
                else
                {
                    int min = int.MaxValue;
                    for (int x = 1; x <= j; x++)
                    {
                        min = Math.Min(min, Math.Max(dp[i - 1, x - 1], dp[i, j - x]));
                    }
                    dp[i, j] = 1 + min;
                }

            }
        return dp[n, k];
    }
    static int eggDropR(int n, int k)
    {
        if (k == 0 || k == 1)
            return k;
        if (n == 1)
            return k;

        int min = int.MaxValue;
        for (int x = 1; x <= k; x++) // forgot to pick x should be from 1 to k. otherwise stackoverflow. values based on below conditions like x-1,k-x
        {
            min = Math.Min(min, Math.Max(eggDropR(n - 1, x - 1), eggDropR(n, k - x)));
        }
        return min + 1; // forgot to add the one trial for the current number of floor.
    }

    static int EggDropMem(int n, int k)
    {

        if (memo[n, k] != -1)
        {
            return memo[n, k];
        }

        if (k == 1 || k == 0)
            return k;

        if (n == 1)
            return k;

        int min = int.MaxValue, x, res;

        for (x = 1; x <= k; x++)
        {
            res = Math.Max(EggDropMem(n - 1, x - 1),
                           EggDropMem(n, k - x));
            if (res < min)
                min = res;
        }

        memo[n, k] = min + 1;

        return memo[n, k];
    }
}