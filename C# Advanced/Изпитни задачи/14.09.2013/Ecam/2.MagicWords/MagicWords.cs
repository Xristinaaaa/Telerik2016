using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.MagicWords
{
    class MagicWords
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> words = new List<string>(n);
            for (int i = 0; i < n; i++)
            {
                words.Add(Console.ReadLine());
            }

            //Reorder
            for (int i = 0; i < n; i++)
            {
                string word = words[i];
                int index = words[i].Length % (words.Count + 1);
                
                words.Insert(index, word);

                if (index<i)
                {
                    words.RemoveAt(i + 1);
                }
                else
                {
                    words.RemoveAt(i);
                }
            }

            //Print
            // var maxlength=words.Max(x=>x.Length);

            int maxlength = words[0].Length;
            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].Length>maxlength)
                {
                    maxlength = words[i].Length;
                }
            }

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < maxlength; i++)
            {
                foreach (var word in words)
                {
                    if (word.Length > i)
                    {
                        result.Append(word[i]);
                    }
                }         
            }
            Console.WriteLine(result.ToString());
        }
    }
}
