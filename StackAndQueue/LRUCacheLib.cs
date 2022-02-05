using System;
using System.Collections.Generic;
using System.Linq;

class LRUCacheLib
{

    Dictionary<int, int> dict;
    LinkedList<int> dll;
    int capacity;
    public LRUCacheLib(int cap)
    {
        capacity = cap;
        dict = new Dictionary<int, int>();
        dll = new LinkedList<int>();

    }
    public void set(int k, int v)
    {
        if (dict.ContainsKey(k))
        {
            // update dict, move dll to first.
            dict[k] = v;
            dll.Remove(k);
            dll.AddFirst(k);
        }
        else
        {
            if (dict.Count >= capacity)
            {
                // remove least used
                int x = dll.Last();  // needs System.Linq or use dll.Last.Value
                //int x = dll.Last.Value;
                dll.RemoveLast();
                dict.Remove(x);

                //add to both
                dict[k] = v;
                dll.AddFirst(k);
            }
            else
            {
                //add to both.
                dict[k] = v;
                dll.AddFirst(k);
            }
        }

    }
    public int get(int k)
    {
        if (dict.ContainsKey(k))
        {
            // move dll to the front.
            dll.Remove(k);
            dll.AddFirst(k);
            return dict[k];
        }
        else
            return -1;
    }
    public static void Main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        LRUCacheLib cache = new LRUCacheLib(2);

        // it will store a key (1) with value 
        // 10 in the cache.
        cache.set(1, 10);

        // it will store a key (1) with value 10 in the cache.
        cache.set(2, 20);
        Console.WriteLine("Value for the key: 1 is " +
                           cache.get(1)); // returns 10

        // evicts key 2 and store a key (3) with
        // value 30 in the cache.
        cache.set(3, 30);

        Console.WriteLine("Value for the key: 2 is " +
                cache.get(2)); // returns -1 (not found)

        // evicts key 1 and store a key (4) with
        // value 40 in the cache.
        cache.set(4, 40);
        Console.WriteLine("Value for the key: 1 is " +
               cache.get(1)); // returns -1 (not found)
        Console.WriteLine("Value for the key: 3 is " +
                           cache.get(3)); // returns 30
        Console.WriteLine("Value for the key: 4 is " +
                           cache.get(4)); // return 40
    }
}