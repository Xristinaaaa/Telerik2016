using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Kitty
{
    class Kitty
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var path = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int souls = 0;
            int food = 0;
            int deadlocks = 0;

            int jumpsBeforeDeadlock = 0;

            char[] symbols = new char[input.Length];
            for (int i = 0; i < symbols.Length; i++)
            {
                symbols[i] = input[i];
            }

            int step = 0;
            for (int i = 0; i < path.Length; i++)
            {
                if (symbols[step]=='0')
                {
                    step += 1;
                    i--;
                    continue;
                }
                else if (symbols[step]=='@')
                {
                    souls++;
                    symbols[step] = '0';
                }
                else if(symbols[step]=='*')
                {
                    food++;
                    symbols[step] = '0';
                }
                else if (step == 0 && symbols[step] =='x')
                {
                    break;
                }
                else if(symbols[step]=='x')
                {
                    deadlocks++;
                    
                    if (step%2==0)
                    {
                        if (souls>0)
                        {
                            souls--;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (food>0)
                        {
                            food--;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                
                step += path[step];
                if (step>symbols.Length)
                {
                    step -= symbols.Length;
                }
                else if (step<0)
                {
                    step += symbols.Length;
                }
                jumpsBeforeDeadlock++;
            }

            if (food == 0 && souls == 0)
            {
                Console.WriteLine("You are deadlocked, you greedy kitty!");
                Console.WriteLine("Jumps before deadlock: {0}", jumpsBeforeDeadlock);
            }
            else
            {         
                Console.WriteLine("Coder souls collected: {0}", souls);
                Console.WriteLine("Food collected: {0}", food);
                Console.WriteLine("Deadlocks: {0}", deadlocks);
            }
        }
    }
}
