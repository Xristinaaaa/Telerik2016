namespace CommonTypeSystem.People
{
    using System;
    public class Person
    {
        private string name;
        private int? age;

        Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public int? Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                this.age = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public override string ToString()
        {
            if (age==null)
            {
                return String.Format("Name= {0}, Age is not specified.", this.Name);
            }
            else
            {
                return string.Format("Name= {0}, Age= {1}", this.Name, this.Age);
            }
        }
    }
}
