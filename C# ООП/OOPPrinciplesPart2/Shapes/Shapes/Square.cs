namespace Shapes.Shapes
{
    using System;

    public class Square : Shape
    {
        public Square(int width, int height)
            :base(width, height)
        {
            width = height;
        }

        public override void CalculateSruface()
        {
            Console.WriteLine("The surface of the square is {0}", this.Height * this.Width);
        }
    }
}
