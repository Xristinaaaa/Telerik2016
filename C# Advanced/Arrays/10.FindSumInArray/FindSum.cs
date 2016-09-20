using System;

class Program
{
    static void Main(string[] args)
    {
        int s = int.Parse(Console.ReadLine());
        int[] arr = { 4, 3, 1, 4, 2, 5, 8 };
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i; j < arr.Length; j++)
            {
                sum += arr[j];
                if (sum>s)
                {
                    sum = 0;
                    break; 
                }
                else if (sum==s)
                {
                    int k = j;
                    for (int var = i; var <= k; var++)
                    {
                        Console.Write(arr[var] + " ");
                    }
                    return;
                }
            }
        }
    }
}

