using System;
using System.Collections.Generic;
using System.Linq;
class SwapPairSum
{
    public static void main(String[] args)
    {
        int[] a = { 4, 1, 2, 1, 1, 2 };
        int[] b = { 1, 6, 3, 3 };

        printSwapValue(a, b);

    }
    static void printSwapValue(int[] a, int[] b)
    {
        HashSet<int> hs = new HashSet<int>();
        foreach (int x in a)
            hs.Add(x);

        int sum1 = a.Sum();
        int sum2 = b.Sum();

        if ((sum1 - sum2) % 2 != 0)
            Console.WriteLine("swap not possible");
        else
        {
            foreach (int y in b)
            {
                int x = (sum1 - sum2 + 2 * y) / 2;
                if (hs.Contains(x))
                    Console.WriteLine(x + " " + y);
            }
        }
    }
}