using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ParseTags
{
    class ParseTags
    {
        static void Main(string[] args)
        {
            /* 100/100
            using System;
            using System.Text.RegularExpressions;

            class ParseTags
            {
                static void Main()
                {
                  string text = Console.ReadLine(); 
                  Console.WriteLine(Regex.Replace(text, "<upcase>(.*?)</upcase>", word => word.Groups[1].Value.ToUpper()));
                }
            }
            */
            string text = Console.ReadLine();

            string pattern1 = "<upcase>";
            string pattern2 = "</upcase>";

            int index1 = text.IndexOf(pattern1);
            int index2 = text.IndexOf(pattern2);

            while (index1 >= 0 && index2 >= 0)
            {
                text = text.Replace(text.Substring(index1, index2 - index1), text.Substring(index1, index2 - index1).ToUpper());

                text = text.Remove(index2, pattern2.Length);
                text = text.Remove(index1, pattern1.Length);

                index1 = text.IndexOf(pattern1, ++index1);
                try
                {
                    index2 = text.IndexOf(pattern2, ++index2);
                }
                catch (ArgumentOutOfRangeException)
                {
                    index2 = -1;
                }
            }
            Console.WriteLine(text);
            
        }
    }
}
