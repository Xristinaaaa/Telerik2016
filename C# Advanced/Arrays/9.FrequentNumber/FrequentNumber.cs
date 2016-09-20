using System;

class FrequentNumber
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[] array = new int[N];
        for (int i = 0; i < N; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(array);
        int count = 1;
        int frequent = 1;
        int mostFrequent=0;

        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] == array[i + 1])
            {
                count++;
                if (count>=frequent)
                {
                    frequent = count;
                    mostFrequent = array[i];
                }
            }
            else
            {
                if (count >= frequent)
                {
                    frequent = count;
                    mostFrequent = array[i];
                    count = 1;
                }
                else
                {
                    count = 1;
                }
            }
        }
        Console.WriteLine("{0} ({1} times)", mostFrequent, frequent);
    }
}


