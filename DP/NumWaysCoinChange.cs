using System;
class NumWaysCoinChange
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        int[] arr = { 1, 2, 3 };
        int m = arr.Length;
        Console.WriteLine(countRec(arr, m, 4));

        Console.WriteLine(countWaysDP(arr, m, 4));


        int n = arr.Length;
        int v = 4;
        int[,] dp = new int[n + 1, v + 1];
        for (int j = 0; j < n + 1; j++)
        {
            for (int l = 0; l < v + 1; l++)
                dp[j, l] = -1;
        }
        int res = coinchangeMem(arr, v, n, dp);
        Console.WriteLine(res);

    }

    static int countRec(int[] S, int m, int n)
    {
        // If n is 0 then there is 1 solution 
        // (do not include any coin)
        if (n == 0)
            return 1;

        // If n is less than 0 then no 
        // solution exists
        if (n < 0)
            return 0;

        // If there are no coins and n 
        // is greater than 0, then no
        // solution exist
        if (m <= 0 && n >= 1)
            return 0;

        // count is sum of solutions (i) 
        // including S[m-1] (ii) excluding S[m-1]
        return countRec(S, m - 1, n) +
            countRec(S, m, n - S[m - 1]);
    }

    static long countWaysDP(int[] S, int m, int n)
    {
        //Time complexity of this function: O(mn)
        //Space Complexity of this function: O(n)

        // table[i] will be storing the number of solutions
        // for value i. We need n+1 rows as the table is
        // constructed in bottom up manner using the base
        // case (n = 0)
        int[] table = new int[n + 1];

        // Initialize all table values as 0
        for (int i = 0; i < table.Length; i++)
        {
            table[i] = 0;
        }

        // Base case (If given value is 0)
        table[0] = 1;

        // Pick all coins one by one and update the table[]
        // values after the index greater than or equal to
        // the value of the picked coin
        for (int i = 0; i < m; i++)
            for (int j = S[i]; j <= n; j++)
                table[j] += table[j - S[i]];

        return table[n];
    }

    static int coinchangeMem(int[] a, int v, int n, int[,] dp)
    {
        if (v == 0)
            return dp[n, v] = 1;
        if (n == 0)
            return 0;
        if (dp[n, v] != -1)
            return dp[n, v];
        if (a[n - 1] <= v)
        {

            // Either Pick this coin or not
            return dp[n, v]
                = coinchangeMem(a, v - a[n - 1], n, dp)
                  + coinchangeMem(a, v, n - 1, dp);
        }
        else // We have no option but to leave this coin
            return dp[n, v] = coinchangeMem(a, v, n - 1, dp);
    }
}