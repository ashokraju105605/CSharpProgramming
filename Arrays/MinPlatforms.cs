using System;
using System.Collections.Generic;

class minplatforms
{
    public static void main(String[] args)
    {
        int[] arr = { 900, 940, 950, 1100, 1500, 1800 };
        int[] dep = { 910, 1200, 1120, 1130, 1900, 2000 };

        minplatforms mp = new minplatforms();
        mp.calcPlatforms(arr, dep);
        mp.countPlatforms(arr, dep);

    }
    void countPlatforms(int[] arr, int[] dep)
    {
        int count = 0, maxcount = 0;
        SortedList<int, char> sl = new SortedList<int, char>();
        foreach (int i in arr)
        {
            sl.Add(i, 'a');
        }
        foreach (int i in dep)
        {
            sl.Add(i, 'd');
        }
        foreach (KeyValuePair<int, char> kvp in sl)
        {
            if (kvp.Value == 'a')
            {
                count++;
                if (count > maxcount)
                {
                    maxcount = count;
                }
            }
            else if (kvp.Value == 'd')
            {
                count--;
            }
        }

        Console.WriteLine("min platforms needed is : " + maxcount);
    }
    void calcPlatforms(int[] arr, int[] dep)
    {
        Array.Sort(arr);
        Array.Sort(dep);

        int i = 0, j = 0, count = 0, maxcount = 0;
        while (i < arr.Length && j < dep.Length)
        {
            if (arr[i] < dep[j])
            {
                i++; count++;
                if (count > maxcount)
                    maxcount = count;
            }
            else if (dep[j] < arr[i])
            {
                j++; count--;
            }
        }

        Console.WriteLine("min platforms needed is : " + maxcount);
    }
}