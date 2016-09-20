using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.ParseUrl
{
    class ParseUrl
    {
        static void Main(string[] args)
        {
            string url = Console.ReadLine();

            int indexCol = url.IndexOf(":");
            string protocol = url.Substring(0, indexCol);
            Console.WriteLine("[protocol] = {0}", protocol);

            string firstSub = url.Substring(indexCol + 3, url.Length-protocol.Length-3);
            int indexSlash = firstSub.IndexOf("/");
            string server = firstSub.Substring(0, indexSlash);
            Console.WriteLine("[server] = {0}", server);


            string resource = firstSub.Substring(indexSlash);
            Console.WriteLine("[resource] = {0}",resource);

        }
    }
}
