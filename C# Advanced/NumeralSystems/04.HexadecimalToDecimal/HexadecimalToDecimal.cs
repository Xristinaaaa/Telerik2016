using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.HexadecimalToDecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Convert.ToInt64(Console.ReadLine(), 16));
        }
    }
}
