using System;
using System.Linq;
class AppearanceCount
{
    static int AppearanceOfNum(int[] numbers, int x)
    {
        int count=0;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i]==x)
            {
                count++;
            }
        }
        return count;
    }
    static void Main(string[] args)
    {
        int sizeOfArray = int.Parse(Console.ReadLine());
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int x = int.Parse(Console.ReadLine());
        Console.WriteLine(AppearanceOfNum(numbers,x));
    }
}

