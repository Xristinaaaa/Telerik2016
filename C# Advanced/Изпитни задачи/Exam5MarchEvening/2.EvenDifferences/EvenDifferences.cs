using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.EvenDifferences
{
    class EvenDifferences
    {
        static void Main(string[] args)
        {
            //1.read input
            //2.put the input numbers in an array
            //3.iterate over the arrray and calculate sum
            //3.1 find abs dif
            //3.2 if even-sum it
            //3.3 make a jump-even or odd
            //4.print the sum

            long[] numbers = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            long evenDif = 0;
            long absdif = 0;
            for (int i = 1; i < numbers.Length;)
            {
                absdif = Math.Abs(numbers[i] - numbers[i - 1]);
                if (absdif % 2 == 0)
                {
                    i += 2;
                    evenDif += absdif;
                }
                else
                {
                    i++;
                }
            }
            Console.WriteLine(evenDif);
        }
    }
}
