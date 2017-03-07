using System;
using System.Collections.Generic;
using System.Linq;

namespace Diameter
{
    public class Startup
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var neighbours = new List<Tuple<int, int>>[n];

            for (int i = 1; i < n; i++)
            {
                var strs = Console.ReadLine().Split(' ');
                int a = int.Parse(strs[0]);
                int b = int.Parse(strs[1]);
                int len = int.Parse(strs[2]);

                if (neighbours[a] == null)
                {
                    neighbours[a] = new List<Tuple<int, int>>();
                }
                if (neighbours[b] == null)
                {
                    neighbours[b] = new List<Tuple<int, int>>();
                }

                neighbours[a].Add(new Tuple<int, int>(b, len));
                neighbours[b].Add(new Tuple<int, int>(a, len));
            }

            int maxIndex = 0;
            bool[] visited = new bool[n];
            int[] path = new int[n];
            path[0] = 0;

            Dfs(0, neighbours, visited, path);

            for (int i = 0; i < n; i++)
            {
                if (path[maxIndex]<path[i])
                {
                    maxIndex = i;
                }
            }

            visited = new bool[n];
            path = new int[n];
            path[maxIndex] = 0;
            Dfs(maxIndex, neighbours, visited, path);

            Console.WriteLine(path.Max());
        }
        static void Dfs(int x, List<Tuple<int, int>>[] neighbours, bool[] visited, int[] path)
        {
            visited[x] = true;

            foreach (var neigh in neighbours[x])
            {
                if (visited[neigh.Item1])
                {
                    continue;
                }

                path[neigh.Item1] = path[x] + neigh.Item2;
                Dfs(neigh.Item1, neighbours, visited, path);
            }
        }
    }
}
