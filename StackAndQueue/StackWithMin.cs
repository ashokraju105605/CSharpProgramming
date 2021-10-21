using System;
using System.Collections.Generic;
class StackWithMin
{
    public class MyStack
    {
        Stack<int> s;
        int minEle;
        public MyStack()
        {
            s = new Stack<int>();
        }
        public void Push(int x)
        {
            if (s.Count == 0)
            {
                s.Push(x);
                minEle = x;
                Console.WriteLine("Number Inserted: " + x);
            }
            else
            {
                if (x >= minEle)
                    s.Push(x);
                else
                {
                    s.Push(2 * x - minEle);
                    minEle = x;
                }
                Console.WriteLine("Number Inserted: " + x);

            }
        }
        public void getMin()
        {
            // Get the minimum number  
            // in the entire stack 
            if (s.Count == 0)
                Console.WriteLine("Stack is empty");

            // variable minEle stores the minimum  
            // element in the stack. 
            else
                Console.WriteLine("Minimum Element in the " +
                                " stack is: " + minEle);
        }
        public void Pop()
        {
            if (s.Count == 0)
            {
                Console.WriteLine("Stack is empty");
                return;
            }

            Console.Write("Top Most Element Removed: ");
            int t = (int)s.Pop();

            if (t < minEle)
            {
                Console.WriteLine(minEle);
                minEle = 2 * minEle - t;

            }
            else
                Console.WriteLine(minEle);
        }
        public void Peek()
        {
            if (s.Count == 0)
            {
                Console.WriteLine("Stack is empty ");
                return;
            }

            int t = (int)s.Peek(); // Top element. 

            Console.Write("Top Most Element is: ");

            // If t < minEle means minEle stores 
            // value of t. 
            if (t < minEle)
                Console.WriteLine(minEle);
            else
                Console.WriteLine(t);
        }

    }
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        MyStack s = new MyStack();
        s.Push(3);
        s.Push(5);
        s.getMin();
        s.Push(2);
        s.Push(1);
        s.getMin();
        s.Pop();
        s.getMin();
        s.Pop();
        s.Peek();
    }
}