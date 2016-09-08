using System;
using Chef.Models;

namespace Chef
{
    public class Chef
    {
        public void Cook()
        {
            Potato potato = GetPotato();
            Carrot carrot = GetCarrot();
            Bowl bowl = GetBowl();

            Peel(potato);
            Peel(carrot);

            Cut(potato);
            Cut(carrot);

            bowl.Add(carrot);
            bowl.Add(potato);
        }

        private Bowl GetBowl()
        {
            return new Bowl("glass");
        }
        private Carrot GetCarrot()
        {
            return new Carrot("orrange", "1.3", "unknown", "cooking");
        }
        private Potato GetPotato()
        {
            return new Potato("brown", "0.5", "", "cooking");
        }

        private void Cut(Vegetable product)
        {
            //...
        }
        public void Peel(Vegetable product)
        {
            //...
        }
    }
}
