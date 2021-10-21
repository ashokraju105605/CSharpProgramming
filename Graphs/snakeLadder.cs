using System;
using System.Collections.Generic;
using System.Linq;
class quNode
{
    public int v;
    public int dist;
    public quNode(int x, int dt)
    {
        v = x;
        dist = dt;
    }
}
class snakeLadder
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        // Let us construct the board 
        // given in above diagram  
        int N = 30;
        int[] moves = new int[N];
        for (int i = 0; i < N; i++)
            moves[i] = -1;

        // Ladders  
        moves[2] = 21;
        moves[4] = 7;
        moves[10] = 25;
        moves[19] = 28;

        // Snakes  
        moves[26] = 0;
        moves[20] = 8;
        moves[16] = 3;
        moves[18] = 6;

        Console.WriteLine("Min Dice throws required is " +
                        getMinDiceThrows(moves));
    }
    static int getMinDiceThrows(int[] moves)
    {
        bool[] vis = Enumerable.Repeat(false, moves.Length).ToArray();
        Queue<quNode> q = new Queue<quNode>();

        q.Enqueue(new quNode(0, 0));
        vis[0] = true;

        while (q.Count != 0)
        {
            quNode p = q.Dequeue();
            if (p.v == moves.Length - 1)
                return p.dist;

            for (int i = 1; i <= 6; i++)
            {
                if (p.v + i < moves.Length && !vis[p.v + i])
                {
                    vis[p.v + i] = true;
                    if (moves[p.v + i] != -1)
                        q.Enqueue(new quNode(moves[p.v + i], p.dist + 1));
                    else
                        q.Enqueue(new quNode(p.v + i, p.dist + 1));
                }

            }
        }
        return 0;
    }
}

/**
if we use visited + distance array, we need to do linear search
if we use visited + queue , we need to process till the required node is processed from the queue.
priority queue or searching for the min dist node is not worth it, as there can be nodes that reach the destination quickly from other places.

made a mistake of not picking the dist or vertex properly when moves is valid. also forgot to add the !vis check for queueing 
*/