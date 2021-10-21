using System;
using System.Collections.Generic;
using System.Linq;
class Graph3
{
    int V;
    List<int>[] adj;
    Graph3(int v)
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
    bool isCyclic()
    {
        bool[] visited = Enumerable.Repeat(false, this.V).ToArray();

        for (int i = 0; i < V; i++)
        {
            if (!visited[i])
            {
                List<int> Rec = new List<int>();
                if (isCyclicUtil(i, visited, Rec))
                    return true;
            }
        }
        return false;
    }
    bool isCyclicUtil(int s, bool[] vis, List<int> rec)
    {
        vis[s] = true;
        rec.Add(s);
        foreach (int x in adj[s])
        {
            if (!vis[x])
            {
                if (isCyclicUtil(x, vis, rec))
                    return true;
            }
            else if (rec.Contains(x))
                return true;
        }
        rec.Remove(s);
        return false;
    }
    // Driver code 
    public static void main(String[] args)
    {
        Graph3 graph = new Graph3(4);
        graph.addEdge(0, 1);
        graph.addEdge(0, 2);
        graph.addEdge(1, 2);
        graph.addEdge(2, 0);
        graph.addEdge(2, 3);
        graph.addEdge(3, 3);

        if (graph.isCyclic())
            Console.WriteLine("Graph contains cycle");
        else
            Console.WriteLine("Graph doesn't "
                                    + "contain cycle");
    }
}

/**
forgot to set the rec.Remove(s); as we need to maintain the only current chain of recursion stack.
take careful look at how the if(func()) is used, because we don't want to terminate the processing if value is false.
and in util as we want to terminate the flow, we directly linked return with the recursive function.
*/