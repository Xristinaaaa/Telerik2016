using System;
using System.Linq;
using System.Text;

namespace ComputersData.Importer
{
    public static class RandomGenerator
    {
        private static readonly char[] Alphabet;

        private static Random random = new Random();

        static RandomGenerator()
        {
            Alphabet =
                Enumerable.Range('A', 26).Select(c => (char)c).Concat(
                Enumerable.Range('a', 26).Select(c => (char)c).Concat(
                Enumerable.Range('0', 10).Select(c => (char)c)))
                .ToArray();
        }

        public static int RandomNumber(int min = 0, int max = int.MaxValue / 2)
        {
            if (min > max)
            {
                return random.Next(max, min + 1);
            }

            return random.Next(min, max + 1);
        }

        public static string RandomString(int minLength = 0, int maxLength = int.MaxValue / 2)
        {
            var length = RandomNumber(minLength, maxLength);
            var result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(Alphabet[random.Next(0, Alphabet.Length)]);
            }

            return result.ToString();
        }
    }
}
