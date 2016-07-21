using System;

class MaximalSequence
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[] array = new int[N];

        int maxSequence = 0;
        int tempSequence = 0;

        for (int i = 0; i < N; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        int element = array[0];
        for (int i = 0; i < N; i++)
        {
            if (array[i] == element)
            {
                maxSequence++;
                if (maxSequence>tempSequence)
                {
                    tempSequence = maxSequence;
                }
            }
            else
            {
                maxSequence = 1;
                element= array[i];
            }
        }
        Console.WriteLine(tempSequence);
    }
}

