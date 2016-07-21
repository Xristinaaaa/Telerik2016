using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace _2.BunnyFactory
{
    class BunnyFactory
    {
        static void Main()
        {
            string currentCage = Console.ReadLine();

            int[] cages = new int[205];
            int n = 0;

            while (currentCage !="END")
            {
                cages[n] = int.Parse(currentCage);
                n++;
                currentCage = Console.ReadLine();
            }

            for (int i = 1; i < n ; i++) //check if correct
            {
                int s = 0;
                for (int j = 0; j < i; j++)
                {
                    s += cages[j];
                }
                //sum is calculated

                if (n-i<s)
                {
                    break;
                }

                //step 4
                int sum = 0;
                BigInteger product = 1;
                for (int j = i; j < i+s; j++)
                {
                    sum +=cages[j];
                    product *=cages[j];                   
                }

                //step 5
                string next = sum.ToString() + product.ToString();
                for (int j = i+s; j < n; j++)
                {
                    next += cages[j].ToString();
                }

                // step 6
                next=next.Replace("0", "").Replace("1", "");

                n = next.Length;
                for (int j = 0; j < n ; j++)
                {
                    cages[j] = next[j] - '0'; //convert char to number
                }
                
            }

            //string[] end = new string[n];
            //for (int i = 0; i < n; i++)
            //{
            //    end[i] = cages[i].ToString();
            //}

            Console.WriteLine(string.Join(" ", cages.Select(x=>x.ToString()).ToArray(), 0, n));
        }
    }
}
