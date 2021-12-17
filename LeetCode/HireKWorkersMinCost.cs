using System;
using System.Collections.Generic;
using System.Linq;
class HireKWorkersMinCost
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        int[] quality = { 10, 20, 5 };
        int[] wage = { 70, 50, 30 };
        int k = 2;

        int[] quality1 = { 3, 1, 10, 10, 1 };
        int[] wage1 = { 4, 8, 2, 2, 7 };
        int k1 = 3;

        Console.WriteLine(kworkersmincost(quality, wage, k));
        Console.WriteLine(kworkersmincost(quality1, wage1, k1));
    }
    static double kworkersmincost(int[] q, int[] w, int k)
    {
        List<worker> lw = new List<worker>();
        for (int i = 0; i < q.Length; i++)
        {
            lw.Add(new worker(w[i], q[i]));
        }
        lw.Sort(delegate (worker w1, worker w2)
        {
            if (w1.r < w2.r)
                return -1;
            else if (w1.r > w2.r)
                return 1;
            else
                return 0;
        });
        //double result = 0; // incorrect, as we need calc min value, this init value should be higher.
        double result = int.MaxValue;
        List<int> qsum = new List<int>();
        for (int i = 0; i < lw.Count; i++)
        {
            qsum.Add(lw[i].q);

            // if (i >= k)  // incorrect
            // {
            //     qsum.Remove(qsum.Max());
            //     result = Math.Min(result, lw[i].r * qsum.Sum());
            // }
            if (qsum.Count > k)
            {
                qsum.Remove(qsum.Max());
            }
            if (qsum.Count == k)
                result = Math.Min(result, lw[i].r * qsum.Sum());
        }
        return result;
    }
    public class worker
    {
        public int w, q;
        public double r;
        public worker(int w, int q)
        {
            this.w = w;
            this.q = q;
            this.r = (double)w / q;
        }
    }
}