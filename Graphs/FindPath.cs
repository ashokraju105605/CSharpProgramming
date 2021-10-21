using System;
class FindPath
{
    public static void main(String[] args)
    {
        /*
        A value of cell 1 means Source.
        A value of cell 2 means Destination.
        A value of cell 3 means Blank cell.
        A value of cell 0 means Blank Wall.
        */
        Console.WriteLine("Jai Shree Ram");
        int[,] M =    { { 0, 3, 0, 1 },
                        { 3, 0, 3, 3 },
                        { 2, 3, 3, 3 },
                        { 0, 3, 3, 3 } };
        bool[,] vis = new bool[M.GetLength(0), M.GetLength(1)];
        //Array.Fill(vis, false); --> doesn't work for double indexed arrays.
        findRoute(M, 0, 3, vis);
    }
    static void findRoute(int[,] mat, int x, int y, bool[,] vis)
    {
        // go from 1 to 2 via 3.
        vis[x, y] = true;
        for (int i = 0; i < a.Length; i++)
        {
            if (isValid(mat, x + a[i], y + b[i]) && !vis[x + a[i], y + b[i]])
            {
                if (mat[x + a[i], y + b[i]] == 2)
                    Console.WriteLine("Path has been found");
                else
                    findRoute(mat, x + a[i], y + b[i], vis);
            }
        }
    }
    static bool isValid(int[,] m, int x, int y)
    {
        if (x >= 0 && x < m.GetLength(0) && y >= 0 && y < m.GetLength(1) && m[x, y] != 0)
            return true;
        return false;
    }
    static int[] a = { -1, 0, 0, 1 };
    static int[] b = { 0, -1, 1, 0 };

}
// missed writing the else if (!vis[x + a[i], y + b[i]]) , which led to stackoverflow.
/**
GFG solved it using BFS, but as the problem is only on finding the path and not necessarily a shortest path, both BFS , DFS should solve the problem.
*/