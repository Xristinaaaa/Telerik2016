using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.HelpDoge
{
    class HelpDoge
    {
        static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);

            nm = Console.ReadLine().Split(' ');
            int fx = int.Parse(nm[0]);
            int fy = int.Parse(nm[1]);

            int k = int.Parse(Console.ReadLine());


            bool[,] matrix = new bool[fx+1, fy+1];
            for (int i = 0; i < k; i++)
            {
                nm = Console.ReadLine().Split(' ');
                int x = int.Parse(nm[0]);
                int y = int.Parse(nm[1]);

                if (x<=fx && y<=fy)
                {
                    matrix[x, y] = true;
                }
            }
            
            int[,] count = new int [fx+1, fy+1];
            count[0, 0] = 1;

            for (int j = 1; j < fy; j++)
            {
                count[0, j] = matrix[0, j] ? 0 : count[0, j - 1];
            }
            for (int i= 1; i < fx; i++)
            {
                count[i, 0] = matrix[i, 0] ? 0 : count[i-1, 0];
            }

            for (int i = 0; i < count.GetLength(0); i++)
            {
                for (int j = 0; j < count.GetLength(1); j++)
                {
                    count[i, j] = matrix[i, j] ? 0 : count[i - 1, j] + count[i, j - 1];
                }
            }
            Console.WriteLine(count[fx,fy]);
        }
    }
}
