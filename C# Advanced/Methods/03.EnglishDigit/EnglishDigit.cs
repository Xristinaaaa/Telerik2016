using System;

class EnglishDigit
{
    static string ReturnAsWord(int number)
    {
        byte lastDigit = (byte)(number % 10);
        string[] words = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        return words[lastDigit];
    }
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(ReturnAsWord(number));
    }
}

