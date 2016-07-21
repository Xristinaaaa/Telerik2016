namespace AnimalHierarchy.Animals.Animals
{
    using System;

    public class Cat : Animal, ISound
    {
        public Cat(string name, int age, Sex sex)
            :base(name, age, sex)
        {

        }

        public override void MakeSound()
        {
            Console.WriteLine("Myau");
        }
    }
}
