using System;
using System.Linq;
class LongestSubstrWithoutRepeat
{
    public static void main(String[] args)
    {
        string str = "geeksforgeeks";
        LongestSubstrWithoutRepeat lswr = new LongestSubstrWithoutRepeat();
        lswr.longest(str);
    }
    void longest(string str)
    {
        int[] lastIndex = Enumerable.Repeat(-1, 256).ToArray();
        int start = 0;
        int maxlength = 1;
        for (int i = 0; i < str.Length; i++)
        {
            start = start > lastIndex[str[i]] + 1 ? start : lastIndex[str[i]] + 1;
            maxlength = maxlength > i - start + 1 ? maxlength : i - start + 1;
            lastIndex[str[i]] = i;
        }
        Console.WriteLine("maxlength of longest substring without repeast is : " + maxlength);
    }
}
/*
mistakes:
didn't add the +1 to lastIndex[str[i]], needed otherwise it will include the repeat character index also into the count.
*/