using System;
using System.Collections.Generic;
class NextLargerElement
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        int[] arr = new int[] { 11, 13, 21, 3 };
        printNGE(arr);
    }
    static void printNGE(int[] arr)
    {
        Stack<int> s = new Stack<int>();
        s.Push(arr[0]);
        for (int i = 1; i < arr.Length; i++)
        {
            int x = arr[i];
            while (s.Count > 0 && x > s.Peek()) // forgot the s.Count > 0 check otherwise Peek throws invalidoperationexception. 
            {
                Console.WriteLine(s.Peek() + " --> " + x);
                s.Pop();
            }
            s.Push(x);
        }
        while (s.Count > 0)
        {
            Console.WriteLine(s.Peek() + " --> -1");
            s.Pop();
        }
    }
}