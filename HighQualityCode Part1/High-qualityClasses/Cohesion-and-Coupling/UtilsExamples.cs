using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileExtensions.GetFileExtension("example"));
            Console.WriteLine(FileExtensions.GetFileExtension("example.pdf"));
            Console.WriteLine(FileExtensions.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileExtensions.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileExtensions.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileExtensions.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                Operations2D.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                Operations3D.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Utils.Width = 3;
            Utils.Height = 4;
            Utils.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", Operations3D.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", Operations3D.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", Operations2D.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", Operations2D.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", Operations2D.CalcDiagonalYZ());
        }
    }
}
