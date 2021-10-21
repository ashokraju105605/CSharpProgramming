using System;
using System.Collections.Generic;
class SubArrayGivenSum
{
    public static void main(string[] args)
    {
        int[] arr = { 1, 4, 20, 3, 10, 5 };
        int sum = 33;
        SubArrayGivenSum sags = new SubArrayGivenSum();
        sags.sumNonNegative(arr, sum);
        int[] arr1 = { 1, 4, 0, 0, 3, 10, 5 };
        int sum1 = 7;
        sags.sumNonNegative(arr1, sum1);
        int[] arr2 = { 1, 4 };
        int sum2 = 0;
        sags.sumNonNegative(arr2, sum2);

        int[] arr3 = { 15, 2, 4, 8, 9, 5, 10, 23 };
        int sum3 = 23;
        sags.sumNonNegative(arr3, sum3);

        int[] arr4 = { 10, 2, -2, -20, 10 };
        int sum4 = -10;
        sags.sumNegativeInc(arr4, sum4);

        int[] arr5 = { -10, 0, 2, -2, -20, 10 };
        int sum5 = 20;
        sags.sumNegativeInc(arr5, sum5);

    }

    int sumNegativeInc(int[] arr, int sum)
    {
        Console.Write("arr  ");
        foreach (int x in arr)
        {
            Console.Write(x + " ");
        }
        Console.Write("with sum {0} ", sum);

        Dictionary<int, int> hm = new Dictionary<int, int>();
        int curSum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            curSum += arr[i];
            if (curSum - sum == 0)
            {
                Console.WriteLine("sum found {0} and {1}", 0, i);
                return 1;
            }
            if (hm.ContainsKey(curSum - sum))
            {
                Console.WriteLine("sum found {0} and {1}", hm[curSum - sum] + 1, i);
                return 1;
            }

            hm[curSum] = i;

        }
        Console.WriteLine("No SubArray found");
        return 0;
    }
    // doesn't work properly for zero sum cases.
    int sumNonNegative(int[] arr, int sum)
    {
        Console.Write("arr  ");
        foreach (int x in arr)
        {
            Console.Write(x + " ");
        }
        Console.Write("with sum {0} ", sum);
        int curSum = 0;
        int start = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            // removing unnecessary elements
            if (curSum > sum)
            {
                while (start < i - 1 && curSum > sum)
                {
                    curSum -= arr[start];
                    start++;
                }
            }
            // check if the required situation is obtained
            if (curSum == sum)
            {
                Console.WriteLine("Required sum found between {0} and {1} ", start, i);
                return 1;
            }
            // keep adding from the other end
            curSum += arr[i];
        }
        Console.WriteLine("No SubArray found");
        return 0;
    }
}