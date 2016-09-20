using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
class AddingPolynomials
{
    static object Polynomials(int n, int[] arr1, int[] arr2)
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
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[] polynomial1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int[] polynomial2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Console.WriteLine(Polynomials(N,polynomial1,polynomial2));
    }
}
