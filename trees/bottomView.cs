using System;
using System.Collections.Generic;
class bottomView
{
    public class Node
    {
        public int data;
        public Node left, right;
        public int hd; // because we are not recursing to pass as parameter to the recursion function. atleast the horizontal distance or the level should be 
                       // saved with the node. as we are using level order travesal of tree using queue, don't need to maintain the lelel in the node.

        public Node(int data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
            this.hd = 1000000;
        }
    }
    public Node root;
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        Node root = new Node(20);
        root.left = new Node(8);
        root.right = new Node(22);
        root.left.left = new Node(5);
        root.left.right = new Node(3);
        root.right.left = new Node(4);
        root.right.right = new Node(25);
        root.left.right.left = new Node(10);
        root.left.right.right = new Node(14);
        bottomView tree = new bottomView();
        tree.root = root;

        Console.WriteLine("Bottom view of the " +
                        "given binary tree:");

        tree.botView();
    }
    // you don't need to pass level param if using bfs, as it is level order traversal
    // higher levels after lower levels
    // and hd is soted in the node itself so no need to pass as param.
    public void botView()
    {
        Queue<Node> q = new Queue<Node>();
        SortedDictionary<int, int> map = new SortedDictionary<int, int>(); // hd, node value
        root.hd = 0;
        q.Enqueue(root);
        while (q.Count != 0)
        {
            Node temp = q.Dequeue();
            //map.Add(temp.hd, temp.data); // if you do like this you will get error "An item with the same key has already been added."
            map[temp.hd] = temp.data; // works for both create, update. where as above only works for create, not for update.

            if (temp.left != null)
            {
                temp.left.hd = temp.hd - 1;
                q.Enqueue(temp.left);
            }
            if (temp.right != null)
            {
                temp.right.hd = temp.hd + 1;
                q.Enqueue(temp.right);
            }

        }
        foreach (int x in map.Values)
            Console.WriteLine(x);

    }
}