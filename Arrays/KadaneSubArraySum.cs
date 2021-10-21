using System;
class kadane
{
    public static void main(string[] args)
    {
        int[] arr1 = { -2, -3, 4, -1, -2, 1, 5, -3 };
        kadane k = new kadane();
        k.LargestSubArraySum(arr1);

    }
    int LargestSubArraySum(int[] arr)
    {
        int curmax = 0;
        int entiremax = 0;
        int start = 0;
        int end = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > curmax + arr[i])
            {
                start = i;
                curmax = arr[i];
            }
            else
            {
                curmax += arr[i];
            }
            if (entiremax < curmax)
            {
                entiremax = curmax;
                end = i;
            }
            //curmax = Math.Max(x, curmax + x);
            //entiremax = Math.Max(curmax, entiremax);
        }
        Console.WriteLine("Largest SubArray Sum is:  " + entiremax);
        Console.WriteLine("Strating from {0} to {1} ", start, end);
        return 0;
    }
}