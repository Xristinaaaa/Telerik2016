using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareAdvancedMaths
{
    class Startup
    {
        static void Main(string[] args)
        {
            MathsMethods.Test(Operations.SquareRoot);
            MathsMethods.Test(Operations.NaturalLogarithm);
            MathsMethods.Test(Operations.Sinus);
        }
    }
}
