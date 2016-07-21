using System;

class IndexOfLetters
{
    static void Main(string[] args)
    {
        char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                           'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        string word = Console.ReadLine();
        char[] arrOfChars = word.ToLower().ToCharArray();

        foreach (char ch in arrOfChars)
        {
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (ch==alphabet[i])
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}

