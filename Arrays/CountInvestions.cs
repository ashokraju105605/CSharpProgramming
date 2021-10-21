using System;
class countinversions
{
    public static void main(String[] args)
    {
        int[] arr = new int[] { 1, 20, 6, 4, 5 };
        countinversions ci = new countinversions();
        ci.countinv(arr);
    }
    void countinv(int[] arr)
    {
        int count = mergesort(arr, 0, arr.Length - 1);
        Console.WriteLine("number of inversions is : " + count);

        Console.Write("arr  ");
        foreach (int x in arr)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine();

    }
    int mergesort(int[] arr, int left, int right)
    {
        int inv = 0;
        if (left < right)
        {
            int mid = (left + right) / 2;
            inv += mergesort(arr, left, mid);
            inv += mergesort(arr, mid + 1, right);
            inv += merge(arr, left, mid, right);
        }
        return inv;
    }
    int merge(int[] arr, int left, int mid, int right)
    {
        int[] copy = new int[right - left + 1];
        int i = left, j = mid + 1, k = 0, count = 0;
        while (i < mid + 1 && j < right + 1)
        {
            if (arr[i] < arr[j])
            {
                copy[k++] = arr[i++];
            }
            else if (arr[i] > arr[j])
            {
                count += mid + 1 - i;
                copy[k++] = arr[j++];
            }
            else
            {
                copy[k++] = arr[i++];
            }
        }
        if (i == mid + 1)
        {
            while (j < right + 1)
            {
                copy[k++] = arr[j++];
            }
        }
        if (j == right + 1)
        {
            while (i < mid + 1)
            {
                copy[k++] = arr[i++];
            }
        }

        for (int t = left, p = 0; t <= right; t++, p++)
            arr[t] = copy[p];
        return count;
    }
}