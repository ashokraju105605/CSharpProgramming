using System;
using System.Collections.Generic;
using System.Linq;
class Graph2
{
    int V;
    List<int>[] adj;
    Graph2(int v)
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
        adj[j].Add(i);
    }
    bool isCyclic()
    {
        bool[] visited = Enumerable.Repeat(false, V).ToArray();

        for (int i = 0; i < V; i++)
        {
            if (!visited[i])
                if (CyclicUtil(i, visited, -1))
                    return true;
        }

        return false;
    }
    bool CyclicUtil(int s, bool[] vis, int parent)
    {
        vis[s] = true;
        foreach (int x in adj[s])
        {
            if (!vis[x])
            {
                // we do return case wise, because cycle detected can be returned
                // then and there, whereas cycle not detected should be searched further.
                if (CyclicUtil(x, vis, s))
                    return true;
            }
            else if (x != parent)
                return true;
        }
        return false;
    }

    // Driver Code
    public static void main(String[] args)
    {
        // Create a graph given in the above diagram
        Graph2 g1 = new Graph2(5);
        g1.addEdge(1, 0);
        g1.addEdge(0, 2);
        g1.addEdge(2, 1);
        g1.addEdge(0, 3);
        g1.addEdge(3, 4);
        if (g1.isCyclic())
            Console.WriteLine("Graph contains cycle");
        else
            Console.WriteLine("Graph doesn't contains cycle");

        Graph2 g2 = new Graph2(3);
        g2.addEdge(0, 1);
        g2.addEdge(1, 2);
        if (g2.isCyclic())
            Console.WriteLine("Graph contains cycle");
        else
            Console.WriteLine("Graph doesn't contains cycle");
    }
}

/**
missed taking care of parent and child relationship, otherwise just says cyclic when visited node is encountered, 
where visited node is just maintained to not explore that further.
as a->b and b->a exists, we need to eliminate the cycles between 2 edges as it is undirected graph, so we need to know from which parent it came
if it is not immediate parent but visited only then there is a cycle.
*/