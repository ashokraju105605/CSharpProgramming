using System;
class optimalGame
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        int[] arr1 = { 8, 15, 3, 7 };
        Console.WriteLine("" + optimalStrategyOfGame(arr1));

        int[] arr2 = { 2, 2, 2, 2 };
        Console.WriteLine("" + optimalStrategyOfGame(arr2));

        int[] arr3 = { 20, 30, 2, 2, 2, 10 };
        Console.WriteLine("" + optimalStrategyOfGame(arr3));
    }
    //tabulation.
    static int optimalStrategyOfGame(int[] arr)
    {
        int[,] dp = new int[arr.Length, arr.Length];

        for (int gap = 0; gap < arr.Length; gap++)
            for (int i = 0, j = gap; j < arr.Length; i++, j++) // picked wrong condition.
            {
                if (i == j)
                    dp[i, j] = arr[i];
                else if (i + 1 == j)
                    dp[i, j] = Math.Max(arr[i], arr[j]); // wrong code with arr[i+1]
                else
                {
                    int x = dp[i + 2, j];
                    int y = dp[i + 1, j - 1];
                    int z = dp[i, j - 2];
                    dp[i, j] = Math.Max(arr[i] + Math.Min(x, y),
                                        arr[j] + Math.Min(y, z));
                }
            }

        return dp[0, arr.Length - 1];

    }
}