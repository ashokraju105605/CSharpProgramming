using System;
class LeftViewTree
{
    // Binary tree node
    public class Node
    {
        public int data;
        public Node left, right;

        public Node(int data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
        }
    }
    public Node root;
    public static int max_level = 0;
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        /* creating a binary tree and entering the nodes */
        LeftViewTree tree = new LeftViewTree();
        tree.root = new Node(12);
        tree.root.left = new Node(10);
        tree.root.right = new Node(30);
        tree.root.right.left = new Node(25);
        tree.root.right.right = new Node(40);

        tree.leftView();
    }

    // A wrapper over leftViewUtil()
    public virtual void leftView()
    {
        leftViewUtil(root, 1);
    }

    // recursive function to print left view
    public virtual void leftViewUtil(Node node, int level)
    {
        if (level > max_level)
        {
            Console.WriteLine(node.data);
            max_level = level;
        }
        if (node.left != null)
            leftViewUtil(node.left, level + 1);
        if (node.right != null)
            leftViewUtil(node.right, level + 1);
    }
}