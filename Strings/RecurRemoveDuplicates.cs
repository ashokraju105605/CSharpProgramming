using System;
class RecurRemoveDuplicates
{
    public static void main(string[] args)
    {
        string str1 = "acaaabbbacdddd";
        string str2 = "qpaaaaadaaaaadprq";
        string str3 = "aaaaaaaaaa";
        string str4 = "aaaacddddcappp";
        string str5 = "gghhg";
        string str6 = "caaabbbaac";
        string str7 = "azxxxzy";
        string str8 = "geeksforgeeg";
        string str9 = "aabaddd";

        RecurRemoveDuplicates rrd = new RecurRemoveDuplicates();
        Console.WriteLine(rrd.removedup(str1));
        Console.WriteLine(rrd.removedup(str2));
        Console.WriteLine(rrd.removedup(str3));
        Console.WriteLine(rrd.removedup(str4));
        Console.WriteLine(rrd.removedup(str5));
        Console.WriteLine(rrd.removedup(str6));
        Console.WriteLine(rrd.removedup(str7));
        Console.WriteLine(rrd.removedup(str8));
        Console.WriteLine(rrd.removedup(str9));

        //Console.WriteLine("Jai Shree Ram");
    }
    string removedup(string str)
    {
        char last_removed = '\0';
        return removedups1(str, ref last_removed);
    }
    // this below doesn't work properly as the last_removed is not updated from the bottom up in recursion.
    // string removedups(string str, char last_removed)
    // {
    //     //str = "a";
    //     if (str.Length == 0 || str.Length == 1)
    //     {

    //         return str;
    //     }
    //     //char last_removed = '\0';
    //     if (str[0] == str[1])
    //     {
    //         //int i = 1;
    //         last_removed = str[0];
    //         while (str.Length > 1 && str[0] == str[1])
    //         {
    //             str = str.Substring(1);
    //         }
    //         return removedups(str.Substring(1), last_removed);

    //     }
    //     string rem_str = removedups(str.Substring(1), last_removed);

    //     if (rem_str.Length != 0 && str[0] == rem_str[0])
    //     {
    //         last_removed = str[0];
    //         return rem_str.Substring(1);
    //     }

    //     if (rem_str.Length == 0 && str[0] == last_removed)
    //         return rem_str;

    //     return str[0] + rem_str;

    //     //return null;

    // }
    string removedups1(string str, ref char last_removed)
    {
        //str = "a";
        if (str.Length == 0 || str.Length == 1)
        {
            //last_removed = '\0';
            return str;
        }
        //char last_removed = '\0';
        if (str[0] == str[1])
        {
            //int i = 1;
            last_removed = str[0];
            while (str.Length > 1 && str[0] == str[1])
            {
                str = str.Substring(1);
            }
            return removedups1(str.Substring(1), ref last_removed);

        }

        string rem_str = removedups1(str.Substring(1), ref last_removed);

        if (rem_str.Length != 0 && str[0] == rem_str[0])
        {
            last_removed = str[0];
            return rem_str.Substring(1);
        }

        if (rem_str.Length == 0 && str[0] == last_removed)
            return rem_str;

        return str[0] + rem_str;

        //return null;

    }
}

/* mistakes:
1. instead of picking the substring, ran while loop with i++ and picking the remaining string ran into index OOB issue.
2. returning from the recursion setting the last_removed with out has issues, so need to use ref as it allows setting from the caller and callee.
*/
