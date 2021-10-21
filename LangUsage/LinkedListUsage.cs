using System;
using System.Collections.Generic;
using System.Linq;
class LLUsage
{
    public static void main()
    {
        Console.WriteLine("Jai Shree Ram");

        LinkedList<int> deq = new LinkedList<int>();
        deq.AddLast(5);
        deq.AddFirst(9);

        Console.WriteLine(deq.Count);

        int x = deq.First(); // needs System.Linq;
        Console.WriteLine(x);

        deq.RemoveLast();
        deq.RemoveFirst();

        deq.AddLast(5);
        deq.AddFirst(9);
        Console.WriteLine(deq.Last);

        deq.Remove(5);  // to remove the first occurrence of a node in a LinkedList

        deq.Remove(deq.First);

        Console.WriteLine(deq.Count);
    }
}