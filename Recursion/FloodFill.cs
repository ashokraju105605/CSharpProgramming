using System;
class FloodFill
{
    public static void main(string[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        int[,] screen = {{1, 1, 1, 1, 1, 1, 1, 1},
                     {1, 1, 1, 1, 1, 1, 0, 0},
                     {1, 0, 0, 1, 1, 0, 1, 1},
                     {1, 2, 2, 2, 2, 0, 1, 0},
                     {1, 1, 1, 2, 2, 0, 1, 0},
                     {1, 1, 1, 2, 2, 2, 2, 0},
                     {1, 1, 1, 1, 1, 2, 1, 1},
                     {1, 1, 1, 1, 1, 2, 2, 1}};
        int x = 4, y = 4, newC = 3;

        floodFill(screen, x, y, newC);

        for (int i = 0; i < screen.GetLength(0); i++)
        {
            for (int j = 0; j < screen.GetLength(1); j++)
                Console.Write(screen[i, j] + " ");
            Console.WriteLine();
        }
    }

    static void floodFill(int[,] mat, int x, int y, int newC)
    {
        if (x >= 0 && x < mat.GetLength(0) && y >= 0 && y < mat.GetLength(1))
            floodfillutil(mat, x, y, mat[x, y], newC);

    }
    static void floodfillutil(int[,] mat, int x, int y, int oldC, int newC)
    {
        if (mat[x, y] == newC || mat[x, y] != oldC)
            return;
        mat[x, y] = newC;
        if (x - 1 >= 0) floodfillutil(mat, x - 1, y, oldC, newC);
        if (y - 1 >= 0) floodfillutil(mat, x, y - 1, oldC, newC);
        if (x + 1 < mat.GetLength(0)) floodfillutil(mat, x + 1, y, oldC, newC);
        if (y + 1 < mat.GetLength(1)) floodfillutil(mat, x, y + 1, oldC, newC);

    }
}

/** 
you can also use the bfs to do the same flood filling.
which is being done here using stack recursion.
remember for DFS , you mark node and put it in the queue.
*/