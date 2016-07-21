using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.TriangleSurfaceByTwoSidesAndAnAngle
{
    class TriangleSurface
    {
        static void Main(string[] args)
        {
            double side1 = double.Parse(Console.ReadLine());
            double side2 = double.Parse(Console.ReadLine());
            double angle = double.Parse(Console.ReadLine());
            Console.WriteLine("{0:F2}", Surface(side1, side2, angle));
        }
        static double Surface(double s1, double s2, double angle)
        {
            double surface = (s1 * s2 * Math.Sin(Math.PI*angle/180.0)) / 2;
            return surface;
        }
    }
}
