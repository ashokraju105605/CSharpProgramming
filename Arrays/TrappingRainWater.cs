using System;
class traprainwater
{
    public static void main(String[] args)
    {
        int[] arr = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
        traprainwater trw = new traprainwater();
        trw.measureRainWater(arr);
    }
    void measureRainWater(int[] arr)
    {
        int count = 0;
        int left = 0, right = arr.Length - 1;
        int maxleft = 0, maxright = 0;

        while (left <= right)
        {
            if (arr[left] < arr[right])
            {
                if (arr[left] < maxleft)
                {
                    count += maxleft - arr[left];
                }
                else
                {
                    maxleft = arr[left];
                }
                left++;
            }
            else
            {
                if (arr[right] < maxright)
                {
                    count += maxright - arr[right];
                }
                else
                {
                    maxright = arr[right];
                }
                right--;
            }
        }

        Console.WriteLine("total rain water is : " + count);
    }
}