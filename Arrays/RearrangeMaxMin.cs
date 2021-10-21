using System;
using System.Linq;
class rearrange
{
    public static void main(String[] args)
    {
        int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
        int[] arr1 = { 1, 2, 3, 4, 5, 6 };
        int[] arr2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        rearrange r = new rearrange();
        r.maxminorder(arr);
        r.maxminorder(arr1);
        r.maxminorder(arr2);
    }
    int maxminorder(int[] arr)
    {
        int left = 0, right = arr.Length - 1;
        // need to have the System.Linq to find the Max of array below working.
        int max = arr.Max() + 1;
        int i = 0;
        while (left <= right)
        {

            arr[i++] += (arr[right--] % max) * max;
            if (i < arr.Length)
                arr[i++] += (arr[left++] % max) * max;
        }
        for (int j = 0; j < arr.Length; j++)
        {
            arr[j] /= max;
        }

        Console.Write("arr  ");
        foreach (int x in arr)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine();

        return 0;
    }
}