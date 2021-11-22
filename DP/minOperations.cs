using System;
class minop
{
    public static void main(String[] args)
    {
        int[] dpm = new int[8];
        //int[] dpb = new int[8];
        int[] dp1m = new int[9];
        //int[] dp1b = new int[9];
        Array.Fill(dpm, -1);
        //Array.Fill(dpb, -1);
        Array.Fill(dp1m, -1);
        //Array.Fill(dp1b, -1);
        Console.WriteLine("Jai Shree Ram");
        Console.WriteLine(" minimum operations is : " + count(7));
        Console.WriteLine(" minimum operations is : " + countRec(7));
        Console.WriteLine(" minimum operations is : " + countRecMem(7, dpm));
        Console.WriteLine(" minimum operations is : " + countDP(7));
        Console.WriteLine(" minimum operations is : " + count(8));
        Console.WriteLine(" minimum operations is : " + countRec(8));
        Console.WriteLine(" minimum operations is : " + countRecMem(8, dp1m));
        Console.WriteLine(" minimum operations is : " + countDP(8));

    }
    static int count(int n)
    {
        int totalops = 0;
        int p = 1;// product operation cost
        int q = 1; // addition operation cost
        while (n > 0)
        {
            if (n % 2 == 1)
            {
                totalops += q;
                n--;
            }
            else
            {
                int temp = n / 2;
                if (temp * q > p)
                    totalops += p; // 2*x jump better
                else
                    totalops += temp * q; // addition x+1 jump better
                n = n / 2;
            }

        }
        return totalops;
    }
    static int countRec(int n)
    {
        if (n == 0)
            return 0;
        else if (n == 1)
            return 1;
        else
        {
            if (n % 2 != 0)
                return countRec(n - 1) + 1;
            else
                return Math.Min(countRec(n / 2) + 1, countRec(n - 1) + 1);
        }
    }
    // replace all the return statements with the solution saving constructs.
    static int countRecMem(int n, int[] dp)
    {
        if (dp[n] != -1)
            return dp[n];
        else
        {
            if (n == 0)
                dp[n] = 0;
            else if (n == 1)
                dp[n] = 1;
            else
            {
                if (n % 2 != 0)
                    dp[n] = countRec(n - 1) + 1;
                else
                    dp[n] = Math.Min(countRec(n / 2) + 1, countRec(n - 1) + 1);
            }
        }
        return dp[n];

    }
    // dont need to pass the result structure around like in recursion.
    static int countDP(int n)
    {
        int[] dp = new int[n + 1];

        dp[0] = 0;
        dp[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            if (i % 2 != 0)
                dp[i] = dp[i - 1] + 1;
            else
            {
                dp[i] = Math.Min(dp[i / 2], dp[i - 1]) + 1;
            }
        }
        return dp[n];

    }

}