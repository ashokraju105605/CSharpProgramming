using System;
using System.Linq;

public class SplitArrLargestSum
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        SplitArrLargestSum sals = new SplitArrLargestSum();
        int[] arr = new int[] { 7, 2, 5, 10, 8 };
        int m = 2;
        Console.WriteLine(sals.SplitArray(arr, m));

        int[] arr1 = new int[] { 1, 2, 3, 4, 5 };
        int m1 = 2;
        Console.WriteLine(sals.SplitArray(arr1, m1));

        int[] arr2 = new int[] { 1, 4, 4 };
        int m2 = 3;
        Console.WriteLine(sals.SplitArray(arr2, m2));
    }

    public int SplitArray(int[] nums, int m)
    {
        int l = nums.Max(), r = nums.Sum();

        int ans = r;

        while (l <= r)
        {
            int cts = 1;
            int subsum = 0;
            int mid = (l + r) >> 1;
            foreach (int x in nums)
            {
                if (subsum + x > mid)
                {
                    cts++;
                    subsum = x;
                }
                else
                {
                    subsum += x;
                }
            }
            if (cts <= m)
            {
                ans = Math.Min(ans, mid);
                r = mid - 1;
            }
            else
                l = mid + 1;
        }
        return ans;

    }
}