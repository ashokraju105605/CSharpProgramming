using System;
using System.Collections.Generic;
using System.Linq;

namespace Programming
{
    class Program
    {
        static void main(string[] args)
        {
            List<int> a = new List<int>();
            a.Add(8);
            a.Add(2);
            a.Add(4);
            a.Add(6);
            a.Add(8);

            a.Sort();
            List<int> d = a.Distinct().ToList();

            var p = new Program();
            List<int> list = new List<int>();
            //int sum = 8;

            //p.CombinationSum(d, sum, list, 0);

            int[] arr = { 12, 1, 78, 90, 57, 89, 56 };
            //int k = 3;
            printMax(arr, arr.Length, 5);

            int[] arr1 = new int[] { 1, 3, 5, 8, 9, 2,
                                6, 7, 6, 8, 9 };

            // calling minJumps method 
            Console.Write(minJumps(arr1));

        }

        static int minJumps(int[] arr)
        {
            if (arr.Length <= 1)
                return 0;

            // Return -1 if not 
            // possible to jump 
            if (arr[0] == 0)
                return -1;

            // initialization 
            int maxReach = arr[0];
            int step = arr[0];
            int jump = 1;

            // Start traversing array 
            for (int i = 1; i < arr.Length; i++)
            {
                // Check if we have reached 
                // the end of the array 
                if (i == arr.Length - 1)
                    return jump;

                // updating maxReach 
                maxReach = Math.Max(maxReach, i + arr[i]);

                // we use a step to get 
                // to the current index 
                step--;

                // If no further steps left 
                if (step == 0)
                {
                    // we must have used a jump 
                    jump++;

                    // Check if the current index/position 
                    // or lesser index is the maximum reach 
                    // point from the previous indexes 
                    if (i >= maxReach)
                        return -1;

                    // re-initialize the steps to 
                    // the amount of steps to reach 
                    // maxReach from position i. 
                    step = maxReach - i;
                }
            }

            return -1;
        }

        static void printMax(int[] arr, int n, int k)
        {

            // Create a Double Ended Queue, Qi that 
            // will store indexes of array elements
            // The queue will store indexes of useful 
            // elements in every window and it will
            // maintain decreasing order of values 
            // from front to rear in Qi, i.e.,
            // arr[Qi.front[]] to arr[Qi.rear()] 
            // are sorted in decreasing order
            List<int> Qi = new List<int>();

            /* Process first k (or first window) 
            elements of array */
            int i;
            for (i = 0; i < k; ++i)
            {
                // For every element, the previous 
                // smaller elements are useless so
                // remove them from Qi
                while (Qi.Count != 0 && arr[i] >=
                                arr[Qi[Qi.Count - 1]])

                    // Remove from rear
                    Qi.RemoveAt(Qi.Count - 1);

                // Add new element at rear of queue
                Qi.Insert(Qi.Count, i);
            }

            // Process rest of the elements, 
            // i.e., from arr[k] to arr[n-1]
            for (; i < n; ++i)
            {
                // The element at the front of 
                // the queue is the largest element of
                // previous window, so print it
                Console.Write(arr[Qi[0]] + " ");

                // Remove the elements which are 
                // out of this window
                while ((Qi.Count != 0) && Qi[0] <= i - k)
                    Qi.RemoveAt(0);

                // Remove all elements smaller 
                // than the currently
                // being added element (remove 
                // useless elements)
                while ((Qi.Count != 0) && arr[i] >=
                               arr[Qi[Qi.Count - 1]])
                    Qi.RemoveAt(Qi.Count - 1);

                // Add current element at the rear of Qi
                Qi.Insert(Qi.Count, i);
            }

            // Print the maximum element of last window
            Console.Write(arr[Qi[0]]);
        }

        public static void ArrSum(int[] arr, int sum)
        {
            var rand = new Random();
            Console.WriteLine(Math.Log10(100));
            rand.Next(0, 1);
            Array.Sort(arr);
            IDictionary<int, int> hm = new Dictionary<int, int>();
            int n = arr.Length;
            int cur_sum = 0;
            int i = 0;

            for (i = 0; i < n; i++)
            {
                cur_sum += arr[i];

                if (cur_sum == sum)
                {
                    Console.WriteLine("0" + " and " + i);
                    break;
                }
                if (hm.ContainsKey(cur_sum - sum))
                {
                    Console.WriteLine(hm[cur_sum - sum] + " and " + i);
                    break;
                }
                hm[cur_sum] = i;
            }
            if (i == n)
            {
                Console.WriteLine("not possible");
            }

        }

        void CombinationSum(List<int> arr, int sum, List<int> l, int i)
        {
            if (sum < 0)
                return;

            if (sum == 0)
            {
                for (int j = 0; j < l.Count; j++)
                {
                    Console.Write(l[j] + " ");
                }
                Console.WriteLine(" ");
                return;
            }

            for (int k = i; k < arr.Count; k++)
            {
                if (arr[k] <= sum)
                {
                    l.Add(arr[k]);
                    CombinationSum(arr, sum - arr[k], l, k);
                    l.Remove(arr[k]);
                }
            }


        }
    }
}
