using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.LeapYear
{
    class LeapYear
    {
        static void Main(string[] args)
        {
            int year = int.Parse(Console.ReadLine());
            if (year%4==0)
            {
                if (year % 100 == 0)
                {
                    if (year % 400 == 0)
                    {
                        Console.WriteLine("Leap");

                    }
                    else
                    {
                        Console.WriteLine("Common");
                    }
                }
                else
                {
                    Console.WriteLine("Leap");
                }
            }
            else
            {
                Console.WriteLine("Common");
            }
        }
    }
}
