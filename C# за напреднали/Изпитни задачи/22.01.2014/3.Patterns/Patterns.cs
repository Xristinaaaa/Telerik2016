using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Patterns
{
    class Patterns
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n,n];

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(line[j]);
                }
            }

            long maxsum = long.MinValue;
            bool found = false;
            for (int i = 0; i+2 < n; i++)
            {
                for (int j = 0; j+4 < n; j++)
                {
                    if ((matrix[i, j] + 1 == matrix[i, j + 1])
                        && (matrix[i, j] + 2 == matrix[i, j + 2])
                        && (matrix[i, j] + 3 == matrix[i + 1, j + 2])
                        && (matrix[i, j] + 4 == matrix[i + 2, j + 2])
                        && (matrix[i, j] + 5 == matrix[i + 2, j + 3])
                        && (matrix[i, j] + 6 == matrix[i + 2, j + 4]))
                    {
                        found = true;
                        long sum = (long)7 * matrix[i, j] + 21;
                        //pattern is consisted of 7 cells
                        //0+...+6=21

                        if (maxsum<sum)
                        {
                            maxsum = sum;
                        }
                    }
                }
            }
            if (!found)
            {

            }
            Console.WriteLine("YES {0}", maxsum);
        }
    }
}
