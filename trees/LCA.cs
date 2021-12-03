using System;
class LCA
{
    public class Node
    {
        public int data;
        public Node left, right;

        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }
    public Node root;
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        // Let us construct the BST shown in the above figure  
        LCA tree = new LCA();
        tree.root = new Node(20);
        tree.root.left = new Node(8);
        tree.root.right = new Node(22);
        tree.root.left.left = new Node(4);
        tree.root.left.right = new Node(12);
        tree.root.left.right.left = new Node(10);
        tree.root.left.right.right = new Node(14);

        int n1 = 10, n2 = 14;
        Node t = tree.lca(tree.root, n1, n2);
        Console.WriteLine("LCA of " + n1 + " and " + n2 + " is " + t.data);

        n1 = 14;
        n2 = 8;
        t = tree.lca1(tree.root, n1, n2);
        Console.WriteLine("LCA of " + n1 + " and " + n2 + " is " + t.data);

        n1 = 10;
        n2 = 22;
        t = tree.lca1(tree.root, n1, n2);
        Console.WriteLine("LCA of " + n1 + " and " + n2 + " is " + t.data);
    }
    public Node lca(Node r, int x, int y)
    {
        if (r == null)
            return null;
        if (r.data == x || r.data == y)
            return r;
        else if (r.left == null && r.right == null)
            return null;

        Node left = lca(r.left, x, y);
        Node right = lca(r.right, x, y);

        if (left != null && right != null)
            return r;
        else if (left != null)
            return left;
        else
            return right;
    }
    public Node lca1(Node node, int n1, int n2)
    {
        if (node == null)
        {
            return null;
        }

        // If both n1 and n2 are smaller than root, then LCA lies in left  
        if (/*node.data > n1 && */node.data > Math.Max(n1,n2)) // you can use code in comments if you don't to order of n1,n2.
        {
            return lca1(node.left, n1, n2);
        }
        // If both n1 and n2 are greater than root, then LCA lies in right  
        else if (node.data < Math.Min(n1,n2))// && node.data < n2)
        {
            return lca1(node.right, n1, n2);
        }
        else
            return node;

        //iterative implementation can be done in this same fashion with a while loop
    }
}