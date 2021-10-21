using System;
using System.Linq;

class prims
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        /* Let us create the following graph 
        2 3 
        (0)--(1)--(2) 
        | / \ | 
        6| 8/ \5 |7 
        | / \ | 
        (3)-------(4) 
            9 */

        int[,] graph = new int[,] { { 0, 2, 0, 6, 0 },
                                      { 2, 0, 3, 8, 5 },
                                      { 0, 3, 0, 0, 7 },
                                      { 6, 8, 0, 0, 9 },
                                      { 0, 5, 7, 9, 0 } };

        // Print the solution 
        primMST(graph);
    }
    static void primMST(int[,] g)
    {
        bool[] mstSet = Enumerable.Repeat(false, g.GetLength(0)).ToArray();
        int[] cut = Enumerable.Repeat(int.MaxValue, g.GetLength(0)).ToArray();
        int[] parent = new int[g.GetLength(0)];

        cut[0] = 0;
        //mstSet[0] = true; // wrong to set it here.
        parent[0] = -1;
        // made a mistake of not adding -1, as there will be only n-1 edges that need to be picked up.
        for (int i = 0; i < g.GetLength(0) - 1; i++)
        {
            int u = minCut(cut, mstSet);
            mstSet[u] = true;
            for (int j = 0; j < g.GetLength(1); j++)
            {
                if (!mstSet[j] && g[u, j] != 0 && g[u, j] < cut[j])
                {
                    cut[j] = g[u, j];
                    parent[j] = u;
                }
            }

        }

        Console.WriteLine("Edge \tWeight");
        for (int i = 1; i < g.GetLength(0); i++)
            Console.WriteLine(parent[i] + " - " + i + "\t" + g[i, parent[i]]);



    }
    static int minCut(int[] cut, bool[] vis)
    {
        int min = int.MaxValue;
        int min_index = -1;
        for (int i = 0; i < cut.Length; i++)
        {
            if (!vis[i] && cut[i] < min)
            {
                min = cut[i];
                min_index = i;
            }
        }
        return min_index;
    }

}

/**
Prims is exactly same as dijkstras algo.
except dijkstra finding path length, prims is finding cut length.


Kruskal algorithm sorts all the edges and picks them one by one till there are n-1 edges that are picked up which don't lead to a cycle. and mark complete.
cycle detection is done using union and find data structure.
*/