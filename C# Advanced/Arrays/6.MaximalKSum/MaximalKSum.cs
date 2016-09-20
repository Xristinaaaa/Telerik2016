using System;

class MaximalKSum
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int K = int.Parse(Console.ReadLine());

        if (K<1 || K>N || N<1 || N>1024)
        {
            Console.WriteLine("Error!");
        }

        int[] arrOfNums = new int[N];
        for (int i = 0; i < N; i++)
        {
            arrOfNums[i] = int.Parse(Console.ReadLine());
        }

        int sumOfNums = 0;
        int temp;

        for (int i = 1; i < arrOfNums.Length; i++)
        {
            for (int j = 0; j < (arrOfNums.Length - 1); j++)
           {
                if (arrOfNums[j + 1] > arrOfNums[j])
                {
                    temp = arrOfNums[j];
                    arrOfNums[j] = arrOfNums[j + 1];
                    arrOfNums[j + 1] = temp;
                }
            }
        }
        for (int i = 0; i < K; i++)
        {
            sumOfNums += arrOfNums[i];
        }
        Console.WriteLine(sumOfNums);
    }
}

