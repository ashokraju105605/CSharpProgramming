using System;

class leftsmallrightgreat
{
    public static void main(String[] args)
    {
        int[] arr = { 5, 1, 4, 3, 6, 8, 10, 7, 9 };
        int[] arr1 = { 5, 1, 4, 4 };
        leftsmallrightgreat lsrg = new leftsmallrightgreat();
        lsrg.findNum1(arr);
        lsrg.findNum1(arr1);
        lsrg.findNum(arr);
        lsrg.findNum(arr1);
    }

    void findNum1(int[] a)
    {
        int left_max = a[0];
        int left_index = 0;
        int elem = a[0];

        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] > left_max)
            {
                // because there can be gap between last left max and current left max, we need to check if they are adjacent 
                //for the very first time,
                // pick probable candidate.
                if (elem == -1 && left_index + 1 == i)
                    elem = a[left_index];
                left_max = a[i];
                left_index = i;

            }
            else if (a[i] > elem)
            {
                continue;
            }
            else
            {
                elem = -1;
            }
        }
        Console.WriteLine("element is " + elem);
    }
    void findNum(int[] arr)
    {

        if (arr.Length <= 2)
            Console.WriteLine("no such element");

        int maxx = 0, element = 0;

        element = arr[0];
        maxx = arr[0];



        int i = 1; int bit = 0;
        while (i < arr.Length)
        {
            // checking against the maxx is important, as the second while broke due to the element and we need to search for higher element 
            //than maxx in the right.
            while (arr[i] < maxx && i < arr.Length)
            {
                i++;
                bit = 0;
            }
            if (arr[i] > maxx)
            {
                element = arr[i];
                maxx = arr[i];
                i++;
                bit = 1;
                while (i < arr.Length && arr[i] >= element)
                {
                    if (arr[i] > maxx)
                        maxx = arr[i];
                    i++;
                }
            }


        }
        if (i == arr.Length && bit == 1)
        {
            Console.WriteLine("element found : " + element);
        }
        else
        {
            Console.WriteLine("No such element found");
        }

    }
}