using System;
class CountPaths
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        Console.WriteLine("Total Paths is : " + CountPath(3, 3));
        Console.WriteLine("Total Paths is : " + CountPath(4, 4));
    }
    static int CountPath(int x, int y)
    {
        if (x == 1 || y == 1)
            return 1;
        // if (x < 0 || y < 0)
        //     return 0;
        return CountPath(x - 1, y) + CountPath(x, y - 1);
    }
}

/**
mistakes:
x==1 check needs to be added instead of x==0
and x==1 || y==1 instead of && as there will be only one path once the base row or column

optimizations include using a DP solution and further more to use 1D array to compute the values.
*/