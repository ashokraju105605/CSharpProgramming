using System;
using System.Collections.Generic;
class CombinationSum
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        List<int> arr = new List<int>();

        arr.Add(2);
        arr.Add(4);
        arr.Add(6);
        arr.Add(8);

        int sum = 8;

        List<List<int>> ans
            = combinationSum(arr, sum);
    }
    public static List<List<int>> combinationSum(List<int> a, int sum)
    {
        List<int> temp = new List<int>();
        List<List<int>> sol = new List<List<int>>();
        // remove duplicates in the input and sort them so no duplicate individual sets get add into final list of answers.
        HashSet<int> hs = new HashSet<int>(a);
        List<int> arr = new List<int>(hs);
        arr.Sort();

        combinationSumUtil(arr, sum, sol, 0, temp);
        return sol;

    }
    static void combinationSumUtil(List<int> a, int sum, List<List<int>> sol, int index, List<int> t)
    {
        if (sum == 0)
        {
            List<int> temp = new List<int>(t);
            sol.Add(temp);
            return;
        }

        for (int i = index; i < a.Count; i++)
        {
            if (a[i] <= sum)
            {
                t.Add(a[i]);
                combinationSumUtil(a, sum - a[i], sol, i, t); // you will only keep going with higher components, and not lower
                                                              // so 2,4,2 or 4,2,2 cannot arise
                t.Remove(a[i]);
            }
        }

    }
}