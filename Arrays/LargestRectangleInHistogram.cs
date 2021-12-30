using System;
using System.Collections.Generic;
public class LargestRectangleInHistogram
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram -- LRIH");
        int[] a = { 6, 7, 5, 2, 4, 5, 9, 3 };
        Console.WriteLine(lrih(a));

        char[,] mat = new char[,]{ { '1', '0', '1', '0', '0' },
                                   { '1', '0', '1', '1', '1' },
                                   { '1', '1', '1', '1', '1' },
                                   { '1', '0', '0', '1', '0' } };
        Console.WriteLine(maximalRectangle(mat));
    }
    static int lrih(int[] heights)
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(-1);
        int maxArea = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            while ((stack.Peek() != -1) && (heights[stack.Peek()] >= heights[i]))
            {
                maxArea = Math.Max(maxArea, heights[stack.Pop()] * (i - stack.Peek() - 1));
            }
            stack.Push(i);
        }
        while (stack.Peek() != -1)
        {
            //int currentHeight = heights[stack.Pop()];
            //int currentWidth = length - stack.Peek() - 1; // right limit is current one, left limit is stack preceeding one.
            maxArea = Math.Max(maxArea, heights[stack.Pop()] * (heights.Length - stack.Peek() - 1));
        }
        return maxArea;
    }


    public static int maximalRectangle(char[,] matrix)
    {

        if (matrix.GetLength(0) == 0) return 0;
        int maxarea = 0;
        int[] dp = new int[matrix.GetLength(1)];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {

                // update the state of this row's histogram using the last row's histogram
                // by keeping track of the number of consecutive ones

                dp[j] = matrix[i, j] == '1' ? dp[j] + 1 : 0;
            }
            // update maxarea with the maximum area from this row's histogram
            maxarea = Math.Max(maxarea, lrih(dp));
        }
        return maxarea;
    }
}