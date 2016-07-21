using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.KotTakoa
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var lines = new List<string>(n);

            for (int i = 0; i < n; i++)
            {
                lines[i] = Console.ReadLine();

            }
            for (int i = 0; i < n; i++)
            {
                if (lines[i]=="/")
                {
                    lines.Remove(lines[i]);
                }
                var name = lines[i].Split(new[] { ' ', ';', '{','}','(',')' }, StringSplitOptions.RemoveEmptyEntries);

            }
            for (int i = 0; i < n; i++)
            {
                Console.Write(lines[i]);
            }
        }
    }
}
