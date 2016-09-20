using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.IncreasingAbsoluteDifferences
{
    class IncreasingAbsoluteDifferences
    {
        //static void Main(string[] args)
        //{
        //    int t = int.Parse(Console.ReadLine());
        //    for (int i = 0; i < t; i++)
        //    {
        //        long[] numbers = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
        //        bool answer = Check(numbers);
        //        Console.WriteLine(answer);
        //    }
        //}
        //static bool Check(long[] numbers)
        //{
        //    if (numbers.Length <= 2)
        //    {
        //        return true;
        //    }

        //    long temp = Math.Abs(numbers[1] - numbers[0]);
        //    for (int i = 2; i < numbers.Length; i++)
        //    {
        //        long diff = Math.Abs(numbers[i] - numbers[i - 1]);
        //        if (diff - temp != 1 && diff - temp != 0)
        //        {
        //            return false;
        //        }
        //        temp = diff;
        //    }
        //    return true;
        //}



            //1.read input
            //2. for every sequence do the following
            //2.1. calculate sequence of absolute dif
            //2.2 check if the absolute dif sequence is increasing
            //2.3 output the result of the current sequence

        static void Main()
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                long[] sequence = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

                bool isIncreasing = true;
                for (int j = 2; j < sequence.Length; j++)
                {
                    var lastAbsDif = Math.Abs(sequence[j - 2] - sequence[j-1]);
                    var currentAbsDif = Math.Abs(sequence[j - 1] - sequence[j]);


                    if (lastAbsDif >currentAbsDif||currentAbsDif-lastAbsDif>1)
                    {
                        isIncreasing = false;
                        break;
                    }
                }
                Console.WriteLine(isIncreasing);
            }
        }
    }
}
