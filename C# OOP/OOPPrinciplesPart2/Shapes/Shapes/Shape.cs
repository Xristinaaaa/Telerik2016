namespace Shapes.Shapes
{
    using System;

    public abstract class Shape
    {
        private int width;
        private int height;

        public Shape(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                this.height = value;
            }
        }

        public abstract void CalculateSruface();

    }
}
