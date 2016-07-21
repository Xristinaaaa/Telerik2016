using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.TriangleSurfaceBySideAndLatitude
{
    class TriangleSurfaceBySideAndLatitude
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            double altitude = double.Parse(Console.ReadLine());
            Console.WriteLine("{0:F2}",Surface(side,altitude));
        }
        static double Surface(double s, double al)
        {
            double surface = (s * al) / 2;
            return surface;
        }
    }
}
