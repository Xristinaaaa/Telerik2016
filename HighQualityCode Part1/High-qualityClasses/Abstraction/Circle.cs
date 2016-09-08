using System;

namespace Abstraction
{
    class Circle : IFigure
    {
        private double radius;

        public double Radius
        {
            get
            {
                return this.radius;
            }
            private set
            {
                if (this.radius <= 0)
                {
                    throw new ArgumentOutOfRangeException("Radius cannot be less than zero.");
                }
                this.radius = value;
            }
        }
        
        public Circle(double radius)
        {
            this.Radius = radius;
        }
        
        public double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
