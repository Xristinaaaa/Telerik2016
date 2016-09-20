namespace AnimalHierarchy.Animals.Animals
{
    using System;

    public class Dog : Animal, ISound
    {
        public Dog(string name, int age, Sex sex)
            :base(name, age, sex)
        {

        }

        public override void MakeSound()
        {
            Console.WriteLine("Bau");
        }
    }
}
