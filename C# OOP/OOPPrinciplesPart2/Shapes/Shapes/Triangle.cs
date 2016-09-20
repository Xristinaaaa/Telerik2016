namespace Shapes.Shapes
{
    using System;

    public class Triangle : Shape
    {
        public Triangle(int width, int height)
            :base(width, height) { }

        public override void CalculateSruface()
        {
            Console.WriteLine("The surface of the triangle is {0}", this.Height * this.Width / 2);
        }

    }
}
