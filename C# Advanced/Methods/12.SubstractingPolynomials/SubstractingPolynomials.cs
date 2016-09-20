using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _12.SubstractingPolynomials
{
    class SubstractingPolynomials
    {
        static object PolynomialsSum(int n, int[] arr1, int[] arr2)
        {
            var result = new StringBuilder();
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum = arr1[i] + arr2[i];
                result.Append(sum + " ");
            }
            return result;
        }
        static object PolynomialsSubstraction(int n, int[] arr1, int[] arr2)
        {
            var result = new StringBuilder();
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum = arr1[i] - arr2[i];
                result.Append(sum + " ");
            }
            return result;
        }
        static object PolynomialsMultiplication(int n, int[] arr1, int[] arr2)
        {
            var result = new StringBuilder();
            int sum = 1;
            for (int i = 0; i < n; i++)
            {
                sum = arr1[i]*arr2[i];
                result.Append(sum + " ");
            }
            return result;
        }
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[] polynomial1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] polynomial2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine(PolynomialsSum(N, polynomial1, polynomial2));
            Console.WriteLine(PolynomialsSubstraction(N, polynomial1, polynomial2));
            Console.WriteLine(PolynomialsMultiplication(N, polynomial1, polynomial2));
        }
    }
}
