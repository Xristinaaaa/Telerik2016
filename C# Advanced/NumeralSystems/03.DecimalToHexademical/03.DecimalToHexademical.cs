using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.DecimalToHexadecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Convert.ToString(Int64.Parse(Console.ReadLine()), 16).ToString().ToUpper());
        }
    }
}
