using System;
using System.Collections.Generic;
class Kruskal
{
    int V;
    Edge[] edge;
    public Kruskal(int v, int e)
    {
        V = v;
        edge = new Edge[e];
        for (int i = 0; i < e; i++)
        {
            edge[i] = new Edge();
        }
    }
    class subset
    {
        public int parent, rank;
    }
    int Find(subset[] x, int i)
    {
        if (x[i].parent != i)
            x[i].parent = Find(x, x[i].parent);
        return x[i].parent;
    }
    void Union(subset[] s, int x, int y)
    {
        int xindex = Find(s, x);
        int yindex = Find(s, y);
        // did a mistake by check the s[x].rank < s[y].rank , it should be with the found indices instead. should check the ranks of roots of subtrees.
        if (s[xindex].rank < s[yindex].rank)
            s[xindex].parent = yindex;  // mistake here as well, we should join the 2 subtrees not the nodes.
        else if (s[xindex].rank > s[yindex].rank)
            s[yindex].parent = xindex;
        else
        {
            s[yindex].parent = xindex;
            s[xindex].rank++;
        }
    }
    class Edge : IComparable<Edge>
    {
        public int src, dest, weight;
        public int CompareTo(Edge x)
        {
            return weight - x.weight;
        }
    }
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        /* Let us create following weighted graph
        10
    0--------1
    | \ |
    6| 5\ |15
    | \ |
    2--------3
        4 */
        int V = 4; // Number of vertices in graph
        int E = 5; // Number of edges in graph
        Kruskal graph = new Kruskal(V, E);

        // add edge 0-1
        graph.edge[0].src = 0;
        graph.edge[0].dest = 1;
        graph.edge[0].weight = 10;

        // add edge 0-2
        graph.edge[1].src = 0;
        graph.edge[1].dest = 2;
        graph.edge[1].weight = 6;

        // add edge 0-3
        graph.edge[2].src = 0;
        graph.edge[2].dest = 3;
        graph.edge[2].weight = 5;

        // add edge 1-3
        graph.edge[3].src = 1;
        graph.edge[3].dest = 3;
        graph.edge[3].weight = 15;

        // add edge 2-3
        graph.edge[4].src = 2;
        graph.edge[4].dest = 3;
        graph.edge[4].weight = 4;

        // Function call
        graph.KruskalMST();
    }
    void KruskalMST()
    {
        Edge[] result = new Edge[V - 1];
        subset[] s = new subset[V];

        for (int i = 0; i < s.Length; i++)
        {
            s[i] = new subset();
            s[i].parent = i;
            s[i].rank = 0;
        }

        Array.Sort(edge);
        int k = 0;
        for (int i = 0; i < edge.Length && k < result.Length; i++)
        {
            Edge e = edge[i];
            int xindex = Find(s, e.src);
            int yindex = Find(s, e.dest);
            if (xindex != yindex)
            {
                result[k++] = e; // forgot to put the k++
                Union(s, e.src, e.dest);
            }

        }

        // print the contents of result[] to display
        // the built MST
        Console.WriteLine("Following are the edges in "
                          + "the constructed MST");

        int minimumCost = 0;
        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine(result[i].src + " -- "
                              + result[i].dest
                              + " == " + result[i].weight);
            minimumCost += result[i].weight;
        }

        Console.WriteLine("Minimum Cost Spanning Tree "
                          + minimumCost);
    }
}