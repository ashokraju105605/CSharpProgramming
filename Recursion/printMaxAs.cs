using System;
class printmaxAs
{
    public static void main(String[] args)
    {
        int[] dp = new int[25];
        Array.Fill(dp, -1);
        Console.WriteLine("Jai Shree Ram");
        for (int i = 1; i <= 20; i++)
        {
            Console.WriteLine("Max A's that can be printed is: " + findOptimal(i));
            Console.WriteLine("Max A's that can be printed is: " + findOptimalDP(i));
            Console.WriteLine("Max A's that can be printed is: " + findOptimalMem(i, dp));
        }
    }
    static int findOptimal(int n)
    {
        if (n <= 6)
        {
            return n;
        }
        return Math.Max(Math.Max(2 * findOptimal(n - 3), 3 * findOptimal(n - 4)), 4 * findOptimal(n - 5));
    }
    static int findOptimalDP(int n)
    {

        if (n <= 6)
        {
            return n;
        }
        int[] solution = new int[n];
        for (int i = 1; i <= 6; i++)
            solution[i - 1] = i;

        for (int i = 7; i <= n; i++)
            solution[i - 1] = Math.Max(Math.Max(2 * solution[i - 4], 3 * solution[i - 5]), 4 * solution[i - 6]);

        return solution[n - 1];
    }
    static int findOptimalMem(int n, int[] dp)
    {
        if (dp[n] != -1)
            return dp[n];
        if (n <= 6)
        {
            return dp[n] = n;
        }
        return dp[n] = Math.Max(Math.Max(2 * findOptimal(n - 3), 3 * findOptimal(n - 4)), 4 * findOptimal(n - 5));
    }
}

/**
for (int i = 7; i <= n; i++) equality condition in <=n is important as the solution is computing the required solutions in n-1th that is zeroth index.
without which we get all zero answers in the DP.
*/