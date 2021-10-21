using System;
class RomanToDecimal
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        string str = "MCMIV";
        RomanToDecimal r2d = new RomanToDecimal();
        r2d.printdecimal(str);
        r2d.printdecimal2(str);


    }
    void printdecimal(string str)
    {
        long total = 0;
        int i = 0;
        while (i < str.Length)
        {
            int current = value(str[i]);
            int before = i - 1 >= 0 ? value(str[i - 1]) : 0;
            if (current > before)
            {
                total += current - before;
                total -= before;
                i++;
            }
            else
            {
                total += current;
                i++;
            }
        }
        Console.WriteLine("total sum is : " + total);

    }
    void printdecimal2(string str)
    {
        long total = 0;
        int i = 0;
        while (i < str.Length)
        {
            int current = value(str[i]);
            int next = i + 1 < str.Length ? value(str[i + 1]) : 0;
            if (current >= next)
            {
                total += current;
                i++;
            }
            else
            {
                total += next - current;
                i++;
                i++;// as two characters are used in the computation.
            }
        }
        Console.WriteLine("total sum is : " + total);

    }
    // This function returns value
    // of a Roman symbol
    int value(char r)
    {
        if (r == 'I')
            return 1;
        if (r == 'V')
            return 5;
        if (r == 'X')
            return 10;
        if (r == 'L')
            return 50;
        if (r == 'C')
            return 100;
        if (r == 'D')
            return 500;
        if (r == 'M')
            return 1000;
        return -1;
    }
}

/*
this only works if only subraction allowed between consecutive characters.
*/