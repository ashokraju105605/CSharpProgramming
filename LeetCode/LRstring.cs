using System;
using System.Collections.Generic;

public class LRstring
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        LRstring lrs = new LRstring();
        Console.WriteLine(lrs.CanTransform("RXXLRXRXL", "XRLXXRRLX"));
        Console.WriteLine(lrs.CanTransform("X", "L"));
    }

    public bool CanTransform(string start, string end)
    {

        if (!start.Replace("X", "").Equals(end.Replace("X", "")))
            return false;

        int i = 0; // start's index
        int j = 0; // end's index

        while (i < start.Length && j < end.Length)
        {
            while (i < start.Length && start[i] == 'X')
                ++i;
            while (j < end.Length && end[j] == 'X')
                ++j;
            if (i == start.Length && j == end.Length)
                return true;
            if (i == start.Length || j == end.Length)
                return false;
            if (start[i] == 'L' && i < j)
                return false;
            if (start[i] == 'R' && i > j)
                return false;
            ++i;
            ++j;
        }

        return true;
    }
}