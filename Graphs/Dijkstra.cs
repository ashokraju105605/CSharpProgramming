using System;
using System.Linq;
class dijkstra
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };

        // dijkstra algo is very similar to prim's algo in approach.
        shortestpaths(graph, 0);

        //https://www.javatpoint.com/graph-theory-graph-representations
        // adjacency matrix can generally represent undirected graph
        // incidence graph and adjacency list can represent directed graph.
    }
    static void shortestpaths(int[,] g, int s)
    {
        bool[] vis = Enumerable.Repeat(false, g.GetLength(0)).ToArray();
        int[] dist = Enumerable.Repeat(int.MaxValue, g.GetLength(0)).ToArray();

        dist[s] = 0;


        for (int count = 0; count < g.GetLength(0); count++)
        {
            int u = getminNode(vis, dist);
            vis[u] = true;
            Console.WriteLine("distance to : " + u + " is : " + dist[u]);

            for (int j = 0; j < g.GetLength(1); j++)
            {
                if (!vis[j] && g[u, j] != 0 && dist[u] != int.MaxValue && g[u, j] + dist[u] < dist[j])
                    dist[j] = g[u, j] + dist[u];
            }
        }
    }
    static int getminNode(bool[] vis, int[] dist)
    {
        int min = int.MaxValue;
        int min_index = -1;
        for (int i = 0; i < dist.Length; i++)
        {
            if (!vis[i] && dist[i] < min)
            {
                min = dist[i];
                min_index = i;
            }
        }
        return min_index;
    }
    // min_index is important here as , we can't save the index properly based on value comparison.
    // and notice the intialization of the index to -1 just to ensure it won't go for a toss with big value.
}

/**
1) The code calculates shortest distance, but doesn’t calculate the path information. We can create a parent array, update the parent array when distance is updated (like prim’s implementation) and use it show the shortest path from source to different vertices.

2) The code is for undirected graph, same dijkstra function can be used for directed graphs also.

3) The code finds shortest distances from source to all vertices. If we are interested only in shortest distance from the source to a single target, we can break the for the loop when the picked minimum distance vertex is equal to target (Step 3.a of the algorithm).

4) Time Complexity of the implementation is O(V^2). If the input graph is represented using adjacency list, it can be reduced to O(E log V) with the help of binary heap. Please see
Dijkstra’s Algorithm for Adjacency List Representation for more details.

5) Dijkstra’s algorithm doesn’t work for graphs with negative weight cycles, it may give correct results for a graph with negative edges. For graphs with negative weight edges and cycles, Bellman–Ford algorithm can be used, we will soon be discussing it as a separate post.
*/