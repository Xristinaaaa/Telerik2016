using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.HexadecimalToBinary
{
    class Program
    {
        public static Dictionary<char, string> HexToBinaryTable = new Dictionary<char, string>()
        {
            {'0',"0000" },
            {'1',"0001" },
            {'2',"0010" },
            {'3',"0011" },
            {'4',"0100" },
            {'5',"0101" },
            {'6',"0110" },
            {'7',"0111" },
            {'8',"1000" },
            {'9',"1001" },
            {'A',"1010" },
            {'B',"1011" },
            {'C',"1100" },
            {'D',"1101" },
            {'E',"1110" },
            {'F',"1111" }
        };

        public static Dictionary<string, char> BinaryToHexTable = new Dictionary<string, char>()
        {
            {"0000", '0' },
            {"0001", '1' },
            {"0010", '2' },
            {"0011", '3' },
            {"0100", '4' },
            {"0101", '5' },
            {"0110", '6' },
            {"0111", '7' },
            {"1000", '8' },
            {"1001", '9' },
            {"1010", 'A' },
            {"1011", 'B' },
            {"1100", 'C' },
            {"1101", 'D' },
            {"1110", 'E' },
            {"1111", 'F' }
        };
        static void Main(string[] args)
        {
            string hexNumber = Console.ReadLine();
            Console.WriteLine(HexadecimalToBinary(hexNumber));
        }

        private static string HexadecimalToBinary(string hexNumber)
        {
            StringBuilder decimalRepresentation = new StringBuilder();

            foreach (var digit in hexNumber)
            {
                decimalRepresentation.Append(HexToBinaryTable[digit]);
            }

            return (decimalRepresentation.ToString().Substring(decimalRepresentation.ToString().IndexOf('1'), decimalRepresentation.ToString().Length - decimalRepresentation.ToString().IndexOf('1')));
        }
    }
}
