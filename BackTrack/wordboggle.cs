using System;
class boggle
{
    static int[,] dir = new int[,]{{-1,-1},{-1,0},{-1,1},{0,-1},
                                 {0,1},{1,-1},{1,0},{1,1}};
    class TrieNode
    {
        public bool leaf;
        public TrieNode[] child;
        public TrieNode()
        {
            leaf = false;
            child = new TrieNode[26];
        }
    }
    static void insert(TrieNode root, String s)
    {
        TrieNode temp = root;
        for (int i = 0; i < s.Length; i++)
        {
            int index = s[i] - 'A';
            if (temp.child[index] == null)
            {
                temp.child[index] = new TrieNode();
            }
            temp = temp.child[index];
        }
        temp.leaf = true;
    }
    // function to check that current location
    // (i and j) is in matrix range
    static bool isSafe(int i, int j, bool[,] visited)
    {
        int M = visited.GetLength(0);
        int N = visited.GetLength(1);
        return (i >= 0 && i < M && j >= 0 && j < N && !visited[i, j]);
    }
    public static void Main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        // Let the given dictionary be following
        String[] dictionary = { "GEEKS", "FOR", "QUIZ", "GEE" };

        // root Node of trie
        TrieNode root = new TrieNode();

        // insert all words of dictionary into trie
        int n = dictionary.Length;
        for (int i = 0; i < n; i++)
            insert(root, dictionary[i]);

        char[,] boggle = { { 'G', 'I', 'Z' },
                            { 'U', 'E', 'K' },
                            { 'Q', 'S', 'E' } };
        findWords(boggle, root);
    }
    static void findWords(char[,] b, TrieNode r)
    {
        bool[,] vis = new bool[b.GetLength(0), b.GetLength(1)]; // need this because cannot use the character that is used once.
        String s = "";

        for (int i = 0; i < b.GetLength(0); i++)
            for (int j = 0; j < b.GetLength(1); j++)
            {
                int index = b[i, j] - 'A';
                if (r.child[index] != null) // you can also add isSafe(i,j,vis) here , but not of big use. Just to bring parity of the search condition for recursion same as in the child util function.
                {
                    // for all the boggle intial searches coming from here, vis is always totally false.
                    searchWord(b, i, j, vis, s, r.child[index]);
                }
                s = ""; // s reset for every node in boggle and also the root of trie.
            }
    }
    // think in your own way, and solve it accordingly, it will work.
    // don't need to follow the exactly given solution and understand the working in that way.
    static void searchWord(char[,] b, int i, int j, bool[,] vis, String s, TrieNode r)
    {
        if (r.leaf == true)
            Console.WriteLine(s + b[i, j]);

        TrieNode ch = r.child[b[i, j] - 'A'];
        vis[i, j] = true;
        // safety check ensures indices are within aray bounds.
        for (int k = 0; k < dir.GetLength(0); k++)
        {
            if (isSafe(i + dir[k, 0], j + dir[k, 1], vis) && r.child[b[i + dir[k, 0], j + dir[k, 1]] - 'A'] != null)
                searchWord(b, i + dir[k, 0], j + dir[k, 1], vis, s + b[i, j], r.child[b[i + dir[k, 0], j + dir[k, 1]] - 'A']);
        }

        vis[i, j] = false; // visited reset after work done.

    }
}