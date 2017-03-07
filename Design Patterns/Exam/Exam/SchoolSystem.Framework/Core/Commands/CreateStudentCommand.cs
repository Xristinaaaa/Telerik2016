using System;
using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private int currentStudentId = int.Parse(Guid.NewGuid().ToString());

        private IEngine engine;
        public CreateStudentCommand(IEngine engine)
        {
            this.engine = engine;
        }
        public string Name { get; set; }
        public List<string> Parameters { get; set; }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            var student = new Student(firstName, lastName, grade);
            this.engine.Students.Add(currentStudentId, student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {currentStudentId} was created.";
        }
    }
}
