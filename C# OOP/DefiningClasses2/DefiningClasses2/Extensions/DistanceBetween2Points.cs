using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefiningClasses2.Models;

namespace DefiningClasses2
{ 
    public static class DistanceBetween2Points
    {
        public static double Distance(Point3D first, Point3D second)
        {
            return Math.Sqrt(Math.Pow(first.X - second.X, 2)
                           + Math.Pow(first.Y - second.Y, 2)
                           + Math.Pow(first.Z - second.Z, 2));
        }
    }
}
