namespace Shapes
{
    using System;
    using Shapes;

    class Startup
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(5, 6);
            rectangle.CalculateSruface();
            Triangle triangle = new Triangle(4, 3);
            triangle.CalculateSruface();
            Square square = new Square(7, 7);
            square.CalculateSruface();
        }
    }
}
