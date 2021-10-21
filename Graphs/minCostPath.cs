using System;
class mincost
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        int[,] grid = { { 31, 100, 65, 12, 18 },
                        { 10, 13, 47, 157, 6 },
                        { 100, 113, 174, 11, 33 },
                        { 88, 124, 41, 20, 140 },
                        { 99, 32, 111, 41, 20 } };
        findCost(grid);
    }
    static void findCost(int[,] g)
    {
        bool[,] vis = new bool[g.GetLength(0), g.GetLength(1)];
        int[,] dist = new int[g.GetLength(0), g.GetLength(1)];
        for (int i = 0; i < dist.GetLength(0); i++)
            for (int j = 0; j < dist.GetLength(1); j++)
            {
                vis[i, j] = false;
                dist[i, j] = int.MaxValue;
            }
        dist[0, 0] = g[0, 0];
        //vis[0, 0] = true;

        for (int t = 0; t < g.GetLength(0) * g.GetLength(1); t++)
        {
            int min = int.MaxValue;
            int u = -1, v = -1;

            // find the min node , to process further, similar to dijkstra.
            // C# doesn't have PriorityQueue object so manually find min.
            for (int i1 = 0; i1 < dist.GetLength(0); i1++)
                for (int j = 0; j < dist.GetLength(1); j++)
                {
                    if (!vis[i1, j] && dist[i1, j] < min)
                    {
                        min = dist[i1, j];
                        u = i1;
                        v = j;
                    }
                }
            vis[u, v] = true;
            if (u == g.GetLength(0) - 1 && v == g.GetLength(1) - 1)
            {
                Console.WriteLine(" min cost for the path is : " + min);
            }
            for (int k = 0; k < a.Length; k++)
            {
                if (isValid(g, u + a[k], v + b[k]) && dist[u, v] + g[u + a[k], v + b[k]] < dist[u + a[k], v + b[k]])
                {
                    dist[u + a[k], v + b[k]] = dist[u, v] + g[u + a[k], v + b[k]];
                }
            }
        }


    }
    static bool isValid(int[,] m, int x, int y)
    {
        if (x >= 0 && x < m.GetLength(0) && y >= 0 && y < m.GetLength(1))
            return true;
        return false;
    }
    static int[] a = { -1, 0, 0, 1 };
    static int[] b = { 0, -1, 1, 0 };
}

/**
you don't need to have queue just to pick the next element as the vis and dist array gives the clues for finding the next element
priority queue can cut down the search to O(1) for the min dist next node, we are just doing it on the array with O(n)
*/