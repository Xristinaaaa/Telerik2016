using System;
using System.Collections.Generic;
using System.Linq;

namespace FindNumber
{
    class Startup
    {
        static void Main()
        {
            var str = Console.ReadLine().Split(' ');

            int n = int.Parse(str[0]);
            int k = int.Parse(str[1]);

            var strings = Console.ReadLine().Split(' ').ToList();

            for (int i = 0; i < strings.Count && strings.Count > 1; i++)
            {
                var collections = new List<string>[128];

                foreach (var item in strings)
                {
                    int ch = i < item.Length ? item[i] : 0;

                    if (collections[ch] == null)
                    {
                        collections[ch] = new List<string>();
                    }

                    collections[ch].Add(item);
                }

                for (int j = 0; j < collections.Length; j++)
                {
                    if (collections[j]==null)
                    {
                        continue;
                    }

                    if (k<collections[j].Count)
                    {
                        strings = collections[j];
                        break;
                    }

                    k -= collections[j].Count;
                }
            }
            Console.WriteLine(strings[0]);
        }
    }
}
