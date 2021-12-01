using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class StringUsage
{
    public static void main()
    {
        Console.WriteLine("Jai Shree Ram");

        //Substring(Int32) - Retrieves a substring from the specified position to the end of 
        //the string.
        //Substring(Int32, Int32 - Retrieves a substring from this instance from 
        //the specified position for the specified length.
        string s = "25525511135";
        Console.WriteLine(s.All(char.IsDigit)); // to check if a string a number or not.

        //s.Append("test");
        string temp = s.Substring(0, 2) + "." + s.Substring(2);
        temp = temp.Substring(0, 5 + 1) + "." + temp.Substring(5 + 1);
        temp = temp.Substring(0, 8 + 2) + "." + temp.Substring(8 + 2);

        Console.WriteLine(temp);

        string jsr = "Jai Shree Ram";
        jsr.Replace(",", ":");
        Console.WriteLine(jsr.IndexOf("Ram"));

        // there is no CharAt method, instead use str[8];

        List<string> ls = new List<string>() { "ashok", "raju" };
        //ls.AddRange(["is","doing","programming"]);

        string[] tokens = jsr.Split(new char[] { ' ' });
        Console.WriteLine("{0}", string.Join(", ", tokens));

        string stringString = "Mahesh Chand, Neel Chand Beniwal, Raj Beniwal, Dinesh Beniwal";
        // String separator  
        string[] stringSeparators = new string[] { "Beniwal, ", "Chand, " };
        string[] firstNames = stringString.Split(stringSeparators, StringSplitOptions.None);

        //String is a class in System.String
        // whereas , string is an alias of System.String.

        Console.WriteLine(jsr.GetType().FullName);

        Console.WriteLine("{0}", string.Join(", ", tokens[0].ToCharArray()));

        string a = "ashok";
        for (int i = 0; i < a.Length; i++)
            Console.WriteLine(a[i]);

        char[] copy = a.ToCharArray();
        string c = new string(copy);

        Console.WriteLine(string.Format("{0}", "hello"));

        Console.WriteLine(string.IsNullOrWhiteSpace(" "));// null, empty , whitespace
        Console.WriteLine(string.IsNullOrEmpty(" "));

        Console.WriteLine("Ashok".ToLower());
        Console.WriteLine("Raju".ToUpper());
        char[] charstotrim = { ' ', '*' };
        Console.WriteLine("   ashok   ".Trim(charstotrim));
        Console.WriteLine("Jai Shree Ram".Contains("Ram"));

        Console.WriteLine("abc".CompareTo("xyz"));
        Console.WriteLine("xyz".CompareTo("abc"));




        String str = "GeeeksforGeeks - A Computer Science Portal for Geeks";
        char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

        List<char> al = vowels.OfType<char>().ToList(); // need System.Linq;

        StringBuilder sb = new StringBuilder(str); // from System.Text;


        for (int i = 0; i < sb.Length; i++)
        {

            if (al.Contains(sb[i]))
            {
                sb.Replace(sb[i].ToString(), "");
                i--;
            }
        }

        Console.WriteLine(sb.ToString());
    }

    // Function to reverse words
    static char[] reverseWords(char []s)
    {
        string str = new String(s);
        string[] splits = str.Split(' ');
        Array.Reverse(splits);
        string rev = string.Join(' ',splits);
        return rev.ToCharArray();
    }
}