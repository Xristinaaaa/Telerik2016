using System;
namespace OddNumber
{
    public class Startup
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            long num = long.Parse(Console.ReadLine());

            for (int i = 0; i < n - 1; i++)
            {
                long current = long.Parse(Console.ReadLine());
                num ^= current;
            }

            Console.WriteLine(num);
        }
    }
}
