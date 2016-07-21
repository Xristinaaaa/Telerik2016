using System;
using System.Numerics;
class NFactorial
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(Factorial(number));
    }
    static BigInteger Factorial(int num)
    {
        BigInteger factorial = 1;
        for (int i = 1; i <= num; i++)
        {
            factorial *= i;
        }
        return factorial;
    }
}

