namespace MatrixOperations
{
    using System;

    public class Startup
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int n = 0;
            while (!int.TryParse(input, out n) || n < 0 || n > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            int[,] matrix = new int[n, n];
            int i = 0,
                j = 0;

            Matrix.ChangeIfUndefined(matrix, n);
            Matrix.OutputMatrix(matrix, n);

            Matrix.FindCell(matrix, out i, out j);

            Matrix.ChangeIfUndefined(matrix, n);
            Matrix.OutputMatrix(matrix, n);
        }
    }
}
