using System;
class CheckBST
{
    //Root of the Binary Tree 
    public Node root;

    // To keep tract of previous node
    // in Inorder Traversal
    Node prev;
    
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
    /* returns true if given search tree is binary 
     search tree (efficient version) */
    public virtual bool BST
    {
        get
        {
            return isBST(root);
        }
    }
    /* Returns true if given search tree is binary
    search tree (efficient version) */
    Boolean isBST(Node node)
    {
        if(node!=null)
        {
            // you should just check here as you need to continue
            // checking the current node and its right.
            if(!isBST(node.left)) 
                return false;
            
            if(prev!=null && node.data<prev.data)
                return false;
            prev = node;
            
            return isBST(node.right);
        }
        return true;
    }

    public static void Main(String[] args)
    {
        CheckBST tree = new CheckBST();
        tree.root = new Node(4);
        tree.root.left = new Node(2);
        tree.root.right = new Node(5);
        tree.root.left.left = new Node(1);
        tree.root.left.right = new Node(3);

        if (tree.BST)
        {
            Console.WriteLine("IS BST");
        }
        else
        {
            Console.WriteLine("Not a BST");
        }
    }
}