using System;
//using System.Linq;
using System.Collections.Generic;
class largestNumber
{
    public static void main(String[] args)
    {
        int[] arr = { 54, 546, 548, 60 };
        int[] arr2 = { 1, 34, 3, 98, 9, 76, 45, 4 };
        largestNumber ln = new largestNumber();
        ln.printLargest(arr);
        ln.printLargest(arr2);

    }
    void printLargest(int[] arr)
    {
        string[] nums = Array.ConvertAll(arr, element => element.ToString());
        List<string> numStrings = new List<string>(nums);
        numStrings.Sort(compare);

        foreach (string x in numStrings)
        {
            Console.Write(" {0}", x);
        }
        Console.WriteLine();

    }

    // below is incorrect as 9 comes before 98, so doesn't solve our issue.
    void printLargest2(int[] arr)
    {
        string[] nums = Array.ConvertAll(arr, element => element.ToString());
        List<string> numStrings = new List<string>(nums);
        numStrings.Sort();
        numStrings.Reverse();

        foreach (string x in numStrings)
        {
            Console.Write(" {0}", x);
        }
        Console.WriteLine();

    }
    int compare(string x, string y)
    {
        string xy = x + y;
        string yx = y + x;
        return yx.CompareTo(xy);
    }
}