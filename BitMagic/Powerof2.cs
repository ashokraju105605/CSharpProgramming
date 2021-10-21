using System;

class Powerof2
{
    public static void main()
    {
        Console.WriteLine("Jai Shree Ram");
        Console.WriteLine(isPowerOfTwo(31) ? "Yes" : "No");
        Console.WriteLine(isPowerOfTwo(64) ? "Yes" : "No");
        Console.WriteLine(getFirstSetBitPos(12));
        Console.WriteLine(countSetBits(14));
        Console.WriteLine(TotalSetBits(14));
    }

    static bool isPowerOfTwo(int x)
    {
        return (x & (x - 1)) == 0;
    }
    public static int getFirstSetBitPos(int n)
    {
        int v = n & (n - 1);
        return (int)Math.Log2(n - v) + 1;
        //return (int)((Math.Log10(n & -n))
        //        / Math.Log10(2)) + 1;
    }
    public static int countSetBits(int x)
    {
        int powerof2 = 1;
        int count = 0;

        for (int i = 0; i < 31; i++)
        {
            if ((x & powerof2) != 0)
                count++;
            powerof2 <<= 1;
        }

        return count;
    }
    static int TotalSetBits(int x)
    {
        // to consider all zero numbers as the starting in count.
        x++;

        int count = x / 2;
        int powerof2 = 2;

        while (x >= powerof2)  // needs equal because if x is power of 2 then also we should count.
        {
            int totalpairs = x / powerof2; // total pairs of the consecutive 1's and 0's based sets.

            count += (totalpairs / 2) * powerof2; // considering only 1's based sets

            if (totalpairs % 2 == 1)
                count += x % powerof2;  // adding the last set which got pruned above.

            powerof2 <<= 1; // go for next higher position of the number
        }

        return count;
    }
}