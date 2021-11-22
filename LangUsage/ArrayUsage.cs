using System;
using System.Linq;
using System.Collections.Generic;

class SampleArrayOps
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        // Array Initialization
        int[] arr = { 5, 32, 1, 7, 10, 50, 19, 21, 2 };
        int[] a1 = new int[5];
        int[] a2 = new int[4] { 1, 2, 3, 4 };
        int[] val = new int[] { 60, 100, 120 };

        int[] temp = arr[2..5];

        Console.WriteLine(val.Length);

        Console.WriteLine(a2[3]);

        Array.Sort(arr);

        string[] animals = { "Cat", "Alligator", "Fox", "Donkey", "Bear", "Elephant", "Goat" };

        Array.Sort(animals, 0, 3); // Result: ["Alligator","Cat","Fox", "Donkey", "Bear", "Elephant", "Goat"]
        // sort 3 elements from 0.

        //double x = double.MaxValue;
        //double y = double.MinValue;
        //double z = 1.023d;

        foreach (int x in arr)
        {
            Console.Write(x + " ");
        }

        //Array.Copy(arr, 0, a1, 1, arr.Length);

        // simple way to print array
        Console.WriteLine("[ {0} ]", string.Join(", ", arr));
        Array.ForEach(arr, Console.Write);

        Console.WriteLine(Array.BinarySearch(arr, 0, arr.Length, 5));
        // binarysearch can only be used after sorting otherwise error results.
        // 0 -- start index, arr.Length -- range of elements to search from start.
        Console.WriteLine(Array.BinarySearch(arr, 0, arr.Length, 8));

        int[] arrk = { 1, 2, 2, 2, 2, 3 };
        Console.WriteLine(Array.BinarySearch(arrk, 2));



        Console.WriteLine(arr.Max()); // using system.linq
        Console.WriteLine(arr.Min());
        Console.WriteLine(arr.Sum());
        Console.WriteLine();

        // FOR all Array Class methods, first parameter will be the arrary object.


        string[] nums = Array.ConvertAll(arr, element => element.ToString());
        List<string> numStrings = new List<string>(nums);

        //Console.WriteLine(numStrings.ToString());  --> doesn't work, prints the object instead

        numStrings.ForEach(p => Console.Write(p + " "));
        Console.WriteLine(string.Join(", ", numStrings));
        foreach (int i in arr)
        {
            Console.WriteLine(i);
        }

        // ForEach on a List object has method that takes individual element as input
        //ForEach on Array class takes array object as input.

        // another way of initializing array with default values.
        int[] Num5Count1 = Enumerable.Repeat(0, 5).ToArray();
        Console.WriteLine("[{0}]", string.Join(", ", Num5Count1));

        int[] table1 = Enumerable.Repeat(int.MaxValue, 3 + 1).ToArray(); // because 0 value also can be given. and indexes are -1 the value always.
        table1[0] = 0;

        int[] dp = Enumerable.Repeat(-1, 5 + 1).ToArray();
        dp[0] = 0;

        bool[] visited = Enumerable.Repeat(false, 5).ToArray();

        bool[] vis = new bool[5];
        Array.Fill(vis, false);



        int[,] table = new int[5, 3];
        Console.WriteLine(table.GetLength(0));
        Console.WriteLine(table.GetLength(1));
        Console.WriteLine(table.Rank);


        Console.WriteLine(int.MaxValue);
        Console.WriteLine(int.MinValue);

        Console.WriteLine(Math.Max(2, 3));
        Console.WriteLine(Math.Min(-1, 2));
        Console.WriteLine(Math.Abs(-2));
        Console.WriteLine(Math.Sqrt(a2.GetLength(0)));


        Box[] arrb = new Box[4];
        arrb[0] = new Box(4, 6, 7);
        arrb[1] = new Box(1, 2, 3);
        arrb[2] = new Box(4, 5, 6);
        arrb[3] = new Box(10, 12, 32);
        Box[] arrbox = arrb;

        Array.Sort(arrb);
        Array.Sort(arrbox, delegate (Box a, Box b) { return b.area - a.area; });

    }
}
class Box : IComparable<Box>
{
    public int h, w, d, area;
    public Box(int h, int w, int d)
    {
        this.h = h;
        this.w = w;
        this.d = d;
        this.area = w * d;
    }
    public int CompareTo(Box o)
    {
        return o.area - area;
    }
}


// Array, Math, Random , String, Tuple, Char, DateTime,  methods, properties and their usage in documentation below
// https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-5.0