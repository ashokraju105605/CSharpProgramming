using System;
using System.Linq;

class numpairs
{
    public static void main(String[] args)
    {
        int[] X = { 2, 1, 6 };
        int[] Y = { 1, 5 };

        int[] X1 = { 10, 19, 18 };
        int[] Y1 = { 11, 15, 9 };

        numpairs np = new numpairs();
        np.totalpairs(X, Y);
        np.totalpairs(X1, Y1);

    }
    int totalpairs(int[] X, int[] Y)
    {
        int[] Num5Count = new int[5];
        // another way of initializing array with default values.
        int[] Num5Count1 = Enumerable.Repeat(0, 5).ToArray();
        int totalpairs = 0;
        Array.Sort(Y);
        foreach (int y in Y)
        {
            if (y < 5)
            {
                Num5Count[y]++;
            }
        }
        foreach (int x in X)
            totalpairs += countpairs(x, Num5Count, Y);

        Console.WriteLine("total pairs count is : " + totalpairs);
        return 0;
    }
    int countpairs(int x, int[] counts, int[] y)
    {
        int pairs = 0;
        if (x == 0)
            return 0;
        if (x == 1)
            return counts[0];

        int yindex = Array.BinarySearch(y, x);

        if (yindex < 0)
        {
            pairs = y.Length - Math.Abs(yindex + 1);
        }
        else
        {
            // Binary Search returns the first occurence of the found element.
            while (yindex < y.Length && y[yindex] == x)
                yindex++;
            pairs = y.Length - yindex;
        }

        pairs += counts[0] + counts[1];


        if (x == 2)
            pairs -= counts[3] + counts[4];

        if (x == 3)
            pairs += counts[2];



        return pairs;
    }
}