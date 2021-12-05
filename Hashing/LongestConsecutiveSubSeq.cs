using System;
using System.Collections.Generic;

class LongestConsecuritveSubSeq
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        int[] arr = new int[] { 1, 9, 3, 10, 4, 20, 2 };
        findlongest(arr);
    }
    static void findlongest(int[] a)
    {
        HashSet<int> hs = new HashSet<int>(a);
        int res = 1;

        foreach (int x in a)
        {
            if (!hs.Contains(x - 1))
            {
                int t = x;
                while (hs.Contains(t))
                    t++;
                res = Math.Max(res, t - x);
            }
        }

        Console.WriteLine(res);

    }
}