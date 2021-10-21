using System;
class triplet
{
    public static void main(string[] args)
    {
        int[] arr = { 5, 32, 1, 7, 10, 50, 19, 21, 2 };
        triplet t = new triplet();
        t.findTriplet(arr);
    }
    int findTriplet(int[] arr)
    {
        Array.Sort(arr);
        //Array.BinarySearch(arr,1,3,15);


        Console.Write("arr  ");
        foreach (int x in arr)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine();
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            int x = arr[i];
            int start = 0, end = i - 1;
            while (start < end)
            {
                int temp = arr[start] + arr[end];
                if (temp == x)
                {
                    Console.WriteLine(" {0} + {1} = {2}", arr[start], arr[end], x);
                    break;
                }
                if (temp > x)
                {
                    end--;
                }
                else if (temp < x)
                {
                    start++;
                }
            }
        }



        return 0;
    }
}