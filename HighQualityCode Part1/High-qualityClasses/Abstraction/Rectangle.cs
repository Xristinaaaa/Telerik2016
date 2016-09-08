using System;

namespace Abstraction
{
    class Rectangle : IFigure
    {
        private double width;
        private double height;

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (this.width <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width cannot be less than zero.");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (this.height <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height cannot be less than zero.");
                }
                this.height = value;
            }
        }
        
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
