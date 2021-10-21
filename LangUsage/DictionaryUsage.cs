using System;
using System.Collections.Generic;
using System.Collections;
class DictionaryUsage
{
    public static void main()
    {
        Console.WriteLine("Jai Shree Ram");
        int[] arr1 = { 2, 1, 2, 5, 7, 1, 9, 3, 6, 8, 8, 7, 5, 6, 9, 7, 5 };
        int[] arr2 = { 2, 1, 8, 3, 4 };
        Dictionary<int, int> hm = new Dictionary<int, int>(); // hashmap is nothing but dictionary in C#
        foreach (int x in arr1)
        {
            if (hm.ContainsKey(x))
                hm[x]++; // add , update happens in one shot. Add method only adds.
            else
                hm[x] = 1;
        }
        foreach (int x in arr2)
        {
            if (hm.ContainsKey(x))
            {
                for (int i = 0; i < hm[x]; i++)
                    Console.Write(" " + x);
                hm.Remove(x);
            }
        }
        List<int> ll = new List<int>();
        foreach (KeyValuePair<int, int> kvp in hm)
        {
            for (int i = 0; i < kvp.Value; i++)
                ll.Add(kvp.Key);
        }
        Console.WriteLine();
        foreach (int x in hm.Keys)
        {
            Console.WriteLine(x);
        }
        foreach (int y in hm.Values)
        {
            Console.WriteLine(y);
        }

        Console.WriteLine(hm.Count);

        // sorted dict keeps the kvp's sorted on keys.
        SortedDictionary<int, int> map = new SortedDictionary<int, int>();

        // non-generic implementation.
        Hashtable ht = new Hashtable();
        ht.Add(1, "one");
        foreach (DictionaryEntry de in ht)
            Console.WriteLine("Key: {0}, Value: {1}", de.Key, de.Value);
    }
}