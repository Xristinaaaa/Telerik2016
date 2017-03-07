using System.Collections.Generic;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Core.Commands.Contracts;
using System;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateTeacherCommandHandler : BaseCommandHandler
    {
        private const string CommandName = "CreateTeacher";
        private int currentTeacherId = int.Parse(Guid.NewGuid().ToString());

        private IEngine engine;
        public CreateTeacherCommandHandler(IEngine engine)
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
            var subject = (Subject)int.Parse(command.Parameters[2]);

            var teacher = new Teacher(firstName, lastName, subject);
            engine.Teachers.Add(currentTeacherId, teacher);

            return string.Format(@"Calling method GetCommand of type ICommandFactory... 
                Total execution time for method GetCommand of type ICommandFactory is {0} milliseconds.") +
                 string.Format(@"Calling method {0} of type {1} ...
                Total execution time for method {0} of type {1} is {1} milliseconds", command.Name, engine.TeacherFactory) +
                $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {currentTeacherId} was created.";
        }
    }
}
