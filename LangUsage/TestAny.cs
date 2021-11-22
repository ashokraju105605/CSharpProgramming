using System;
using System.Collections.Generic;
class Test
{
    public static void main(String[] args)
    {
        //Solution sol = new Solution();
        //IList<IList<string>> temp = sol.WordSquares(new string[] { "abaa", "aaab", "baaa", "aaba" });
        SortedList<ListNode, int> sl = new SortedList<ListNode, int>(new ListComparer());

        sl.Add(new ListNode(8), 0);
        sl.Add(new ListNode(4), 0);
        sl.Add(new ListNode(3), 0);
        sl.Add(new ListNode(1), 0);

        foreach (KeyValuePair<ListNode, int> kvp in sl)
        {
            Console.WriteLine(kvp.Key.val);
        }

        for (int i = 0; i < sl.Count; i++)
        {
            //Console.WriteLine(sl[i].Value);
        }
        ListNode first = sl.Keys[0];
        ListNode last = sl.Keys[sl.Count - 1];
        sl.RemoveAt(0);
        ListNode second = sl.Keys[0];
    }
}
public class ListComparer : IComparer<ListNode>
{
    public int Compare(ListNode l1, ListNode l2)
    {
        return l1.val - l2.val;
    }
}
/**
 * Definition for singly-linked list. **/
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode() { }
    public ListNode(int val) { this.val = val; }
    public ListNode(int val, ListNode next) { this.val = val; this.next = next; }
}
