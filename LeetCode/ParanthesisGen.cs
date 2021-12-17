using System;
using System.Collections.Generic;
public class ParanthesisGen
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        ParanthesisGen pg = new ParanthesisGen();
        pg.GenerateParenthesis(2);
    }

    public IList<string> GenerateParenthesis(int n)
    {
        IList<string> output = new List<string>();
        backtrack(output, "", 0, 0, n);
        return output;
    }
    public void backtrack(IList<string> output, string current, int open, int close, int max)
    {
        if (current.Length == max * 2)
        {
            output.Add(current);
            return;
        }
        if (open < max) backtrack(output, current + "(", open + 1, close, max);
        if (close < open) backtrack(output, current + ")", open, close + 1, max);
    }
}