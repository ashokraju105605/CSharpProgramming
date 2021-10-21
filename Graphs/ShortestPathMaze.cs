using System;
using System.Collections.Generic;
using System.Linq;
class Point
{
    public int x;
    public int y;
    public Point(int a, int b)
    {
        x = a;
        y = b;
    }
}
class qNode
{
    public Point p;
    public int dist;
    public qNode(Point point, int x)
    {
        p = point;
        dist = x;
    }
}
class shortestpaths
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        int[,] mat =   {{ 1, 0, 1, 1, 1, 1, 0, 1, 1, 1 },
                        { 1, 0, 1, 0, 1, 1, 1, 0, 1, 1 },
                        { 1, 1, 1, 0, 1, 1, 0, 1, 0, 1 },
                        { 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 },
                        { 1, 1, 1, 0, 1, 1, 1, 0, 1, 0 },
                        { 1, 0, 1, 1, 1, 1, 0, 1, 0, 0 },
                        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                        { 1, 0, 1, 1, 1, 1, 0, 1, 1, 1 },
                        { 1, 1, 0, 0, 0, 0, 1, 0, 0, 1 }};

        int dist = BFS(mat, new Point(0, 0), new Point(3, 4));
        Console.WriteLine("distance from source to destination is : " + dist);
    }
    // we need to use BFS here as shortest path is requested, otherwise both DFS, BFS does the searchability problem, but DFS cannot guarantee the shortest distance.
    static int BFS(int[,] mat, Point s, Point d)
    {
        // sanity for source and dest nodes to be valid
        if (mat[s.x, s.y] != 1 || mat[d.x, d.y] != 1)
            return -1;

        Queue<qNode> q = new Queue<qNode>();

        bool[,] vis = new bool[mat.GetLength(0), mat.GetLength(1)];

        q.Enqueue(new qNode(s, 0));
        vis[s.x, s.y] = true;

        while (q.Count != 0)
        {
            qNode t = q.Dequeue();
            Point p = t.p;
            if (p.x == d.x && p.y == d.y)
            {
                return t.dist;
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (isValid(mat, p.x + a[i], p.y + b[i]) && !vis[p.x + a[i], p.y + b[i]])
                {
                    vis[p.x + a[i], p.y + b[i]] = true;
                    q.Enqueue(new qNode(new Point(p.x + a[i], p.y + b[i]), t.dist + 1));
                }
            }
        }


        return -1;
    }
    static bool isValid(int[,] m, int x, int y)
    {
        if (x >= 0 && x < m.GetLength(0) && y >= 0 && y < m.GetLength(1) && m[x, y] == 1)
            return true;
        return false;
    }
    static int[] a = { -1, 0, 0, 1 };
    static int[] b = { 0, -1, 1, 0 };
}
/**
forgot !vis after the isValid check
and also forgot to add the check m[x,y]==1
*/