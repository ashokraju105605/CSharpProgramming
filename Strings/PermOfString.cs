using System;
class permstring
{
    public static void main(String[] args)
    {
        String str = "ABC";
        permstring ps = new permstring();
        ps.permute(str, 0);

    }
    void permute(String s, int i)
    {
        if (i == s.Length)
        {
            Console.WriteLine(s);
        }
        else
        {
            for (int j = i; j < s.Length; j++)
            {
                string c = swap(s, i, j);
                permute(c, i + 1);
            }
        }
    }
    string swap(string s, int i, int j)
    {
        char[] copy = s.ToCharArray();
        char t = copy[i];
        copy[i] = copy[j];
        copy[j] = t;
        string c = new string(copy);
        return c;
    }
}