using System;
using System.Collections.Generic;
class SortByAnotherArray
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        int[] arr1 = { 2, 1, 2, 5, 7, 1, 9, 3, 6, 8, 8, 7, 5, 6, 9, 7, 5 };
        int[] arr2 = { 2, 1, 8, 3, 4 };
        sorta1bya2(arr1, arr2);
        Console.WriteLine();
        sorta1bya2_1(arr1, arr2);
    }
    static void sorta1bya2_1(int[] arr1, int[] arr2)
    {
        List<int> ll = new List<int>();
        foreach (int x in arr1)
            ll.Add(x);
        ll.Sort(delegate (int x, int y)
        {
            int idx1 = Array.IndexOf(arr2, x);
            int idx2 = Array.IndexOf(arr2, y);
            if (idx1 != -1 && idx2 != -1)
            {
                return idx1 - idx2;
            }
            else
            {
                if (idx1 != -1)
                    return -1;
                else if (idx2 != -1)
                    return 1;
                else
                    return x - y;
            }

        });
        foreach (int x in ll)
            Console.Write(" " + x);
    }
    static void sorta1bya2(int[] arr1, int[] arr2)
    {
        Dictionary<int, int> hm = new Dictionary<int, int>();
        foreach (int x in arr1)
        {
            if (hm.ContainsKey(x))
                hm[x]++;
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
        ll.Sort();
        foreach (int x in ll)
        {
            Console.Write(" " + x);
        }
    }
}
/**
you can write one more function to do it directly through list sort method by writing a comparer which takes arr2 indexes into account.
see the use of Array.IndexOf()
also see instead of checking x>y just used x-y to get the sign of the operation.
you can also use CompareTo method for a non-primitive data type object to do same operation as '-'
Array.IndexOf give lowest index -1 if not found and the index of element if found.
*/