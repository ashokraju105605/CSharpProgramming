using System;
class AllUsages
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        // HashSet<string> hs = new HashSet<string>();
        // foreach(string email in emails)
        // {
        //     string[] splits = email.Split('@');
        //     splits[0]=splits[0].Replace(".","");
        //     string[] localname = splits[0].Split('+');
        //     string temp = localname[0] + '@' + splits[1];
        //     hs.Add(temp);
        // }
        // string s = "test";
        // s = s.ToUpper();
        // s = s.Replace("-","");
        // StringBuilder str = new StringBuilder(s);
        // for(int i= s.Length-k;i>0;i-=k)
        //     str.Insert(i,"-");

        // return str.ToString();


        // max = Math.Max(max, pairlen);

        // int[] vis = new int[127];
        // int max = 0;

        // Array.Fill(vis,-1);

        // IList<IList<int>> arr = new List<IList<int>>();

        // Array.Reverse(nums,i+1, nums.Length-i-1);

        // StringBuilder sb = new StringBuilder();
        // sb.Insert(0, mod);
        // sb.Remove(0,1);
        // sb.ToString();
    }

    public string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}