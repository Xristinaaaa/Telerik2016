using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRings
{
    public static class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var rings = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                rings.Add(num);
            }

            Console.WriteLine(CountConfigs(rings));
        }
        static int CountConfigs(List<int> rings)
        {
            var counts = new Dictionary<int, int>();
            foreach (var ring in rings)
            {
                if (!counts.ContainsKey(ring+1))
                {
                    counts.Add(ring+1, 0);
                }

                counts[ring+1]++;
            }

            var configs = 1;

            foreach (var count in counts)
            {
                configs *= Factorial(count.Value);
            }

            return configs;
        }

        static int Factorial(int num)
        {
            int sum = 1;
            for (int i = 1; i <= num; i++)
            {
                sum *= i;
            }
            return sum;
        }
    }
}
