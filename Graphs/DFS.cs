using System;
using System.Collections.Generic;
using System.Linq;
class Graph
{
    int V;
    List<int>[] adj;
    Graph(int v)
    {
        V = v;
        adj = new List<int>[v];
        for (int i = 0; i < v; i++)
        {
            adj[i] = new List<int>();
        }
    }
    void AddEdge(int i, int j)
    {
        adj[i].Add(j);
    }
    void DFS(int s)
    {
        bool[] visited = Enumerable.Repeat(false, this.V).ToArray();
        // below is needed for identifying the islands present in the graph.
        // for (int i = 0; i < this.V; i++)
        // {
        //     Console.WriteLine();
        //     if (!visited[i])
        //         DFSUtil(visited, i);
        // }
        DFSUtil(visited, s);
    }
    void DFSUtil(bool[] vis, int s)
    {
        vis[s] = true;
        Console.Write(" " + s);
        foreach (int k in adj[s])
        {
            if (!vis[k])
                DFSUtil(vis, k);
        }
    }
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        Graph g = new Graph(4);

        g.AddEdge(0, 1);
        g.AddEdge(0, 2);
        g.AddEdge(1, 2);
        g.AddEdge(2, 0);
        g.AddEdge(2, 3);
        g.AddEdge(3, 3);

        Console.WriteLine(
            "Following is Depth First Traversal "
            + "(starting from vertex 2)");

        g.DFS(2);

    }
}