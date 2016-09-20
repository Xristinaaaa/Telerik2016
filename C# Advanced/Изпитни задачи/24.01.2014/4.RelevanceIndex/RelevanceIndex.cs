using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.RelevanceIndex
{
    class RelevanceIndex
    {
        static string[] symbols = new string[] { " ", ",", ".", "(", ")", ";", "-", "!", "?" };

        static void Main()
        {
            string searchWord = Console.ReadLine();
            int L = int.Parse(Console.ReadLine());

            List<string> paragraphs = new List<string>();
            List<int> indexes = new List<int>();
            
            //add the paragraphs with searched words to upper in a list
            //add the relevance indexes of all lines in a list
            for (int i = 0; i < L; i++)
            {
                var currentLine = Console.ReadLine().Split(symbols, StringSplitOptions.RemoveEmptyEntries);

                int relevanceIndex = 0;
                for (int j= 0; j < currentLine.Length; j++)
                {
                    string word = currentLine[j];
                    if (word.ToLower() == searchWord.ToLower())
                    {
                        relevanceIndex++;
                        currentLine[j] = word.ToUpper();
                    }
                }
                paragraphs.Add(string.Join(" ", currentLine));
                indexes.Add(relevanceIndex);
            }

            //sort the paragraphs depending on their index
            List<string> sortedParagraphs = new List<string>();

            while (sortedParagraphs.Count<paragraphs.Count)
            {
                int maxIndex = 0;
                int maxParagraphIndex = 0;
                for (int i = 0; i < indexes.Count; i++)
                {
                    if (maxIndex < indexes[i])
                    {
                        maxIndex = indexes[i];
                        maxParagraphIndex = i;
                    }
                }
                sortedParagraphs.Add(paragraphs[maxParagraphIndex]);
                indexes[maxParagraphIndex] = -1;
            }
            Console.WriteLine(string.Join(Environment.NewLine, sortedParagraphs));
        }
    }
}
