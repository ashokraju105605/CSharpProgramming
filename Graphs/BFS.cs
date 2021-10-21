using System;
using System.Collections.Generic;
using System.Linq;
class Graph1
{
    int V;
    List<int>[] adj;
    Graph1(int v)
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
    void BFS(int s)
    {
        LinkedList<int> q = new LinkedList<int>();
        bool[] visited = Enumerable.Repeat(false, V).ToArray();

        q.AddLast(s);
        visited[s] = true;

        while (q.Count != 0)
        {
            int x = q.First();
            Console.Write(" " + x);
            q.RemoveFirst();

            foreach (int i in adj[x])
            {
                if (!visited[i])
                {
                    q.AddLast(i);
                    visited[i] = true;
                }
            }
        }
    }
    // Driver code
    static void main(string[] args)
    {
        Graph1 g = new Graph1(4);

        g.AddEdge(0, 1);
        g.AddEdge(0, 2);
        g.AddEdge(1, 2);
        g.AddEdge(2, 0);
        g.AddEdge(2, 3);
        g.AddEdge(3, 3);

        Console.Write("Following is Breadth First " +
                    "Traversal(starting from " +
                    "vertex 2)\n");
        g.BFS(2);
    }
}

/**
RemoveFirst() doesn't return anything , so First() needs to be used to read the first element of the Queue.
we mark nodes as visited before we place them for processing in the Queue for BFS unlike DFS where during processing it is marked.(both ways should give the same results though)
understand the usage of LinkedList data structure as Double Ended queue.
Enumerable.Repeat in System.Linq for setting an array object with default values for elements.
*/