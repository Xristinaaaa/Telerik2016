namespace AnimalHierarchy.Animals.Animals
{
    using System;
    using AnimalHierarchy.Animals.Animals;

    public class Kitten : Cat, ISound
    {
        public Kitten(string name, int age)
            :base(name, age, Sex.female)
        {

        }

        public override void MakeSound()
        {
            Console.WriteLine("Myau");
        }
    }
}
