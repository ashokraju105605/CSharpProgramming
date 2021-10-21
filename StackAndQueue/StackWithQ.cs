using System;
using System.Collections.Generic;
class StackWithQ
{
    public class Stack
    {
        Queue<int> q1;
        Queue<int> q2;
        public Stack()
        {
            q1 = new Queue<int>();
            q2 = new Queue<int>();
        }
        public void push(int x)
        {
            // making push costly
            q2.Enqueue(x);
            while (q1.Count > 0)
                q2.Enqueue(q1.Dequeue());
            while (q2.Count > 0) // you can avoid this loop by swapping the queue references.
                q1.Enqueue(q2.Dequeue());
        }
        public int pop()
        {
            if (q1.Count == 0)
                return -1;
            return q1.Dequeue();
        }
        // making pop costly is also similar as enqueue, just need to give the last item , can accommodate swapping of queue reference to avoid extra processing.

        public int top()
        {
            if (q1.Count > 0)
                return q1.Peek();
            return -1;
        }


    }
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        Stack s = new Stack();
        s.push(1);
        s.push(2);
        s.push(3);
        //Console.WriteLine("current size: " + s.size());
        Console.WriteLine(s.top());
        s.pop();
        Console.WriteLine(s.top());
        s.pop();
        Console.WriteLine(s.top());
        //Console.WriteLine("current size: " + s.size());
    }
}