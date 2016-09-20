using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.DayOfWeek
{
    class DayOfWeek
    {
        static void Main(string[] args)
        {
            DateTime ClockInfoFromSystem = DateTime.Now;
            int day1= (int)ClockInfoFromSystem.DayOfWeek;
            Console.WriteLine(day1);
        }
    }
}
