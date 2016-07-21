using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Konspiration
{
    // observations
    // all methods begin with static keyword
    //all methods will have(...) on the same line
    //all methods will have { on the next lina
    //get method bodies by splitting by "static" or by
    //all calls and names will begin with capital letter
    //need to handle the new keyword

    class Konspiration
    {
        
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var lines = new string[n];

            for (int i = 0; i < n; i++)
            {
                lines[i] = Console.ReadLine();
                
            }


            for (int i = 0; i < n; i++)
            {
                if (lines[i].Contains(" static "))
                {
                    var name = lines[i].Split(new[] { ' ', '(', }, StringSplitOptions.RemoveEmptyEntries)[2];

                    i +=2;

                    var openBrackets = 1;
                    var methodCalls = new List<string>();
                    while (openBrackets>0)
                    {
                        var splitByRoundBracket = lines[i].Split('(');

                        if (splitByRoundBracket.Length>1)
                        {
                            for (int k = 0; k < splitByRoundBracket.Length-1; k++)
                            {
                                var methodName = ExtractMethodName(splitByRoundBracket[k]);
                                
                            }
                        }

                        foreach (var symbol in lines[i])
                        {
                            if (symbol=='{')
                            {
                                openBrackets++;
                            }
                            else if(symbol=='}')
                            {
                                openBrackets--;
                            }
                        }

                        i++;
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
