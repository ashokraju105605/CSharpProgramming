using System;
class mindiff
{
    // Driver Code 
    public static void main()
    {
        int[] arr = { 4, 6 };
        int n = arr.Length;
        int k = 10;
        Console.Write("Maximum difference is " +
                        getMinDiff(arr, k));
    }
    static int getMinDiff(int[] arr, int k)
    {
        if (arr.Length == 1)
        {
            return 0;
        }
        int mindiff = -1;
        Array.Sort(arr);

        mindiff = arr[arr.Length - 1] - arr[0];
        // above has to be the worst case.


        int low = arr[0] + k; int high = arr[arr.Length - 1] - k;
        if (low > high)
        {
            int temp = low;
            low = high;
            high = temp;
        }

        for (int i = 1; i < arr.Length - 1; i++)
        {
            int add = arr[i] + k;
            int sub = arr[i] - k;

            if (add <= high || sub >= low)
                continue;
            else
            {
                if (add - high > low - sub)
                {
                    low = sub;
                }
                else
                    high = add;
            }
        }

        return Math.Min(mindiff, high - low);
    }
}
/**
forgot to add the equlity condition to the add<=high and sub >= low
*/