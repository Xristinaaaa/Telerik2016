using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.TriangleSurfaceByThreeSides
{
    class TriangleSurface
    {
        static void Main(string[] args)
        {
            double side1 = double.Parse(Console.ReadLine());
            double side2 = double.Parse(Console.ReadLine());
            double side3 = double.Parse(Console.ReadLine());
            Console.WriteLine("{0:F2}", Surface(side1, side2, side3));
        }
        static double Surface(double s1, double s2, double s3)
        {
            double perimeter = (s1 + s2 + s3) / 2;
            double surface = Math.Sqrt(perimeter * (perimeter - s1) * (perimeter - s2) * (perimeter - s3));
            return surface;
        }
    }
}
