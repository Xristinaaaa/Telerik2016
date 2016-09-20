using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;
class DecimalToBinary
{
    static void Main(string[] args)
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine());
        Console.WriteLine(Binary(n));
    }
    static char[] Binary(BigInteger num)
    {
        BigInteger rem;
        StringBuilder binary = new StringBuilder();
        while (num>0)
        {
            rem = num % 2;
            binary.Append(rem);
            num /= 2;
        }
        string result = binary.ToString();
        char[] arr = result.ToCharArray();
        Array.Reverse(arr);
        return arr;
    }
}

