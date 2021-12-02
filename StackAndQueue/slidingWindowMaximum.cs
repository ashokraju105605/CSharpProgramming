using System;
using System.Collections.Generic;
class SlidingWindowMax
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        int[] arr = { 12, 1, 78, 90, 57, 89, 56 };
        //printMax(arr, 3);

        int[] arr1 = { 1, 2, 3, 1, 4, 5, 2, 3, 6 };
        //printMax(arr1, 3);
        int[] arr2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        //printMax(arr2, 3);
        int[] arr3 = { 8, 5, 10, 7, 9, 4, 15, 12, 90, 13 };
        printMax(arr3, 4);
    }
    public static void printMax(int[] arr, int k)
    {

        LinkedList<int> deq = new LinkedList<int>();

        for (int i = 0; i < k; i++)
        {
            // push new element till the first block in the order where it belongs
            while (deq.Count != 0 && deq.Last.Value < arr[i])
            {
                deq.RemoveLast();
            }
            deq.AddLast(arr[i]);
        }

        Console.WriteLine("highest number in window of " + k + " elements is " + deq.First.Value);

        for (int i = k; i < arr.Length; i++)
        {

            // remove outgoing element
            if (arr[i - k] == deq.First.Value)
                deq.RemoveFirst();
            
            // push new element till the first block in the order where it belongs
            while (deq.Count != 0 && deq.Last.Value < arr[i])
            {
                deq.RemoveLast();
            }
            deq.AddLast(arr[i]);

            Console.WriteLine("highest number in window of " + k + " elements is " + deq.First.Value);
        }

    }
}