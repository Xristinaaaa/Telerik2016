namespace SchoolClasses.School.People
{
    using System;

    public abstract class Person
    {
        private string name;

        public Person(string nameOfPerson)
        {
            this.Name = nameOfPerson;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name should be entered");
                }
                this.name = value;
            }
        }
    }
}
