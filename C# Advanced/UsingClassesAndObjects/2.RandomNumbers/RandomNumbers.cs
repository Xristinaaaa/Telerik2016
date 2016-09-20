using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.RandomNumbers
{
    class RandomNumbers
    {
        static void Main(string[] args)
        {
            Random rgb = new Random(10);
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(rgb.Next(100, 200));
            }
        }
    }
}
