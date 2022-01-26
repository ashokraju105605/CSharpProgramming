using System;
using System.Collections.Generic;
class HashSetUsage
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        HashSet<int> hs = new HashSet<int>();

        hs.Add(1);
        hs.Add(2);

        Console.WriteLine(hs.Contains(2));
        Console.WriteLine(hs.Count);

        int[] a = new int[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 5 };
        // remove duplicates in array in one go like below 
        HashSet<int> hs1 = new HashSet<int>(a);
        List<int> l = new List<int>(hs1);

        HashSet<int> myhash3 = new HashSet<int>() { 10, 100, 1000, 10000, 100000 };

        foreach (var valu in myhash3)
        {
            Console.WriteLine(valu);
        }

        // HashSet Removetrue if the element is successfully found and removed; otherwise, false. 
        // This method returns false if item is not found
        myhash3.Remove(100);

        myhash3.Clear();

        HashSet<string> myhash1 = new HashSet<string>();
        myhash1.Add("C");
        myhash1.Add("C++");
        myhash1.Add("C#");
        myhash1.Add("Java");
        myhash1.Add("Ruby");

        // Creating another HashSet
        // Using HashSet class
        HashSet<string> myhash2 = new HashSet<string>();

        // Add the elements in HashSet
        // Using Add method
        myhash2.Add("PHP");
        myhash2.Add("C++");
        myhash2.Add("Perl");
        myhash2.Add("Java");

        // Using UnionWith method
        myhash1.UnionWith(myhash2);
        myhash1.ExceptWith(myhash2);
        myhash1.IntersectWith(myhash2);

        foreach (var ele in myhash1)
        {
            Console.WriteLine(ele);
        }

    }
}