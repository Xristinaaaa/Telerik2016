using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bunnies.Contracts;

namespace Bunnies
{
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Threading.Tasks;

    public class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
