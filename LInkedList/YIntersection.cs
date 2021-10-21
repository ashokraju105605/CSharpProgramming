using System;
using System.Collections.Generic;

class YIntersection
{
    public class Node
    {
        public int data;
        public Node next;
        public Node(int d)
        {
            data = d;
            next = null;
        }
    }
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        // list 1
        Node n1 = new Node(1);
        n1.next = new Node(2);
        n1.next.next = new Node(3);
        n1.next.next.next = new Node(4);
        n1.next.next.next.next = new Node(5);
        n1.next.next.next.next.next = new Node(6);
        n1.next.next.next.next.next.next = new Node(7);
        // list 2
        Node n2 = new Node(10);
        n2.next = new Node(9);
        n2.next.next = new Node(8);
        n2.next.next.next = n1.next.next.next;
        Print(n1);
        Print(n2);
        Node mergeNode = MergeNode(n1, n2);
        string result = mergeNode != null ? mergeNode.data.ToString() : "No Merge Node Exist";
        Console.WriteLine(result);
    }
    // function to print the list
    public static void Print(Node n)
    {
        Node cur = n;
        while (cur != null)
        {
            Console.Write(cur.data + " ");
            cur = cur.next;
        }
        Console.WriteLine();
    }
    public static Node MergeNode(Node n1, Node n2)
    {
        HashSet<Node> hs = new HashSet<Node>();
        Node one = n1;
        while (one != null)
        {
            hs.Add(one);
            one = one.next;
        }
        Node two = n2;
        while (two != null)
        {
            if (hs.Contains(two))
            {
                return two;
            }
            two = two.next;
        }
        return null;
    }
}