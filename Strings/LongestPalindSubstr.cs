using System;
class LongestPalindSubstr
{
    public static void Main(string[] args)
    {
        string str = "forgeeksskeegfor";
        Console.WriteLine(str);
        LongestPalindSubstr lpss = new LongestPalindSubstr();
        lpss.printLongPalindSubstr(str);
        lpss.printLongPalindSubstrRec(str);

    }
    void printLongPalindSubstr(string str)
    {
        int maxpalinlength = 1;
        int j, k;
        int start = 0;
        for (int i = 0; i < str.Length; i++)
        {
            j = i; k = i + 1;
            while (j >= 0 && k < str.Length && str[j] == str[k])
            {
                if (k - j > maxpalinlength)
                {
                    start = j;
                    maxpalinlength = k - j + 1;
                }
                j--; k++;

            }

            j = i - 1; k = i + 1;
            while (j >= 0 && k < str.Length && str[j] == str[k])
            {
                if (k - j > maxpalinlength)
                {
                    start = j;
                    maxpalinlength = k - j + 1;
                }
                j--; k++;

            }

        }
        Console.WriteLine("maximum palindrome length is : " + maxpalinlength);
        Console.WriteLine("palindrome is  : " + str.Substring(start, maxpalinlength));
    }
    void printLongPalindSubstrRec(string str)
    {
        int maxpalinlength = 1;
        int j, k;
        int start = 0;
        var ret = new Tuple<int,int>(0,0);
        for (int i = 0; i < str.Length; i++)
        {
            j = i; k = i + 1;
            ret = maxPal(str,j,k);
            if(ret.Item2>maxpalinlength && ret.Item1!=-1)
            {
                start = ret.Item1;
                maxpalinlength = ret.Item2;
            }
            j = i - 1; k = i + 1;
            ret = maxPal(str,j,k);
            if(ret.Item2>maxpalinlength && ret.Item1!=-1)
            {
                start = ret.Item1;
                maxpalinlength = ret.Item2;
            }

        }
        Console.WriteLine("maximum palindrome length is : " + maxpalinlength);
        Console.WriteLine("palindrome is  : " + str.Substring(start, maxpalinlength));
    }
    Tuple<int,int> maxPal(string str, int i, int j)
    {
        int maxpalinlength = 0;
        int start = -1;
        while (i >= 0 && j < str.Length && str[i] == str[j])
        {
            if (j - i > maxpalinlength)
            {
                start = i;
                maxpalinlength = j - i + 1;
            }
            i--; j++;

        }
        return Tuple.Create(start,maxpalinlength);
    }
}

// mistakes:
//1. didn't put the = in the >= of the j condition
//2. didn't place the j and k checks on the while, and went into infinite loop
//3. didn't pick the start properly , picked the i instead of j.