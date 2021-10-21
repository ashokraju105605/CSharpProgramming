using System;
class longestPath
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        int[][] mat = new int[][] {
            new int[] { 1, 2, 9 },
            new int[] { 5, 3, 8 },
            new int[] { 4, 6, 7 }
        };
        Console.WriteLine("Length of the longest path is " + finLongestOverAll(mat));
    }
    // lets use the memoization technique for solving this DP problem.
    static int finLongestOverAll(int[][] mat)
    {
        //Console.WriteLine(mat.GetLength(0));
        //Console.WriteLine(mat.GetLength(1)); error because array of arrays, not a 2 dimensional array.
        int[,] dp = new int[mat.GetLength(0), mat.GetLength(0)];
        for (int i = 0; i < dp.GetLength(0); i++)
        {
            for (int j = 0; j < dp.GetLength(1); j++)
            {
                dp[i, j] = -1;
            }
        }
        int result = 0;
        // Compute longest path beginning 
        // from all cells 
        for (int i = 0; i < dp.GetLength(0); i++)
        {
            for (int j = 0; j < dp.GetLength(1); j++)
            {
                if (dp[i, j] == -1)
                {
                    FindLongest(mat, i, j, dp);
                }

                result = Math.Max(result, dp[i, j]);
            }
        }
        return result;
    }
    static int FindLongest(int[][] mat, int i, int j, int[,] dp)
    {
        if (i < 0 || i > mat.GetLength(0) || j < 0 || j > mat[0].GetLength(0))
            return 0;
        if (dp[i, j] != -1)
            return dp[i, j];

        int a = i + 1 < mat.GetLength(0) && mat[i][j] + 1 == mat[i + 1][j] ? FindLongest(mat, i + 1, j, dp) + 1 : int.MinValue;

        int b = i > 0 && mat[i][j] + 1 == mat[i - 1][j] ? FindLongest(mat, i - 1, j, dp) + 1 : int.MinValue;

        int c = j + 1 < mat.GetLength(0) && mat[i][j] + 1 == mat[i][j + 1] ? FindLongest(mat, i, j + 1, dp) + 1 : int.MinValue;

        int d = j > 0 && mat[i][j] + 1 == mat[i][j - 1] ? FindLongest(mat, i, j - 1, dp) + 1 : int.MinValue; // forgot to add the +1 to the recursed value.

        dp[i, j] = Math.Max(a, Math.Max(b, Math.Max(c, Math.Max(d, 1)))); // forgot to add the base case where 1 should be returned for the current elements when there is no path further.

        return dp[i, j];
    }
}

// complexity is only O(n^2), as all the dp[i,j] elements are computed once.