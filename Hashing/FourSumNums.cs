using System;
using System.Collections.Generic;
using System.Linq;

public class FourSumNus
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        int[] arr = { 10, 20, 30, 40, 1, 2 };
        int X = 91;
        fourSum(arr, X);

    }
    public static void fourSum(int[] a, int x)
    {
        Dictionary<int, Tuple<int, int>> hm = new Dictionary<int, Tuple<int, int>>();
        for (int i = 0; i < a.Length - 1; i++)
        {
            for (int j = i; j < a.Length; j++)
            {
                hm[a[i] + a[j]] = Tuple.Create(i, j);
            }
        }
        //hashset is of no use here.
        List<Tuple<int, int, int, int>> ll = new List<Tuple<int, int, int, int>>();
        // hs.Add(Tuple.Create(1, 2, 3, 4));
        // hs.Add(Tuple.Create(1, 2, 3, 4));
        // hs.Add(Tuple.Create(1, 3, 2, 4));
        foreach (KeyValuePair<int, Tuple<int, int>> kvp in hm)
        {
            if (hm.ContainsKey(x - kvp.Key))
            {
                Tuple<int, int> t1 = hm[x - kvp.Key];
                if (kvp.Value.Item1 != t1.Item1 && kvp.Value.Item1 != t1.Item2
                    && kvp.Value.Item2 != t1.Item1 && kvp.Value.Item2 != t1.Item2)
                {
                    ll.Add(Tuple.Create(a[kvp.Value.Item1], a[kvp.Value.Item2], a[t1.Item1], a[t1.Item2]));
                    Console.WriteLine(a[kvp.Value.Item1] + " " + a[kvp.Value.Item2] + " " + a[t1.Item1] + " " + a[t1.Item2]);
                }
            }
        }
        // doesn't work as order inside the Tuple is considered and so not treated as duplicates..
        foreach (Tuple<int, int, int, int> t in ll)
        {
            Console.WriteLine(t.Item1 + " " + t.Item2 + " " + t.Item3 + " " + t.Item4);
        }

        ll
    .Select(x => new[] { x.Item1, x.Item2, x.Item3, x.Item4 }.OrderBy(s => s).ToArray())
    .Select(x => Tuple.Create<int, int, int, int>(x[0], x[1], x[2], x[3]))
    .Distinct();
    }
    // incomplete.
    class TupleComparer : IEqualityComparer<Tuple<int, int, int, int>>
    {
        public bool Equals(Tuple<int, int, int, int> a, Tuple<int, int, int, int> b)
        {
            HashSet<int> hs1 = new HashSet<int>();
            return a.Item1 == b.Item1 && a.Item2 == b.Item2
                || a.Item1 == b.Item2 && a.Item2 == b.Item1;
        }

        public int GetHashCode(Tuple<int, int, int, int> t)
        {
            return t.Item1 + 31 * t.Item2;
        }
    }
}