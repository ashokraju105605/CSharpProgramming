using System;
class RandomUsage
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        var rand = new Random();
        Console.WriteLine(rand.Next(200, 300)); // min, max

        //bool lowercase = true;
        bool lowercase = false;
        char offset = lowercase ? 'a' : 'A';
        Console.WriteLine((char)rand.Next(offset, offset + 26));


        Console.WriteLine(rand.Next()); // signed integer from 0 - max value

        Console.WriteLine(rand.Next(100)); // returns rands till max parameter.

        //Console.WriteLine(Math.Random()*5); -- doesn't exist.

    }
}