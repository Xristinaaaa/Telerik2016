using System;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace Products
{
    class Startup
    {
        static void Main()
        {
            var products = new OrderedMultiDictionary<int, string>(false);

            for (int product = 0; product < 500000; product++)
            {
                products.Add(product, string.Format("product {0}", product));
            }

            var output = new StringBuilder();

            for (int range = 0; range < 10000; range++)
            {
                var result = products.Range(range, true, range * 50, true).Take(20);
                output.AppendLine(string.Join(", ", result.Select(x => x.Key))).AppendLine();
            }

            Console.WriteLine(output);
        }
    }
}
