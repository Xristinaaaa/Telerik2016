using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayerRanking
{
    public static class Program
    {
        static void Main()
        {
            var inputs = new List<string>();

            var input = Console.ReadLine();
            while (input != "end")
            {
                inputs.Add(input);
                input = Console.ReadLine();
            }

            var players = new List<Tuple<string, string, int>>();

            foreach (var item in inputs)
            {
                var currentInput = item.Split(' ').ToArray();
                var command = currentInput[0];

                var playerType = "";

                switch (command)
                {
                    case "add":
                        var playerName = currentInput[1];
                        playerType = currentInput[2];
                        var playerAge = int.Parse(currentInput[3]);
                        var playerPosition = int.Parse(currentInput[4]);

                        players.Insert(playerPosition-1, new Tuple<string, string, int>(playerName, playerType, playerAge));
                       
                        Console.WriteLine("Added player {0} to position {1}", playerName, playerPosition);
                        break;
                    case "find":
                        //finds the top 5 units, first ordered by name in ascending order and then by age in descending order
                        //If no players are found just print "Type PLAYER_TYPE: "
                        playerType = currentInput[1];

                        Console.Write("Type {0}: ", playerType);

                        players.OrderBy(x => x.Item1).OrderByDescending(x => x.Item3);
                        for (var i = 0; i < players.Count; i++)
                        {
                            if (players[i] != null)
                            {
                                if (players[i].Item2 == playerType)
                                {
                                    Console.Write("{0}({1}); ", players[i].Item1, players[i].Item3);
                                }
                            }
                        }
                        
                        Console.WriteLine();
                        break;
                    case "ranklist":
                        var startPosition = int.Parse(currentInput[1]);
                        var endPosition = int.Parse(currentInput[2]);

                        var c = 1;
                        for (int i = 0; i < players.Count; i++)
                        {
                            if (players[i] != null)
                            {
                                if (c == endPosition + 1)
                                {
                                    break;
                                }
                                Console.Write("{0}. {1}({2}); ", c, players[i].Item1, players[i].Item3);
                                c++;
                            }
                        }
                        Console.WriteLine();
                       break;
                    default:
                        break;
                }
            }
        }
    }
}
