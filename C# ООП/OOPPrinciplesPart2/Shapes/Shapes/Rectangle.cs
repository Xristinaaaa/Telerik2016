namespace Shapes.Shapes
{
    using System;

    public class Rectangle : Shape
    {
        public Rectangle(int width, int height)
            :base(width, height) { }

        public override void CalculateSruface()
        {
            Console.WriteLine("The surface of the rectangle is {0}", this.Height*this.Width);
        }
    }
}
