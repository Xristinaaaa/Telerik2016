using System;
using Dealership.Contracts;

namespace Dealership.Engine.IOProvider
{
    public class IOProvider : IIOProvider
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string input)
        {
            Console.Write(input);
        }

        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }
    }
}
