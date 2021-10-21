using System;
using System.Collections.Generic;
class LRUCache
{
    class Node
    {
        public int k;
        public int v;
        public Node l;
        public Node r;
        public Node(int key, int val)
        {
            k = key;
            v = val;
            l = null;
            r = null;
        }

    }
    public int capacity;
    Dictionary<int, Node> hm;
    Node head;
    Node tail;
    public LRUCache(int c)
    {
        capacity = c;
        hm = new Dictionary<int, Node>();
        head = null;
        tail = null;
    }
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        Console.WriteLine("Going to test the LRU " +
                           " Cache Implementation");
        LRUCache cache = new LRUCache(2);

        // it will store a key (1) with value 
        // 10 in the cache.
        cache.set(1, 10);

        // it will store a key (1) with value 10 in the cache.
        cache.set(2, 20);
        Console.WriteLine("Value for the key: 1 is " +
                           cache.get(1)); // returns 10

        // evicts key 2 and store a key (3) with
        // value 30 in the cache.
        cache.set(3, 30);

        Console.WriteLine("Value for the key: 2 is " +
                cache.get(2)); // returns -1 (not found)

        // evicts key 1 and store a key (4) with
        // value 40 in the cache.
        cache.set(4, 40);
        Console.WriteLine("Value for the key: 1 is " +
               cache.get(1)); // returns -1 (not found)
        Console.WriteLine("Value for the key: 3 is " +
                           cache.get(3)); // returns 30
        Console.WriteLine("Value for the key: 4 is " +
                           cache.get(4)); // return 40
    }
    //using Doubly linked list and hash.
    // in Java LinkedHashMap library API solves this directly.
    public void set(int k, int v)
    {
        if (hm.ContainsKey(k))
        {
            // this case is same as get case, but need to update the value in the Node.
            Node temp = hm[k];
            if (head != temp)
            {
                Node prev = temp.l;
                Node next = temp.r;
                prev.r = next;
                if (next != null)
                    next.l = prev;
                else
                {
                    tail = prev;
                }
                temp.l = null;
                temp.r = head;
                head.l = temp;
                head = temp;
            }
            temp.v = v;
        }
        else
        {
            if (hm.Count < capacity)
            {
                Node t = new Node(k, v);
                hm.Add(k, t);
                t.r = head;
                if (head != null)
                    head.l = t;
                else
                    tail = t;
                head = t;
            }
            else
            {
                Node t = tail;
                hm.Remove(t.k);
                Node prev = t.l;
                if (prev != null)
                {
                    prev.r = null;
                    tail = prev;
                }
                else
                {
                    // should not be the case , because the capacity is full. or capacity has to be 1 for this case.
                    head = null;
                }
                t.l = null;

                Node p = new Node(k, v);
                p.r = head;
                if (head != null)
                {
                    head.l = p;
                }
                else
                {
                    tail = p;
                }
                head = p;
                hm.Add(k, p);
            }
        }


    }
    public int get(int k)
    {
        if (hm.ContainsKey(k))
        {
            Node temp = hm[k];
            if (head != temp)
            {
                Node prev = temp.l;
                Node next = temp.r;
                prev.r = next;
                if (next != null)
                    next.l = prev;
                else
                {
                    tail = prev;
                }
                temp.l = null;
                temp.r = head;
                head.l = temp;
                head = temp;
            }
            Console.WriteLine("Got the value: " + temp.v + " for the key " + k);
            return temp.v;
        }
        else
        {
            Console.WriteLine("did not get any value for the key " + k);
            return -1;
        }
    }

}

// one easy way to implement this is to directly use the LinkedList<int,int> datastructure for removing from end and adding from the start.
// but this won't give the O(1) removal and addition of nodes. so implemented it intentionally.