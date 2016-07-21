using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.SquareRoot
{
    class SquareRoot
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            try
            {
                double n = double.Parse(input);
                if (n<=0)
                {
                    throw new FormatException("Invalid number");
                }
                double square = Math.Sqrt(n);
                Console.WriteLine("{0:F3}", square);
            }
            catch (System.FormatException) // Catches exception if the input is not a number
            {
                Console.WriteLine("Invalid number");
            }
            catch (System.OverflowException) // Catches exception if the input out of integer scope
            {
                Console.WriteLine("Invalid number");
            }
            catch (System.ArgumentNullException) // Catches exception if the input is null
            {
                Console.WriteLine("Invalid number");
            }
            catch (System.ArithmeticException) // Catches exception if the input is negative integer
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
