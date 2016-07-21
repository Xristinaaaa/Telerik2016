using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
class SolveTasks
{
    static string Reverse()
    {
        string n = Console.ReadLine();
        char[] num = n.ToCharArray();
        string reversed = string.Empty;
        for (int i = num.Length; i>0; i--)
        {
            reversed += num[i];
        }
        return reversed;
    }
    static int Average()
    {
        int n = int.Parse(Console.ReadLine());
        int[] sequence = new int[n];
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += sequence[i];
        }
        int average = sum / n;
        return average;
    }
    static double Equation()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        double x = (double)-b / a;
        return x;
    }
    static void Main(string[] args)
    {
        
    }
}

