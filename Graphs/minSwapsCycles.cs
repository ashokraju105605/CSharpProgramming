using System;
using System.Collections.Generic;
using System.Linq;

class Pair<T, V>
{
    public T First;
    public V Second;
    public Pair(T a, V b)
    {
        First = a;
        Second = b;
    }
}

class minSwaps
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        int[] arr = { 1, 5, 4, 3, 2 };
        countswaps(arr);
    }

    static void countswaps(int[] arr)
    {
        List<KeyValuePair<int, int>> lb = new List<KeyValuePair<int, int>>();
        List<Pair<int, int>> ll = new List<Pair<int, int>>();
        for (int i = 0; i < arr.Length; i++)
        {
            ll.Add(new Pair<int, int>(arr[i], i));
            lb.Add(new KeyValuePair<int, int>(arr[i], i));
        }
        lb.Sort(delegate (KeyValuePair<int, int> a, KeyValuePair<int, int> b)
        {
            if (a.Key < b.Key)
                return -1;
            else if (a.Key > b.Key)
                return 1;
            else
                return 0;
        });
        //instead of ll, lb can also be used.
        ll.Sort(delegate (Pair<int, int> a, Pair<int, int> b)
        {
            if (a.First < b.First)
                return -1;
            else if (a.First > b.First)
                return 1;
            else
                return 0;
        });
        bool[] vis = new bool[arr.Length];
        Array.Fill(vis, false);
        int totalswaps = 0;

        for (int i = 0; i < ll.Count; i++)
        {
            int count = 0;
            if (vis[i] || ll[i].Second == i)
                continue;
            int k = i;
            while (!vis[k])
            {
                count++;
                vis[k] = true;
                k = ll[k].Second;
            }
            if (count > 0)
            {
                totalswaps += count - 1;
            }
        }
        Console.WriteLine("number of swaps needed is : " + totalswaps);
    }
}
/**
see how Array.Fill is used instead of Enumerable.Repeat for filling the array with default values.
*/