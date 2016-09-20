using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.StrangeLandNumbers
{
    class Program
    {
        static void Main()
        {
            string[] strangeLandNumbers = new string[7];
            strangeLandNumbers[0] = "f";
            strangeLandNumbers[1] = "bIN";
            strangeLandNumbers[2] = "oBJEC";
            strangeLandNumbers[3] = "mNTRAVL";
            strangeLandNumbers[4] = "lPVKNQ";
            strangeLandNumbers[5] = "pNWE";
            strangeLandNumbers[6] = "hT";

            string input = Console.ReadLine();

            StringBuilder currentStrangeLandNumber = new StringBuilder();
            int currentNumPos = 0;

            ulong output = 0;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                currentStrangeLandNumber.Append(input[i]);

                char[] letters = currentStrangeLandNumber.ToString().ToCharArray();

                Array.Reverse(letters);

                int currentIndex = Array.IndexOf(strangeLandNumbers, new string(letters));

                if (currentIndex != -1)
                {
                    output += (ulong)Math.Pow(7, currentNumPos) * (ulong)currentIndex;
                    currentStrangeLandNumber.Clear();
                    currentNumPos++;
                }
            }
            Console.WriteLine(output);
        }
    }
}
