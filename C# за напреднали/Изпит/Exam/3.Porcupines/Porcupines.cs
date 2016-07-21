using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Porcupines
{
    class Porcupines
    {
        static void Main()
        {
            int columns = int.Parse(Console.ReadLine());
            int totalRows = int.Parse(Console.ReadLine());

            for (int i = 0; i < totalRows; i++)
            {
                for (int i = 0; i < columns; i++)
                {

                }
            }

            var porcupines = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var rabbit = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var rabbitsPoints = 0;
            var porcupinesPoints = 0;

            while(true)
            {
                var direction = Console.ReadLine().Split(' ');
                if (direction[0] == "E")
                {
                    break;
                }
                else if (direction[0]=="R")
                {
                    switch (direction[1])
                    {
                        case "T":
                            if (direction[3]>rabbit[2])
                            {

                            }
                            break;
                        case "R":
                            break;
                        case "B":
                            break;
                        case "L":
                            break;
                        default:
                            break;
                    }
                }
                else if(direction[0]=="P")
                {
                    switch (direction[1])
                    {
                        case "T":
                            break;
                        case "R":
                            break;
                        case "B":
                            break;
                        case "L":
                            break;
                        default:
                            break;
                    }
                }
            }

            if (rabbitsPoints>porcupinesPoints)
            {
                Console.WriteLine("The rabbit WON with {0} points.The porcupine scored {1} points only.", rabbitsPoints, porcupinesPoints );
            }
            else if(porcupinesPoints>rabbitsPoints)
            {
                Console.WriteLine("The porcupine destroyed the rabbit with {0} points.The rabbit must work harder.He scored {1} points only.",porcupinesPoints,rabbitsPoints );
            }
            else
            {
                Console.WriteLine("Both units scored {0} points. Maybe we should play again?", rabbitsPoints);
            }
        }
    }
}
