using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ReverseString
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            char[] reversed=new char[s.Length];
            int index = 0;
            for (int i = s.Length-1; i >= 0; i--)
            {             
                reversed[index] = s[i];
                index++;
            }
            Console.WriteLine(reversed);
        }
    }
}
