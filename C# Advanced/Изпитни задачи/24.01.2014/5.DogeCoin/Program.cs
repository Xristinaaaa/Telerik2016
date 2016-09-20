using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.DogeCoin
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);

            int k = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n , m];
            for (int i = 0; i < k; i++)
            {
                nm = Console.ReadLine().Split(' ');
                int x = int.Parse(nm[0]);
                int y = int.Parse(nm[1]);

                matrix[x, y]++;
            }

            //Solve
            int[,] count = new int[n, m];
            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < m; y++)
                {
                    int up = 0, left = 0;
                    if (x > 0)
                    {
                        up = count[x - 1, y];
                    }

                    if (y > 0)
                    {
                        left = count[x, y - 1];
                    }

                    count[x, y] = Math.Max(up, left) + matrix[x, y];
                }
            }
            // Print answer
            Console.WriteLine(count[n - 1, m - 1]);
        }
    }
}

