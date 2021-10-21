using System;
using System.Collections.Generic;

class SmallestWindow
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        String str = "this is a test string";
        String pat = "tist";
        findsmallwindow(str, pat);
    }
    static void findsmallwindow(String str, String pat)
    {
        int minWindow = int.MaxValue;
        int count = 0;
        int start = 0;
        string matchedString = null;
        if (pat.Length > str.Length)
            Console.WriteLine("Not Possible");

        Dictionary<char, int> hstr = new Dictionary<char, int>();
        Dictionary<char, int> hpat = new Dictionary<char, int>();

        foreach (char c in pat)
            if (hpat.ContainsKey(c))
                hpat[c]++;
            else
                hpat[c] = 1;

        for (int i = 0; i < str.Length; i++)
        {
            if (hstr.ContainsKey(str[i]))
                hstr[str[i]]++;
            else
                hstr[str[i]] = 1;

            if (pat.IndexOf(str[i]) >= 0)
                if (hstr[str[i]] <= hpat[str[i]])
                    count++;
            if (count == pat.Length)
            {
                while (pat.IndexOf(str[start]) < 0 || hstr[str[start]] > hpat[str[start]])
                {
                    hstr[str[start]]--;
                    start++;
                }

                if (minWindow > i - start + 1)
                {
                    minWindow = i - start + 1;
                    matchedString = str.Substring(start, minWindow);
                }
            }


        }
        Console.WriteLine("minimum window Length is : " + minWindow);
        Console.WriteLine(matchedString);
    }
}

/**
unhandled exception: because hash is different to array, so cannot directly have hpat[c]++ without creating the pair in dictionary.
missed the !=0 condition in count++ addition check as default value is zero, and always gets counted otherwise.
forgot to set the minWindow = int.MaxValue , which led to the value default 0 and so never the actual min value was set.
when copy pasting code, check all the variables and all the code thoroughly in the context of the current code. hstr[str[start]]--; instead i is used for start, causing waste of time.
*/