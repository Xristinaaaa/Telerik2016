using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DefineClass
{
    class GSMTest
    {
        public static void Print()
        {
            GSM[] gsmArray = new GSM[4];
            GSM[] array =
            {
                new GSM ("HTC","China", 120, "Ivan"),
                new GSM ("Smasung","USA", 340, "Petko"),
                new GSM ("LG","Japan", 500, "Blagoy"),
                new GSM ("Nokia","France", 600, "Georgi")
            };

            foreach (var gsm in array)
            {
                Console.WriteLine(gsm);
            }
            Console.WriteLine(GSM.Iphone4S);
        }
    }
}
