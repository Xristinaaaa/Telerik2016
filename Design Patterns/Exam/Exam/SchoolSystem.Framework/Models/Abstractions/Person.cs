using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Common;

namespace SchoolSystem.Framework.Models.Abstractions
{
    public abstract class Person : IPerson
    {
        private readonly string stringCharactersExceptionMessage = $"must contain only latin characters.";
        private readonly string stringLenghtExceptionMessage = $"be in lenght between {Constants.MinFirstNameLenght} and {Constants.MaxFirstNameLenght} long.";

        private string firstName;
        private string lastName;

        protected Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                Validator.ValidateSymbols(value, "^[A-Za-z]+$", $"FirstName {this.stringCharactersExceptionMessage}");
                Validator.ValidateRange(value.Length, Constants.MinFirstNameLenght, Constants.MaxFirstNameLenght, $"LastName {this.stringLenghtExceptionMessage}");

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                Validator.ValidateSymbols(value, "^[A-Za-z]+$", $"FirstName {this.stringCharactersExceptionMessage}");
                Validator.ValidateRange(value.Length, Constants.MinFirstNameLenght, Constants.MaxFirstNameLenght, $"LastName {this.stringLenghtExceptionMessage}");

                this.lastName = value;
            }
        }
    }
}
