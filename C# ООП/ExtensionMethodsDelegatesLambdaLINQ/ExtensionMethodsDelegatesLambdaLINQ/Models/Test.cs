using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodsDelegatesLambdaLINQ.Models
{
    public class Test
    {
        public static void Testing()
        {
            var text = "Testing my builder";
            var str = new StringBuilder();
            str.Append(text);
            str = str.Substring(5, 3);
            Console.WriteLine(str);
            //??
        }
    }
}
