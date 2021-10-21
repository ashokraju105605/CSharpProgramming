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
        int i = 0, j = 0;
        bool[,] vis = new bool[m.GetLength(0), m.GetLength(1)];

        pathutil(m, i, j, vis);

        // Print all possible paths
        for (int t = 0; t < possiblePaths.Count; t++)
            Console.Write(possiblePaths[t] + " ");
    }
    static void pathutil(int[,] m, int i, int j, bool[,] vis)
    {
        if (i == -1 || i == m.GetLength(0) || j == -1 ||
            j == m.GetLength(1) || vis[i, j] ||
                        m[i, j] == 0)
            return;

        if (i == m.GetLength(0) - 1 && j == m.GetLength(1) - 1)
            possiblePaths.Add(path);

        vis[i, j] = true;

        if (isSafe(i + 1, j, m, vis))
        {
            path = path + "D";
            pathutil(m, i + 1, j, vis);
            path = path.Substring(0, path.Length - 1); // backtrack for the next direction to work

        }

        if (isSafe(i, j + 1, m, vis))
        {
            path = path + "R";
            pathutil(m, i, j + 1, vis);
            path = path.Substring(0, path.Length - 1);

        }

        if (isSafe(i - 1, j, m, vis))
        {
            path = path + "U";
            pathutil(m, i - 1, j, vis);
            path = path.Substring(0, path.Length - 1);

        }

        if (isSafe(i, j - 1, m, vis))
        {
            path = path + "L";
            pathutil(m, i, j - 1, vis);
            path = path.Substring(0, path.Length - 1);

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