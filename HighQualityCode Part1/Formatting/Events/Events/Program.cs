using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            while (EventsCommands.ExecuteNextCommand())
            {
            }

            Console.WriteLine(Messages.output);
        }
    }
}
