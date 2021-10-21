using System;
class sudoku
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        int[,] board = new int[,] {
            { 3, 0, 6, 5, 0, 8, 4, 0, 0 },
            { 5, 2, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 8, 7, 0, 0, 0, 0, 3, 1 },
            { 0, 0, 3, 0, 1, 0, 0, 8, 0 },
            { 9, 0, 0, 8, 6, 3, 0, 0, 5 },
            { 0, 5, 0, 0, 9, 0, 6, 0, 0 },
            { 1, 3, 0, 0, 0, 0, 2, 5, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 7, 4 },
            { 0, 0, 5, 2, 0, 6, 3, 0, 0 }
        };

        if (solveSudoku(board))
        {

            // print solution
            print(board);
        }
        else
        {
            Console.Write("No solution");
        }
    }
    static bool solveSudoku(int[,] mat)
    {
        int i, j;
        if (findEmpty(mat, out i, out j))
        {
            for (int k = 1; k <= 9; k++)
            {
                if (isSafe(mat, i, j, k))
                {
                    mat[i, j] = k;
                    if (solveSudoku(mat))
                        return true;
                    mat[i, j] = 0;
                }
            }
            return false;
        }
        else
            return true;
    }
    public static bool isSafe(int[,] board,
                              int row, int col,
                              int num)
    {

        // Row has the unique (row-clash)
        for (int d = 0; d < board.GetLength(0); d++)
        {

            // Check if the number
            // we are trying to
            // place is already present in
            // that row, return false;
            if (board[row, d] == num)
            {
                return false;
            }
        }

        // Column has the unique numbers (column-clash)
        for (int r = 0; r < board.GetLength(0); r++)
        {

            // Check if the number 
            // we are trying to
            // place is already present in
            // that column, return false;
            if (board[r, col] == num)
            {
                return false;
            }
        }

        // corresponding square has
        // unique number (box-clash)
        int sqrt = (int)Math.Sqrt(board.GetLength(0));
        int boxRowStart = row - row % sqrt;
        int boxColStart = col - col % sqrt;

        for (int r = boxRowStart;
             r < boxRowStart + sqrt; r++)
        {
            for (int d = boxColStart;
                 d < boxColStart + sqrt; d++)
            {
                if (board[r, d] == num)
                {
                    return false;
                }
            }
        }

        // if there is no clash, it's safe
        return true;
    }
    static bool findEmpty(int[,] board, out int p, out int q)
    {
        int row = -1;
        int col = -1;
        bool isEmpty = true;
        int n = board.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (board[i, j] == 0)
                {
                    row = i;
                    col = j;

                    // We still have some remaining
                    // missing values in Sudoku
                    isEmpty = false;
                    break;
                }
            }
            if (!isEmpty)
            {
                break;
            }
        }

        // no empty space left
        if (isEmpty)
        {
            p = -1;
            q = -1;
            return false;
        }
        else
        {
            p = row;
            q = col;
            return true;
        }
    }
    public static void print(int[,] board)
    {

        // We got the answer, just print it
        for (int r = 0; r < board.GetLength(0); r++)
        {
            for (int d = 0; d < board.GetLength(1); d++)
            {
                Console.Write(board[r, d]);
                Console.Write(" ");
            }
            Console.Write("\n");

            if ((r + 1) % (int)Math.Sqrt(board.GetLength(0)) == 0)
            {
                Console.Write("");
            }
        }
    }
}