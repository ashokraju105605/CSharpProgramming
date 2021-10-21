using System;
class AtoI
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        string str = "89789";
        string str1 = "-123";
        string str2 = " -123";

        AtoI ai = new AtoI();
        ai.calcValue(str);
        ai.calcValue(str1);
        ai.calcValue(str2);
    }
    void calcValue(string str)
    {
        int num = 0;
        int sign = 1;
        int i = 0;

        for (i = 0; str[i].Equals(' '); i++) ;

        str = str.Substring(i);

        if (str[0] == '+')
        {
            sign = 1;
            str = str.Substring(1);
        }
        else if (str[0] == '-')
        {
            sign = -1;
            str = str.Substring(1);
        }

        int j = 0;
        while (j < str.Length && str[j] - '0' >= 0 && str[j] - '0' <= 9)
        {
            int value = str[j] - '0';

            // check for overflows.
            if (num > int.MaxValue / 10 || (num == int.MaxValue / 10 && value > 7))
            {
                if (sign == 1)
                    Console.WriteLine(int.MaxValue);
                else
                    Console.WriteLine(int.MinValue);

            }
            num *= 10;
            num += value;
            j++;
        }
        Console.WriteLine("restultant integer is : " + (num * sign));

    }
}
/*
didn't take care of the ; properly at end of for loop removing the empty spaces.
minor mistakes.
forgot to check the overflow condition and return accordingly based on sign.
*/