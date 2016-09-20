using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefiningClasses2.Models;

namespace DefiningClasses2.Models
{
    public class Path 
    {
        private List<Point3D> points;

        public Path()
        {
            this.points = new List<Point3D>();
        }
        public List<Point3D> Points
        {
            get
            {
                return this.points;
            }
            set
            {
                this.points = value;
            }
        }

        public void Add(Point3D point)
        {
            this.points.Add(point);
        }
        public void Remove(Point3D point)
        {
            this.points.Remove(point);
        }
    }
}
