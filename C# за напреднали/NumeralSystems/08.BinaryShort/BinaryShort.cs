using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.BinaryShort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Convert.ToString(short.Parse(Console.ReadLine()), 2).PadLeft(16, '0'));
        }
    }
}