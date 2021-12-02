using System;
using System.Collections.Generic;

/*
0: Empty cell

1: Cells have fresh oranges

2: Cells have rotten oranges
*/
class RottenOranges
{
    class Ele
    {
        public int x;
        public int y;
        public Ele(int a, int b)
        {
            x = a;
            y = b;
        }
    }
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        int[,] v = { { 2, 1, 0, 2, 1 },
                     { 1, 0, 1, 2, 1 },
                     { 1, 0, 0, 2, 1 } };
        Console.Write("Max time incurred: " + rotOranges(v));

    }
    public static bool isValid(int x, int y, int[,] m)
    {
        if (x >= 0 && x < m.GetLength(0) && y >= 0 && y < m.GetLength(1) && m[x, y] == 1)
            return true;
        else
            return false;
    }
    public static bool checkforfresh(int[,] m)
    {
        for (int i = 0; i < m.GetLength(0); i++)
            for (int j = 0; j < m.GetLength(1); j++)
            {
                if (m[i, j] == 1)
                    return true;
            }
        return false;
    }
    public static int rotOranges(int[,] m)
    {
        Queue<Ele> q = new Queue<Ele>();
        int distance = 0;


        for (int i = 0; i < m.GetLength(0); i++)
            for (int j = 0; j < m.GetLength(1); j++)
            {
                if (m[i, j] == 2)
                    q.Enqueue(new Ele(i, j));
            }

        q.Enqueue(new Ele(-1, -1));

        int[,] d = {{1,0},{0,1},{-1,0},{0,-1}};

        while (q.Count != 0)
        {
            Ele e = q.Dequeue();
            if (e.x != -1) // you can use count while loop here instead of tombstone method.
            {
                for(int i=0;i<d.GetLength(0);i++)
                {
                    if(isValid(e.x+d[i,0], e.y+d[i,1], m))
                    {
                        m[e.x+d[i,0], e.y+d[i,1]] = 2;
                        q.Enqueue(new Ele(e.x+d[i,0], e.y+d[i,1]));
                    }
                }

                // if (isValid(e.x + 1, e.y, m))
                // {
                //     m[e.x + 1, e.y] = 2;
                //     q.Enqueue(new Ele(e.x + 1, e.y));
                // }

                // if (isValid(e.x, e.y + 1, m))
                // {
                //     m[e.x, e.y + 1] = 2;
                //     q.Enqueue(new Ele(e.x, e.y + 1));
                // }

                // if (isValid(e.x - 1, e.y, m))
                // {
                //     m[e.x - 1, e.y] = 2;
                //     q.Enqueue(new Ele(e.x - 1, e.y));
                // }

                // if (isValid(e.x, e.y - 1, m))
                // {
                //     m[e.x, e.y - 1] = 2;
                //     q.Enqueue(new Ele(e.x, e.y - 1));
                // }
            }
            else
            {
                if (q.Count != 0)
                {
                    distance++;
                    q.Enqueue(new Ele(-1, -1));
                }
            }
        }

        if (checkforfresh(m))
            return -1;
        else
            return distance;
    }
}