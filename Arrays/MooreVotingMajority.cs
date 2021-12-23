using System;
public class MooreVotingMajority
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram -- Moore Voting");

        int[] a = { 1, 3, 3, 1, 2 };
        int[] arr = { 1, 1, 2, 1, 3, 5, 1 };

        // Function call
        printMajority(a);
        printMajority(arr);
    }
    static void printMajority(int[] a)
    {
        /* Find the candidate for Majority*/
        int cand = findCandidate(a);

        /* Print the candidate if it is Majority*/
        if (isMajority(a, cand))
            Console.WriteLine(" " + cand + " ");
        else
            Console.WriteLine("No Majority Element");
    }
    /* Function to find the candidate for Majority */
    static int findCandidate(int[] a)
    {
        int majindex = 0;
        int majcount = 1;
        int i;
        for (i = 1; i < a.Length; i++)
        {
            if (a[i] != a[majindex])
            {
                majcount--;
            }
            else
            {
                majcount++;
            }

            if (majcount == 0)
            {
                majindex = i;
                majcount = 1;
            }
        }
        return a[majindex];
    }

    // Function to check if the candidate
    // occurs more than n/2 times
    static bool isMajority(int[] a, int cand)
    {
        int i, count = 0;
        int size = a.Length;
        for (i = 0; i < size; i++)
        {
            if (a[i] == cand)
                count++;
        }
        if (count > size / 2)
            return true;
        else
            return false;
    }
}