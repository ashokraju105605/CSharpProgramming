using System;
class subsetSum
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        int[] arr = { 1, 2, 5 };
        int sum = 7;
        //int n = arr.Length;
        if (isSubsetSum(arr, sum) == true)
            Console.WriteLine("There exists a subset with" +
                                         "given sum");
        else
            Console.WriteLine("No subset exists with" +
                                        " given sum");
    }
    static bool isSubsetSum(int[] arr, int sum)
    {
        bool[,] table = new bool[2, sum + 1];
        for (int i = 0; i <= arr.Length; i++) // keep in mind the <= condition.
            for (int j = 0; j <= sum; j++)
            {
                //int row = i % 2;
                if (j == 0)
                    table[i % 2, j] = true;
                else if (i == 0)
                    table[i % 2, j] = false;
                else
                {
                    if (arr[i - 1] <= j) // it should be arr[i-1] as the i is for the table , array has table -1 index. also has to be <= condition.
                        table[i % 2, j] = table[(i + 1) % 2, j - arr[i - 1]] || table[(i + 1) % 2, j]; // row+1%2 because for the zeroth row, you will have problems
                    else
                        table[i % 2, j] = table[(i + 1) % 2, j];
                }
            }

        return table[arr.Length % 2, sum];
    }
}