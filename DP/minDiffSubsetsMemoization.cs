using System;
using System.Linq;
class minDiffSubsets
{
    public static void mxain(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        int[] arr = { 3, 1, 4, 2, 2, 1 };
        int n = arr.Length;

        Console.WriteLine("The minimum difference " +
                        "between 2 sets is " +
                        findMinD(arr));


        //bool[,] dpm = new bool[arr.Sum() / 2 + 1, arr.Length + 1]; // cannot work with bool array for memoization as we need to know whether calculation is started or not.
        // so need to have the values false, true, and non-initialized.
        int[,] dpm = new int[arr.Sum() + 1, arr.Length + 1];
        int k = arr.Length;
        int total = 0;
        for (int i = 0; i < dpm.GetLength(0); i++)
            for (int j = 0; j < dpm.GetLength(1); j++)
                dpm[i, j] = -1;

        findMinR(arr, total, k, dpm);
        int mindiff = int.MaxValue;
        for (int i = arr.Sum() / 2; i > 0; i--)
        {
            if (dpm[i, arr.Length] != -1)
            {
                mindiff = dpm[i, arr.Length];
                break;
            }
        }
        Console.WriteLine("The minimum difference " +
                        "between 2 sets is " +
                        mindiff);
    }
    //memoization method.
    // not able to get the memoization work.
    static int findMinR(int[] arr, int total, int i, int[,] dp)
    {
        if (dp[total, i] != -1)
            return dp[total, i];
        else
        {
            if (i == 0)
                dp[total, i] = Math.Abs(arr.Sum() - 2 * total);
            else
            {
                dp[total, i] = Math.Min(findMinR(arr, total + arr[i - 1], i - 1, dp), findMinR(arr, total, i - 1, dp));
            }
        }
        return dp[total, i];
    }
    //tabulation method.
    static int findMinD(int[] arr)
    {
        int sum = arr.Sum();
        bool[,] dp = new bool[sum / 2 + 1, arr.Length + 1];

        for (int i = 0; i <= (sum / 2); i++)
            for (int j = 0; j <= arr.Length; j++)
            {
                if (i == 0)
                    dp[i, j] = true;
                else if (j == 0)
                    dp[i, j] = false;
                else
                {
                    dp[i, j] = dp[i, j - 1];
                    if (i >= arr[j - 1])
                    {
                        dp[i, j] = dp[i, j] || dp[i - arr[j - 1], j - 1];
                    }
                }
            }
        int mindiff = int.MaxValue;
        for (int i = sum / 2; i > 0; i--)
        {
            if (dp[i, arr.Length] == true)
            {
                mindiff = sum - 2 * i;
                break;
            }
        }
        return mindiff;

    }
}