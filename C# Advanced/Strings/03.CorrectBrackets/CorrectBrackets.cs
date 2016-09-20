using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CorrectBrackets
{
    class CorrectBrackets
    {
        static void Check(string expr)
        {
            char[] str = expr.ToCharArray();
            int brackets = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i]=='(')
                {
                    brackets++;
                }
                if (str[i]==')')
                {
                    brackets--;
                }
                if (brackets<0)
                {
                    break;
                }
            }
            if (brackets==0)
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect");
            }
        }
        static void Main(string[] args)
        {
            string expr = Console.ReadLine();
            Check(expr);
        }
    }
}
