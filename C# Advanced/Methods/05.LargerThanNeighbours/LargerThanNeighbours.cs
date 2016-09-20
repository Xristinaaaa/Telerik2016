using System;
using System.Linq;
class LargerThanNeighbours
{
    static int LargerNum(int[] array)
    {
        int count = 0;
        for (int i = 1; i < array.Length-1; i++)
        {
            if (array[i-1]<array[i] && array[i]>array[i+1])
            {
                count++;
            }
        }
        return count;
    }

    static void Main(string[] args)
    {
        int sizeOfArray = int.Parse(Console.ReadLine());
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Console.WriteLine(LargerNum(array));
    }
}
