using System;
class MakePalindrome
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        string str = "geeks";
        MakePalindrome mp = new MakePalindrome();
        mp.countInsertions(str);
    }
    void countInsertions(string str)
    {
        int[,] table = new int[str.Length, str.Length];
        for (int gap = 1; gap < str.Length; gap++)
            for (int i = 0, j = gap; j < str.Length; i++, j++)
            {
                table[i, j] = str[i] == str[j] ? table[i + 1, j - 1] : Math.Min(table[i, j - 1], table[i + 1, j]) + 1;
            }



        Console.WriteLine(table[0, str.Length - 1]);
    }
}

/*
mistakes:
1. wrote gap<str.Length -1
2. wrote i < str.Length && j< str.Length, i condition causes failures.

*/