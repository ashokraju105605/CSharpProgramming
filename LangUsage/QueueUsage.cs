using System;
using System.Collections.Generic;
using System.Collections;
class QueueUsage
{
    public static void main()
    {
        Console.WriteLine("Jai Shree Ram");

        Queue<int> q = new Queue<int>();

        q.Enqueue(1);
        q.Enqueue(2);

        Console.WriteLine(q.Count);
        Console.WriteLine(q.Peek());
        Console.WriteLine(q.Contains(2));

        q.Dequeue();

        Console.WriteLine(q.Peek());

        Queue qt = new Queue();
        qt.Enqueue(1);
        qt.Enqueue("ashok");
    }
}