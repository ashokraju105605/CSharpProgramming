using System;
class Nqueens
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        Nqueen(6);
    }
    static void Nqueen(int n)
    {
        int[,] mat = new int[n, n];

        for (int i = 0; i < mat.GetLength(0); i++)
            for (int j = 0; j < mat.GetLength(1); j++)
            {
                mat[i, j] = 0;
            }

        if (queenutil(mat, 0))
            printSolution(mat);

    }

    static bool queenutil(int[,] mat, int col)
    {
        if (col == mat.GetLength(0))
            return true;
        for (int i = 0; i < mat.GetLength(0); i++)
        {
            if (safe(mat, i, col))
            {
                mat[i, col] = 1;
                if (queenutil(mat, col + 1)) // you need this check to not remove the successful saving of the solution.
                    return true;
                mat[i, col] = 0;
            }
        }
        return false;
    }
    static bool safe(int[,] board, int row, int col)
    {
        int i, j;

        /* Check this row on left side */
        for (i = 0; i < col; i++)
            if (board[row, i] == 1)
                return false;

        /* Check upper diagonal on left side */
        for (i = row, j = col; i >= 0 &&
             j >= 0; i--, j--)
            if (board[i, j] == 1)
                return false;

        /* Check lower diagonal on left side */
        for (i = row, j = col; j >= 0 &&
                      i < board.GetLength(0); i++, j--)
            if (board[i, j] == 1)
                return false;

        return true;
    }


    /* A utility function to print solution */
    static void printSolution(int[,] board)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
                Console.Write(" " + board[i, j]
                                  + " ");
            Console.WriteLine();
        }
    }

}