using System;
class BTtoDLL
{
    /* Structure for tree and Linked List */
    public class Node
    {
        public int data;
        public Node left, right;

        public Node(int data)
        {
            this.data = data;
            left = right = null;
        }
    }
    public Node root;
    public Node head;
    public static void main(String[] args)
    {
        /* Constructing below tree  
            5  
            / \  
            3     6  
        / \     \  
        1 4     8  
        / \     / \  
        0 2     7 9 */

        BTtoDLL tree = new BTtoDLL();
        tree.root = new Node(5);
        tree.root.left = new Node(3);
        tree.root.right = new Node(6);
        tree.root.left.right = new Node(4);
        tree.root.left.left = new Node(1);
        tree.root.right.right = new Node(8);
        tree.root.left.left.right = new Node(2);
        tree.root.left.left.left = new Node(0);
        tree.root.right.right.left = new Node(7);
        tree.root.right.right.right = new Node(9);

        tree.BToDLL(tree.root);
        tree.printList(tree.head);

    }
    public void BToDLL(Node r)
    {
        if (r == null)
            return;
        BToDLL(r.right);
        r.right = head;
        if (head != null) // missed this condition, even without this it should print the list by traversing the right nodes.
            head.left = r;
        head = r;

        BToDLL(r.left);
    }
    // Utility function for printing double linked list. 
    public virtual void printList(Node head)
    {
        Console.WriteLine("Extracted Double "
                          + "Linked List is : ");
        while (head != null)
        {
            Console.Write(head.data + " ");
            head = head.right;
        }
    }
}