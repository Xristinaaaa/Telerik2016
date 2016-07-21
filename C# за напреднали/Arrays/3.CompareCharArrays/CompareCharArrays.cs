using System;

class CompareCharArrays
{
    static void Main(string[] args)
    {
        string arr1 = Console.ReadLine();
        string arr2 = Console.ReadLine();

        for (int i = 0; i < Math.Min(arr1.Length, arr2.Length); i++)
        {
            if (arr1[i] < arr2[i])
            {
                Console.WriteLine("<");
                return;
            }
            else if (arr1[i]>arr2[i])
            {
                Console.WriteLine(">");
                return;
            }
        }
        if (arr1.Length == arr2.Length)
        {
            Console.WriteLine("=");
        }
        else if (arr1.Length < arr2.Length)
        {
            Console.WriteLine("<");
        }
        else if (arr1.Length > arr2.Length)
        {
            Console.WriteLine(">");
        }
    }
}
