using System;
using System.Linq;
class GetLargestNumber
{
    static int GetMax(int a, int b)
    {
        return (a > b ? a : b);
    }

    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int num1 = numbers[0];
        int num2 = numbers[1];
        int num3 = numbers[2];

        if (GetMax(num1,num2)>num3)
        {
            Console.WriteLine(GetMax(num1,num2));
        }
        else
        {
            Console.WriteLine(num3);
        }
    }
}
