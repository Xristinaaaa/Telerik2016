//Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. Use variable number of arguments. 
//Write a program that reads 5 elements and prints their minimum, maximum, average, sum and product.

using System;
using System.Linq;
class IntegerCalculations
{
    static int Minimum(int[] nums)
    {
        int minimum = int.MaxValue;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i]<minimum)
            {
                minimum = nums[i];
            }
        }
        return minimum;
    }
    static int Maximum(int[] nums)
    {
        int maximum = int.MinValue;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > maximum)
            {
                maximum = nums[i];
            }
        }
        return maximum;
    }
    static decimal Average(int[] nums)
    {
        long sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }
        decimal average=(decimal)sum/nums.Length;
        return average;
    }
    static long Sum(int[] nums)
    {
        long sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }
        return sum;
    }
    static long Product(int[] nums)
    {
        long product = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            product *= nums[i];
        }
        return product;
    }
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Console.WriteLine(Minimum(numbers));
        Console.WriteLine(Maximum(numbers));
        Console.WriteLine("{0:F2}", Average(numbers));
        Console.WriteLine(Sum(numbers));
        Console.WriteLine(Product(numbers));
    }
}

