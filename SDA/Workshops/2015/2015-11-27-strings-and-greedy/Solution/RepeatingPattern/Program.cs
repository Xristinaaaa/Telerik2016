using System;

namespace RepeatingPattern
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            int n = text.Length;

            text = text + text;

            //precompute
            int[] fl = new int[n + 1];
            fl[0] = -1;
            fl[1] = 0;

            for (int i = 1; i < n; i++)
            {
                int j = fl[i];
                while (j >= 0 && text[j] != text[i])
                {
                    j = fl[j];
                }
                fl[i + 1] = j + 1;
            }


            // search
            int matched = 0;
            for (int i = 1; i < text.Length; i++)
            {
                while (matched >= 0 && text[i] != text[matched])
                {
                    matched = fl[matched];
                }

                matched++;

                if (matched == n)
                {
                    Console.WriteLine(text.Substring(0, i - (n - 1)));
                    break;
                }
            }
        }
    }
}
