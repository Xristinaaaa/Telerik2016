using System;
using System.Collections.Generic;
using System.Linq;

namespace Guards
{
    public static class Program
    {
        static void Main()
        {
            string[] str = Console.ReadLine().Split(' ');

            int rows = int.Parse(str[0]);
            int cols = int.Parse(str[1]);

            bool[,] wall = new bool[rows, cols];
            int[,] seconds = new int[rows, cols];

            int guards = int.Parse(Console.ReadLine());
            
            for(var i=0; i<guards; i++)
            {
                var guardCoords = Console.ReadLine().Split(' ');
                wall[int.Parse(guardCoords[0]), int.Parse(guardCoords[1])] = true;
                switch (char.Parse(guardCoords[2]))
                {
                    case 'U':
                        if (int.Parse(guardCoords[0]) > 0)
                        {
                            if (seconds[int.Parse(guardCoords[0]) - 1, int.Parse(guardCoords[1])] < 3)
                            {
                                seconds[int.Parse(guardCoords[0]) - 1, int.Parse(guardCoords[1])] = 3;
                            }
                        }
                        break;
                    case 'D':
                        if (int.Parse(guardCoords[1]) < seconds.GetLength(1))
                        {
                            if (seconds[int.Parse(guardCoords[0]) + 1, int.Parse(guardCoords[1])] < 3)
                            {
                                seconds[int.Parse(guardCoords[0]) + 1, int.Parse(guardCoords[1])] = 3;
                            }
                        }
                        break;
                    case 'L':
                        if (int.Parse(guardCoords[1])>0)
                        {
                            if (seconds[int.Parse(guardCoords[0]), int.Parse(guardCoords[1]) - 1] < 3)
                            {
                                seconds[int.Parse(guardCoords[0]), int.Parse(guardCoords[1]) - 1] = 3;
                            }
                        }
                        break;
                    case 'R':
                        if (int.Parse(guardCoords[0]) < seconds.GetLength(1))
                        {
                            if (seconds[int.Parse(guardCoords[0]), int.Parse(guardCoords[1]) + 1] < 3)
                            {
                                seconds[int.Parse(guardCoords[0]), int.Parse(guardCoords[1]) + 1] = 3;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            
            var table = new long[rows + 1, cols + 1];
            long total = 2;
        
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    if (wall[i, j])
                    {
                        continue;
                    }

                    if (seconds[i, j] == 3)
                    {
                        total += 3;
                    }
                }
            }
            Console.WriteLine(total);
        }
    }
}
