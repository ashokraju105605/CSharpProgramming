using System;
class HeightBalancedBT
{
    public class Node
    {

        public int data;
        public Node left, right;

        public Node(int d)
        {
            data = d;
            left = right = null;
        }
    }
    // A wrapper class used to modify height across 
    // recursive calls. 
    public class Height
    {
        public int height = 0;
    }
    public Node root;
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        Height height = new Height();

        /* Constructed binary tree is  
                   1  
                 /   \  
                2      3  
              /  \    /  
            4     5  6  
            /  
           7         */
        HeightBalancedBT tree = new HeightBalancedBT();
        tree.root = new Node(1);
        tree.root.left = new Node(2);
        tree.root.right = new Node(3);
        tree.root.left.left = new Node(4);
        tree.root.left.right = new Node(5);
        tree.root.right.right = new Node(6);
        tree.root.left.left.left = new Node(7);

        if (tree.isBalanced(tree.root, height))
        {
            Console.WriteLine("Tree is balanced");
        }
        else
        {
            Console.WriteLine("Tree is not balanced");
        }
    }
    public bool isBalanced(Node r, Height h)
    {
        Height lh = new Height();
        Height rh = new Height();

        // if (r.right == null && r.left == null)
        // {
        //     h.height = 1;
        //     return true;
        // }  // there is a difficulty in doing like this because , you need to initialize the results of lb,rb which can lead to false results due to chosen defaults 
        // unnecessarily.

        if (r == null)
        {
            h.height = 0;
            return true;
        }

        bool lb = isBalanced(r.left, lh);
        bool rb = isBalanced(r.right, rh);


        h.height = 1 + Math.Max(lh.height, rh.height);
        if (Math.Abs(lh.height - rh.height) > 1)
        {

            return false;
        }
        else
        {
            return lb && rb; // wrote a wrong case of static true;
        }
    }
}