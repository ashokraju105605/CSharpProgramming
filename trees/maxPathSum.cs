using System;

// find max path sum between two leaves of a binary tree.
class BinaryTree
{
    public class Node
    {

        public int data;
        public Node left, right;

        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }
    // same as height balanced check, but instead of 1, we use node.data and max of left or right path , until the point where both the childs give a value.
    public static Node root;

    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        BinaryTree tree = new BinaryTree();
        BinaryTree.root = new Node(-15);
        BinaryTree.root.left = new Node(5);
        BinaryTree.root.right = new Node(6);
        BinaryTree.root.left.left = new Node(-8);
        BinaryTree.root.left.right = new Node(1);
        BinaryTree.root.left.left.left = new Node(2);
        BinaryTree.root.left.left.right = new Node(6);
        BinaryTree.root.right.left = new Node(3);
        BinaryTree.root.right.right = new Node(9);
        BinaryTree.root.right.right.right = new Node(0);
        BinaryTree.root.right.right.right.left = new Node(4);
        BinaryTree.root.right.right.right.right = new Node(-1);
        BinaryTree.root.right.right.right.right.left = new Node(10);
        int result = 0;
        tree.maxPathSum(root, ref result);
        Console.WriteLine("Max pathSum of the given binary tree is " + result);

        Tuple<int, int> t = tree.maxPathSum1(root);
        Console.WriteLine("Max pathSum of the given binary tree is " + t.Item1);
    }
    public int maxPathSum(Node r, ref int res)
    {
        if (r == null)
            return 0;
        else if (r.left == null && r.right == null)
            return r.data;
        else
        {
            int leftsum = maxPathSum(r.left, ref res);
            int rightsum = maxPathSum(r.right, ref res);
            res = Math.Max(res, r.data + leftsum + rightsum);
            return r.data + Math.Max(leftsum, rightsum);
        }
    }

    public Tuple<int, int> maxPathSum1(Node r)
    {
        if (r == null)
            return Tuple.Create(0, 0);
        else if (r.left == null && r.right == null)
            return Tuple.Create(r.data, r.data);
        else
        {
            Tuple<int, int> leftsum = maxPathSum1(r.left);
            Tuple<int, int> rightsum = maxPathSum1(r.right);
            int res = Math.Max(Math.Max(leftsum.Item1, rightsum.Item1), r.data + leftsum.Item2 + rightsum.Item2);
            return Tuple.Create(res, r.data + Math.Max(leftsum.Item2, rightsum.Item2));
        }
    }
}