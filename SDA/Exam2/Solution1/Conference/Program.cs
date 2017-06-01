using System;
using System.Collections.Generic;
using System.Linq;
namespace Conference
{
    public static class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int n = input[0];
            int m = input[1];

            var connections = new List<int>[n];

            for (int i = 0; i < m; i++)
            {
                var line = Console.ReadLine().Split(' ');

                int a = int.Parse(line[0]);
                int b = int.Parse(line[1]);

                if (connections[a]==null)
                {
                    connections[a] = new List<int>();
                }
                if (connections[b]==null)
                {
                    connections[b] = new List<int>();
                }

                connections[a].Add(b);
                connections[b].Add(a);
            }

            int numOfChoices = 0;
            var visited = new bool[n];
            var componentId = new int[n];

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    Dfs(i, connections, visited, i, componentId);
                }
            }
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (connections[i] != null && i != j && !connections[i].Contains(j))
                    {
                        if (componentId[i] != componentId[j])
                        {
                            numOfChoices++;
                        }
                    }
                    if (connections[i] == null && i != j)
                    {
                        numOfChoices++;
                    }
                }
            }
            Console.WriteLine(numOfChoices/2);
        }
        static void Dfs(int x, List<int>[] connections, bool[] visited, int id, int[] componentId)
        {
            visited[x] = true;
            componentId[x] = id;

            if (connections[x]!=null)
            {
                foreach (var dev in connections[x])
                {
                    if (visited[dev])
                    {
                        continue;
                    }

                    Dfs(dev, connections, visited, id, componentId);
                }
            }
        }
    }
}
