using System;
using System.Collections.Generic;
using System.Collections;
class StackUsage
{
    public static void main()
    {
        Console.WriteLine("Jai Shree Ram");
        Stack<int> s = new Stack<int>();
        s.Push(1);
        s.Push(2);
        Console.WriteLine(s.Peek());
        int x = s.Pop();
        Console.WriteLine(s.Contains(1));
        Console.WriteLine(s.Count);

        int[] a = s.ToArray();

        Stack st = new Stack();
        st.Push(1);
        st.Push("ashok");

    }
}