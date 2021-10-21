using System;
using System.Collections.Generic;


class QwithS
{
    public class Queue
    {
        Stack<int> s1;
        Stack<int> s2;
        public Queue()
        {
            s1 = new Stack<int>();
            s2 = new Stack<int>();
        }
        public void enQueue(int x)
        {
            // making enqueue costly.
            while (s1.Count > 0)
                s2.Push(s1.Pop());
            s2.Push(x);
            while (s2.Count > 0)
                s1.Push(s2.Pop());
        }
        public int deQueue()
        {
            if (s1.Count == 0)
                return -1;
            return s1.Pop();
        }
        // making dequeue with 2 stackly as costly is the best options, as you will empty the pushing queue only when you need to dequeue.
    }
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        Queue q = new Queue();
        q.enQueue(1);
        q.enQueue(2);
        q.enQueue(3);

        Console.Write(q.deQueue() + " ");
        Console.Write(q.deQueue() + " ");
        Console.Write(q.deQueue());
    }
}