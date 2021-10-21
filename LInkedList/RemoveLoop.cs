using System;
using System.Collections.Generic;
class RemoveLoop
{
    public Node head;

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

        RemoveLoop list = new RemoveLoop();
        list.head = new Node(50);
        list.head.next = new Node(20);
        list.head.next.next = new Node(15);
        list.head.next.next.next = new Node(4);
        list.head.next.next.next.next = new Node(10);

        // Creating a loop for testing
        list.head.next.next.next.next.next = list.head.next.next;
        list.detectAndRemoveLoop(list.head);
        Console.WriteLine("Linked List after removing loop : ");
        list.printList(list.head);
    }
    // Function that detects loop in the list
    void detectAndRemoveLoop(Node node)
    {
        if (node == null || node.next == null)
        {
            Console.WriteLine(" only 2 elements in list ");
            return;
        }
        //detect by rabbit, hare or floyd 
        Node fast = node.next.next;
        Node slow = node.next;

        while (fast.next != null && slow != null)
        {
            if (slow == fast)
                break;
            fast = fast.next.next;
            slow = slow.next;
        }

        Node start = node;
        while (start.next != slow.next)
        {
            slow = slow.next;
            start = start.next;
        }
        Console.WriteLine("loop start is " + slow.next.data);
        slow.next = null; // remove loop



    }
    // Function to print the linked list
    void printList(Node node)
    {
        while (node != null)
        {
            Console.Write(node.data + " ");
            node = node.next;
        }
    }
}