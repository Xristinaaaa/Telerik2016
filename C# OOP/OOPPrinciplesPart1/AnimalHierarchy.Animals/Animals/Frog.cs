namespace AnimalHierarchy.Animals.Animals
{
    using System;

    public class Frog : Animal, ISound
    {
        public Frog(string name, int age, Sex sex)
            :base(name, age, sex)
        {

        }

        public override void MakeSound()
        {
            Console.WriteLine("Kwaak");
        }
    }
}
