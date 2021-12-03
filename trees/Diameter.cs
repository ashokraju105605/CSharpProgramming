using System;
class Diameter
{
    //similar to maxPathSum problem, but here instead of node.data, we are taking 1;
    public class Node
    {
        public int data;
        public Node left, right;
    }
    static int res;
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

        int h = diameter(root, ref result);
        Console.WriteLine("Diameter is " + result);

        Tuple<int> t = Dia(root);
        Console.WriteLine("Diameter is " + res);
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
    public static Tuple<int> Dia(Node r)
    {
        if(r==null)
            return Tuple.Create(0);
        else
        {
            Tuple<int> t, t1;

                t = Dia(r.left);
                t1 = Dia(r.right);
            res = Math.Max(t.Item1+t1.Item1+1,res);
            return Tuple.Create(Math.Max(t.Item1,t1.Item1)+1);
        }
    }
}