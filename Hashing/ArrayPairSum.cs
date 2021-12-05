using System;
using System.Collections.Generic;
class ArrayPairsum
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        int[] arr = { 92, 75, 65, 48, 45, 35 };
        int k = 10;

        Console.WriteLine(pairSumMultipleK(arr, k));
    }
    static bool pairSumMultipleK(int[] a, int k)
    {
        Dictionary<int, int> hm = new Dictionary<int, int>();
        for (int i = 0; i < a.Length; i++)
        {
            int t = a[i] % k;
            if (hm.ContainsKey(t))
                hm[t]++;
            else
                hm[t] = 1;
        }
        foreach (KeyValuePair<int, int> kvp in hm)
        {
            if (kvp.Key % k == 0 && kvp.Value % 2 != 0)
                return false;
            else if (kvp.Key * 2 == k && kvp.Value % 2 != 0)
                return false;
            else if (hm[kvp.Key] != hm[k - kvp.Key])
                return false; ;
        }
        return true;
    }
}