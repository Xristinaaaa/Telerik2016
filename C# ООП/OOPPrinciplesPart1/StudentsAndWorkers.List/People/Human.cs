namespace StudentsAndWorkers.List.People
{
    using System;

    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                this.lastName = value;
            }
        }

        public Human(string first, string last)
        {
            this.FirstName = first;
            this.LastName = last;
        }
    }
}
