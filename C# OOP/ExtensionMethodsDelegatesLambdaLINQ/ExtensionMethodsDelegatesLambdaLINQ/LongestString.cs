using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodsDelegatesLambdaLINQ
{
    class LongestString
    {
        public string MaxLength()
        {
            List<string> arrOfStrings = new List<string>();
            int maxLength = arrOfStrings[0].Length;

            foreach (var str in arrOfStrings)
            {
                if (str.Length>maxLength)
                {
                    maxLength = str.Length;
                }
            }
            var result = arrOfStrings
                .Where(x => x.Length == maxLength)
                .Select(x => x)
                .ToString();

            return result;
        }
    }
}
