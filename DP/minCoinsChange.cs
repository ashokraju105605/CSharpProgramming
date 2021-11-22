using System;
using System.Linq;

class minCoinsChange
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        int[] coins = { 9, 6, 5, 1 };
        int V = 11;
        Console.Write("Minimum coins required is " +
                             minCoins(coins, V));
        Console.Write("Minimum coins required is " +
                             minCoinsRec(coins, V));
    }
    static int minCoins(int[] coins, int V)
    {
        int[] table = Enumerable.Repeat(int.MaxValue, V + 1).ToArray(); // because 0 value also can be given. and indexes are -1 the value always.
        table[0] = 0;

        for (int i = 1; i < table.Length; i++) // this represents the recursion order in inverse from bottom up manner
        {
            for (int j = 0; j < coins.Length; j++) // this represents the iteration over all possible coins for minimum number.
            {
                if (coins[j] <= i && table[i - coins[j]] != int.MaxValue && table[i - coins[j]] + 1 < table[i]) // forgot to add the coins[j]<= i condition.
                    table[i] = table[i - coins[j]] + 1;
            }
        }
        return table[table.Length - 1];
    }
    static int minCoinsRec(int[] coins, int V)
    {

        // base case
        if (V == 0) return 0;

        // Initialize result
        int res = int.MaxValue;

        // Try every coin that has
        // smaller value than V
        for (int i = 0; i < coins.Length; i++)
        {
            if (coins[i] <= V)
            {
                int sub_res = minCoins(coins, V - coins[i]);

                // Check for INT_MAX to
                // avoid overflow and see
                // if result can minimized
                if (sub_res != int.MaxValue &&
                            sub_res + 1 < res)
                    res = sub_res + 1;
            }
        }
        return res;
    }
}