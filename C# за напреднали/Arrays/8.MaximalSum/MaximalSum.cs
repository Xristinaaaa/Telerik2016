using System;

class MaximalSum
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        if (N < 1 || N > 1024)
        {
            Console.WriteLine("Error!");
        }

        int[] arrOfNums = new int[N];
        for (int i = 0; i < N; i++)
        {
            arrOfNums[i] = int.Parse(Console.ReadLine());
        }

        int maxSum = int.MinValue;
        int curSum = 0;
        
        for (int i = 0; i < N; i++)
        {
            curSum += arrOfNums[i];
            if (curSum>maxSum)
            {
                maxSum = curSum;
            }
            if (curSum<0)
            {
                curSum = 0;
            }
        }
        Console.WriteLine(maxSum);
    }
}

