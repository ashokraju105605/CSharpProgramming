using System;
using System.Collections.Generic;
class generateIP
{
    static List<String> sols = new List<String>();
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        restoreIpAddresses("25525511135");
    }
    static void restoreIpAddresses(String s)
    {
        if (s.Length < 3 || s.Length > 12)
            return;
        printSol(s);

    }
    static void printSol(String s)
    {
        string temp = "";
        for (int i = 1; i < s.Length - 2; i++)
            for (int j = i + 1; j < s.Length - 1; j++)
                for (int k = j + 1; k < s.Length; k++)
                {
                    temp = s.Substring(0, i) + "." + s.Substring(i);
                    temp = temp.Substring(0, j + 1) + "." + temp.Substring(j + 1);
                    temp = temp.Substring(0, k + 2) + "." + temp.Substring(k + 2);

                    if (isValid(temp))
                    {
                        sols.Add(temp);
                    }
                    temp = "";
                }
        foreach (String str in sols)  // you can sort these strings if you want.
            Console.WriteLine(str);
    }
    private static bool isValid(String ip)
    {
        string[] a = ip.Split(".");
        foreach (String s in a)
        {
            int i = int.Parse(s);
            if (s.Length > 3 || i < 0 || i > 255)
            {
                return false;
            }
            if (s.Length > 1 && i == 0)
                return false;
            if (s.Length > 1 && i != 0
                && s[0] == '0')
                return false;
        }

        return true;
    }

}