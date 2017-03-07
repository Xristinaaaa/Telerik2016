using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Core.Commands.Contracts;
using System;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateStudentCommandHandler : BaseCommandHandler
    {
        private int currentStudentId = int.Parse(Guid.NewGuid().ToString());
        private const string CommandName = "CreateStudent";

        private IEngine engine;
        public CreateStudentCommandHandler(IEngine engine)
        {
            if (this.engine == null)
            {
                throw new ArgumentNullException(nameof(engine));
            }

            this.engine = engine;
        }
        protected override bool CanHandle(ICommand command)
        {
            return command.Name == CommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var firstName = command.Parameters[0];
            var lastName = command.Parameters[1];
            var grade = (Grade)int.Parse(command.Parameters[2]);

            var student = new Student(firstName, lastName, grade);
            this.engine.Students.Add(currentStudentId, student);

            return string.Format(@"Calling method GetCommand of type ICommandFactory... 
                Total execution time for method GetCommand of type ICommandFactory is {0} milliseconds.") +
                 string.Format(@"Calling method {0} of type {1} ...
                Total execution time for method {0} of type {1} is {1} milliseconds", command.Name, engine.StudentFactory) +
                $"A new student with name {firstName} {lastName}, grade {grade} and ID {currentStudentId} was created.";
        }
    }
}
 