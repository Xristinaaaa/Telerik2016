using System;
using System.Collections.Generic;
using System.Linq;

namespace Rabbits
{
    public class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var inputAnswers = input.Split(' ').Select(int.Parse).ToList();
            inputAnswers.RemoveAt(inputAnswers.Count - 1);

            var result = MinimumRabbits(inputAnswers);
            Console.WriteLine(result);
        }
        public static int MinimumRabbits(IEnumerable<int> answers)
        {
            var groups = new Dictionary<int, int>(); // Key= group size, Value= count of rabbits in group

            foreach (var answer in answers)
            {
                if (!groups.ContainsKey(answer + 1))
                {
                    groups.Add(answer + 1, 0);
                }

                groups[answer + 1]++;
            }

            var rabbits = 0;

            foreach (var group in groups)
            {
                var size = group.Key;
                var rabbitsInGroup = group.Value;
                
                var groupsCount = (int)Math.Ceiling(rabbitsInGroup / (decimal)size);
                rabbits += groupsCount * size;
            }
            return rabbits;
        }
    }
}
