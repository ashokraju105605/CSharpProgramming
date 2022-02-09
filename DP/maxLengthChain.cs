using System;
using System.Linq;
class maxLengthChain
{
    class Pair
    {
        public int a, b; // because this is internal class and want to access these in a method outside this class.
        public Pair(int x, int y)
        {
            a = x;
            b = y;
        }
    }
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        Pair[] arr = new Pair[]
        {new Pair(5,24), new Pair(15, 25),
        new Pair (27, 40), new Pair(50, 60)};
        Console.Write("Length of maximum size  chain is " + maxChainLength(arr));
    }
    static int maxChainLength(Pair[] arr)
    {
        int[] mcl = new int[arr.Length];

        Array.Fill(mcl, 1);

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (arr[j].b < arr[i].a && mcl[j] + 1 > mcl[i]) // forgot to add the b < a condition check.
                    mcl[i] = mcl[j] + 1;
            }
        }
        return mcl.Max(); // best way rather to write the loop again here.
    }
}

/**
did a mistake by taking a double index matrix, where as only single index matrix is sufficient. 
because there is only one degree that is variying . so thinking needs to be oriented correctly.

can solve it also like activity selection problem in O(nlogn) by sorting the pairs with their finish times and then picking for the first finish times greedily.
*/

