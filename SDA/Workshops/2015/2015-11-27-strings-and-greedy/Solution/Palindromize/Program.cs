using System;
using System.Collections.Generic;
using System.Linq;

namespace Palindromize
{
    public static class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var result = Palindromize(input);
            Console.WriteLine(result);
        }
        private static bool IsPalindrome(string str)
        {
            for (int i = 0; i < str.Length/2; i++)
            {
                if (str[i] != str[str.Length-i-1])
                {
                    return false;
                    
                }
            }
            return true;
        }
        private static string Palindromize(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var substr = input.Substring(0, i).ToCharArray();
                Array.Reverse(substr);
                var result = input + new string(substr);
                if (IsPalindrome(result))
                {
                    return result;
                }
            }

            return string.Empty;
        }
    }
}
