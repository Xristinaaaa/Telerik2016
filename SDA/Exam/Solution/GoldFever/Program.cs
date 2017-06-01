using System;
using System.Collections.Generic;
using System.Linq;

namespace GoldFever
{
    public static class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            
            var prices = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            double maxProfit = 0;

            for (int i = 0; i < n; i++)
            {
                var currentPrice = prices[i];

                if (currentPrice == prices.Min())
                {
                    maxProfit -= currentPrice;
                }

                if (i > 0 && currentPrice>prices[i-1])
                {
                    maxProfit += currentPrice;
                }
                
            }

            if (maxProfit<0)
            {
                maxProfit = 0;
            }
            Console.WriteLine(maxProfit);
        }
    }
}
