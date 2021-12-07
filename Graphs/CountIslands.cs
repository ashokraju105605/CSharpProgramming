using System;

class CountIslands
{
    static int[,] dir = new int[,]{{-1,-1},{-1,0},{-1,1},{0,-1},
                                 {0,1},{1,-1},{1,0},{1,1}};
    public static void main(String[] args)
    {
        int[,] M = new int[,] { { 1, 1, 0, 0, 0 },
                                  { 0, 1, 0, 0, 1 },
                                  { 1, 0, 0, 1, 1 },
                                  { 0, 0, 0, 0, 0 },
                                  { 1, 0, 1, 0, 1 } };
        Console.Write("Number of islands is: " + countIslands(M));
    }
    static int countIslands(int[,] m)
    {
        bool[,] vis = new bool[m.GetLength(0), m.GetLength(1)];
        int count = 0;

        for (int i = 0; i < m.GetLength(0); i++)
            for (int j = 0; j < m.GetLength(1); j++)
            {
                if (m[i, j] == 1 && vis[i, j] == false)
                {
                    DFS(m, i, j, vis);
                    count++;
                }
            }

        return count;
    }
    static bool check(int i, int j, bool[,] vis, int[,] m)
    {
        if (i >= 0 && i < m.GetLength(0) && j >= 0 && j < m.GetLength(1) && m[i, j] == 1 && !vis[i, j])
            return true;
        return false;
    }
    static void DFS(int[,] m, int x, int y, bool[,] vis)
    {
        vis[x, y] = true;
        for (int i = 0; i < dir.GetLength(0); i++)
        {
            if (check(x + dir[i, 0], y + dir[i, 1], vis, m))
                DFS(m, x + dir[i, 0], y + dir[i, 1], vis);
        }
    }
}