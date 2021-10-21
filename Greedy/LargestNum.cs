using System;
class largestnum
{
    // Driver Code 
    static public void main()
    {
        int s = 9, m = 2;
        findLargest(m, s);
    }
    static void findLargest(int m, int s)
    {
        // If sum of digits is 0,  
        // then a number is possible  
        // only if number of digits is 1 
        if (s == 0)
        {
            Console.Write(m == 1 ?
                   "Largest number is 0" :
                          "Not possible");

            return;
        }

        // Sum greater than the 
        // maximum possible sum 
        if (s > 9 * m)
        {
            Console.WriteLine("Not possible");
            return;
        }

        int[] num = new int[m];
        for (int i = 0; i < m; i++)
        {
            if (s >= 9)
            {
                num[i] = 9;
                s -= 9;
            }
            else
            {
                num[i] = s;
                s = 0;
            }
        }
        Console.Write("Largest number is ");
        for (int i = 0; i < m; i++)
            Console.Write(num[i]);
    }

}
