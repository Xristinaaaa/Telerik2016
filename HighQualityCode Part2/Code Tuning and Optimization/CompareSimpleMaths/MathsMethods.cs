using System;
using System.Diagnostics;

namespace CompareSimpleMaths
{
    public static class MathsMethods
    {
        private const int ValueInteger = 1;
        private const long ValueLong = 1L;
        private const float ValueFloat = 1.0F;
        private const double ValueDouble = 1.0;
        private const decimal ValueDecimal = 1.0M;
        private const int Repeat= 10;
        private static Stopwatch stopwatch = new Stopwatch();

        public static void Test(Operation operation)
        {
            Console.WriteLine(operation);

            int intResult = ValueInteger;
            stopwatch.Start();

            for (var i = 0; i < Repeat; i +=1) {
                switch (operation)
                {
                    case Operation.Addition:
                        intResult += ValueInteger;
                        break;
                    case Operation.Subtraction:
                        intResult -= ValueInteger;
                        break;
                    case Operation.Multiplication:
                        intResult *= ValueInteger;
                        break;
                    case Operation.Division:
                        intResult /= ValueInteger;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Result of ineger " + operation + "= " + stopwatch.Elapsed);
            stopwatch.Reset();

            long longResult = ValueLong;
            stopwatch.Start();

            for (var i = 0; i < Repeat; i += 1)
            {
                switch (operation)
                {
                    case Operation.Addition:
                        longResult += ValueLong;
                        break;
                    case Operation.Subtraction:
                        longResult -= ValueLong;
                        break;
                    case Operation.Multiplication:
                        longResult *= ValueLong;
                        break;
                    case Operation.Division:
                        longResult /= ValueLong;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Result of long " + operation + "= " + stopwatch.Elapsed);
            stopwatch.Reset();

            float floatResult = ValueFloat;
            stopwatch.Start();

            for (var i = 0; i < Repeat; i += 1)
            {
                switch (operation)
                {
                    case Operation.Addition:
                        floatResult += ValueFloat;
                        break;
                    case Operation.Subtraction:
                        floatResult -= ValueFloat;
                        break;
                    case Operation.Multiplication:
                        floatResult *= ValueFloat;
                        break;
                    case Operation.Division:
                        floatResult /= ValueFloat;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Result of float " + operation + "= " + stopwatch.Elapsed);
            stopwatch.Reset();


            double doubleResult = ValueDouble;
            stopwatch.Start();

            for (var i = 0; i < Repeat; i += 1)
            {
                switch (operation)
                {
                    case Operation.Addition:
                        doubleResult += ValueDouble;
                        break;
                    case Operation.Subtraction:
                        doubleResult -= ValueDouble;
                        break;
                    case Operation.Multiplication:
                        doubleResult *= ValueDouble;
                        break;
                    case Operation.Division:
                        doubleResult /= ValueDouble;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Result of double " + operation + "= " + stopwatch.Elapsed);
            stopwatch.Reset();


            decimal decimalResult = ValueDecimal;
            stopwatch.Start();

            for (var i = 0; i < Repeat; i += 1)
            {
                switch (operation)
                {
                    case Operation.Addition:
                        decimalResult += ValueDecimal;
                        break;
                    case Operation.Subtraction:
                        decimalResult -= ValueDecimal;
                        break;
                    case Operation.Multiplication:
                        decimalResult *= ValueDecimal;
                        break;
                    case Operation.Division:
                        decimalResult /= ValueDecimal;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Result of decimal " + operation + "= " + stopwatch.Elapsed);
            stopwatch.Reset();
        }
    }
}
