using System;
class Diameter
{
    //similar to maxPathSum problem, but here instead of node.data, we are taking 1;
    public class Node
    {
        public int data;
        public Node left, right;
    }
    static Node newNode(int data)
    {
        Node node = new Node();
        node.data = data;
        node.left = null;
        node.right = null;

        return (node);
    }
    public static void main(String[] args)
    {
        int result = 0;
        Console.WriteLine("Jai Shree Ram");
        Node root = newNode(1);
        root.left = newNode(2);
        root.right = newNode(3);
        root.left.left = newNode(4);
        root.left.right = newNode(5);

        diameter(root, ref result);
        Console.WriteLine("Diameter is " + result);
    }
    public static int diameter(Node r, ref int res)
    {
        if (r == null)
            return 0;
        else if (r.left == null && r.right == null)
            return 1;
        else
        {
            int left = diameter(r.left, ref res);
            int right = diameter(r.right, ref res);
            res = Math.Max(res, left + right + 1);
            return 1 + Math.Max(left, right);
        }
        //return -1;
    }
}