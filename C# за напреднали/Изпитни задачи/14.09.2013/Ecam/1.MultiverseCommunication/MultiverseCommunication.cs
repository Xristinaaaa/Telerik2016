using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.MultiverseCommunication
{
    class MultiverseCommunication
    {
        static void Main(string[] args)
        {
            List<string> message = new List<string> { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };
            string input = Console.ReadLine();

            long decimalRepresentation = 0;
            for (int i = 0; i < input.Length; i+=3)
            {
                var inputInMessage = input.Substring(i, 3);
                long index = message.IndexOf(inputInMessage);

                decimalRepresentation *= 13;
                decimalRepresentation += index;
            }
            Console.WriteLine(decimalRepresentation);
        }
    }
}
