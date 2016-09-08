using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bunnies
{
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Threading.Tasks;

    public static class StringExtensions
    {
        public static string SplitToSeparateWordsByUppercaseLetter(this string sequence)
        {
            var probableStringMargin = 10;
            var probableStringSize = sequence.Length + probableStringMargin;
            var builder = new StringBuilder(probableStringSize);

            var singleWhitespace = ' ';
            foreach (var letter in sequence)
            {
                if (Char.IsUpper(letter))
                {
                    builder.Append(singleWhitespace);
                }

                builder.Append(letter);
            }

            return builder.ToString().Trim();
        }
    }
}
