using System;
using System.Linq;
class maxSegments
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        int n = 7, a = 5, b = 2, c = 5;
        //Console.WriteLine(maximumSegmentsRec(n, a, b, c));
        Console.WriteLine(maximumSegmentsDP(n, a, b, c));
        //Console.WriteLine(maximumSegmentsDP(n, a, b, c));
    }
    // recursion has issues doesn't work.
    static int maximumSegmentsRec(int n, int a, int b, int c)
    {
        if (n <= 0 || (n < a && n < b && n < c))
            return 0;
        int val = -1;
        val = Math.Max(n - a >= 0 ? maximumSegmentsRec(n - a, a, b, c) + 1 : -1, val);
        val = Math.Max(n - b >= 0 ? maximumSegmentsRec(n - b, a, b, c) + 1 : -1, val);
        val = Math.Max(n - c >= 0 ? maximumSegmentsRec(n - c, a, b, c) + 1 : -1, val);

        return val;
    }
    static int maximumSegmentsDP(int n, int a, int b, int c)
    {
        int[] dp = Enumerable.Repeat(-1, n + 1).ToArray();

        dp[0] = 0;

        for (int i = 0; i < n; i++) // made error of <= , which is not necessary
        {
            if (dp[i] != -1) // should not build solution on top of dead end possibilities.
            {
                if (i + a <= n)
                    dp[i + a] = Math.Max(dp[i + a], dp[i] + 1); // made the error of not adding the condition for overflow on i+a of the index.
                if (i + b <= n)
                    dp[i + b] = Math.Max(dp[i + b], dp[i] + 1);
                if (i + c <= n)
                    dp[i + c] = Math.Max(dp[i + c], dp[i] + 1);
            }
        }
        return dp[n];
    }

}