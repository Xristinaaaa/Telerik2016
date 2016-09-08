using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    class Person
    {
        enum Gender
        {
            Male,
            Female
        };

        class PersonInfo
        {
            public Gender Gender { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public void Generate(int uniqueNumber)
        {
            PersonInfo newPerson = new PersonInfo();
            newPerson.Age = uniqueNumber;
            if (uniqueNumber % 2 == 0)
            {
                newPerson.Name = "Ivan";
                newPerson.Gender = Gender.Male;
            }
            else
            {
                newPerson.Name = "Mariq";
                newPerson.Gender = Gender.Female;
            }
        }
    }
}
