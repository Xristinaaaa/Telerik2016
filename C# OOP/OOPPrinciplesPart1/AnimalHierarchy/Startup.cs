using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalHierarchy.Animals.Animals;

namespace AnimalHierarchy
{
    class Startup
    {
        static void Main(string[] args)
        {
            Cat[] cats = new Cat[]
            {
                new Cat("Aira", 2, Sex.female),
                new Cat("Roni", 6, Sex.male),
                new Cat("Ketty", 3, Sex.female),
            };

            Console.WriteLine(Animal.AverageAge(cats));

            Dog[] dogs = new Dog[]
            {
                new Dog("Rijko", 4, Sex.male),
                new Dog("Roni", 5, Sex.male),
                new Dog("Molly", 3, Sex.female),
            };

            Console.WriteLine(Animal.AverageAge(dogs));

            Kitten[] kittens = new Kitten[]
            {
                new Kitten("Kremi", 3),
                new Kitten("Maca", 1),
                new Kitten("Murja", 8),
            };

            Console.WriteLine(Animal.AverageAge(kittens));

            Tomcat[] tomcats = new Tomcat[]
            {
                new Tomcat("Rijka", 2),
                new Tomcat("Bojka", 1),
                new Tomcat("Sara", 10),
            };

            Console.WriteLine(Animal.AverageAge(tomcats));

            Frog[] frogs = new Frog[]
            {
                new Frog("Ash", 1, Sex.female),
                new Frog("Hrk", 1, Sex.female),
                new Frog("JKl", 1, Sex.female),
            };

            Console.WriteLine(Animal.AverageAge(frogs));
        }   
    }
}
