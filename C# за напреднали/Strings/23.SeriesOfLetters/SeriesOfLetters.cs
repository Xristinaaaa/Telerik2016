using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23.SeriesOfLetters
{
    class SeriesOfLetters
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            StringBuilder compressed = new StringBuilder();
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i - 1] == text[i])
                {
                    continue;
                }
                else
                {
                    compressed.Append(text[i - 1]);
                }
            }
            compressed.Append(text[text.Length - 1]);
            Console.WriteLine(compressed);
        }
    }
}
