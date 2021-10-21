using System;
using System.Linq;
class MSIS
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        int[] arr = new int[] { 1, 101, 2, 3, 100, 4, 5 };
        int n = arr.Length;
        Console.WriteLine("Sum of maximum sum increasing " +
                                        " subsequence is " +
        maxSumIS(arr));
    }
    static int maxSumIS(int[] arr)
    {
        int[] msis = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            msis[i] = arr[i];
        }
        //msis[0] = 0;

        for (int i = 1; i < arr.Length; i++) // can be started from 1
            for (int j = 0; j < i; j++)
            {
                if (arr[i] > arr[j] && msis[j] + arr[i] > msis[i])
                    msis[i] = msis[j] + arr[i];
            }

        return msis.Max();
    }
}

/**
this is O(n2) algorithm.
*/