using System;

class SelectionSort
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

        int temp;
        for (int i = 0; i < arrOfNums.Length-1; i++)
        {
            for (int j = i+1; j < arrOfNums.Length; j++)
            {
                if (arrOfNums[i] > arrOfNums[j])
                {
                    temp = arrOfNums[i];
                    arrOfNums[i] = arrOfNums[j];
                    arrOfNums[j] = temp;
                }
            }
        }

        for (int i = 0; i < arrOfNums.Length; i++)
        {
            Console.WriteLine(arrOfNums[i]);
        }
    }
}

