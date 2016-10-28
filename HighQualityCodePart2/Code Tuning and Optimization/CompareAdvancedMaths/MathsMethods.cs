using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareAdvancedMaths
{
    public static class MathsMethods
    {
        private const float ValueFloat = 1.0F;
        private const double ValueDouble = 1.0;
        private const decimal ValueDecimal = 1.0M;
        private static Stopwatch stopwatch = new Stopwatch();

        public static void Test(Operations operation)
        {
            Console.WriteLine(operation);

            float floatResult = ValueFloat;
            stopwatch.Start();

            switch (operation)
            {
                case Operations.SquareRoot:
                    floatResult = (float)Math.Sqrt(ValueFloat);
                    break;
                case Operations.NaturalLogarithm:
                    floatResult = (float)Math.Log(ValueFloat);
                    break;
                case Operations.Sinus:
                    floatResult = (float)Math.Sin(ValueFloat);
                    break;
                default:
                    throw new InvalidOperationException();
            }
            
            stopwatch.Stop();
            Console.WriteLine("Result of float " + operation + "= " + stopwatch.Elapsed);
            stopwatch.Reset();

            double doubleResult = ValueDouble;
            stopwatch.Start();

            switch (operation)
            {
                case Operations.SquareRoot:
                    doubleResult = Math.Sqrt(ValueDouble);
                    break;
                case Operations.NaturalLogarithm:
                    doubleResult = Math.Log(ValueDouble);
                    break;
                case Operations.Sinus:
                    doubleResult = Math.Sin(ValueDouble);
                    break;
                default:
                    throw new InvalidOperationException();
            }

            stopwatch.Stop();
            Console.WriteLine("Result of double " + operation + "= " + stopwatch.Elapsed);
            stopwatch.Reset();


            decimal decimalResult = ValueDecimal;
            stopwatch.Start();

            switch (operation)
            {
                case Operations.SquareRoot:
                    decimalResult = (decimal)Math.Sqrt((double)ValueDecimal);
                    break;
                case Operations.NaturalLogarithm:
                    decimalResult = (decimal)Math.Log((double)ValueDecimal);
                    break;
                case Operations.Sinus:
                    decimalResult = (decimal)Math.Sin((double)ValueDecimal);
                    break;
                default:
                    throw new InvalidOperationException();
            }

            stopwatch.Stop();
            Console.WriteLine("Result of decimal " + operation + "= " + stopwatch.Elapsed);
            stopwatch.Reset();
        }
    }
}
