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
}