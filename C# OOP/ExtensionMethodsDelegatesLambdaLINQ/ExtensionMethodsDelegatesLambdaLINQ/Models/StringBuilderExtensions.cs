using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodsDelegatesLambdaLINQ.Models
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder Substring(this StringBuilder builder, int index, int length)
        {
            var result = new StringBuilder();
            string append = builder.ToString().Substring(index, length);
            result.Clear();
            result.Append(append);
            return result;   
        }
    }
}
