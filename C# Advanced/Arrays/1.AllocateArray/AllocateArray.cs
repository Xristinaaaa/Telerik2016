using System;

class AllocateArray
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[] arr = new int[N];

        for (int i = 0; i < N; i++)
        {
            arr[i] = i*5;
            Console.WriteLine(arr[i]);
        }
    }
}

