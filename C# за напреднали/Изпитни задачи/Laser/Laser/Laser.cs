using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Laser
{
    class Laser
    {
        static void Main(string[] args)
        {
            if (File.Exists("input.txt"))
            {
                Console.SetIn(new StreamReader("input.txt"));
            }
            int[] dims = GetThreeNumbersFromConsole();
            int[] pos = GetThreeNumbersFromConsole();
            int[] vect = GetThreeNumbersFromConsole();
        }
        static int[] GetThreeNumbersFromConsole ()
        {
            string input = Console.ReadLine();
            string[] split = input.Split(' ');
            int[] array = new int[3];
            for (int i = 0; i < 3; i++)
            {
                array[i] = int.Parse(split[i]);
            }
            return array;
            //return split.Select(s => int.Parse(s)).ToArray();
        }
    }
}
