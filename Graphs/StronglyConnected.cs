using System;
using System.Collections.Generic;
using System.Linq;
class Graph5
{
    int V;
    List<int>[] adj;
    Graph5(int v)
    {
        V = v;
        adj = new List<int>[v];
        for (int i = 0; i < v; i++)
        {
            adj[i] = new List<int>();
        }
    }
    void addEdge(int i, int j)
    {
        adj[i].Add(j);
    }
    // Driver method 
    public static void main(String[] args)
    {
        // Create a graph given in the above diagram 
        Graph5 g = new Graph5(5);
        g.addEdge(1, 0);
        g.addEdge(0, 2);
        g.addEdge(2, 1);
        g.addEdge(0, 3);
        g.addEdge(3, 4);

        Console.WriteLine("Following are strongly connected components " +
                           "in given graph ");
        g.printSCCs();
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
    Graph5 Transpose()
    {
        Graph5 t = new Graph5(V);
        for (int i = 0; i < V; i++)
        {
            foreach (int x in adj[i])
                t.addEdge(x, i);
        }
        return t;
    }
    void topologicalSortUtil(int s, bool[] vis, Stack<int> st)
    {
        vis[s] = true;
        foreach (int x in adj[s])
        {
            if (!vis[x])
                topologicalSortUtil(x, vis, st);
        }
        st.Push(s);
    }
    void printSCCs()
    {
        Stack<int> st = new Stack<int>();
        bool[] vis = Enumerable.Repeat(false, V).ToArray();

        for (int i = 0; i < V; i++)
            if (!vis[i])
                topologicalSortUtil(i, vis, st);

        Graph5 gt = Transpose();

        bool[] visited = new bool[V];
        Array.Fill(visited, false);

        while (st.Count != 0)
        {
            int x = st.Pop();
            // do it only for non-visited stack nodes, otherwise would print the first node unnecessarily as DFS blindly prints the first node.
            if (!visited[x])
            {
                gt.DFSUtil(visited, x);
                Console.WriteLine();
            }
        }

    }
}