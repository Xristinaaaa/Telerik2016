﻿using System;

class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[] unsortedArray = new int[N];
        for (int i = 0; i < N; i++)
        {
            unsortedArray[i] = int.Parse(Console.ReadLine());
        }

        QuickSortAlgorithm(unsortedArray, 0, unsortedArray.Length - 1);
        for (int i = 0; i < unsortedArray.Length; i++)
        {
            Console.WriteLine(unsortedArray[i]);
        }
    }

    static void QuickSortAlgorithm(int[] array, int start, int end)
    {
        int i = start, j = end;
        int pivot = array[start + (end - start) / 2];

        while (i <= j)
        {
            while (array[i].CompareTo(pivot) < 0)
            {
                i++;
            }

            while (array[j].CompareTo(pivot) > 0)
            {
                j--;
            }

            if (i <= j)
            {
                // Swap the elements
                int tmp = array[i];
                array[i] = array[j];
                array[j] = tmp;

                i++;
                j--;
            }
        }

        // Recursive calls
        if (start < j)
        {
            QuickSortAlgorithm(array, start, j);
        }

        if (i < end)
        {
            QuickSortAlgorithm(array, i, end);
        }

    }
}

