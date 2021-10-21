using System;
using System.Collections.Generic;
class Key
{
    public int value;
    public int freq;
    public int index;
    public Key(int x, int y, int z)
    {
        value = x;
        freq = y;
        index = z;
    }
}
class sortByFreq
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        int[] arr = { 2, 5, 2, 6, -1, 9999999, 5, 8, 8, 8 };
        freqsort(arr);
    }
    static void freqsort(int[] arr)
    {
        Dictionary<int, int> hm = new Dictionary<int, int>();
        for (int i = 0; i < arr.Length; i++)
        {
            if (hm.ContainsKey(arr[i]))
            {
                hm[arr[i]]++;
            }
            else
                hm[arr[i]] = 1;
        }
        List<Key> ll = new List<Key>();
        int t = 0;
        foreach (KeyValuePair<int, int> kvp in hm)
        {
            ll.Add(new Key(kvp.Key, kvp.Value, t++)); // index follows order in dictionary
        }
        ll.Sort(delegate (Key k1, Key k2)
        {
            if (k1.freq > k2.freq)
                return -1;
            else if (k1.freq < k2.freq)
                return 1;
            else
            {
                if (k1.index < k2.index)
                    return -1;
                else if (k1.index > k2.index)
                    return 1;
                else
                    return 0;
            }
        });
        foreach (Key k in ll)
        {
            for (int i = 0; i < k.freq; i++)
                Console.Write(k.value + " ");

        }
    }
}

/**
keep notice of how the keyvalue pairs are read like foreach , like reading an array.
dictonary traversal order gives the first visited numbers order.
so t++ insertion will do just fine.
class members are private by default so had to set them to public to be able to access them directly in a different class.
*/
