using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Swapping
{
    public static class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var collection = new List<int>();

            for (int i = 0; i < n; i++)
            {
                collection.Add(i + 1);
            }

            foreach (var number in numbers)
            {
                collection = SwapNumbers(collection, number);
            }

            for (int i = 0; i < collection.Count; i++)
            {
                if (i == collection.Count - 1)
                {
                    Console.Write(collection[i]);
                }
                else
                {
                    Console.Write(collection[i] + " ");
                }
            }
        }
        public static List<int> SwapNumbers(List<int> input, int num)
        {
            var index = input.IndexOf(num);
            var firstPart = input.GetRange(index + 1, input.Count - 1 - index);
            var secondPart = input.GetRange(0, index);

            input.Clear();
            input.AddRange(firstPart);
            input.Add(num);
            input.AddRange(secondPart);

            return input;
        }
    }
}
