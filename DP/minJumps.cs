using System;
class minJumps
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        int[] arr = new int[] { 1, 3, 5, 8, 9, 2,
                                6, 7, 6, 8, 9 };

        // calling minJumps method 
        Console.Write(minjumps(arr));
    }
    static int minjumps(int[] arr)
    {
        if (arr.Length <= 1)
            return 0;
        if (arr[0] == 0)
            return -1;

        int maxReach = arr[0];
        int steps = arr[0];
        int jumps = 1;

        for (int i = 1; i < arr.Length; i++)
        {
            // if we are able to reach the end of array, then return the jumnps so far.
            if (i == arr.Length - 1)
                return jumps;

            maxReach = Math.Max(maxReach, i + arr[i]);
            steps--;

            if (steps == 0)
            {
                jumps++;
                if (i >= maxReach)
                    return -1;
                // above check is need to make sure steps are not zero for the next walk.
                steps = maxReach - i;
            }
        }

        return jumps;
    }
}

// total jumps is 3 , 1->3->9->9