using System;
class merge
{
    public static void Main(String[] args)
    {
        int[] a1 = { 10, 27, 38, 43, 82 };
        int[] a2 = { 3, 18 };

        merge m = new merge();
        m.mergesorted(a1, a2);
        m.mergeSorted(a1, a2);

    }
    int nextgap(int x)
    {
        if (x <= 1)
            return 0;
        return x / 2 + x % 2;
    }
    int swap(int[] a, int i, int[] b, int j)
    {
        int temp = a[i];
        a[i] = b[j];
        b[j] = temp;
        return 1;
    }
    int mergesorted(int[] a1, int[] a2)
    {
        int m = a1.Length, n = a2.Length;

        for (int gap = nextgap(m + n); gap > 0; gap = nextgap(gap))
        {
            int i;
            for (i = 0; i + gap < m; i++)
            {
                if (a1[i] > a1[i + gap])
                    swap(a1, i, a1, i + gap);
            }
            for (int j = i; j < m; j++)
            {
                // first condition in the below if is necessary as the index with the gap can go beyond the second array when second array is smaller than the gap itself.
                if ((gap - (m - j) < n) && (a1[j] > a2[gap - (m - j)]))
                    swap(a1, j, a2, gap - (m - j));
            }
            for (int k = gap; k + gap < n; k++)
            {
                if (a2[k] > a2[k + gap])
                    swap(a2, k, a2, k + gap);
            }
        }


        Console.Write("arr1  ");
        foreach (int x in a1)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine();
        Console.Write("arr2  ");
        foreach (int x in a2)
        {
            Console.Write(x + " ");
        }
        return 0;
    }
    void mergeSorted(int[] a1, int[] a2)
    {
        if (a1.Length > a2.Length)
        {
            int[] temp = a1;
            a1 = a2;
            a2 = temp;
        }
        int i = 0, j = 0;
        while (i < a1.Length && j < a2.Length)
        {
            if (a1[i] < a2[j])
            {
                i++;
                continue;
            }
            else
            {
                int temp = a2[j];
                a2[j] = a1[i];
                a1[i] = temp;
                i++; j++;
            }
        }
        Array.Sort(a1);
        Array.Sort(a2);
    }
}