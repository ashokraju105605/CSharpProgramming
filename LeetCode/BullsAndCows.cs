using System;

class BullsAndCows
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        BullsAndCows bnc = new BullsAndCows();
        Console.WriteLine(bnc.GetHint("1807", "7810"));
        Console.WriteLine(bnc.GetHint("1123", "0111"));
    }

    public string GetHint(string secret, string guess)
    {
        int[] h = new int[10];

        int bulls = 0, cows = 0;
        int n = guess.Length;
        for (int idx = 0; idx < n; ++idx)
        {
            char s = secret[idx];
            char g = guess[idx];
            if (s == g)
            {
                bulls++;
            }
            else
            {
                if (h[s - '0'] < 0)
                    cows++;
                if (h[g - '0'] > 0)
                    cows++;
                h[s - '0']++;
                h[g - '0']--;
            }
        }

        // StringBuilder sb = new StringBuilder(); // using System.Text;
        // sb.Append(bulls);
        // sb.Append("A");
        // sb.Append(cows);
        // sb.Append("B");
        return bulls + "A" + cows + "B";
    }
}