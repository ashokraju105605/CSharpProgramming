using System;
class ConnectSameLevel
{
    public class Node
    {
        public int data;
        public Node left, right, nextRight;

        public Node(int item)
        {
            data = item;
            left = right = nextRight = null;
        }
    }
    public Node root;
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        ConnectSameLevel tree = new ConnectSameLevel();
        tree.root = new Node(10);
        tree.root.left = new Node(8);
        tree.root.right = new Node(2);
        tree.root.left.left = new Node(3);
        tree.root.right.right = new Node(90);

        // Populates nextRight pointer in all nodes  
        //tree.connectRecur(tree.root);

        // Iterative method is easy to conprehend and works on level one by one in connecting starting from root level to leaves.
        tree.connect(tree.root);

        // Let us check the values of nextRight pointers  
        int a = tree.root.nextRight != null ? tree.root.nextRight.data : -1;
        int b = tree.root.left.nextRight != null ? tree.root.left.nextRight.data : -1;
        int c = tree.root.right.nextRight != null ? tree.root.right.nextRight.data : -1;
        int d = tree.root.left.left.nextRight != null ? tree.root.left.left.nextRight.data : -1;
        int e = tree.root.right.right.nextRight != null ? tree.root.right.right.nextRight.data : -1;

        // Now lets print the values  
        Console.WriteLine("Following are populated nextRight pointers in the tree(-1 is printed if there is no nextRight)");
        Console.WriteLine("nextRight of " + tree.root.data + " is " + a);
        Console.WriteLine("nextRight of " + tree.root.left.data + " is " + b);
        Console.WriteLine("nextRight of " + tree.root.right.data + " is " + c);
        Console.WriteLine("nextRight of " + tree.root.left.left.data + " is " + d);
        Console.WriteLine("nextRight of " + tree.root.right.right.data + " is " + e);
    }
    public void connectRecur(Node r)
    {

    }
    public Node getNextRight(Node t)
    {
        Node temp = t;
        temp = temp.nextRight; // as we need to connect the requesting child to the next right child.
        while (temp != null)
        {
            if (temp.left != null)
                return temp.left;
            if (temp.right != null)
                return temp.right;
            else
                temp = temp.nextRight;

        }
        return null;
    }
    public void connect(Node r)
    {
        if (r == null)
            return;

        r.nextRight = null;
        Node p = r; // level start node to work with.
        while (p != null)
        {
            Node q = p; // for iterating and finishing the level.
            while (q != null)
            {
                if (q.left != null)
                {
                    if (q.right != null)
                        q.left.nextRight = q.right;
                    else
                        q.left.nextRight = getNextRight(q);
                    //q = getNextRight(q);
                }
                if (q.right != null) // writing else if here is incorrect, as weneed to connect the right for both left child, right child.
                {
                    q.right.nextRight = getNextRight(q);
                    //q = getNextRight(q);
                }
                //q = getNextRight(q); // incorrect.
                q = q.nextRight;
            }
            //p = p.left; // incorrect
            if (p.left != null)
                p = p.left;
            else if (p.right != null) // need to have else if here, as we only need to choose once case, not check both and pick the last one.
                p = p.right;
            else
                p = getNextRight(p);
        }
    }
}