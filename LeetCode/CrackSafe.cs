using System;
using System.Collections.Generic;

public class CrackSafe
{
    string ans;
    HashSet<string> hs;
    public string CrackSafeCode(int n, int k)
    {
        string start = "";
        ans = "";
        hs = new HashSet<string>();

        if (n == 1 && k == 1)
            return "0";

        for (int i = 0; i < n - 1; i++)
            start += "0";
        dfs(start, k);

        return ans + start;
    }
    public void dfs(string start, int k)
    {
        for (int i = 0; i < k; i++)
        {
            string temp = start + i;
            if (!hs.Contains(temp))
            {
                hs.Add(temp);
                dfs(temp.Substring(1), k);
                ans += i;
            }
        }
    }
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        CrackSafe cs = new CrackSafe();
        Console.WriteLine(cs.CrackSafeCode(1, 2));
        Console.WriteLine(cs.CrackSafeCode(2, 2));
        Console.WriteLine(cs.CrackSafeCode(2, 3));
        Console.WriteLine(cs.CrackSafeCode(2, 4));
    }

    // think edges as not the k transitions , but k state values from a node. 
    // so covering all edges and the resultant string will be the required answer.
    // so there will be 2^n edges and 1 positional value change between edge movements.

    // we should record which num at a position took us to a new unique state. list of all this is the answer.
    // draw out the dfs traversal graph to figure out.try out for n=2 and k=2
    // we are recording things after subtree traversal is done. so we are adding initial n-1 state after returning.

    // least significant position is the one that keep on changing all possible values to lead to new state.
}