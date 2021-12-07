using System;
using System.Collections.Generic;
class ratinMaze
{
    static List<String> possiblePaths = new List<String>();
    static String path = "";
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        int[,] m = { { 1, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 1 },
                    { 1, 1, 1, 0, 1 },
                    { 0, 0, 0, 0, 1 },
                    { 0, 0, 0, 0, 1 } };
        //int n = m.GetLength(0);   
        printPath(m);
    }
    static void printPath(int[,] m)
    {
        //int i = 0, j = 0;
        bool[,] vis = new bool[m.GetLength(0), m.GetLength(1)];

        if (m[0, 0] == 0 || m[m.GetLength(0) - 1, m.GetLength(1) - 1] == 0)
            return;

        pathutil(m, 0, 0, vis);

        // Print all possible paths
        for (int t = 0; t < possiblePaths.Count; t++)
            Console.Write(possiblePaths[t] + " ");
    }
    static void pathutil(int[,] m, int i, int j, bool[,] vis)
    {

        if (i == m.GetLength(0) - 1 && j == m.GetLength(1) - 1)
            possiblePaths.Add(path);

        var direc = new List<(int, int, string)> { (-1, 0, "U"), (0, -1, "L"), (1, 0, "D"), (0, 1, "R") };

        vis[i, j] = true;

        foreach (var d in direc)
        {
            if (isSafe(i + d.Item1, j + d.Item2, m, vis))
            {
                path = path + d.Item3;
                pathutil(m, i + d.Item1, j + d.Item2, vis);
                path = path.Substring(0, path.Length - 1);
            }
        }

        vis[i, j] = false; // backtrack for the next iternation of node traversal.
    }
    // Function returns true if the
    // move taken is valid else 
    // it will return false.
    static bool isSafe(int row, int col, int[,] m, bool[,] visited)
    {
        int n = m.GetLength(0);
        if (row == -1 || row == n || col == -1 ||
            col == n || visited[row, col] ||
                        m[row, col] == 0)
            return false;
        return true;
    }
}