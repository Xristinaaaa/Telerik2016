using System;

class CompareArrays
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[] arr1 = new int[N];
        int[] arr2 = new int[N];

        for (int i = 0; i < N; i++)
        {
            arr1[i] = int.Parse(Console.ReadLine());
        }
        for (int j = 0; j <  N; j++)
        {
            arr2[j] = int.Parse(Console.ReadLine());
        }

        bool equal = true;
        for (int k = 0; k < N; k++)
        {
            if (arr1[k]!=arr2[k])
            {
                equal = false;
                Console.WriteLine("Not equal");
                break;
            }
        }
        if (equal)
        {
            Console.WriteLine("Equal");
        }
    }
}

