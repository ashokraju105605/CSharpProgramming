using System;
class minop
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        Console.WriteLine(" minimum operations is : " + count(7));
        Console.WriteLine(" minimum operations is : " + count(8));
    }
    static int count(int n)
    {
        int totalops = 0;
        int p = 1;// product operation cost
        int q = 1; // addition operation cost
        while (n > 0)
        {
            if (n % 2 == 1)
            {
                totalops += q;
                n--;
            }
            else
            {
                int temp = n / 2;
                if (temp * q > p)
                    totalops += p; // 2*x jump better
                else
                    totalops += temp * q; // addition x+1 jump better
                n = n / 2;
            }

        }
        return totalops;
    }
}