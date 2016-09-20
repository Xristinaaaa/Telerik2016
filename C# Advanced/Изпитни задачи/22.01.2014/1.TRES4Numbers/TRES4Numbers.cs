//input-> convert to 9 numeral system and then chek the words of the table

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.TRES4Numbers
{
    class TRES4Numbers
    {
        static void Main(string[] args)
        {
            string[] tres4 = new string[] { "LON+", "VK-", "*ACAD", "^MIM", "ERIK|", "SEY&", "EMY>>", "/TEL", "<<DON" };
            ulong number = ulong.Parse(Console.ReadLine());
            int[] digits = new int[32];
            int digitCount = 0;

            do
            {
                digits[digitCount] = (int)(number % 9);
                number /= 9;
                digitCount++;
            }
            while (number>0);

            StringBuilder output = new StringBuilder();
            for (int i = digitCount-1; i >=0 ; i--)
            {
                output.Append(tres4[digits[i]]);
            }
            Console.WriteLine(output.ToString());
        }
    }
}
