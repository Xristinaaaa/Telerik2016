using System;
using System.Linq;

/*
string wantedWord = Console.ReadLine();
wantedWord = wantedWord.ToLower();

string word = Console.ReadLine();
        
word = word.ToLower();

int curentIndex = 0;
int counter = 0;
int index = 0;
        
while (word.IndexOf(wantedWord, index) != -1)
{
    curentIndex = word.IndexOf(wantedWord, index);
    counter++;
    index = curentIndex + wantedWord.Length;
}

Console.WriteLine(counter);
*/
  
class SubstringInText
{
    static void Main()
    {
        string pattern = Console.ReadLine();
        string text = Console.ReadLine();

        int counter = 0;
        for (int i = 0; i < text.Length - pattern.Length + 1; i++)
        {
            if (text.Substring(i, pattern.Length).Equals(pattern, StringComparison.OrdinalIgnoreCase))
                counter++;
        }
        Console.WriteLine(counter);

    }
}
