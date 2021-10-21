using System;
class josephus
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        Console.WriteLine("position that reamins after all rounds is : " + josephusutil(14, 2));
    }
    static int josephusutil(int n, int k)
    {
        if (n == 1)
            return 0;
        return (josephusutil(n - 1, k) + k) % n;
    }
}

/**
index is considered starting from zero in this approach
otherwise it should base case return 1 and + k-1) % n +1
*/