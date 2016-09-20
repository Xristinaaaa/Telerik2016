using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace _2.TwoGirlsOnePath
{
    class TwoGirlsOnePath
    {
        static void Main(string[] args)
        {
            BigInteger[] pathOfFlowers = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();
            BigInteger fOfMolly = 0;
            BigInteger fOfDolly = 0;

            int n = pathOfFlowers.Length;

            int stepOfMolly = 0;
            int stepOfDolly = n - 1;

            string winner = string.Empty;
            while (true) 
            {
                if (pathOfFlowers[stepOfDolly]==0 || pathOfFlowers[stepOfMolly]==0)
                {
                    if (pathOfFlowers[stepOfMolly] == 0 && pathOfFlowers[stepOfDolly] == 0)
                    {
                        winner = "Draw";
                    }
                    else if (pathOfFlowers[stepOfMolly]==0)
                    {
                        winner = "Dolly";
                    }
                    else if (pathOfFlowers[stepOfDolly]==0)
                    {
                        winner = "Molly";
                    }
                        
                    fOfMolly += pathOfFlowers[stepOfMolly];
                    fOfDolly += pathOfFlowers[stepOfDolly];
                    break;
                }

                 BigInteger tempM = pathOfFlowers[stepOfMolly];
                 BigInteger tempD = pathOfFlowers[stepOfDolly];

                if (stepOfMolly == stepOfDolly)
                {
                    pathOfFlowers[stepOfMolly] = tempM % 2;
                    fOfMolly += tempM / 2;
                    fOfDolly += tempD / 2;
                }
                else
                {
                    fOfMolly += tempM;
                    fOfDolly += tempD;

                    pathOfFlowers[stepOfMolly] = 0;
                    pathOfFlowers[stepOfDolly] = 0;
                }
                stepOfMolly = (int)((stepOfMolly+ tempM)% n);
                stepOfDolly = (int)((stepOfDolly- tempD)% n);
                if (stepOfDolly < 0)
                {
                    stepOfDolly += n;
                }
                
            }
            Console.WriteLine(winner);
            Console.WriteLine(fOfMolly + " " + fOfDolly);
        }
    }
}
