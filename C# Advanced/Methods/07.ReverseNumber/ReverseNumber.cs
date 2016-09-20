using System;

class ReverseNumber
{
    static string Reverse(string number)
    {
        string reverse=string.Empty;
        for (int i = number.Length-1; i>=0; i--)
        {
            reverse += number[i];
        }
        return reverse;
    }
    static void Main(string[] args)
    {
        string number = Console.ReadLine();
        Console.WriteLine(Reverse(number));
    }
}

