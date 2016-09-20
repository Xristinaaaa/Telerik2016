using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.BadCat
{
    class BadCat
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder();
            int num;
            int temp=0;
            for (int i = 0; i < N; i++)
            {
                string text = Console.ReadLine();
                int index1 = text.IndexOf("before");
                int index2 = text.IndexOf("after");

                if (i==N-1)
                {
                    if (index1<1)
                    {
                        result.Append(Convert.ToInt32(text.Substring(text.Length - 1, 1)));
                        result.Append(Convert.ToInt32(text.Substring(0, 1)));
                    }
                    else if(index2<1)
                    {
                        result.Append(Convert.ToInt32(text.Substring(0, 1)));
                        result.Append(Convert.ToInt32(text.Substring(text.Length - 1, 1)));
                    }
                }
                else
                {
                    if (index1 < 0)
                    {
                        num = Convert.ToInt32(text.Substring(text.Length - 1, 1));
                        if (num>temp)
                        {
                            temp = num;
                            result.Append(temp);
                        }
                        else
                        {
                            
                        }
                    }
                    else if (index2 < 0)
                    {
                        num = Convert.ToInt32(text.Substring(0, 1));
                        temp = num;
                        result.Append(temp);
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
