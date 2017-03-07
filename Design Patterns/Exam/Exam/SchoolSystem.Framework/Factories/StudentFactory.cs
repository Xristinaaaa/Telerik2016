using System;
using SchoolSystem.Framework.Factories.Contracts;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Models;

namespace SchoolSystem.Framework.Factories
{
    public class StudentFactory : IStudentFactory
    {
        public IStudent CreateStudent(string firstName, string lastName, Grade grade)
        {
            return new Student(firstName, lastName, grade);
        }
    }
}
