using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefiningClasses2.Models;

namespace DefiningClasses2
{
    class Program
    {
        static void Main(string[] args)
        {
            var point = new Point3D();

            point.X = 0.5;
            point.Y = -3;
            point.Z = 1.35;

            Console.WriteLine(point);
            Console.WriteLine(DistanceBetween2Points.Distance(point, Point3D.Start));

            Path test = new Path();
            Point3D point1 = new Point3D(1, 2, 3);
            Point3D point2 = new Point3D(-1, 6, 7);
            Point3D point3 = new Point3D(4, 2, 3);
            Point3D point4 = new Point3D(-3, -4, 3);
            Point3D point5 = new Point3D(1.20, 2.35, 3);

            test.Add(point1);      
            test.Add(point2);
            test.Add(point3);
            test.Add(point4);
            test.Add(point5);

            PathStorage.SavePath(test, "sample"); 

            Path path = PathStorage.LoadPath(@"pointsample.txt"); 
            
            for (int i = 0; i < path.Points.Count; i++)
            {
                Console.WriteLine("{0}: {1}", i + 1, path.Points[i].ToString());
            }
        }
    }
}
