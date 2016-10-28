using System;

namespace CompareSimpleMaths
{
    class Startup
    {
        static void Main(string[] args)
        {
            MathsMethods.Test(Operation.Addition);
            MathsMethods.Test(Operation.Subtraction);
            MathsMethods.Test(Operation.Multiplication);
            MathsMethods.Test(Operation.Division);
        }
    }
}
