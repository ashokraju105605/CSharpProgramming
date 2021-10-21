using System;
using System.Collections.Generic;
using System.Linq;
class Graph4
{
    int V;
    List<int>[] adj;
    Graph4(int v)
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
    void topologicalSort()
    {
        bool[] visited = Enumerable.Repeat(false, this.V).ToArray();
        Stack<int> s = new Stack<int>();

        for (int i = 0; i < V; i++)
        {
            if (!visited[i])
                topologicalSortUtil(i, visited, s);
        }
        while (s.Count != 0)
        {
            Console.Write(" " + s.Peek());
            s.Pop();
        }
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
    // Driver method 
    public static void main(String[] args)
    {
        // Create a graph given in the above diagram 
        Graph4 g = new Graph4(6);
        g.addEdge(5, 2);
        g.addEdge(5, 0);
        g.addEdge(4, 0);
        g.addEdge(4, 1);
        g.addEdge(2, 3);
        g.addEdge(3, 1);

        Console.WriteLine(
"Following is a Topological " +
                           "sort of the given graph");
        g.topologicalSort();
    }
}
/**
see the usage of stack to store the visited nodes at the end of processing the recursion func.
so that it comes last while popping.
*/