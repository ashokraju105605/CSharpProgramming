using System;
public class NextPermutation
{
    public static void main(String[] args)
    {
        int[] nums = { 1, 2, 3 };
        int[] nums1 = { 3, 2, 1 };
        int[] nums2 = { 1, 1, 5 };
        int[] nums3 = { 1 };
        Solution s = new Solution();
        s.NextPermutation(nums);
        Array.ForEach(nums, Console.Write);
        Console.WriteLine();
        s.NextPermutation(nums1);
        Array.ForEach(nums1, Console.Write);
        Console.WriteLine();
        s.NextPermutation(nums2);
        Array.ForEach(nums2, Console.Write);
        Console.WriteLine();
        s.NextPermutation(nums3);
        Array.ForEach(nums3, Console.Write);
        Console.WriteLine();
    }
}


public class Solution
{
    public void NextPermutation(int[] nums)
    {
        int i = nums.Length - 2;
        while (i >= 0 && nums[i] >= nums[i + 1])
        {
            i--;
        }
        if (i >= 0)
        {
            int j = nums.Length - 1;
            while (j >= 0 && nums[j] <= nums[i]) j--;
            swap(nums, i, j);
        }

        Array.Reverse(nums, i + 1, nums.Length - i - 1);
    }

    public void swap(int[] nums, int i, int j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}