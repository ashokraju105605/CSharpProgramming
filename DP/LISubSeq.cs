using System;
using System.Collections.Generic;
using System.Linq;
class LISubSeq
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        int[] A = { 2, 5, 3, 7, 11, 8, 10, 13, 6 };
        int n = A.Length;
        Console.WriteLine("Length of Longest "
                      + "Increasing Subsequence is " + LongestIncreasingSubsequenceLength(A));
        Console.WriteLine("Length of Longest "
                      + "Increasing Subsequence is " + LongestIncreasingSubsequenceLength1(A));

        Console.WriteLine("Length of Longest "
        + "Increasing Subsequence Traditional is " + lis(A));
    }
    static int LongestIncreasingSubsequenceLength(int[] a)
    {
        int[] lis = new int[a.Length + 1]; // array is causing issues with binary search, so lets try the list
        //List<int> lis = new List<int>();
        int len = 1;
        lis[0] = a[0];
        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] < lis[0])
                lis[0] = a[i];
            else if (a[i] > lis[len - 1]) // mistake as len is always the next position to be filled, need to use len-1
                lis[len++] = a[i];
            else
            {
                int k = Array.BinarySearch(lis, 0, len, a[i]);// forgot to give the a[i] argument and instead passed the null as parameter, which caused issues.
                if (k < 0)
                {
                    int index = Math.Abs(k + 1);
                    if (index < len)
                    {
                        lis[index] = a[i];
                    }
                    else
                    {
                        lis[len++] = a[i];
                    }

                }
            }
        }
        return len; // as we need the number not the index.
    }
    static int LongestIncreasingSubsequenceLength1(int[] a)
    {
        //int[] lis = new int[a.Length + 1]; // array is causing issues with binary search, so lets try the list
        List<int> lis = new List<int>();
        //int len = 1;
        lis.Add(a[0]);
        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] < lis[0])
                lis[0] = a[i];
            else if (a[i] > lis[lis.Count - 1]) // mistake as len is always the next position to be filled, need to use len-1
                lis.Add(a[i]);
            else
            {
                int k = lis.BinarySearch(0, lis.Count, a[i], null);// forgot to give the a[i] argument and instead passed the null as parameter, which caused issues.
                if (k < 0)
                {
                    int index = Math.Abs(k + 1);
                    if (index < lis.Count)
                    {
                        lis[index] = a[i];
                    }
                    else
                    {
                        lis.Add(a[i]);
                    }

                }
            }
        }
        return lis.Count; // as we need the number not the index.
    }

    static int lis(int[] arr)
    {
        int n = arr.Length;
        int[] lis = new int[n];
        int i, j;

        Array.Fill(lis, 1);

        /* Compute optimized LIS values in bottom up manner
         */
        for (i = 1; i < n; i++)
            for (j = 0; j < i; j++)
                if (arr[i] > arr[j] && lis[i] < lis[j] + 1)
                    lis[i] = lis[j] + 1;

        return lis.Max();
    }
}