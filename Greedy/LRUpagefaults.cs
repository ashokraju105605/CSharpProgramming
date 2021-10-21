using System;
using System.Collections.Generic;
class pagefaults
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        int[] pages = {7, 0, 1, 2, 0, 3,
                       0, 4, 2, 3, 0, 3, 2};

        int capacity = 4;

        Console.WriteLine(pageFaults(pages, capacity));
    }
    static int pageFaults(int[] pages, int capacity)
    {
        LinkedList<int> ll = new LinkedList<int>();
        HashSet<int> hs = new HashSet<int>();

        int count = 0;

        foreach (int x in pages)
        {
            if (hs.Contains(x))
            {
                ll.Remove(x);
                ll.AddLast(x);
            }
            else
            {
                count++;
                if (ll.Count < capacity)
                {
                    hs.Add(x);
                    ll.AddLast(x);
                }
                else
                {
                    hs.Add(x);
                    ll.RemoveFirst();
                    ll.AddLast(x);
                }
            }
        }
        return count;
    }
}