using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.VariableLengthCoding
{
    class VariableLengthCoding
    {
        static string ToBinary(string x)
        {
            return Convert.ToString(byte.Parse(x), 2).PadLeft(8,'0');
        }
        static void Main(string[] args)
        {
            var binaryCode = string.Join("", Console.ReadLine().Split(' ').Select(ToBinary).ToArray());

            var code=binaryCode.Split(new char[] { '0' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Length);

            int n = int.Parse(Console.ReadLine());
            char[] reverseTable = new char[n + 1];

            for (int i = 0; i < n; i++)
            {
                var line=Console.ReadLine();
                int index = int.Parse(line.Substring(1));
                reverseTable[index] = line[0];
            }

            var text =code.Select(x => reverseTable[x]).ToArray();

            Console.WriteLine(text);
        }
    }
}
