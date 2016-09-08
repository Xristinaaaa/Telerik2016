using System;
using Chef.Models;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public void Validate()
        {
            int x = 0;
            int y = 0;

            const int MinX=0,
                      MaxX=10,
                      MinY=0,
                      MaxY=10;

            bool peeled = false,
                 rotten = true,
                 visited= true;

            Potato potato = new Potato("brown", "0.4", "fsdf", "cooking");
            //...

            if (potato != null)
            {
                if (!(peeled || rotten))
                {
                    Cook(potato);
                }
            }

            if (x >= MinX && x <= MaxX &&
                y >= MinY && y <= MaxY && 
                !visited)
            {
                VisitCell();
            }
        }

        public void VisitCell()
        {
            //...
        }
        public void Cook(Vegetable vegetable)
        {
            //..
        }

    }
}
