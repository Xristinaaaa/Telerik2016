using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses2.Models
{
    public class Point3D
    {
        private static readonly Point3D start;

        private double x; 
        private double y; 
        private double z; 

        //public Point3D()
        //{

        //}
        static Point3D() 
        {
            start = new Point3D(0, 0, 0);
        }

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        
        public double X  
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }
        public double Z 
        {
            get
            {
                return this.z;
            }
            set
            {
                this.z = value;
            }
        }
        public static Point3D Start
        {
            get
            {
                return start;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", this.X, this.Y, this.Z);
        }
        public static Point3D Parse(string input)
        {
            StringBuilder coordinates = new StringBuilder();
            double[] xyz = new double[3];
            int index = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]) || input[i] == '-')
                {
                    while (i < input.Length && (Char.IsDigit(input[i]) || input[i] == '-' || input[i] == '.'))
                    {
                        coordinates.Append(input[i]);
                        i++;
                    }
                }
                if (coordinates.Length > 0)
                {
                    double coord = double.Parse(coordinates.ToString());
                    xyz[index] = coord;
                    index++;
                    coordinates.Clear();
                }
            }
            return new Point3D(xyz[0], xyz[1], xyz[2]);
        }
    }
}
