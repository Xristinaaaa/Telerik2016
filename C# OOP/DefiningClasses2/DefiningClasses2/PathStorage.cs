using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DefiningClasses2.Models;

namespace DefiningClasses2
{
    public static class PathStorage
    {
        public static void SavePath(Models.Path path, string identifier)
        {
            using (StreamWriter sw = new StreamWriter("path" + identifier + ".txt"))
            { 
                for (int i = 0; i < path.Points.Count; i++)
                {
                    sw.WriteLine(path.Points[i]);
                }
            }
        }
        public static Models.Path LoadPath(string filePath)
        {
            Models.Path path = new Models.Path();

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (sr.EndOfStream == false)
                {
                    string text = sr.ReadLine();
                    Point3D nextPoint = Point3D.Parse(text);
                    path.Add(nextPoint);
                }
            }
            return path;
        }
    }
}
