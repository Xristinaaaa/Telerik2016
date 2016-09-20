using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.EnterNumbers
{
    class EnterNumbers
    {
        static void Main(string[] args)
        {
            int count = 10;
            List<int> input = new List<int>();

            for (int i = 0; i < count; i++)
            {
                input.Add(int.Parse(Console.ReadLine()));
            }

            try
            {
                if (input.Any(x => x < 0) || input.Any(x => x > 100) || !IsIncreasing(input))
                {
                    throw new ArgumentException();
                }
                Console.WriteLine("1 < " + string.Join(" < ", input) + " < 100");
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
            }
        }
        private static bool IsIncreasing(List<int> input)
        {
            for (int i = 1; i < input.Count; i++)
            {
                if (input[i - 1].CompareTo(input[i]) >= 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
