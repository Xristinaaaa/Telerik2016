using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.StringLength
{
    class StringLength
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            str = str.Replace(@"\", string.Empty);
            Console.WriteLine(str.PadRight(20, '*'));        
        }
    }
}
