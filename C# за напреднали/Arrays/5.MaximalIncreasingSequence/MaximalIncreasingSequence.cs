using System;

class MaximalIncreasingSequence
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[] array = new int[N];

        for (int i = 0; i < N; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        int maxIncreasing = 1;
        int tempIncreasing = 1;

        for (int i = 1; i < N; i++)
        {
            if (array[i] > array[i-1])
            {
                tempIncreasing++;
                if (tempIncreasing > maxIncreasing)
                {
                    maxIncreasing = tempIncreasing;
                }
            }
            else
            {
                tempIncreasing = 1;
            }
        }
        Console.WriteLine(maxIncreasing);
    }
}

