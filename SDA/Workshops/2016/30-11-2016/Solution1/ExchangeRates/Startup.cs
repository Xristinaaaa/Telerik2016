using System;
using System.Linq;

namespace ExchangeRates
{
    class Startup
    {
        static void Main()
        {
            double currency1 = double.Parse(Console.ReadLine());
            double currency2 = 0;
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var currencies = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
                var rate12 = currencies[0];
                var rate21 = currencies[1];

                double currentCurrency1 = Math.Max(currency1, currency2 * rate21);
                double currentCurrency2 = Math.Max(currency2, currency1 * rate12);

                currency1 = currentCurrency1;
                currency2 = currentCurrency2;
            }

            Console.WriteLine("{0:F2}", currency1);
        }
    }
}
