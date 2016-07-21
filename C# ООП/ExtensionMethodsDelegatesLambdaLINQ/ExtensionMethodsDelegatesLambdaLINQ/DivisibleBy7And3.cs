using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodsDelegatesLambdaLINQ
{
    class DivisibleBy7And3
    {
        public  Array Divisible ()
        { 
            int[] array = { 3, 4, 5, 6, 1, 3, 7, 8 };
            var divisible = array
                .Select(x => x % 3 == 0 && x % 7 == 0)
                .ToArray();
            return divisible;
        }

    }
}
