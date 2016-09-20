using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace _1.CryptoCs
{
    class CryptoCs
    {
        static BigInteger Convert26to10(string input)
        {
            BigInteger result = 0;

            foreach (var digit in input)
            {
                result = (digit - 'a') + result*26;
            }

            return result;
        }

        static BigInteger Convert7to10(string input)
        {
            //BigInteger sum = 0;

            //foreach (var digit in input)
            //{
            //    sum = (digit - 'a') + sum * 7;
            //}
            //return sum;

            string characters = "0123456";
            int cbase = 7;
            BigInteger results = 0;

            foreach (char digit in input.ToString().ToArray())
            {
                results = (cbase * results) + characters.IndexOf(digit);
            }

            return results;
        }

        const string NineDigits = "012345678";

        static string Convert10to9(BigInteger input)
        {
            //BigInteger sum = 0;

            //foreach (var digit in input)
            //{
            //    sum = (digit - 'a') + sum * 10;
            //}
            //return sum;

            string result = string.Empty;

            do
            {
                BigInteger value = input % 9;
                result = NineDigits[(int)value] + result;
                input /= 9;

            } while (input != 0);

            return result;

        }
        static void Main()
        {
            //1.2 read num1 in 26 based system
            //1.2 read + or -
            //1.3 read num2 in 7 based system
            //2.1 convert num1 to dec
            //2.2 convert num2 to dec
            //3 sum the numbers
            //4 print the result

            var num1 = Console.ReadLine();
            char sign = char.Parse(Console.ReadLine());
            var num2 = Console.ReadLine();

            BigInteger sum = 0;
            if (sign == '+')
            {
                sum = (Convert26to10(num1)) + (Convert7to10(num2));
            }
            else if (sign == '-')
            {
                sum = (Convert26to10(num1)) - (Convert7to10(num2));
            }

            Console.WriteLine(Convert10to9(sum));
        }
    }
}
